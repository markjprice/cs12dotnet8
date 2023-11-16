**What's New in the 8th Edition**

There are hundreds of minor fixes and improvements throughout the 8th edition; too many to list individually. All [errata and improvements for the 7th edition](https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/README.md) have been made to the 8th edition. The main new sections in *C# 12 and .NET 8 - Modern Cross-Platform Development*, 8th edition compared to the previous edition are shown below.

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

- Added a section about the structure and style of this book, including the topics covered in the book and its companion book, *Apps and Services with .NET 8*.
- Removed mentions of Visual Studio 2022 for Mac and added a note that it reaches end-of-life in August 2024.
- Added a warning about JetBrains Rider giving errors like `Cannot resolve symbol` and boxing warnings.
- Noted the change in name for Polyglot Notebooks and moved the step-by-step instructions to an [online page](ch01-polyglot-notebooks.md) because most readers don't use it.
- Added information about C# Dev Kit including its license agreement.
- When installing Visual Studio 2022, added a step to install **Desktop development with C++** because its tools are required for native AOT compilation.
- Moved the section about .NET history to an [online page](ch01-dotnet-history.md) because at this point the history is less important and more readers already know it.
- Added an explanation about .NET support phases, for example, active, go-live, maintenance, and so on.
- Added a note and link to the [Command-Lines](command-lines.md) page.
- Added links to [pages online](code-editors/README.md) that replicate the step-by-step instructions for working with code editors including Visual Studio 2022 for Windows, Visual Studio 2022 for Mac, Visual Studio Code, and JetBrains Rider.
- Added a note with link to an [online page](ch01-project-options.md) that shows all the options in various code editors when creating a new project.
- Added a note explaining how to start a project without attaching the debugger and why that's good practice.
- Added a section explaining how to show the name of the namespace which is `null` for a top-level console app. This helps readers understand why it is important not to define a namespace if they extend the `Program` class with extra methods later in the book.
- Modified how the two projects are created: second one selecting the **Do not use top-level statements** check box or adding the `--use-program-main` switch.
- When adding the second project, added a note about **File** | **New** | **Project** versus **File** | **Add** | **New Project**.
- Added a note about why I recommend configuring the startup project to be the current selection.
- Updated the step-by-step instructions for Visual Studio Code to create a solution file, add projects to a solution, and open its folder with C# Dev Kit. I also add a summary of these steps for reference later.
- Added a summary of all the project types that will be created throughout the book, including the project template names used by Visual Studio 2022, JetBrains Rider, and the `dotnet new` command. This is designed to avoid confusion in later chapters when some readers don't know how to create a new project that is not a console app.
- Added a note recommending that all readers review the [errata section](errata/README.md) online before attempting any coding tasks.
- Updated the note about solution code in the GitHub repository becase now all code editors can open the same solutions/folders.
- Added a section about avoiding [common mistakes](errata/common-mistakes.md).
- Added a section about how documentation links work on Microsoft Learn, includng how to request a specific version of .NET and to list the versions of .NET that an API applies to.
- Added a warning that there is a bug with the `dotnet help` command when asking for help about `new`.
- Added a note about the difference between **Go To Definition** and **Go To Implementation** with Visual Studio 2022, and how to toggle **Enable navigation to Source Link and Embedded sources** to control the behavior.
- Added a section about how to configure inline aka inlay hints in the three common code editors.
- Added a section about searching the .NET source code.
- Added a section about AI tools like ChatGPT and GitHub Copilot.
- Added a section about how to disable tools when they get in the way.
- Added exercises about C# certification and using alpha versions of .NET.

# Chapter 2 Speaking C#

- Moved the C# language version and feature tables to an [online page](ch02-features.md).
- Added a section about how to enable preview versions of C# 13 with .NET 9 and future versions of C# that still target .NET 8 for long-term support.
- Added a section about defining collapsable regions in code.
- Added a section about formatting code using white space.
- Explain the `private field _` prefix convention.
- Extended the coding task about global usings to show examples of aliasing types like `Environment`.
- Added a section about asking ChatGPT to explain code using the reflection coding task about listing types and their members.
- Added a note about `nameof` in C# 12 that can now access instance data from a static context.
- Added a section about literal values to formally define what they are instead of only showing examples.
- Added an extended example using raw string literals to show indenting.
- Added an extended example for numbers to output values using format codes.
- Extended the example comparing `double` to `decimal` to also cover `float`.
- Added a section about new number types and their sizes, including `System.Half`, `System.Int128` and `System.UInt128`, including why you need to allow `unsafe` code.
- Added a section about displaying output to the user and the difference between the `WriteLine` and `Write` methods.
- Added a section about custom number format strings: add tables of standard and custom format codes especially for numbers and date/time values.
- Added a step to show how arguments in Visual Studio 2022 are stored in the `launchSettings.json` file and it can also be used by JetBrains Rider.
- Explain how to disable the implicitly imported namespaces feature if you want to manually create a global using file so there is only one place other developers need to go to see what's imported.
- Added the new number types to *Exercise 2.3*.
- Added a new exercise 2.5 to explore Spectre.

# Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions

- Added a section about the conditional `?:` operator with example code.
- Added a note to show how to search the .NET source code to see how often the .NET team uses `goto` even though it's generally considered bad practice.
- Added a section about how adding a new item to a project using Visual Studio 2022 has been simplified in recent versions by using **Show Compact View**.
- In the `SelectionStatements` project, explain that the step to add a class named `Animals.cs` is VS2022-specific.
- Added a note about the discard character `_`.
- Updated the figure visualizing jagged arrays to make it clearer.
- Added a section linking to inline arrays in C# 12 but explaining that they are too advanced for this book.
- Added a section about how negative numbers are represented in binary.
- In the parsing section, use globalization to explicitly set the current culture so that all readers have the same experience, US English.
- Added a section about understanding the `Try` method naming convention.

# Chapter 4 Writing, Debugging, and Testing Functions

- Added a warning about the auto-generated namespace issue for `partial Program`.
- Explain that there should be no namespace in `Program.Helpers.cs` and how to show the namespace name.
- Added a `ConfigureConsole` method to control the current culture and provide the reader with a consistent experience when formatting date/time and currency values.
- Changed the `CardinalToOrdinal` function to use `uint` since the parameter should never be negative.
- Changed to use `ArgumentOutOfRangeException` for the `Factorial` function instead of a generic exception.
- Added a section about how to use the Visual Studio Code integrated terminal during debugging.
- Understanding logging options: added a **Good Practice** about asking about logging in interview to show that you know its different for enterprises and its importance.
- Added a **Good Practice** about adding `Trace.AutoFlush = true;` only during development so we don't lose performance in release/production.
- Changed the coding task to only reference the minimum two packages needed since the others are dependencies they will be included anyway.
- Added a note to warn about the [issue](https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/errata.md#page-178---reviewing-project-packages) with .NET 7 when the .NET team fixed a bug in a later package version that changed behavior and caused an exception. This is an example of a *bug regression*.
- Changed the code to output the configuration file contents to make it easuer to spot if there is an issue with it, for example, if it is not found.
- Added more explicit step-by-step instructions when creating the class library since this is the first time the reader will add a project that is not a console app.
- When running the unit tests, show the C# Dev Kit user interface.
- Added a section about throwing exceptions using guard clauses, including the new ones introduced with .NET 8.
- Add an exercise to suggest that readers review the **C# 101 .NET Interactive** notebook.

# Chapter 5 Building Your Own Types with Object-Oriented Programming

- Expanded on the descriptions of OOP concepts like abstraction since readers of previous editions were sometimes confused.
- Added a paragraph about the `file` access modifier introduced with .NET 7.
- Added a `ConfigureConsole` method to control the current culture and provide the reader with a consistent experience when formatting date/time and currency values.
- Added a section about renaming a type with a `using` alias.
- Changed the property named `DateOfBirth` to `Born` because it is not just a date, it also includes a time.
- Moved `required` section to the constructors section because it is about initializing fields and properties.
- Added a section about mixing optional and required parameters.
- In the section about controlling how parameters are passed, I added an example of `in` as well as `ref` and `out`.
- Added a section about aliasing tuples.
- In the section about splitting classes using `partial`, I added a step to build the project first to make sure the reader has applied the `partial` keyword to both classes before continuing otherwise some readers don't understand the compiler error that they see later.
- Added a section about limiting flags `enum` values by adding validation code in a property setter.
- Added a section about equality of `record` types because it is more important than the optional immutability of records.
- Added a section about defining a primary constructor for a `class` and how it does not do as much as primary constructors in `record` types.
- Added *Exercise 5.2 – Practice with access modifiers*.

# Chapter 6 Implementing Interfaces and Inheriting Classes

- Rewrote the code task for methods and operators to fix some issues and added more explanation of design decisions in how the example is implemented.
- Added a section about understanding boxing and how to avoid it.
- Added a section about disabling `null` and other compiler warnings.
- Added a section about understanding the `this` and `base` keywords and when to use them.
- Added a section about choosing between an `interface` and an `abstract class` when implementing the concept of abstraction.
- Rewrote and expanded the sections about class features especially important differences between the *concept of abstraction* and the `abstract` keyword.
- Added a section about mutability and records, including code to show the different ways that you can define a type and the effect that has on its mutability.
- Moved the *Writing better code* section to an [online page](ch06-writing-better-code.md) in *Exercise 6.3*.

# Chapter 7 Packaging and Distributing .NET Types

- Moved the .NET versions and features tables to an [online page](ch07-features.md).
- Added a section about mixing SDKs and framework targets, including how to use previews of .NET 9 and .NET 10 when they become available in February 2024 and February 2025 respectively.
- Added a section about controlling where build artifacts are created using a `Directory.Build.props` file.
- Added a section about native ahead-of-time (AOT) compilation with a code task to show how it works, including the limitations and requirements.
- Added a section about viewing source links with Visual Studio 2022.
- Added a step to include a `readme.md` file when publishing a package to NuGet.org which is a recent requirement.
- Added a link for those readers who need to know how to publish a package to a private NuGet feed.
- Briefly mention method interceptors.
- Moved two sections online: [*Exercise 7.3 – Porting from .NET Framework to modern .NET*](ch07-porting.md) and [*Exercise 7.4 – Creating source generators*](ch07-source-generators.md).
- Added an exercise to learn about performance improvements by reading all the blog posts written by Stephen Toub.

# Chapter 8 Working with Common .NET Types

- Fixed the output for complex numbers.
- Added a coding task to show the two new `Random` methods `GetItems<T>` and `Shuffle<T>` introduced with .NET 8.
- Added a section about generating GUIDs.
- Added a section about comparing string values, including ignoring case.
- Added a section about collection add and remove methods, with a table to compare them.
- Added a section about read-only, immutable, and the new frozen collections, with coding task to compare their functionality.
- Added a section about initializing collections using collection expressions.
- Moved the section about network resources to an [online page](ch08-network-resources.md) as *Exercise 8.4*.

# Chapter 9 Working with Files, Streams, and Serialization

- Added the `Spectre.Console` package to use its tables for output.
- Added a note about the `Path.Exists` method that was added in .NET 7. It is not available in earlier versions of .NET.
- Added a new 5-page section titled *Working with environment variables*. This shows methods on the `Environment` class and is useful to prepare readers for loading secret values like user names and passwords from environment variables instead of hard-coding them in source code.

# Chapter 10 Working with Data Using Entity Framework Core

- Updated the connection string for SQLite to explain that `Filename` means the same as `Data Source` and to use the modern one.
- Added a note about updating as well as installing the EF Core tools: `dotnet tool update --global dotnet-ef`
- Added a new section about tracking including the `AsNoTracking()` method that often gets LinkedIn posts that are overly simplistic.

# Chapter 11 Querying and Manipulating Data Using LINQ

- Added a new section titled **Grouping for lookups**. It covers the `ToLookup` method that I later use in a solution to an exercise. Errata item: https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/improvements.md#page-512---group-joining-sequences

# Chapter 12 Introducing Web Development Using ASP.NET Core

- Moved the ASP.NET Core versions and features tables to an [online page](ch12-features.md).
- Added a table to list all the ports for all projects and make them all different based on the chapter number. Note: just before publishing, we moved the MVC chapter online instead of being Chapter 14. The instructions still use port numbers based on chapter number 14.
- Added an explanation of **Build Action** and `.csproj` entries with an explanation of the `<ItemGroup><Content>` and `<Remove>` entries.
- Added a diagram explaining difference between Razor Pages and Razor views.
- I added code to use `Path.GetFullPath(path)` in the `DbContext` configuration and to output the path to logs.
- Fixed the `CanConnect` unit test with wrong/missing file creates a `Northwind.db` with 0 bytes! The code now checks if the file exists and throws an exception if it does not.
- I now use use `SqlConnectionStringBuilder` in `NorthwindContext` in the online-only SQL Server instructions because it is a safer way to create connection strings.

# Chapter 13 Building Websites Using ASP.NET Core Razor Pages

- Added a summary of middleware order: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/#middleware-order.
- The previous *Chapter 14 - Building Websites Using the Model-View-Controller Pattern* becomes an [online section](aspnetcoremvc.md).
- MVC: Switched the auto-registration code for the Admin user account to use `admin@example.com` instead of `test@example.com`.
- MVC: Added a diagram to illustrate the different types of caching.
- MVC: Added a table for the new validation attributes and the existing ones, for example, `Range[min and mix]`.

# Chapter 14 Building and Consuming Web Services

- Added `307` to the table of status codes.
- Added instructions to start both web services.
- Added examples of how to use Visual Studio 2022 `.http` file support to test a Web API service.

# Chapter 15 Building User Interface Components Using Blazor

- Replaced the legacy Blazor Server and Blazor WebAssembly projects with a single Blazor Full Stack project.
