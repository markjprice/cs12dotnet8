**Errata** (11 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Page 10 - Installing other extensions](#page-10---installing-other-extensions)
- [Page 15 - Understanding .NET runtime and .NET SDK versions](#page-15---understanding-net-runtime-and-net-sdk-versions)
- [Page 43 - Configuring inline aka inlay hints](#page-43---configuring-inline-aka-inlay-hints)
- [Page 50 - Exercise 1.2 – Practice C# anywhere with a browser](#page-50---exercise-12--practice-c-anywhere-with-a-browser)
- [Page 58 - Showing the compiler version](#page-58---showing-the-compiler-version)
- [Page 87 - Comparing double and decimal types](#page-87---comparing-double-and-decimal-types)
- [Page 95 - Displaying output to the user](#page-95---displaying-output-to-the-user)
- [Page 124 - Exploring bitwise and binary shift operators](#page-124---exploring-bitwise-and-binary-shift-operators)
- [Page 383 - Creating a console app to publish](#page-383---creating-a-console-app-to-publish)
- [Page 386 - Publishing a self-contained app](#page-386---publishing-a-self-contained-app)
- [Page 616 - Be careful with Count!](#page-616---be-careful-with-count)

# Page 10 - Installing other extensions

> Thanks to [Muhammad Faisal Siddiqui](https://github.com/devcloud-ops) for raising [this issue on November 20, 2023](https://github.com/markjprice/cs12dotnet8/issues/3).

At the time of publishing, the Polyglot Notebooks extension has a dependency on .NET 7. The extension will soon be updated to use .NET 8 but for now you must install .NET 7 SDK. Hopefully the team will also update the extension to use the **.NET Install Tool** that ensures a correct version of a required .NET SDK is installed so users do not have to manually install it.

# Page 15 - Understanding .NET runtime and .NET SDK versions

> Thanks to a reader who contacted my publisher Packt on November 16, 2023 about this issue.

I wrote, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are tied to the runtime version it is matched with. The patch number follows a convention that indicates 
the major and minor versions of the SDK."

But the patch number is not created from the major and minor versions of the SDK. It is created from the minor and patch versions of the SDK.

I should have written, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are tied to the runtime version it is matched with. The third number follows a convention that indicates the minor and patch versions of the SDK. The third number starts at `100` for the initial version (equivalent to `0.0` for minor and patch number). The first digit increments with minor increments, and the other two digits increment with patch increments."

# Page 43 - Configuring inline aka inlay hints

> Thanks to [TheFumblebee](https://github.com/TheFumblebee) for raising [this issue on November 30, 2023](https://github.com/markjprice/cs12dotnet8/issues/5).

In the bullet for Visual Studio 2022, I wrote the label for the check box was **Display inline parameter hint names**. I should have written **Display inline parameter name hints**.

# Page 50 - Exercise 1.2 – Practice C# anywhere with a browser

> Thanks to MrBiteyFace in the book's Discord channel for raising this issue.

In this exercise, I wrote "You can start coding online at any of the following links: **Visual Studio Code for Web**: https://vscode.dev/".

Although **Visual Studio Code for Web** does support some extensions, it does not support the C# extension. If you edit a `.cs` file then you will not have IntelliSense to help you. It also does not support running and debugging C# code. 

In the next edition, I will remove this bullet or change it to **GitHub Codespaces** (i.e. Visual Studio Code hosted in a cloud-based virtual machine) instead.

# Page 58 - Showing the compiler version

In Step 3, the code should have been styled as `Code` (monospace black-on-light-gray text) instead of `Command Line` (monospace white-on-black).

# Page 87 - Comparing double and decimal types

> Thanks to Yousef Imran who raised this issue via email on December 15, 2023.

At the top of page 87, I end the section describing a few special values associated with real numbers that are available as constants in the `float` and `double` types. I wrote, "`NaN` represents not-a-number (for example, the result of dividing by zero)," but that sentence is missing a "zero". It should be, "`NaN` represents not-a-number (for example, the result of dividing zero by zero),". In the next edition I will fix this mistake. 

> Please also note a [related improvement](https://github.com/markjprice/cs12dotnet8/blob/main/docs/errata/improvements.md#page-87---comparing-double-and-decimal-types).

# Page 95 - Displaying output to the user

> Thanks to SilentSolace in the book's Discord channel for raising this issue on December 18, 2023.

I wrote, "If you want to write three letters to the console without carriage returns after them, then call the `Write` method, as shown in the following code:"
```cs
Write("A");
Write("B");
Write("C");
```

But I neglected to prefix the method calls with `Console.` so how does this work?

On page 102, in the section titled "Simplifying the usage of the console", I show how to avoid needing to prefix those method calls with `Console.` by adding a statement to statically import the `System.Console` class, as shown in the following code:
```cs
using static System.Console;
```

But seven pages earlier I show code without the prefix without an explanation why that works! 

In the next edition, I will show the full code, as shown in the following code:
```cs
Console.Write("A");
Console.Write("B");
Console.Write("C");
```

And the same for the second code block:
```cs
Console.WriteLine("A");
Console.WriteLine("B");
Console.WriteLine("C");
```

# Page 124 - Exploring bitwise and binary shift operators

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) for raising [this issue on January 19, 2024](https://github.com/markjprice/cs12dotnet8/issues/13).

In Step 3, I refer to variables `a` and `b`, "In `Program.cs`, add statements to output the results of applying the left-shift operator to move
the bits of the variable `a` by three columns, multiplying `a` by 8, and right-shifting the bits of the variable `b` by one column, ...". 

I should have written `x` and `y`.

In the last paragraph, I wrote, "The `3` result is because the 1 bits in `b` were shifted one column into the 2-and 1-bit columns."

I should have written, "The `3` result is because the 1 bits in `y` were shifted one column into the 2-and 1-bit columns."

# Page 383 - Creating a console app to publish

> Thanks to `mdj._` in the book's Discord channel for raising this issue on December 18, 2023.

In Step 5, I tell the reader to "add the runtime identifiers (RIDs) to target five operating systems" including Windows 10 or later. The legacy RID was `win10-x64` but in .NET 8 RC1 this changed to `win-x64`. The RID for MacOS/OS X also changed. From the documentation, "Starting with .NET 8, the default behavior of the .NET SDK and runtime is to only consider non-version-specific and non-distro-specific RIDs."

The book lists the RIDs as shown in the following markup:
```xml
<RuntimeIdentifiers>
  win10-x64;osx-x64;osx.11.0-arm64;linux-x64;linux-arm64
</RuntimeIdentifiers>
```

The RIDs should be as shown in the following markup:
```xml
<RuntimeIdentifiers>
  win-x64;osx-x64;osx-arm64;linux-x64;linux-arm64
</RuntimeIdentifiers>
```

In the next edition, as well as fixing the RID values, I will link to the official documentation so that readers can confirm the current valid values. For example, for known RIDs: https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#known-rids.

# Page 386 - Publishing a self-contained app

> Thanks to `mdj._` in the book's Discord channel for raising this issue on December 18, 2023.

Related to the [previous issue](#page-383---creating-a-console-app-to-publish), in Step 2, I tell the reader to "Enter a command to build and publish the self-contained release version of the console application for Windows 10". But the command uses the legacy RID value `win10-x64`, as shown in the following command:
```
dotnet publish -c Release -r win10-x64 --self-contained
```

The command should be:
```
dotnet publish -c Release -r win-x64 --self-contained
```

Any other references to `win10-x64`, like the folder name, should also be changed to `win-x64`.

Similarly, in Step 4, the command `dotnet publish -c Release -r osx.11.0-arm64 --self-contained` should be:
```
dotnet publish -c Release -r osx-arm64 --self-contained
```

I have updated the **Command Lines** summary file to use the new valid RIDs: https://github.com/markjprice/cs12dotnet8/blob/main/docs/command-lines.md#page-386---publishing-a-self-contained-app

# Page 616 - Be careful with Count!

> Thanks to Clint Mayers who submitted this issue via email.

I showed a code teaser by Amichai Mantinband, a software engineer at Microsoft, as shown in the following code:
```cs
IEnumerable<Task> tasks = Enumerable.Range(0, 2)
  .Select(_ => Task.Run(() => Console.WriteLine("*")));

await Task.WhenAll(tasks);
Console.WriteLine($"{tasks.Count()} stars!");
```

But I mistakenly used `WriteLine` methods when they should have been `Write` methods, as shown in the following code:
```cs
IEnumerable<Task> tasks = Enumerable.Range(0, 2)
  .Select(_ => Task.Run(() => Console.Write("*")));

await Task.WhenAll(tasks);
Console.Write($"{tasks.Count()} stars!");
```
