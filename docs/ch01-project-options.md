**Project Options**

When creating new project either using Visual Studio 2022 or using the command prompt for tools like Visual Studio Code, it is useful to see a summary of your options for common types of project template.

- [Console App / `console`](#console-app--console)
- [Class Library / `classlib`](#class-library--classlib)
- [ASP.NET Core Empty / `web`](#aspnet-core-empty--web)
- [ASP.NET Core Web App (Model-View-Controller) / `mvc`](#aspnet-core-web-app-model-view-controller--mvc)
- [ASP.NET Core Web API / `webapi`](#aspnet-core-web-api--webapi)
- [Blazor Web App / `blazor`](#blazor-web-app--blazor)

# Console App / `console`

![Console App default options](assets/B19586_01_Projects_01.png)

![Other common options](assets/B19586_01_Projects_02.png)

# Class Library / `classlib`

Create a .NET 8.0 class library:

`dotnet new classlib`

Create a .NET Standard 2.0 class library:

`dotnet new classlib --framework netstandard2.0`

# ASP.NET Core Empty / `web`

![ASP.NET Core Empty default options](assets/B19586_01_Projects_03.png)

# ASP.NET Core Web App (Model-View-Controller) / `mvc`

This project template has the same options as **ASP.NET Core Empty** / `web`.

# ASP.NET Core Web API / `webapi`

> **Warning!** The .NET SDK 8 defaults to implementing services using Minimal APIs and you must use the `--use-controllers` or `-controllers` switch to implement services using controllers. The .NET SDK 6 or 7 defaults to implementing services using controllers and you must use the `--use-minimal-apis` or `-minimal` switch to implement services using Minimal APIs. JetBrains Rider does not yet have an option to "use controllers" so you should use the `dotnet new` command to create a Web API project if you need to use controllers.

![ASP.NET Core Web API default options](assets/B19586_01_Projects_04.png)

# Blazor Web App / `blazor`

![ASP.NET Core Web default options](assets/B19586_01_Projects_05.png)
