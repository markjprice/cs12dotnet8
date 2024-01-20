**Improvements** (13 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Print Book](#print-book)
  - [Page 64 - Formatting code using white space](#page-64---formatting-code-using-white-space)
  - [Page 79 - Raw interpolated string literals](#page-79---raw-interpolated-string-literals)
  - [Page 87 - Comparing double and decimal types](#page-87---comparing-double-and-decimal-types)
  - [Page 96 - Formatting using numbered positional arguments \& Formatting using interpolated strings](#page-96---formatting-using-numbered-positional-arguments--formatting-using-interpolated-strings)
  - [Page 131 - Pattern matching with the switch statement](#page-131---pattern-matching-with-the-switch-statement)
  - [Page 144 - List pattern matching with arrays](#page-144---list-pattern-matching-with-arrays)
  - [Page 248 - Storing multiple values using an enum type](#page-248---storing-multiple-values-using-an-enum-type)
  - [Page 369 - Understanding .NET components](#page-369---understanding-net-components)
  - [Page 426 - Comparing string values](#page-426---comparing-string-values)
  - [Page 457 - Initializing collections using collection expressions](#page-457---initializing-collections-using-collection-expressions)
    - [Using the spread element](#using-the-spread-element)
    - [Collection expression limitations](#collection-expression-limitations)
  - [Page 460 - Identifying ranges with the Range type](#page-460---identifying-ranges-with-the-range-type)
  - [Page 484 - Compressing streams](#page-484---compressing-streams)
  - [Page 493 - Serializing as XML](#page-493---serializing-as-xml)
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

In Step 2, I tell the reader to create an `Spider` class with a field named `IsPoisonous`. The field would be better named `IsVenomous` because poison is a thing that you consume and venom is transmitted by an animal bite. One way to remember the difference is that the villain from Spider-man is named Venom instead of Poison.

In the next edition, I will change the field name to `IsVenomous`.

## Page 144 - List pattern matching with arrays

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) who raised this [issue on January 20, 2024].

On page 446, I have a note about C# allowing trailing commas, "The trailing commas after the third item is added to the dictionary are optional and the compiler will not complain about them. This is convenient so that you can change the order of the three items without having to delete and add commas in the right places."

But that is not the first time in the book that I use trailing commas. On page 144, I wrote a switch expression that uses a trailing comma, as shown in the following code:
```cs
static string CheckSwitch(int[] values) => values switch
{
  [] => "Empty array",
  [1, 2, _, 10] => "Contains 1, 2, any single number, 10.",
  [1, 2, .., 10] => "Contains 1, 2, any range including empty, 10.",
  [1, 2] => "Contains 1 then 2.",
  [int item1, int item2, int item3] => $"Contains {item1} then {item2} then {item3}.",
  [0, _] => "Starts with 0, then one other number.",
  [0, ..] => "Starts with 0, then any range of numbers.",
  [2, .. int[] others] => $"Starts with 2, then {others.Length} more numbers.",
  [..] => "Any items in any order.", // <-- Note the trailing comma.
};
```

Most languages, including C#, allow the code style of trailing commas. When multiple items are separated by the comma, for example, when declaring an anonymous object, an array, collection initializers, enums, and switch expressions, C# allows you to have the trailing comma after the last item. This makes it easy to rearrange the order without having to keep adding and removing commas.

Here is the discussion about allowing trailing commas for switch expressions back in 2018: dotnet/csharplang#2098

Even JSON serializers have an option to allow this because it is so common to use.
https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.allowtrailingcommas

In the next edition, I will move the note earlier in the book to when I first use the technique.

## Page 248 - Storing multiple values using an enum type

In the **Good Practice** box, I will list the integer types that an `enum` is allowed to inherit from: `Byte`, `SByte`, `Int16`, `Int32`, `Int64`, `UInt16`, `UInt32`, `UInt64`. The new integer types `Int128` and `UInt128` are not supported.

## Page 369 - Understanding .NET components

> Thanks to Saeed Fathi who emailed this suggestion to me on December 6, 2023.

I used the term "CoreFX" which is an old term for what is now better known as `dotnet/runtime`. In future editions, I will remove that term.

## Page 426 - Comparing string values

> Thanks to **f6a4** in the book's Discord channel for suggesting this improvement.

In the introduction to this section, I describe the theory of comparing string values and how they are culture-dependent, including examples from Swedish and German like the word for *street*, `Straße` and `Strasse`. 

In Step 2, the reader enters code to compare two string values: `Mark` and `MARK`, both exact comparison and case-insensitive. 

In the next edition, I will add code to compare two string values in German culture: `Straße` and `Strasse`, both exact comparison and case-insensitive, as shown in the following code:
```cs
// German string comparisons

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

text1 = "Strasse";
text2 = "Straße";

WriteLine($"text1: {text1}, text2: {text2}");

WriteLine("Compare: {0}.", string.Compare(text1, text2, 
  CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace));

WriteLine("Compare (IgnoreCase, IgnoreNonSpace): {0}.",
  string.Compare(text1, text2, CultureInfo.CurrentCulture, 
  CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}.",
  string.Compare(text1, text2,
  StringComparison.InvariantCultureIgnoreCase));
```

I have also added this example to the current edition solution code here:
https://github.com/markjprice/cs12dotnet8/blob/0ee475706186d2c82fdb836837783aed3a4d4fd0/code/Chapter08/WorkingWithText/Program.cs#L78

## Page 457 - Initializing collections using collection expressions

In this section, I introduce the use of collection expressions to initialize collections. A related feature is the `..` spread element. In the next edition, I will add a section about it, as shown below.

### Using the spread element

> Microsoft official documentation uses both **spread element** and **spread operator** to refer to the same language feature. I prefer *element* because it is used in collection expressions to represent an element within the defined collection.

The spread element `..` can be prefixed before any expression that can be enumerated to evaluate it in a collection expression. For example, any type that can be enumerated using `foreach`, like an array or collection, can be evaluated using the spread element. The use of the spread element `..` in a collection expression replaces its argument with the elements from that collection. You can combine spread elements with individual elements in a collection expression.

For example:
```cs
int[] row0 = [1, 2, 3];
int[] row1 = [4, 5];
int[] row2 = [6, 7, 8, 9];

// Use the spread element to combine the three arrays and an integer into one array.
int[] combinedRows = [..row0, ..row1, ..row2, 10];

foreach (int number in combinedRows)
{
  Console.Write($"{number}, ");
}
```

The output would be:
```
1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
```

> **More Information**: You can learn more about the spread element at the following link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/collection-expressions#spread-element.

### Collection expression limitations

Collection expressions do not work with all collections. For example, they do not work with dictionaries or multi-dimensional arrays. The documenation lists the types that a collection expression can be converted to: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/collection-expressions#conversions.

> **Warning!** Be careful not to confuse the spread element `..` that must be applied before an enumerable expression, with the range operator `..` that is used to define a `Range`. There is a discussion about the design decision around the spread element at the following link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/collection-expressions#drawbacks.

## Page 460 - Identifying ranges with the Range type

In this section, I introduce ways to define a `Range`, including the range operator `..` available in C# 8 or later, as shown in the following code:
```cs
Range r3 = 3..7; // Using C# 8.0 or later syntax.
Range r5 = 3..; // From index 3 to last index.
Range r7 = ..3; // From index 0 to index 3.
```

In the next edition, I will add a note to warn the reader that the spread element `..` looks the same but means something different and refer back to it in a  new section explaining the spread element. 

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

## Page 493 - Serializing as XML

> Thanks to [Robin Bastian](https://github.com/centpede) for raising this issue on [January 12, 2024](https://github.com/markjprice/cs12dotnet8/issues/11).

In Step 2, I wrote, "In the project file, add elements to statically and globally import the `System.Console`, `System.Environment`, and `System.IO.Path` classes."

Some readers do not notice that they need to statically import `System.Environment` so in the next edition I will write, "In the project file, add elements to statically and globally import the `System.Console` (to use `ForegroundColor` and `WriteLine`), `System.Environment` (to use `CurrentDirectory`), and `System.IO.Path` classes (to use `Combine`, `GetFileName`, and `GetDirectoryName`)."

# Bonus Content 

None so far.
