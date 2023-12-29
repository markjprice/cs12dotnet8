**Improvements** (8 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Print Book](#print-book)
  - [Page 64 - Formatting code using white space](#page-64---formatting-code-using-white-space)
  - [Page 79 - Raw interpolated string literals](#page-79---raw-interpolated-string-literals)
  - [Page 87 - Comparing double and decimal types](#page-87---comparing-double-and-decimal-types)
  - [Page 96 - Formatting using numbered positional arguments \& Formatting using interpolated strings](#page-96---formatting-using-numbered-positional-arguments--formatting-using-interpolated-strings)
  - [Page 131 - Pattern matching with the switch statement](#page-131---pattern-matching-with-the-switch-statement)
  - [Page 248 - Storing multiple values using an enum type](#page-248---storing-multiple-values-using-an-enum-type)
  - [Page 369 - Understanding .NET components](#page-369---understanding-net-components)
  - [Page 484 - Compressing streams](#page-484---compressing-streams)
- [Bonus Content](#bonus-content)

# Print Book

## Page 64 - Formatting code using white space

In this section, I show code examples of white space.

I wrote, "The following four statements are all equivalent:"
```cs
int sum = 1 + 2; // Most developers would prefer this format.

int
sum=1+
2; // One statement over three lines.

int        sum=    1     +2;int sum=1+2; // Two statements on one line.
```

Since all four statements are all equivalent, they all have the same variable name, and therefore cannot be all declared in the same code block. 

Unless a step-by-step instruction tells the reader to enter code, all code examples are written to be read and understood, not entered into a code editor. Code examples should be considered to be "snippets" that are not guaranteed to compile without changes or additional statements.

In the next edition, I will explicitly say that, and explain that if the reader does decide to enter the code, they would (of course) need to rename the variables. 

## Page 79 - Raw interpolated string literals

> Thanks to [Robin](https://github.com/centpede) who raised this [issue on December 11, 2023](https://github.com/markjprice/cs12dotnet8/issues/6).

At the bottom of page 79, I show some code that will output some JSON.

```cs
var person = new { FirstName = "Alice", Age = 56 };

string json = $$"""
{
  "first_name": "{{person.FirstName}}",
  "age": {{person.Age}},
  "calculation": "{{{ 1 + 2 }}}"
}
""";

Console.WriteLine(json);
```
It produces the following output:
```
{
  "first_name": "Alice",
  "age": 56,
  "calculation": "{3}"
}
```
Note the braces `{}` around the `3`. This is intentional. In this example, the JSON document must generate a `calculation` that contains braces. To show this, the code uses three braces: the first open brace will output as literal character The next two braces will be interpreted as the beginning of an expression. The first two close braces will be interpreted as the end of an expression. The last close brace will be a literal character.

If the code only used two braces then those are treated as a delimiter for the express `1 + 2` and do not appear in the output:
```cs
var person = new { FirstName = "Alice", Age = 56 };

string json = $$"""
{
  "first_name": "{{person.FirstName}}",
  "age": {{person.Age}},
  "calculation": "{{ 1 + 2 }}"
}
""";

Console.WriteLine(json);
```
Now it produces the following output:
```
{
  "first_name": "Alice",
  "age": 56,
  "calculation": "3"
}
```
In the next edition, I will add this extra explanation.

## Page 87 - Comparing double and decimal types

> Thanks to Yousef Imran who raised this issue via email on December 15, 2023.

At the top of page 87, I end the section describing a few special values associated with real numbers that are available as constants in the `float` and `double` types. But I do not show any example code. 

In the next edition, I will add an example to show the values and how they can be generated using expressions, as shown in the following code:
```cs
#region Special float and double values

Console.WriteLine($"double.Epsilon: {double.Epsilon}");
Console.WriteLine($"double.Epsilon to 324 decimal places: {double.Epsilon:N324}");
Console.WriteLine($"double.Epsilon to 330 decimal places: {double.Epsilon:N330}");

const int col1 = 37; // First column width.
const int col2 = 6; // Second column width.
string line = new string('-', col1 + col2 + 3);

Console.WriteLine(line);
Console.WriteLine($"{"Expression",-col1} | {"Value",col2}");
Console.WriteLine(line);
Console.WriteLine($"{"double.NaN",-col1} | {double.NaN,col2}");
Console.WriteLine($"{"double.PositiveInfinity",-col1} | {double.PositiveInfinity,col2}");
Console.WriteLine($"{"double.NegativeInfinity",-col1} | {double.NegativeInfinity,col2}");
Console.WriteLine(line);
Console.WriteLine($"{"0.0 / 0.0",-col1} | {0.0 / 0.0,col2}");
Console.WriteLine($"{"3.0 / 0.0",-col1} | {3.0 / 0.0,col2}");
Console.WriteLine($"{"-3.0 / 0.0",-col1} | {-3.0 / 0.0,col2}");
Console.WriteLine($"{"3.0 / 0.0 == double.PositiveInfinity",-col1} | {3.0 / 0.0 == double.PositiveInfinity,col2}");
Console.WriteLine($"{"-3.0 / 0.0 == double.NegativeInfinity",-col1} | {-3.0 / 0.0 == double.NegativeInfinity,col2}");
Console.WriteLine($"{"0.0 / 3.0",-col1} | {0.0 / 3.0,col2}");
Console.WriteLine($"{"0.0 / -3.0",-col1} | {0.0 / -3.0,col2}");
Console.WriteLine(line);

#endregion
```

When you run the code the results are as shown in the following output:
```
double.Epsilon: 5E-324
double.Epsilon to 324 decimal places: 0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005
double.Epsilon to 330 decimal places: 0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004940656
----------------------------------------------
Expression                            |  Value
----------------------------------------------
double.NaN                            |    NaN
double.PositiveInfinity               |      8
double.NegativeInfinity               |     -8
----------------------------------------------
0.0 / 0.0                             |    NaN
3.0 / 0.0                             |      8
-3.0 / 0.0                            |     -8
3.0 / 0.0 == double.PositiveInfinity  |   True
-3.0 / 0.0 == double.NegativeInfinity |   True
0.0 / 3.0                             |      0
0.0 / -3.0                            |     -0
----------------------------------------------
```
Note the following: 

- `NaN` outputs as `NaN`. It can be generated from an expression of zero divided by zero.
- `PositiveInfinity` value outputs as an `8` which looks like an infinity symbol on its side. It can be generated from an expression of any positive real number divided by zero.
- `NegativeInfinity` value outputs as a `-8` which looks like an infinity symbol on its side with a negative sign before it. It can be generated from an expression of any negative real number divided by zero.
- Zero divided by any positive real number is zero.
- Zero divided by any negative real number is negative zero.
- `Epsilon` is slightly less than `5E-324` represented using scientific notation: https://en.wikipedia.org/wiki/Scientific_notation.

## Page 96 - Formatting using numbered positional arguments & Formatting using interpolated strings

> Thanks to [Robin](https://github.com/centpede) who raised this [issue on December 15, 2023](https://github.com/markjprice/cs12dotnet8/issues/7).

In Step 1, you create a new project named `Formatting`. In Step 2, you write code to define some variables and output them formatted using positional arguments, as shown in the following code:
```cs
int numberOfApples = 12;
decimal pricePerApple = 0.35M;

Console.WriteLine(
  format: "{0} apples cost {1:C}",
  arg0: numberOfApples,
  arg1: pricePerApple * numberOfApples);
...
```

In the next section, you write code to output the variables formatted using string interpolation, as shown in the following code:
```cs
// The following statement must be all on one line when using C# 10
// or earlier. If using C# 11 or later, we can include a line break
// in the middle of an expression but not in the string text.
Console.WriteLine($"{numberOfApples} apples cost {pricePerApple
  * numberOfApples:C}");
```

Then you run the code and view the result, as shown in the following partial output:
```
12 apples cost £4.20
```

The output includes culture-dependent formatting like currency symbols. The output shown is when run on my computer in the United Kingdom so the currency symbol is `£`. Most readers are in the United States so they see a dollar `$` symbol. A small fraction of readers are in Europe so they see a `?` instead of the Euro currency symbol because by default the output encoding for the console does not support that special symbol.

In *Chapter 4, Writing, Debugging, and Testing Functions*, on page 179, I tell the reader to write a function to control this formatting named `ConfigureConsole`, as shown in the following code:
```cs
static void ConfigureConsole(string culture = "en-US",
  bool useComputerCulture = false)
{
  // To enable Unicode characters like Euro symbol in the console.
  OutputEncoding = System.Text.Encoding.UTF8;

  if (!useComputerCulture)
  {
    CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
  }
  WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
}
```

The issue is when to introduce how to control culture and enable special characters. 

In the next edition, in *Chapter 2*, I will add a step to get the reader to set the current culture to US English so that everyone sees exactly the same output, as shown in the following code:
```cs
using System.Globalization; // To use CultureInfo.

// Set current culture to US English so that all readers 
// see the same output as shown in the book.
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
```
And I will change the output to show dollars, of course.

I will also add a note to tell readers that in *Chapter 4* they will learn how to write a function to control the culture so that they can see (1) US English by default, (2) local computer culture, (3) a specified culture. Hopefully this improvement will be the best of all worlds.

## Page 131 - Pattern matching with the switch statement

> Thanks to Yousef Imran who raised this issue via email.

In Step 2, I tell the reader to create an `Spider` class with a field named `IsPoisonous`. The field would be better named `IsVenomous` because poison is a thing that you consume and venom is transmitted by an animal bite. One way to remember the difference is that the villain from Spider-man is named Venom rather name Poison.

In the next edition, I will change the field name.

## Page 248 - Storing multiple values using an enum type

In the **Good Practice** box, I will list the integer types that an `enum` is allowed to inherit from: `Byte`, `SByte`, `Int16`, `Int32`, `Int64`, `UInt16`, `UInt32`, `UInt64`. The new integer types `Int128` and `UInt128` are not supported.

## Page 369 - Understanding .NET components

> Thanks to Saeed Fathi who emailed this suggestion to me on December 6, 2023.

I used the term "CoreFX" which is an old term for what is now better known as `dotnet/runtime`. In future editions, I will remove that term.

## Page 484 - Compressing streams

> Thanks to [DrAvriLev](https://github.com/DrAvriLev) who raised this [issue on November 26, 2023](https://github.com/markjprice/cs12dotnet8/issues/4).

In Step 2, on page 485, I use a `using` statement without braces to ensure that the `decompressor` object has its `Dispose` method called. This can look confusing because I did not specify braces around the start and end of its scope.

In the 9th edition, I will add more code and explanations to multiple related sections of the book, as described below.

**Page 333 - Ensuring that Dispose is called**

In this section, I show how to use a `using` block to ensure that the `Dispose` method is called at the end of the scope, as shown in the following code:

```cs
using (ObjectWithUnmanagedResources thing = new())
{
  // Code that uses thing.
}
```

In the 9th edition, I will add a second example, using simplified syntax without braces, as shown in the following code:
```cs
using ObjectWithUnmanagedResources thing = new();

// Code that uses thing.

// Dispose called at the end of the container scope e.g. method.
```

I will explain that because there is no explicit block defined by braces, an implicit block is defined that ends at the end of the containing scope, and give an expanded code example. I will add a link to the following documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/using and https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/statements#1314-the-using-statement

At the end of the section, I wrote, "You will see practical examples of releasing unmanaged resources with `IDisposable`, `using` statements,
and `try...finally` blocks in *Chapter 9, Working with Files, Streams, and Serialization*." I will also add a note about the simplied syntax to Chapter 9.

**Page 483 - Simplifying disposal by using the using statement**

In this section, I show how to use a `using` block to ensure that the `Dispose` method is called at the end of the scope, and then I wrote, "You can even simplify the code further by not explicitly specifying the braces and indentation for the `using` statements, as shown in the following code:"

```cs
using FileStream file2 = File.OpenWrite(Path.Combine(path, "file2.txt"));

using StreamWriter writer2 = new(file2);

try
{
  writer2.WriteLine("Welcome, .NET!");
}
catch(Exception ex)
{
  WriteLine($"{ex.GetType()} says {ex.Message}");
}
```

In the 9th edition, I will add an expanded code example and explain how the end of the scope is determined.

**Page 484 - Compressing streams**

Somewhat ironically, in the code that uses the `decompressor` object, it does not use the simplified `using` syntax. Instead, it uses the fact that `using` blocks can omit their braces for a single "statement", just like `if` statements. Remember that `if` statements can have explicit braces even if only one statement is executed within the block, as shown in the following code:
```cs
if (c = 1)
{
  // Execute a single statement.
}

if (c = 1)
  // Execute a single statement.
```

```cs
using (someObject)
{
  // Execute a single statement.
}

using (someObject)
  // Execute a single statement.
```

In the following code, `using (XmlReader reader = XmlReader.Create(decompressor))` and the entire `while (reader.Read()) { ... }` block are equivalent to single statements, so we can remove the braces and the code works as expected:
```cs
    using (decompressor)

    using (XmlReader reader = XmlReader.Create(decompressor))

      while (reader.Read())
      {
        // Check if we are on an element node named callsign.
        if ((reader.NodeType == XmlNodeType.Element)
          && (reader.Name == "callsign"))
        {
          reader.Read(); // Move to the text inside element.
          WriteLine($"{reader.Value}"); // Read its value.
        }

        // Alternative syntax with property pattern matching:
        // if (reader is { NodeType: XmlNodeType.Element,
        //   Name: "callsign" })
      }
```

I will also explain why I did not use the simplified syntax with the `compressor` object (to dispose of it earlier).

# Bonus Content 

None so far.
