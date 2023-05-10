**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 9 - Managing Visual Studio Code extensions at the command line](#page-9---managing-visual-studio-code-extensions-at-the-command-line)
  - [Page 14 - Listing and removing versions of .NET](#page-14---listing-and-removing-versions-of-net)
  - [Page 27 - Writing code using Visual Studio Code](#page-27---writing-code-using-visual-studio-code)
  - [Page 29 - Compiling and running code using the dotnet CLI](#page-29---compiling-and-running-code-using-the-dotnet-cli)
  - [Page 36 - Cloning the book solution code repository](#page-36---cloning-the-book-solution-code-repository)
  - [Page 36 - Getting help for the dotnet tool](#page-36---getting-help-for-the-dotnet-tool)
- [Chapter 2 - Speaking C#](#chapter-2---speaking-c)
  - [Page 51 - How to output the SDK version](#page-51---how-to-output-the-sdk-version)
- [Chapter 3 - Controlling Flow, Converting Types, and Handling Exceptions](#chapter-3---controlling-flow-converting-types-and-handling-exceptions)
  - [Page 176 - Configuring trace listeners](#page-176---configuring-trace-listeners)
  - [Page 178 - Adding packages to a project in Visual Studio Code](#page-178---adding-packages-to-a-project-in-visual-studio-code)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Page 315 - Checking your .NET SDKs for updates](#page-315---checking-your-net-sdks-for-updates)
  - [Page 324 - Creating a .NET Standard 2.0 class library](#page-324---creating-a-net-standard-20-class-library)
  - [Page 325 - Controlling the .NET SDK](#page-325---controlling-the-net-sdk)
  - [Page 328 - Creating new projects](#page-328---creating-new-projects)
  - [Page 330 - Publishing a self-contained app](#page-330---publishing-a-self-contained-app)
  - [Page 332 - Publishing a single-file app](#page-332---publishing-a-single-file-app)
  - [Page 333 - Enabling assembly-level trimming](#page-333---enabling-assembly-level-trimming)
  - [Page 333 - Enabling type-level and member-level trimming](#page-333---enabling-type-level-and-member-level-trimming)
  - [Page 350 - .NET Upgrade Assistant](#page-350---net-upgrade-assistant)
- [Chapter 10 - Working with Data Using Entity Framework Core](#chapter-10---working-with-data-using-entity-framework-core)
  - [Page 440 - Creating the Northwind sample database for SQLite](#page-440---creating-the-northwind-sample-database-for-sqlite)
  - [Page 452 - Setting up the dotnet-ef tool](#page-452---setting-up-the-dotnet-ef-tool)
  - [Page 453 - Scaffolding models using an existing database](#page-453---scaffolding-models-using-an-existing-database)
- [Chapter 11 - Querying and Manipulating Data Using LINQ](#chapter-11---querying-and-manipulating-data-using-linq)
  - [Page 503 - Building an EF Core model](#page-503---building-an-ef-core-model)
- [Chapter 12 - Introducing Web Development Using ASP.NET Core](#chapter-12---introducing-web-development-using-aspnet-core)
  - [Page 540 - Creating a class library for entity models using SQLite](#page-540---creating-a-class-library-for-entity-models-using-sqlite)
  - [Page 549 - Creating a class library for entity models using SQL Server](#page-549---creating-a-class-library-for-entity-models-using-sql-server)
- [Chapter 13 - Building Websites Using ASP.NET Core Razor Pages](#chapter-13---building-websites-using-aspnet-core-razor-pages)
  - [Page 564 - Testing and securing the website](#page-564---testing-and-securing-the-website)
  - [Page 585 - Creating a Razor class library](#page-585---creating-a-razor-class-library)
- [Chapter 14 - Building Websites Using the Model-View-Controller Pattern](#chapter-14---building-websites-using-the-model-view-controller-pattern)
  - [Page 602 - Creating an ASP.NET Core MVC website](#page-602---creating-an-aspnet-core-mvc-website)
  - [Page 604 - Creating the authentication database for SQL Server LocalDB](#page-604---creating-the-authentication-database-for-sql-server-localdb)
- [Chapter 15 - Building and Consuming Web Services](#chapter-15---building-and-consuming-web-services)
  - [Page 695 - Building web services using Minimal APIs](#page-695---building-web-services-using-minimal-apis)
- [Chapter 16 - Building User Interfaces Using Blazor](#chapter-16---building-user-interfaces-using-blazor)
  - [Page 717 - Reviewing the Blazor WebAssembly project template](#page-717---reviewing-the-blazor-webassembly-project-template)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 9 - Managing Visual Studio Code extensions at the command line

```
code --install-extension ms-dotnettools.csharp
```

## Page 14 - Listing and removing versions of .NET

Listing all installed .NET SDKS:
```
dotnet --list-sdks
```

Listing all installed .NET runtimes:
```
dotnet --list-runtimes
```

Details of all .NET installations:
```
dotnet --info
```

Remove all but the latest .NET SDK preview:
```
dotnet-core-uninstall remove --all-previews-but-latest --sdk
```

## Page 27 - Writing code using Visual Studio Code

Creating a new **Console App** project:
```
dotnet new console
```

Creating a new **Console App** project that targets a specified framework version, for example, .NET 6:
```
dotnet new console -f net6.0
```

Creating a new **Console App** project that in a named subfolder:
```
dotnet new console -o HelloCS
```

## Page 29 - Compiling and running code using the dotnet CLI
```
dotnet run
```

## Page 36 - Cloning the book solution code repository

```
git clone https://github.com/markjprice/cs11dotnet7.git
```

## Page 36 - Getting help for the dotnet tool

Getting help for a `dotnet` command like `new`:
```
dotnet help new
```

Getting help for a specified project template, for example, `console`:
```
dotnet new console -h
```

# Chapter 2 - Speaking C#

## Page 51 - How to output the SDK version

```
dotnet --version
```

# Chapter 3 - Controlling Flow, Converting Types, and Handling Exceptions

## Page 176 - Configuring trace listeners

Running a project with its release configuration:
```
dotnet run --configuration Release
```

Running a project with its debug configuration:
```
dotnet run --configuration Debug
```

## Page 178 - Adding packages to a project in Visual Studio Code

Adding the `Microsoft.Extensions.Configuration.Binder` package:
```
dotnet add package Microsoft.Extensions.Configuration.Binder
```

Adding the `Microsoft.Extensions.Configuration.Json` package:
```
dotnet add package Microsoft.Extensions.Configuration.Json
```

> Note: You do not need to add the other two packages because they are transitive depedencies and so will be implicitly referenced.

# Chapter 7 - Packaging and Distributing .NET Types

## Page 315 - Checking your .NET SDKs for updates

```
dotnet sdk check
```

## Page 324 - Creating a .NET Standard 2.0 class library

```
dotnet new classlib -f netstandard2.0
```

## Page 325 - Controlling the .NET SDK

Creating a `global.json` file to control to default .NET SDK for projects created in the current folder and its descendents:
```
dotnet new globaljson --sdk-version 6.0.404
```

## Page 328 - Creating new projects

Listing available project templates using .NET 7:
```
dotnet new list
```

Listing available project templates using .NET 6:
```
dotnet new --list
```

Listing available project templates using .NET 6 short form:
```
dotnet new -l
```

## Page 330 - Publishing a self-contained app

Build and publish the release version for Windows:
```
dotnet publish -c Release -r win10-x64 --self-contained
```
Build and publish the release version for macOS on Intel:
```
dotnet publish -c Release -r  osx-x64 --self-contained
```

Build and publish the release version for macOS on Apple Silicon:
```
dotnet publish -c Release -r osx.11.0-arm64 --self-contained
```

Build and publish the release version for Linux on Intel:
```
dotnet publish -c Release -r linux-x64 --self-contained
```

Build and publish the release version for Linus on ARM64:
```
dotnet publish -c Release -r linux-arm64 --self-contained
```

## Page 332 - Publishing a single-file app

```
dotnet publish -c Release -r win10-x64 --no-self-contained /p:PublishSingleFile=true
```

```
dotnet publish -c Release -r win10-x64 --self-contained /p:PublishSingleFile=true
```

## Page 333 - Enabling assembly-level trimming

```
dotnet publish -c Release -r win10-x64 --self-contained /p:PublishSingleFile=true -p:PublishTrimmed=True
```

## Page 333 - Enabling type-level and member-level trimming

```
dotnet publish -c Release -r win10-x64 --self-contained /p:PublishSingleFile=true -p:PublishTrimmed=True -p:TrimMode=Link
```

## Page 350 - .NET Upgrade Assistant

Installing the .NET Upgrade Assistant:
```
dotnet tool install -g upgrade-assistant
```

# Chapter 10 - Working with Data Using Entity Framework Core

## Page 440 - Creating the Northwind sample database for SQLite

Creating the Northwind SQLite database:
```
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

## Page 452 - Setting up the dotnet-ef tool

Listing installed `dotnet` global tools:
```
dotnet tool list --global
```

Uninstalling an older `dotnet-ef` tool:
```
dotnet tool uninstall --global dotnet-ef
```

Installing the latest `dotnet-ef` as a global tool:
```
dotnet tool install --global dotnet-ef
```

## Page 453 - Scaffolding models using an existing database

```
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context Northwind
```

Note the following:
- The command action: `dbcontext scaffold`
- The connection string: `"Filename=Northwind.db"`
- The database provider: `Microsoft.EntityFrameworkCore.Sqlite`
- The tables to generate models for: `--table Categories --table Products`
- The output folder: `--output-dir AutoGenModels`
- The namespace: `--namespace WorkingWithEFCore.AutoGen`
- To use data annotations as well as the Fluent API: `--data-annotations`
- To rename the context from [database_name]Context: `--context Northwind`

# Chapter 11 - Querying and Manipulating Data Using LINQ

## Page 503 - Building an EF Core model

Creating the Northwind SQLite database:
```
sqlite3 Northwind.db -init Northwind4Sqlite.sql
```

# Chapter 12 - Introducing Web Development Using ASP.NET Core

## Page 540 - Creating a class library for entity models using SQLite

Creating the Northwind SQLite database:
```
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

Creating the EF Core model for the Northwind database:
```
dotnet ef dbcontext scaffold "Filename=../Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --namespace Packt.Shared --data-annotations
```

## Page 549 - Creating a class library for entity models using SQL Server

Creating the EF Core model for the Northwind database:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --namespace Packt.Shared --data-annotations
```

> If you do not have a "full" edition of SQL Server installed with a default instance then you will need to changed the `.` to the correct `servername\instancename`.

# Chapter 13 - Building Websites Using ASP.NET Core Razor Pages

## Page 564 - Testing and securing the website

Starting an ASP.NET Core project and specifying the `https` profile:
```
dotnet run --launch-profile https
```

## Page 585 - Creating a Razor class library

```
dotnet new razorclasslib --support-pages-and-views
```

# Chapter 14 - Building Websites Using the Model-View-Controller Pattern

## Page 602 - Creating an ASP.NET Core MVC website

Showing all the options for an ASP.NET Core MVC project:
```
dotnet new mvc --help
```

## Page 604 - Creating the authentication database for SQL Server LocalDB

```
dotnet ef database update
```

# Chapter 15 - Building and Consuming Web Services

## Page 695 - Building web services using Minimal APIs

Creating a Web API project using Minimal APIs:
```
dotnet new webapi --use-minimal-apis
```

Creating a Web API project using Minimal APIs short form:
```
dotnet new webapi -minimal
```

# Chapter 16 - Building User Interfaces Using Blazor

## Page 717 - Reviewing the Blazor WebAssembly project template

Creating a Blazor WASM project that supports Progressive Web App capabilities and is hosted in an ASP.NET Core website project:
```
dotnet new blazorwasm --pwa --hosted
```

