**Improvements** (5 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Print Book](#print-book)
  - [Page 64 - Formatting code using white space](#page-64---formatting-code-using-white-space)
  - [Page 79 - Raw interpolated string literals](#page-79---raw-interpolated-string-literals)
  - [Page 131 - Pattern matching with the switch statement](#page-131---pattern-matching-with-the-switch-statement)
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

> Thanks to [centpede](https://github.com/centpede) who raised this [issue on December 11, 2023](https://github.com/markjprice/cs12dotnet8/issues/6).

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

## Page 131 - Pattern matching with the switch statement

> Thanks to Yousef Imran who raised this issue via email.

In Step 2, I tell the reader to create an `Spider` class with a field named `IsPoisonous`. The field would be better named `IsVenomous` because poison is a thing that you consume and venom is transmitted by an animal bite. One way to remember the difference is that the villain from Spider-man is named Venom rather name Poison.

In the next edition, I will change the field name.

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
