**What's New in Modern C# and .NET**

This chapter covers the following topics:

- [Understanding modern .NET](#understanding-modern-net)
  - [Understanding .NET support](#understanding-net-support)
  - [Understanding .NET Runtime and .NET SDK versions](#understanding-net-runtime-and-net-sdk-versions)
- [What's new in modern C# and .NET?](#whats-new-in-modern-c-and-net)
- [Performance improvements](#performance-improvements)
  - [Indices and ranges](#indices-and-ranges)
- [Code simplification](#code-simplification)
  - [Top-level statements](#top-level-statements)
  - [Implicitly imported namespaces](#implicitly-imported-namespaces)
  - [Using declarations](#using-declarations)
  - [Target-typed new](#target-typed-new)
  - [Raw string literals](#raw-string-literals)
  - [Requiring properties to be set during instantiation](#requiring-properties-to-be-set-during-instantiation)
- [Null and nullability](#null-and-nullability)
  - [Nullable reference types](#nullable-reference-types)
  - [Checking for null in method parameters](#checking-for-null-in-method-parameters)
- [Functional programming](#functional-programming)
  - [Record types and init-only setters](#record-types-and-init-only-setters)
  - [Switch expressions](#switch-expressions)
- [Practicing and exploring](#practicing-and-exploring)
  - [Exercise 2.1 – Test your knowledge](#exercise-21--test-your-knowledge)
  - [Exercise 2.2 – Explore topics](#exercise-22--explore-topics)
  - [Exercise 2.3 – Online content](#exercise-23--online-content)
  - [Default interface methods](#default-interface-methods)
  - [Generic math support](#generic-math-support)
  - [File-scoped types](#file-scoped-types)
- [Summary](#summary)


In this online-only section, the goal is to review what is new since C# 6 and .NET Core 1.0 that were released in 2016. Instead of just listing the new features introduced with each version of .NET, we will take a themed approach to make it easier to understand how small individual improvements are supposed to work together holistically.

# Understanding modern .NET

In 2020, .NET Core was rebranded .NET and the major version number skipped 4 to avoid confusion with legacy .NET Framework 4.x. Microsoft plans on annual major version releases every November from now on, rather like Apple does major version number releases of iOS every September.

The following table shows when recent versions of modern .NET were released, when future releases are planned, and when they reach end of life and are therefore become officially unsupported and will receive no more bug fixes and security updates:

Version|Support|Released|End of life
---|---|---|---
.NET 6|LTS|November 8, 2021|November 8, 2024
.NET 7|STS|November 8, 2022|May 2024
.NET 8|LTS|November 2023|November 2026
.NET 9|STS|November 2024|May 2026
.NET 10|LTS|November 2025|November 2028

## Understanding .NET support

.NET releases are either **LTS**, **STS** (formerly known as **Current**), or **Preview**, as described in the following list:

- **Long Term Support (LTS)** releases are stable and require fewer updates over their lifetime. These are a good choice for applications that you do not intend to update frequently. LTS releases are supported by Microsoft for 3 years after general availability, or 1 year after the next LTS release ships, whichever is longer.
- **Standard Term Support (STS)** releases include features that may change based on feedback. These are a good choice for applications that you are actively developing because they provide access to the latest improvements. STS releases are supported by Microsoft for 18 months after general availability, or 6 months after the next release ships, whichever is longer.
- **Preview** releases are for public testing. These are a good choice for adventurous programmers who want to live on the bleeding edge, or programming book writers who need to have early access to new language features, libraries, and app platforms. Preview releases are not supported by Microsoft but preview or Release Candidate (RC) releases may be declared Go Live, meaning they are supported by Microsoft in production.

STS and LTS releases receive critical fixes throughout their lifetime for security and reliability. You must stay up to date with the latest patches to get support. For example, if a system is running 1.0 and 1.0.1 has been released, 1.0.1 must be installed to get support.
End of support or end of life means the date after which bug fixes, security updates, or technical assistance are no longer available from Microsoft.

## Understanding .NET Runtime and .NET SDK versions

.NET Runtime versioning follows semantic versioning; that is, a major increment indicates breaking changes, minor increments indicate new features, and patch increments indicate bug fixes.

.NET SDK versioning does not follow semantic versioning. The major and minor version numbers are tied to the runtime version it is matched with. The patch number follows a convention that indicates the major and minor versions of the SDK. 

For example, patch number 100 means SDK version 1.0, patch number 101 means SDK version 1.1, and patch number 200 means SDK version 2.0. You can see an example of this in the following table:

Change|Runtime|SDK|SDK Meaning
---|---|---|---
Initial release|8.0.0|8.0.100|.NET 8 SDK 1.0
SDK bug fix|8.0.0|8.0.101|.NET 8 SDK 1.1
Runtime and SDK bug fix|8.0.1|8.0.102|.NET 8 SDK 1.2
SDK new feature|8.0.1|8.0.200|.NET 8 SDK 2.0

# What's new in modern C# and .NET?

There were many language and library features introduced with C# 6 and .NET Core 1:
- x

There were many language and library features introduced with C# 7 and .NET Core 2:
- x

There were many language and library features introduced with C# 8 and .NET Core 3:
- You can apply readonly to members of a struct.
- You can use ??= to assign the value only if the left-hand operand evaluates to null.
- You can use both $@"..." and @$"..." as valid interpolated verbatim strings.
- There are more ways to perform pattern matching.
- You can make local functions static.
- You can create and consume async streams, meaning iterators that implement IAsyncEnumerable<T>, not streams that derive from the abstract Stream class. You will see an example in Chapter 4, Benchmarking Performance, Multitasking, and Concurrency.
- You can use await using to work with an asynchronously disposable object that implements the System.IAsyncDisposable interface.
There were some important language and library features introduced with C# 9 and .NET 5:
- More pattern matching enhancements like type patterns, parenthesized patterns, use of and, or, and not in patterns, relational patterns with <, >, and so on.
- Support for source code generators. They can only add code, not modify existing code.

There were many language and library features introduced with C# 10 and .NET 6:
- Project templates enable nullability checks by default.
- Project templates enable implicitly globally imported namespaces by default.
- You can define value type records using record struct.
- Constant interpolated strings.
- File-scoped namespace declarations.
- Lambda expressions are easier to write because the compiler can infer a delegate type from the expression.

There were many language and library features introduced with C# 11 and .NET 7:
- You can use newlines in string interpolations.
- You can use static abstract members in interfaces.
- You can define generic attributes.

There were many language and library features introduced with C# 12 and .NET 8:
- Primary constructors.
- Aliasing any type.
- Lambda expression parameter default values.

# Performance improvements

Performance improvements include:
- Simplifying specifying indexes and ranges.

## Indices and ranges

Indices and ranges enable efficient access to elements and slices of elements with an array:
- Define a position using `System.Index`
- Define a slice using `System.Range`

Items in an array can be accessed by passing an integer into their indexer, as shown in the following code:
```cs
int index = 3;
Person p = people[index]; // fourth person in array
char letter = name[index]; // fourth letter in name
```

The `Index` value type is a more formal way of identifying a position, and supports counting from the end, as shown in the following code:
```cs
// two ways to define the same index, 3 in from the start 
Index i1 = new Index(value: 3); // counts from the start 
Index i2 = 3; // using implicit int conversion operator

// two ways to define the same index, 5 in from the end
Index i3 = new Index(value: 5, fromEnd: true); 
Index i4 = ^5; // using the caret operator
```

The `Range` value type uses `Index` values to indicate the start and end of its range, using its constructor, C# syntax, or its static methods, as shown in the following code:
```cs
Range r1 = new Range(start: new Index(3), end: new Index(7));
Range r2 = new Range(start: 3, end: 7); // using implicit int conversion
Range r3 = 3..7; // using C# 8.0 or later syntax
Range r4 = Range.StartAt(3); // from index 3 to last index
Range r5 = 3..; // from index 3 to last index
Range r6 = Range.EndAt(3); // from index 0 to index 3
Range r7 = ..3; // from index 0 to index 3
```

# Code simplification

Code simplification includes:
- Top-level statements to minimize the amount of code needed in a simple console app.
- Implicitly imported namespaces.
- Removing the need to define indented blocks.
- Simplifying instantiating objects.
- Simplifying string definitions.
- Simplifying how to enforce setting properties.

## Top-level statements

Before the C# 9 compiler, a console app and its `Program.cs` file needed to define a class with a `Main` method as its entry point, as shown in the following code:
```cs
using System;

namespace HelloCS
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }
}
```

With C# 9, the top-level statements feature allows the `Program` class to be created by the compiler, as shown in the following code:
```cs
using System;

Console.WriteLine("Hello World!");
```

All the boilerplate code to define a `namespace`, the `Program` class, and its `Main` method is generated and wrapped around the statements you write.

Key points to remember about top-level programs include the following:
- There can be only one file like this in a project.
- Any `using` statements must go at the top of the file.
- You must have at least one executable statement, like the `Console.WriteLine` statement above, or you will get a compile error because the compiler cannot identify where the statements that need to go inside the `Main` method are. This is one reason why the Microsoft project template writes `Hello World!` to the console instead of just having a comment!
- If you declare any classes or other types, they must go at the bottom of the file.
- Although you should name the method `Main` if you explicitly define it, the method is named `<Main>$` when created by the compiler.

## Implicitly imported namespaces

With .NET 6 and later, Microsoft updated the project template for console apps to use top-level statements by default. It also implicitly imports common namespaces globally by default.

Traditionally, every `.cs` file that needs to import namespaces would have to start with using statements to import those namespaces. Namespaces like `System` and `System.Linq` are needed in almost all `.cs` files, so the first few lines of every `.cs` file often had at least a few using statements, as shown in the following code:
```cs
using System;
using System.Linq;
using System.Collections.Generic;
```

When creating websites and services using ASP.NET Core, there are often dozens of namespaces that each file would have to import.

C# 10 introduced a new keyword combination and .NET SDK 6 introduced a new project setting that work together to simplify importing common namespaces.

The `global using` keyword combination means you only need to import a namespace in one `.cs` file and it will be available throughout all `.cs` files. You could put `global using` statements in the `Program.cs` file, but I recommend creating a separate file for those statements named something like `GlobalUsings.cs` with the contents being all your `global using` statements but nothing else, as shown in the following code:
```cs
global using System;
global using System.Linq;
global using System.Collections.Generic;
```

But rather than create this file yourself, you can get the SDK to create it for you. Any projects that target .NET 6.0 or later, and that therefore use the C# 10 or later compiler, can generate a `<ProjectName>.GlobalUsings.g.cs` file in the `obj` folder to implicitly globally import some common namespaces like `System`, as shown in the following code:
```cs
// <autogenerated />
global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
```

The specific list of implicitly imported namespaces depends on which SDK you target, as shown in the following table:

SDK|Implicitly imported namespaces
---|---
Microsoft.NET.Sdk|`System`, `System.Collections.Generic`, `System.IO`, `System.Linq`, `System.Net.Http`, `System.Threading`, `System.Threading.Tasks`
Microsoft.NET.Sdk.Web|Same as Microsoft.NET.Sdk and: `System.Net.Http.Json`, `Microsoft.AspNetCore.Builder`, `Microsoft.AspNetCore.Hosting`, `Microsoft.AspNetCore.Http`, `Microsoft.AspNetCore.Routing`, `Microsoft.Extensions.Configuration`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.Logging`
Microsoft.NET.Sdk.Worker|Same as Microsoft.NET.Sdk and: `Microsoft.Extensions.Configuration`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.Logging`

To control the implicit generation of this file and to control which namespaces are implicitly imported, you can create an item group in the project file, as highlighted in the following markup:
```cs
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <Using Remove="System.Threading" />
    <Using Include="System.Numerics" />
    <Using Include="System.Console" Static="true" />
    <Using Include="System.Environment" Alias="Env" />
  </ItemGroup>

</Project>
```

The `Using` element supports attributes to control how the namespace or type is imported, as shown in the following table:

Attribute name|Description
---|---
`Remove`|The name of a namespace to remove from the auto-generated `global using` file.
`Include`|The name of a namespace or type to import in  the auto-generated `global using` file.
`Static`|If `true`, imports the type statically, for example, `global using static System.Console;`
`Alias`|An alias that can be used instead of the namespace or type, for example, `global using Env = System.Environment;`

## Using declarations

You can simplify using blocks by removing the curly braces. For example, when working with a disposable resource like a file, as shown in the following code:
```cs
using (FileStream file = File.OpenWrite(Path.Combine(path, "file.txt")))
{
  ...
} // automatically calls Dispose if the file is not null
```

This could be simplified, as shown in the following code:
```cs
using (FileStream file = File.OpenWrite(Path.Combine(path, "file.txt")));
...
// automatically calls Dispose at the end of current scope if the file is not null
```

## Target-typed new

With C# 9, Microsoft introduced another syntax for instantiating objects known as target-typed new. When instantiating an object, you can specify the type first and then use new without repeating the type, as shown in the following code:
```cs
XmlDocument xmlDoc = new(); // target-typed new in C# 9 or later
```

If you have a type with a field or property that needs to be set, then the type can be inferred, as shown in the following code:
```cs
// In Program.cs
Person kim = new();
kim.BirthDate = new(1967, 12, 26); // instead of: new DateTime(1967, 12, 26)

// In a separate Person.cs file or at the bottom of Program.cs
class Person
{
  public DateTime BirthDate;
}
```

## Raw string literals

Raw string literals are convenient for entering any arbitrary text without needing to escape the contents. They make it easy to define literals containing other languages like XML, HTML, or JSON.

Raw string literals start and end with three or more double-quote characters, as shown in the following code:
```cs
string xml = """
             <person age="50">
               <first_name>Mark</first_name>
             </person>
             """;
```

In the previous code, the XML is indented by 13 spaces. The compiler looks at the indentation of the last three double-quote characters, and then automatically removes that level of indentation from all the content inside the raw string literal, as shown in the following markup:
```cs
<person age="50">
  <first_name>Mark</first_name>
</person>
```

You can mix interpolated with raw string literals. You specify the number of braces that indicate a replaced expression by adding that number of dollar signs to the start of the literal. Any fewer braces than that is treated as raw content. 

For example, if we want to define some JSON, single braces will be treated as normal braces, but the two dollar symbols tell the compiler that any two curly braces indicate a replaced expression value, as shown in the following code:
```cs
string json = $$"""
              {
                "first_name": "{{person.FirstName}}",
                "age": {{person.Age}},
              };
              """
```

## Requiring properties to be set during instantiation

The `required` modifier can be applied to a field or property. The compiler will ensure that you set the field or property to a value when you instantiate it.

For example, you might have two properties, one of which should be required, as shown in the following code:
```cs
namespace Packt.Shared;

public class Book
{
  public required string Isbn { get; set; }
  public string? Title { get; set; }
}
```

If you attempt to instantiate a `Book` without setting the `Isbn` property, as shown in the following code:
```cs
Book book = new();
book.Title = "C# 11 and .NET 7 - Modern Cross-Platform Development";
```

Then you will see a compiler error, as shown in the following output:
`Error	CS9035	Required member 'Book.Isbn' must be set in the object initializer or attribute constructor.`

You would therefore have to set the property during initialization, as shown in the following code:
```cs
Book book = new() { Isbn = "1234-5678"};
```

# Null and nullability

## Nullable reference types

The use of the `null` value is so common, in so many languages, that many experienced programmers never question the need for its existence. But there are many scenarios where we could write better, simpler code if a variable is not allowed to have a null value.

The most significant change to the C# 8 language compiler was the introduction of checks and warnings for nullable and non-nullable reference types. "But wait!", you are probably thinking, "Reference types are already nullable!"

And you would be right, but in C# 8 and later, reference types can be configured to no longer allow the `null` value by setting a file- or project-level option to enable this useful new feature. Since this is a big change for C#, Microsoft decided to make the feature opt-in.

It will take multiple years for this new C# language compiler feature to make an impact since thousands of existing library packages and apps will expect the old behavior. Even Microsoft did not have time to fully implement this new feature in all the main .NET packages until .NET 6. Important libraries like `Microsoft.Extensions` for logging, dependency injections, and configuration were not annotated until .NET 7.

For example, in Microsoft's implementation of the `System.String` class, the `IsNullOrEmpty` method is annotated to indicate expected nullability. Since the purpose of the method is to return `true` only when the `value` parameter is either `null` or empty, if the method returns `false`, the `value` must not be `null`, so the static compiler analysis can be informed that the parameter will not be `null` when the method returns `false`, as shown in the following code:
```cs
bool IsNullOrEmpty([NotNullWhen(false)] string? value)
```

During the transition, you can choose between several approaches for your own projects:
- Default: For projects created using .NET 5 or earlier, no changes are needed. Non-nullable reference types are not checked. For projects created using .NET 6 or later, nullability checks are enabled by default, but this can be disabled by either deleting the <Nullable> entry in the project file or setting it to disable.
- Opt-in project, opt-out files: Enable the feature at the project level and, for any files that need to remain compatible with old behavior, opt out. This was the approach Microsoft was using internally while it updated its own packages to use this new feature. 
- Opt-in files: Only enable the feature for individual files.

To enable the nullability warning check feature at the project level, add the following to your project file:
```xml
<PropertyGroup>
  ...
  <Nullable>enable</Nullable>
</PropertyGroup>
```

To disable the nullability warning check feature at the project level, add the following to your project file:
```xml
<PropertyGroup>
  ...
  <Nullable>disable</Nullable>
</PropertyGroup>
```

To disable the feature at the file level, add the following to the top of a code file:
```cs
#nullable disable
```

To enable the feature at the file level, add the following to the top of a code file:
```cs
#nullable enable
```

If you enable nullable reference types and you want a reference type to be assigned the `null` value, then you will have to use the same syntax as making a value type nullable, that is, adding a `?` symbol after the type declaration.

## Checking for null in method parameters

When defining methods with parameters, it is good practice to check for `null` values.

In earlier versions of C#, you would have to write `if` statements to check for `null` parameter values and then throw an `ArgumentNullException` for any parameter that is `null`, as shown in the following code:
```cs
public void Hire(Person manager, Person employee)
{
  if (manager == null)
  {
    throw new ArgumentNullException(nameof(manager));
  }

  if (employee == null)
  {
    throw new ArgumentNullException(nameof(employee));
  }
  ...
}
```

.NET 6 introduced a convenient method to throw an exception if an argument is `null`, as shown in the following code:
```cs
public void Hire(Person manager, Person employee)
{
  ArgumentNullException.ThrowIfNull(manager);
  ArgumentNullException.ThrowIfNull(employee);
  ...
}
```

C# 11 previews in early 2022 introduced a new `!!` operator that did this for you when you applied the operator as a suffix to parameter names, as shown in the following code:
```cs
public void Hire(Person manager!!, Person employee!!)
{
  ...
}
```

The `if` statement and throwing of the exception are done for you. The code is injected and executes before any statements that you write.
The .NET product team claims to have saved more than 10,000 lines of code throughout the .NET libraries by using this feature. But this syntax is controversial within the C# developer community and unfortunately there were enough complaints during the previews that Microsoft reversed their decision and removed the feature from previews. It is unlikely to return.

# Functional programming

Functional Programming (FP) means

## Record types and init-only setters

The biggest new language feature in C# 9 was **records**. Sometimes you want to treat properties like `readonly` fields so they can be set during instantiation but not after. The new `init` keyword enables this. It can be used in place of the set keyword, as shown in the following code:
```cs
namespace Packt.Shared;

public class ImmutablePerson
{
  public string? FirstName { get; init; }
  public string? LastName { get; init; }
}

ImmutablePerson jeff = new() 
{
  FirstName = "Jeff", // allowed
  LastName = "Winger"
};

jeff.FirstName = "Geoff"; // compile error!
```

The syntax for defining a record can be greatly simplified using positional data members, as shown in the following code:
```cs
// simpler way to define a record
// auto-generates the properties, constructor, and deconstructor
public record ImmutableAnimal(string Name, string Species);
```

## Switch expressions

Switch expressions are a more compact switch syntax. For example, a switch statement, as shown in the following code:
```cs
Stream? s;
...
string message; 
switch (s)
{
  case FileStream writeableFile when s.CanWrite:
    message = "The stream is a file that I can write to.";
    break;
  case FileStream readOnlyFile:
    message = "The stream is a read-only file.";
    break;
  case MemoryStream ms:
    message = "The stream is a memory address.";
    break;
  default: // always evaluated last despite its current position
    message = "The stream is some other type.";
    break;
  case null:
    message = "The stream is null.";
    break;
}
```

Could be more succinctly expressed as a switch expression, as shown in the following code:
```cs
Stream? s;
...
string message = s switch
{
  FileStream writeableFile when s.CanWrite
    => "The stream is a file that I can write to.", 
  FileStream readOnlyFile
    => "The stream is a read-only file.", 
  MemoryStream ms
    => "The stream is a memory address.", 
  null
    => "The stream is null.",
  _
    => "The stream is some other type."
};
```

# Practicing and exploring

Test your knowledge and understanding by answering some questions, getting some hands-on practice, and exploring with deeper research the topics in this chapter.

## Exercise 2.1 – Test your knowledge

Use the web to answer the following questions:

1.	Which type of .NET release is higher quality, STS or LTS?
2.	In new .NET projects, nullable checks are enabled. What are two ways to disable them?
3.	If you define any types in a top-level program, where must they go in the Program.cs file?
4.	How do you import a class like Console so that its static members like WriteLine are available in all code files throughout a project?
5.	What is the best new C# 11 language feature?

## Exercise 2.2 – Explore topics

Use the links on the following page to learn more about the topics covered in this chapter:

https://github.com/markjprice/apps-services-net8/blob/main/book-links.md#chapter-2---whats-new-in-modern-net

## Exercise 2.3 – Online content

There are some advanced new features introduced with modern .NET including:
- x

Read more about them at the following link: 

## Default interface methods

You can provide implementations of members in an interface. This is most useful when you have defined an interface, and in a later version you want to extend it. Normally you would not be able to without breaking any clients that consume your interface, because any types that implement the interface will not provide implementations for the new members. Now you can add new members with implementations in the interface and the types will inherit the default implementations in the interface. This is also useful for interactions with APIs for Android or Swift that also support this functionality.

## Generic math support

C# has supported math operations like addition and division using operators like + and / since its first version. But that support was implemented only for the numeric data types that were built into the language like int and double.

What if a developer needs to define a new type of number? They could override the standard operators, but that is a lot of work.

Microsoft has added features like static virtual members in interfaces, checked user defined operators, relaxed shift operators, and an unsigned right-shift operator, which are needed to enable anyone to define new types of number that can implement some new interfaces and then work just like all the built-in number types.

For example, you would implement the `System.IAdditionOperators<TSelf, TOther, TResult>` interface in a new number type that implements the `+` operator.

As you can imagine, defining your own numeric types is a rare and advanced capability, so I do not cover it in this book. If you are interested in learning more, then I recommend reading the blog article at the following link: https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/

## File-scoped types

You can use `file` keyword.

# Summary

In these online-only sections, you:
- Reviewed some of the new features in the C# compiler and the .NET libraries in modern versions.
