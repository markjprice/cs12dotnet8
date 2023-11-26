**Improvements** (1 item)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Print Book](#print-book)
  - [Page 484 - Compressing streams](#page-484---compressing-streams)
- [Bonus Content](#bonus-content)

# Print Book

## Page 484 - Compressing streams

> Thanks to [DrAvriLev](https://github.com/DrAvriLev) who raised this [issue on November 16, 2023](https://github.com/markjprice/cs12dotnet8/issues/4).

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
