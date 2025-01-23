**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

> Note: Page numbers will be updated once the final print files are made available to me in November 2023.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 11 - Managing Visual Studio Code extensions at the command prompt](#page-11---managing-visual-studio-code-extensions-at-the-command-prompt)
  - [Page 15 - Listing and removing versions of .NET](#page-15---listing-and-removing-versions-of-net)
  - [Page 21 - Understanding top-level programs](#page-21---understanding-top-level-programs)
  - [Page 27 - Writing code using Visual Studio Code](#page-27---writing-code-using-visual-studio-code)
  - [Page 30 - Compiling and running code using the dotnet CLI](#page-30---compiling-and-running-code-using-the-dotnet-cli)
  - [Page 31 - Adding a second project using Visual Studio Code](#page-31---adding-a-second-project-using-visual-studio-code)
  - [Page 37 - Cloning the book solution code repository](#page-37---cloning-the-book-solution-code-repository)
  - [Page 38 - Getting help for the dotnet tool](#page-38---getting-help-for-the-dotnet-tool)
- [Chapter 2 - Speaking C#](#chapter-2---speaking-c)
  - [Page 55 - How to output the SDK version](#page-55---how-to-output-the-sdk-version)
  - [Page 95 - Exploring more about console apps](#page-95---exploring-more-about-console-apps)
  - [Page 106 - Passing arguments to a console app](#page-106---passing-arguments-to-a-console-app)
- [Chapter 4 - Writing, Debugging, and Testing Functions](#chapter-4---writing-debugging-and-testing-functions)
  - [Page 201 - Hot reloading using Visual Studio Code and dotnet watch](#page-201---hot-reloading-using-visual-studio-code-and-dotnet-watch)
  - [Page 205 - Configuring trace listeners](#page-205---configuring-trace-listeners)
  - [Page 207 - Adding packages to a project in Visual Studio Code](#page-207---adding-packages-to-a-project-in-visual-studio-code)
  - [Page 216 - Creating a class library that needs testing](#page-216---creating-a-class-library-that-needs-testing)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Page 369 - Checking your .NET SDKs for updates](#page-369---checking-your-net-sdks-for-updates)
  - [Page 378 - Creating a .NET Standard 2.0 class library](#page-378---creating-a-net-standard-20-class-library)
- [Page 379 - Controlling the .NET SDK](#page-379---controlling-the-net-sdk)
  - [Page 384 - Understanding dotnet commands](#page-384---understanding-dotnet-commands)
  - [Page 385 - Getting information about .NET and its environment](#page-385---getting-information-about-net-and-its-environment)
  - [Page 386 - Publishing a self-contained app](#page-386---publishing-a-self-contained-app)
  - [Page 388 - Publishing a single-file app](#page-388---publishing-a-single-file-app)
  - [Page 390 - Enabling assembly-level trimming](#page-390---enabling-assembly-level-trimming)
  - [Page 390 - Enabling type-level and member-level trimming](#page-390---enabling-type-level-and-member-level-trimming)
  - [Page 395 - Publishing a native AOT project](#page-395---publishing-a-native-aot-project)
- [Chapter 9 - Working with Files, Streams, and Serialization](#chapter-9---working-with-files-streams-and-serialization)
  - [Page 508 - Expanding, setting, and getting an environment variables](#page-508---expanding-setting-and-getting-an-environment-variables)
- [Chapter 10 - Working with Data Using Entity Framework Core](#chapter-10---working-with-data-using-entity-framework-core)
  - [Page 518 - Setting up SQLite for macOS and Linux](#page-518---setting-up-sqlite-for-macos-and-linux)
  - [Page 519 - Creating the Northwind sample database for SQLite](#page-519---creating-the-northwind-sample-database-for-sqlite)
  - [Page 534 - Setting up the dotnet-ef tool](#page-534---setting-up-the-dotnet-ef-tool)
  - [Page 536 - Scaffolding models using an existing database](#page-536---scaffolding-models-using-an-existing-database)
- [Chapter 11 - Querying and Manipulating Data Using LINQ](#chapter-11---querying-and-manipulating-data-using-linq)
  - [Page 598 - Creating a console app for exploring LINQ to Entities](#page-598---creating-a-console-app-for-exploring-linq-to-entities)
- [Chapter 12 - Introducing Web Development Using ASP.NET Core](#chapter-12---introducing-web-development-using-aspnet-core)
  - [Page 635 - Creating a class library for entity models using SQLite](#page-635---creating-a-class-library-for-entity-models-using-sqlite)
- [Chapter 13 - Building Websites Using ASP.NET Core Razor Pages](#chapter-13---building-websites-using-aspnet-core-razor-pages)
  - [Page 660 - Testing and securing the website](#page-660---testing-and-securing-the-website)
  - [Page 675 - Using code-behind files with Razor Pages](#page-675---using-code-behind-files-with-razor-pages)
- [Chapter 14 - Building and Consuming Web Services](#chapter-14---building-and-consuming-web-services)
- [Chapter 15 - Building User Interfaces Using Blazor](#chapter-15---building-user-interfaces-using-blazor)
  - [Page 749 - Creating a Blazor Web App project](#page-749---creating-a-blazor-web-app-project)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 11 - Managing Visual Studio Code extensions at the command prompt

```shell
code --install-extension ms-dotnettools.csdevkit
```

## Page 15 - Listing and removing versions of .NET

Listing all installed .NET SDKS:
```shell
dotnet --list-sdks
```

Listing all installed .NET runtimes:
```shell
dotnet --list-runtimes
```

Details of all .NET installations:
```shell
dotnet --info
```

## Page 21 - Understanding top-level programs

If you are using the dotnet CLI at the command prompt, add a switch to generate a console app project using the legacy `Program` class with a `Main` method:
```shell
dotnet new console --use-program-main
```

## Page 27 - Writing code using Visual Studio Code

Using the dotnet CLI to create a new solution named `Chapter01`:
```shell
dotnet new sln --name Chapter01
```

Creating a new **Console App** project in a folder named `HelloCS` with a project file named `HelloCS.csproj`:
```shell
dotnet new console --output HelloCS
```

Adding a named project to the solution file:
```shell
dotnet sln add HelloCS
```

Opening Visual Studio Code in the current folder:
```shell
code .
```

Creating a new **Console App** project named `HelloCS` that targets a specified framework version, for example, .NET 6:
```shell
dotnet new console -f net6.0 -o HelloCS
```

## Page 30 - Compiling and running code using the dotnet CLI
```shell
dotnet run
```

## Page 31 - Adding a second project using Visual Studio Code

Creating a project named `AboutMyEnvironment` using the legacy `Program` class with a `Main` method:
```shell
dotnet new console -o AboutMyEnvironment --use-program-main
```

## Page 37 - Cloning the book solution code repository

```shell
git clone https://github.com/markjprice/cs12dotnet8.git
```

## Page 38 - Getting help for the dotnet tool

Getting help for a `dotnet` command like `build` from the documentation web page:
```shell
dotnet help build
```

Getting help for a `dotnet` command like `build` at the command prompt:
```shell
dotnet build -?
```

Getting help for a specified project template, for example, `console`:
```shell
dotnet new console -?
```

# Chapter 2 - Speaking C#

## Page 55 - How to output the SDK version

Output the current version of the .NET SDK:
```shell
dotnet --version
```

## Page 95 - Exploring more about console apps

Example of a command line with multiple arguments:
```shell
dotnet new console -lang "F#" --name "ExploringConsole"
```

## Page 106 - Passing arguments to a console app

Passing four arguments when running your project:
```shell
dotnet run firstarg second-arg third:arg "fourth arg"
```

Setting options using arguments:
```shell
dotnet run red yellow 50
```

# Chapter 4 - Writing, Debugging, and Testing Functions

## Page 201 - Hot reloading using Visual Studio Code and dotnet watch

Starting a project using Hot Reload:
```shell
dotnet watch
```

## Page 205 - Configuring trace listeners

Running a project with its release configuration:
```shell
dotnet run --configuration Release
```

Running a project with its debug configuration:
```shell
dotnet run --configuration Debug
```

## Page 207 - Adding packages to a project in Visual Studio Code

Adding the `Microsoft.Extensions.Configuration.Binder` package:
```shell
dotnet add package Microsoft.Extensions.Configuration.Binder
```

Adding the `Microsoft.Extensions.Configuration.Json` package:
```shell
dotnet add package Microsoft.Extensions.Configuration.Json
```

## Page 216 - Creating a class library that needs testing

Creating a class library project and adding it to the solution file:
```shell
dotnet new classlib -o CalculatorLib
```
```shell
dotnet sln add CalculatorLib
```

Creating an XUnit text project and adding it to the solution file:
```shell
dotnet new xunit -o CalculatorLibUnitTests
```
```shell
dotnet sln add CalculatorLibUnitTests
```

Running a unit test project:
```shell
dotnet test
```

# Chapter 7 - Packaging and Distributing .NET Types

## Page 369 - Checking your .NET SDKs for updates

Listing the installed .NET SDKs with a column to indicate if it has a newer version that can be upgraded to:
```shell
dotnet sdk check
```

## Page 378 - Creating a .NET Standard 2.0 class library

Creating a new class library project that targets .NET Standard 2.0:
```shell
dotnet new classlib -f netstandard2.0
```

# Page 379 - Controlling the .NET SDK

Listing the installed .NET SDKs:
```shell
dotnet --list-sdks
```

Creating a `global.json` file to control to default .NET SDK for projects created in the current folder and its descendents:
```shell
dotnet new globaljson --sdk-version 6.0.320
```

## Page 384 - Understanding dotnet commands

Listing available project templates using .NET 7 or later:
```shell
dotnet new list
```

Listing available project templates using .NET 6 or earlier:
```shell
dotnet new --list
```

Listing available project templates using .NET 6 or earlier (short form):
```shell
dotnet new -l
```

## Page 385 - Getting information about .NET and its environment

Getting detailed information about installed .NET runtimes, SDKs, and workloads:
```shell
dotnet --info
```

## Page 386 - Publishing a self-contained app

Build and publish the release version for Windows:
```shell
dotnet publish -c Release -r win-x64 --self-contained
```

Build and publish the release version for macOS on Intel:
```shell
dotnet publish -c Release -r osx-x64 --self-contained
```

Build and publish the release version for macOS on Apple Silicon:
```shell
dotnet publish -c Release -r osx-arm64 --self-contained
```

Build and publish the release version for Linux on Intel:
```shell
dotnet publish -c Release -r linux-x64 --self-contained
```

Build and publish the release version for Linus on ARM64:
```shell
dotnet publish -c Release -r linux-arm64 --self-contained
```

## Page 388 - Publishing a single-file app

```shell
dotnet publish -c Release -r win-x64 --no-self-contained /p:PublishSingleFile=true
```

```shell
dotnet publish -c Release -r win-x64 --self-contained /p:PublishSingleFile=true
```

## Page 390 - Enabling assembly-level trimming

```shell
dotnet publish -c Release -r win-x64 --self-contained /p:PublishSingleFile=true -p:PublishTrimmed=True
```

## Page 390 - Enabling type-level and member-level trimming

```shell
dotnet publish -c Release -r win-x64 --self-contained /p:PublishSingleFile=true -p:PublishTrimmed=True -p:TrimMode=Link
```

## Page 395 - Publishing a native AOT project

```shell
dotnet publish
```

# Chapter 9 - Working with Files, Streams, and Serialization

## Page 508 - Expanding, setting, and getting an environment variables

To temporarily set an environment variable at the command prompt or terminal on macOS or Linux,
you can use the `export` command:
```shell
export MY_ENV_VAR=Delta
```

To set some environment variables at the user and machine scope levels on Windows:
```shell
setx MY_SECRET "Beta"
```
```shell
setx MY_SECRET "Gamma" /M
```

# Chapter 10 - Working with Data Using Entity Framework Core

## Page 518 - Setting up SQLite for macOS and Linux

On Linux, you can get set up with SQLite using the following command:
```shell
sudo apt-get install sqlite3
```

## Page 519 - Creating the Northwind sample database for SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

## Page 534 - Setting up the dotnet-ef tool

Listing installed `dotnet` global tools:
```shell
dotnet tool list --global
```

Updating an older `dotnet-ef` tool:
```shell
dotnet tool update --global dotnet-ef
```

Installing the latest `dotnet-ef` as a global tool:
```shell
dotnet tool install --global dotnet-ef
```

Uninstalling an older `dotnet-ef` tool:
```shell
dotnet tool uninstall --global dotnet-ef
```

## Page 536 - Scaffolding models using an existing database

```shell
dotnet ef dbcontext scaffold "Data Source=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context NorthwindDb
```

Note the following:
- The command action: `dbcontext scaffold`
- The connection string: `"Data Source=Northwind.db"`
- The database provider: `Microsoft.EntityFrameworkCore.Sqlite`
- The tables to generate models for: `--table Categories --table Products`
- The output folder: `--output-dir AutoGenModels`
- The namespace: `--namespace WorkingWithEFCore.AutoGen`
- To use data annotations as well as the Fluent API: `--data-annotations`
- To rename the context from [database_name]Context: `--context NorthwindDb`

# Chapter 11 - Querying and Manipulating Data Using LINQ

## Page 598 - Creating a console app for exploring LINQ to Entities

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4Sqlite.sql
```

# Chapter 12 - Introducing Web Development Using ASP.NET Core

## Page 635 - Creating a class library for entity models using SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

Creating the EF Core model for the Northwind database:
```shell
dotnet ef dbcontext scaffold "Data Source=../Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --namespace Northwind.EntityModels --data-annotations
```

# Chapter 13 - Building Websites Using ASP.NET Core Razor Pages

## Page 660 - Testing and securing the website

Starting an ASP.NET Core project and specifying the `https` profile:
```shell
dotnet run --launch-profile https
```

## Page 675 - Using code-behind files with Razor Pages

Creating a Razor Page named `Suppliers.cshtml` with a code-behind file:
```shell
dotnet new page -n Suppliers --namespace Northwind.Web.Page
```

# Chapter 14 - Building and Consuming Web Services

Creating a Web API project using controllers:
```shell
dotnet new webapi --use-controllers -o Northwind.WebApi
```

Creating a Web API project using controllers (short form):
```shell
dotnet new webapi -controllers -o Northwind.WebApi
```

Creating a Web API project using Minimal APIs:
```shell
dotnet new webapi --use-minimal-api -o Northwind.WebApi
```

Creating a Web API project using Minimal APIs (short form):
```shell
dotnet new webapi -minimal -o Northwind.WebApi
```

# Chapter 15 - Building User Interfaces Using Blazor

## Page 749 - Creating a Blazor Web App project

Creating a new project using the Blazor Web App template with no server-side or client-side interactivity enabled by default:
```shell
dotnet new blazor --interactivity None -o Northwind.Blazor
```
