**What's New in the 8th Edition**

There are hundreds of minor fixes and improvements throughout the 8th edition; too many to list individually. All errata and improvements listed [here](https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/README.md) have been made to the 8th edition. 

The main new sections in C# 12 and .NET 8, 8th edition compared to C# 11 and .NET 7, 7th edition are shown below.



# Chapter 1 Hello C#, Welcome .NET!

- Note about the **Command-Lines** page in GitHub.
- Explain "Support phase" e.g. active, go-live, maintenance.
- Two projects: one using `--use-program-main` (https://github.com/markjprice/cs10dotnet6/blob/main/docs/errata/errata.md#page-18-19---writing-code-using-visual-studio-2022); when adding second project, add note about File > New > Project vs File > Add > New Project; Add New Item (short view).
- https://spectreconsole.net/best-practices, 
- Set up console and terminal to support unicode and statically import System.Text.Encoding so you can see Euro symbol.
- Note about how to clean up VSCode: https://code.visualstudio.com/docs/setup/setup-overview#_how-can-i-do-a-clean-uninstall-of-vs-code
- Common principles e.g. https://en.wikipedia.org/wiki/You_aren%27t_gonna_need_it
- Explain about code in GitHub and please do not make PRs.
- Replace PS repo link with https://learn.microsoft.com/en-us/powershell/
- Add section about code snippets.
- Moved all text about notebooks to an optional exercise.
- Created a custom `dotnet new packt-console` project template and link to its GitHub repository and NuGet package.

# Chapter 2 Speaking C#

- Understanding format strings: add table of custom format codes especially date time; 
- Explain `private field _` prefix convention.
- Explain that there should be no namespace in `Program.Helpers.cs` and how to show the namespace name.
- "disable the implicitly imported namespaces feature" do this if you want to manually create a global using file so there is only one place other developers need to go to see what's imported.

# Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions

- Explain the conditional `?:` operator.
- In the `SelectionStatements` project, explain that the step to add a class named `Animals.cs` is VS2022-specific.
- Moved exercise 3.5 to 3.3.

# Chapter 4 Writing, Debugging, and Testing Functions

- `ArgumentOutOfRange` exception for Fibonacci.
- Understanding logging options: add bit about asking about logging in interview to show that you know its different for enterprises and its important; 
- in Note box but not code, suggest adding if (Dev-mode) `Trace.AutoFlush = true;` so we don't lose performance.
- add Stress testing and QA testing; 
- Warn about the auto-generated namespace issue for `partial Program`.
- How to make a test dependent on another test and how to run pre-run initializations.
- Move functional programming to GitHub.

# Chapter 5 Building Your Own Types with Object-Oriented Programming

- "It might help to have a non-optional parameter in this method to compare."
- Changed the property named `DateOfBirth` to `Born`.
- init => field.Trim()
- Moved `required` to the constructors section because it is about initializing.
- Explain file-scope: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/file

# Chapter 6 Implementing Interfaces and Inheriting Classes

- C# 101 .NET Interactive notebook to review - extend some examples with suggested tasks.
- Explain pointers and `unsafe` keyword in an optional online section.

# Chapter 7 Packaging and Distributing .NET Types

- Explain `dotnet new gitignore`.
- Explain Native AOT: https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/
- Removed Ex7.3

# Chapter 8 Working with Common .NET Types

- Generic math https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/; 
- static abstract and INumber<T>; 
- explain the comma-separator regex; 
- working with ISet, HashSet<T>; 
- String comparison example; 
- using System.Runtime.InteropServices; RuntimeInformation.FrameworkDescription; 
- Immutable vs Frozen collections;

# Chapter 9 Working with Files, Streams, and Serialization

- `using` best practice https://github.com/markjprice/cs10dotnet6/issues/90; 
- JSON polymorphism https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#polymorphism; 
- ReadExactly, ReadAtLeast https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/#readexactly-and-readatleast; 
- custom ShouldSerialize: https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#conditional-serialization-of-properties; 
- enum UnixFileMode; 

# Chapter 10 Working with Data Using Entity Framework Core

- Performance improvements (bulk is SQL only): https://devblogs.microsoft.com/dotnet/announcing-ef7-preview6/; 
- SQL health check package; https://devblogs.microsoft.com/dotnet/announcing-entity-framework-7-preview-4/#domain-driven-design-and-guarded-keys; 
- AsNoTracking(); 
- Connection string for SQLite: `Filename` means same as `Data Source`.

# Chapter 11 Querying and Manipulating Data Using LINQ

- Reader asked, "why order when paging?" give example, and the team literally has a good example: https://devblogs.microsoft.com/dotnet/announcing-ef7-preview7/#linq-expression-tree-interception; but I only cover details in B18857.

# Chapter 12 Introducing Web Development Using ASP.NET Core

- list the ports for all projects and make them all different; 
- Build Action and .csproj entries: https://learn.microsoft.com/en-us/visualstudio/ide/build-actions; 
- diagram explaining difference between Razor Pages and Razor views; 
- dotnet tool update --global dotnet-ef; 
- use Path.GetFullPath(path) in DbContext configuration and output to logs; 
- CanConnect with wrong/missing file creates a Northwind.db with 0 bytes! so check if the file exists and throw an exception if not; 
- use SqlConnectionStringBuilder in NorthwindContext; 
- make the CanConnect a dependent test;

# Chapter 13 Building Websites Using ASP.NET Core Razor Pages

- Summary of middleware order: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/#middleware-order
- Explain `<ItemGroup><Content>` and `<Remove>`.
- https://learn.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation

# Chapter 14 Building Websites Using the Model-View-Controller Pattern

- auto-register admin@example.com instead; 
- diagram for types of caching; 
- more output caching; 
- new validation attributes e.g. Range[min and mix];

# Chapter 15 Building and Consuming Web Services

- add 307 to the table of status codes; 
- change the port to 5002+5003 immediately after creating the project and retake all screenshots; 
- configure VSCode multi-launch; 
- use 5004+5 for Minimal APIs project; 
- start both web services; 
- update Ch12 with ports; 
- replace Q10 about endpoint routing; 
- replace Q8 about HTTP/3 benefits because its online section; 
- move online section to end; 
- Explain VS17.5 `.http` file support.

# Chapter 16 Building User Interface Components Using Blazor

- Replace Blazor Server and Blazor WebAssembly projects with a single Blazor United project.
- Replace the Blazor Mobile Bindings text with class libraries as Wasm.
- Northwind.Common.EntityModels.Sqlite: remove the two SQLite packages and therefore [Index] and so on, so it does not complain when used in Blazor Wasm projects; 
- "The label says “Customer Id” but the error messages are calling it “CustomerId” (no space). Could we get those consistent?"; 
- New Blazor loading page: https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-7-preview-7/#new-blazor-loading-page
- How to use `dotnet tool update --global dotnet-ef`.
- page 550 add `Trust Server Certificate=true;`: `dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;Trust Server Certificate=true;" Microsoft.EntityFrameworkCore.SqlServer --namespace Packt.Shared --data-annotations`
- 