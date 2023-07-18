**Using multiple threads with parallel LINQ**

- [Introducing Parallel LINQ](#introducing-parallel-linq)
- [Creating an app that benefits from multiple threads](#creating-an-app-that-benefits-from-multiple-threads)
- [Using Windows](#using-windows)
- [Using macOS](#using-macos)
- [For all operating systems](#for-all-operating-systems)


# Introducing Parallel LINQ

By default, only one thread is used to execute a LINQ query. **Parallel LINQ (PLINQ)** is an easy way to enable multiple threads to execute a LINQ query.

> **Good Practice**: Do not assume that using parallel threads will improve the performance of your applications. Always measure real-world timings and resource usage.

# Creating an app that benefits from multiple threads

To see it in action, we will start with some code that only uses a single thread to calculate Fibonacci numbers for 45 integers. We will use the `StopWatch` type to measure the change in performance.

We will use operating system tools to monitor the CPU and CPU core usage. If you do not have multiple CPUs or at least multiple cores, then this exercise won't show much!

1.	Use your preferred code editor to add a new **Console App** / `console` project named `LinqInParallel` to the `Chapter11` solution.
2.	In `Program.cs`, delete the existing statements and then import the `System.Diagnostics` namespace so that we can use the `StopWatch` type. Add statements to create a stopwatch to record timings, wait for a keypress before starting the timer, create 45 integers, calculate the Fibonacci number for each of them, stop the timer, and display the elapsed milliseconds, as shown in the following code:
```cs
using System.Diagnostics; // To use Stopwatch.

Write("Press ENTER to start. ");
ReadLine();
Stopwatch watch = Stopwatch.StartNew();

watch.Start();
int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);

WriteLine($"Calculating Fibonacci sequence up to term {max}. Please wait...");

int[] fibonacciNumbers = numbers
  .Select(number => Fibonacci(number))
  .ToArray(); 

watch.Stop();
WriteLine("{0:#,##0} elapsed milliseconds.",
  arg0: watch.ElapsedMilliseconds);

Write("Results:");
foreach (int number in fibonacciNumbers)
{
  Write($"  {number:N0}");
}

static int Fibonacci(int term) =>
  term switch
  {
    1 => 0,
    2 => 1,
    _ => Fibonacci(term - 1) + Fibonacci(term - 2)
  };
```

3.	Run the console app, but do not press *Enter* to start the stopwatch yet because we need to make sure a monitoring tool is showing processor activity.

# Using Windows

If you are using Windows:

1.	Right-click on the Windows Start button or press *Ctrl* + *Alt* + *Delete*, and then click on **Task Manager**.
2.	At the bottom of the **Task Manager** window, click **More details**.
3.	At the top of the **Task Manager** window, click on the **Performance** tab.
4.	Right-click on the **CPU Utilization** graph, select **Change graph to**, and then select **Logical processors**.

# Using macOS

If you are using macOS:

1.	Launch **Activity Monitor**.
2.	Navigate to **View** | **Update Frequency Very often (1 sec)**.
3.	To see the CPU graphs, navigate to **Window** | **CPU History**.

# For all operating systems

If you are using Windows, macOS, or any other OS:

1.	Rearrange your monitoring tool and your code editor so that they are side by side.
2.	Wait for the CPUs to settle and then press *Enter* to start the stopwatch and run the query. The result should be a number of elapsed milliseconds, as shown in the following output:
```
Calculating Fibonacci sequence up to term 45. Please wait...
17,624 elapsed milliseconds.
Results: 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1,597 2,584 4,181 6,765 10,946 17,711 28,657 46,368 75,025 121,393 196,418 317,811 514,229 832,040 1,346,269 2,178,309 3,524,578 5,702,887 9,227,465 14,930,352 24,157,817 39,088,169 63,245,986 102,334,155 165,580,141 267,914,296 433,494,437 701,408,733
```

The monitoring tool will probably show that one or two CPUs were used the most, alternating over time. Others may execute background tasks at the same time, such as the garbage collector, so the other CPUs or cores won't be completely flat, but the work is certainly not being evenly spread among all the possible CPUs or cores. Also, note that some of the logical processors are maxing out at 100%.

3.	In `Program.cs`, modify the query to make a call to the `AsParallel` extension method and to sort the resulting sequence, because when processing in parallel the results can become misordered, as shown highlighted in the following code:
```cs
int[] fibonacciNumbers = numbers.AsParallel()
  .Select(number => Fibonacci(number))
  .OrderBy(number => number)
  .ToArray();
```

> **Good Practice**: Never call `AsParallel` at the end of a query. This does nothing. You must perform at least one operation after the call to `AsParallel` for that operation to be parallelized. .NET 6 introduced a code analyzer that will warn about this type of misuse.

4.	Run the code, wait for CPU charts in your monitoring tool to settle, and then press *Enter* to start the stopwatch and run the query. This time, the application should complete in less time (although it might not be as less as you might hope for—managing those multiple threads takes extra effort!):
```
Calculating Fibonacci sequence up to term 45. Please wait...
9,028 elapsed milliseconds.
Results: 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1,597 2,584 4,181 6,765 10,946 17,711 28,657 46,368 75,025 121,393 196,418 317,811 514,229 832,040 1,346,269 2,178,309 3,524,578 5,702,887 9,227,465 14,930,352 24,157,817 39,088,169 63,245,986 102,334,155 165,580,141 267,914,296 433,494,437 701,408,733
```

5.	The monitoring tool should show that all CPUs were used equally to execute the LINQ query and note that none of the logical processors max out at 100% because the work is more evenly spread.
