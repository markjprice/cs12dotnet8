**What's New in the 8th Edition**

There are hundreds of minor fixes and improvements throughout the 8th edition; too many to list individually. All [errata and improvements for the 7th edition](https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/README.md) have been made to the 8th edition. The main new sections in C# 12 and .NET 8, 8th edition compared to the previous edition are shown below.

- [Chapter 1 Hello C#, Welcome .NET!](#chapter-1-hello-c-welcome-net)
- [Chapter 2 Speaking C#](#chapter-2-speaking-c)
- [Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions](#chapter-3-controlling-flow-converting-types-and-handling-exceptions)
- [Chapter 4 Writing, Debugging, and Testing Functions](#chapter-4-writing-debugging-and-testing-functions)
- [Chapter 5 Building Your Own Types with Object-Oriented Programming](#chapter-5-building-your-own-types-with-object-oriented-programming)
- [Chapter 6 Implementing Interfaces and Inheriting Classes](#chapter-6-implementing-interfaces-and-inheriting-classes)
- [Chapter 7 Packaging and Distributing .NET Types](#chapter-7-packaging-and-distributing-net-types)
- [Chapter 8 Working with Common .NET Types](#chapter-8-working-with-common-net-types)
- [Chapter 9 Working with Files, Streams, and Serialization](#chapter-9-working-with-files-streams-and-serialization)
- [Chapter 10 Working with Data Using Entity Framework Core](#chapter-10-working-with-data-using-entity-framework-core)
- [Chapter 11 Querying and Manipulating Data Using LINQ](#chapter-11-querying-and-manipulating-data-using-linq)
- [Chapter 12 Introducing Web Development Using ASP.NET Core](#chapter-12-introducing-web-development-using-aspnet-core)
- [Chapter 13 Building Websites Using ASP.NET Core Razor Pages](#chapter-13-building-websites-using-aspnet-core-razor-pages)
- [Chapter 14 Building and Consuming Web Services](#chapter-14-building-and-consuming-web-services)
- [Chapter 15 Building User Interface Components Using Blazor](#chapter-15-building-user-interface-components-using-blazor)

# Chapter 1 Hello C#, Welcome .NET!

- Added a note and link to the [Command-Lines](command-lines.md) page.
- Added an explaination about support phases, for example, active, go-live, maintenance, and so on.
- Modified how the two projects are created: one using `--use-program-main`; when adding the second project, added a note about **File** | **New** | **Project** versus **File** | **Add** | **New Project**.
- Moved all text about notebooks to an optional exercise.

# Chapter 2 Speaking C#

- Understanding format strings: add tables of standard and custom format codes especially for numbers and date/time values.
- Explain the `private field _` prefix convention.
- Explain that there should be no namespace in `Program.Helpers.cs` and how to show the namespace name.
- Explain how to disable the implicitly imported namespaces feature if you want to manually create a global using file so there is only one place other developers need to go to see what's imported.

# Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions

- Explain the conditional `?:` operator.
- In the `SelectionStatements` project, explain that the step to add a class named `Animals.cs` is VS2022-specific.
- Moved exercise 3.5 to 3.3.

# Chapter 4 Writing, Debugging, and Testing Functions

- Use `ArgumentOutOfRange` exception for the Fibonacci function instead of a generic exception.
- Understanding logging options: added a Good Practice about asking about logging in interview to show that you know its different for enterprises and its importance.
- Added a Good Practice about adding `Trace.AutoFlush = true;` only during development so we don't lose performance in release/production.
- Added a warning about the auto-generated namespace issue for `partial Program`.

# Chapter 5 Building Your Own Types with Object-Oriented Programming

- Changed the property named `DateOfBirth` to `Born` because it is not just a date, it also includes a time.
- Moved `required` section to the constructors section because it is about initializing fields and properties.
- Added an explanation about file-scope: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/file.

# Chapter 6 Implementing Interfaces and Inheriting Classes

- Add an exercise to suggest that readers review the **C# 101 .NET Interactive** notebook.
- Rewrote and expanded the sections about class features especially important differences between the *concept of abstraction* and the `abstract` keyword.

# Chapter 7 Packaging and Distributing .NET Types

- Added an explanation about `dotnet new gitignore`.
- Added a new section about Native AOT with a code task: https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/.
- Removed Ex7.3.

# Chapter 8 Working with Common .NET Types

- Added a new section explaining read-only, immutable, and the new frozen collections.

# Chapter 9 Working with Files, Streams, and Serialization

- Added the `Spectre.Console` package to use its tables for output.
- Added a note about the `Path.Exists` method that was added in .NET 7. It is not available in earlier versions of .NET.
- Added a new 5-page section titled *Working with environment variables*. This shows methods on the `Environment` class and is useful to prepare readers for loading secret values like user names and passwords from environment variables instead of hard-coding them in source code.

# Chapter 10 Working with Data Using Entity Framework Core

- Updated the connection string for SQLite to explain that `Filename` means the same as `Data Source` and to use the modern one.
- Added a new section about tracking including the `AsNoTracking()` method that often gets LinkedIn posts that are overly simplistic.

# Chapter 11 Querying and Manipulating Data Using LINQ

- Added a new section titled **Grouping for lookups**. It covers the `ToLookup` method that I later use in a solution to an exercise. Errata item: https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/improvements.md#page-512---group-joining-sequences

# Chapter 12 Introducing Web Development Using ASP.NET Core

- Added a table to list all the ports for all projects and make them all different based on the chapter number.
- Added an explanation of **Build Action** and `.csproj` entries with an explanation of the `<ItemGroup><Content>` and `<Remove>` entries.
- Added a diagram explaining difference between Razor Pages and Razor views.
- Added a note about updating as well as installing the EF Core tools: `dotnet tool update --global dotnet-ef`
- I added code to use `Path.GetFullPath(path)` in the `DbContext` configuration and to output the path to logs.
- Fixed the `CanConnect` unit test with wrong/missing file creates a `Northwind.db` with 0 bytes! The code now checks if the file exists and throws an exception if it does not.
- I now use use `SqlConnectionStringBuilder` in `NorthwindContext` in the online-only SQL Server instructions.

# Chapter 13 Building Websites Using ASP.NET Core Razor Pages

- Added a summary of middleware order: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/#middleware-order.
- The previous *Chapter 14 Building Websites Using the Model-View-Controller Pattern* becomes an online section.
- Switched the auto-registration code for the Admin user account to use `admin@example.com` instead of `test@example.com`.
- Added a diagram to illustrate the different types of caching.
- Added a table for the new validation attributes and the existing ones, for example, `Range[min and mix]`.

# Chapter 14 Building and Consuming Web Services

- Added `307` to the table of status codes.
- Added instructions to start both web services.
- Added examples of how to use Visual Studio 2022 `.http` file support to test a Web API service.

# Chapter 15 Building User Interface Components Using Blazor

- Replaced the legacy Blazor Server and Blazor WebAssembly projects with a single Blazor Full Stack project.
