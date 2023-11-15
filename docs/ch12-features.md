**New features in ASP.NET Core**

If you already have some familiarity with older versions of ASP.NET and are excited to find out about the new features in the most recent versions of ASP.NET Core, then I have made it easier for you to jump around by listing ASP.NET Core versions and their important new features below, along with the chapter number and topic title where you can learn about them.

- [ASP.NET Core 1.0, June 2016](#aspnet-core-10-june-2016)
- [ASP.NET Core 1.1, November 2016](#aspnet-core-11-november-2016)
- [ASP.NET Core 2.0, August 2017](#aspnet-core-20-august-2017)
- [ASP.NET Core 2.1, May 2018](#aspnet-core-21-may-2018)
- [ASP.NET Core 2.2, December 2018](#aspnet-core-22-december-2018)
- [ASP.NET Core 3.0, September 2019](#aspnet-core-30-september-2019)
- [ASP.NET Core 3.1, December 2019](#aspnet-core-31-december-2019)
- [Blazor WebAssembly 3.2, May 2020](#blazor-webassembly-32-may-2020)
- [ASP.NET Core 5, November 2020](#aspnet-core-5-november-2020)
- [ASP.NET Core 6, November 2021](#aspnet-core-6-november-2021)
- [ASP.NET Core 7, November 2022](#aspnet-core-7-november-2022)
- [ASP.NET Core 8, November 2023](#aspnet-core-8-november-2023)

> **Note**: Chapter number `*` in the tables means the online-only chapter about ASP.NET Core MVC that is available at the following link: https://github.com/markjprice/cs12dotnet8/blob/main/docs/aspnetcoremvc.md.

# ASP.NET Core 1.0, June 2016

Implemented a minimum API suitable for building modern cross-platform web apps and services for Windows, macOS, and Linux.

# ASP.NET Core 1.1, November 2016

Focused on bug fixes and general improvements to features and performance.

# ASP.NET Core 2.0, August 2017

Added new features such as Razor Pages, bunded assemblies into a `Microsoft.AspNetCore.All` metapackage, targeted .NET Standard 2.0, provided a new authentication model, and added many performance improvements. The biggest new features introduced with ASP.NET Core 2.0 are ASP.NET Core Razor Pages, which is covered in *Chapter 13, Building Websites Using ASP.NET Core Razor Pages*, and ASP.NET Core OData support. OData is covered in an online-only chapter of the companion book, *Apps and Services with .NET 8*, and is available at the following link: https://github.com/markjprice/apps-services-net8/blob/main/docs/ch08-odata.md.

# ASP.NET Core 2.1, May 2018

Added new features such as **SignalR** for real-time communication, **Razor class libraries** for reusing web components, **ASP.NET Core Identity** for authentication, and better support for HTTPS and the European Union's **General Data Protection Regulation (GDPR)**, including the topics listed in *Table 12.2*:

Feature|Chapter|Topic
---|---|---
Razor class libraries|13|Using Razor class libraries
GDPR support|*|Creating and exploring an ASP.NET Core MVC website
Identity UI library and scaffolding|*|Exploring an ASP.NET Core MVC website
Integration tests|*|Testing an ASP.NET Core MVC website
`[ApiController]`, `ActionResult<T>`|14|Creating an ASP.NET Core Web API project
Problem details|14|Implementing a Web API controller
`IHttpClientFactory`|14|Configuring HTTP clients using HttpClientFactory

*Table 12.2: Features of ASP.NET Core 2.1 covered in this book*

# ASP.NET Core 2.2, December 2018

Improved the building of RESTful HTTP APIs, updated the project templates to Bootstrap 4 and Angular 6, an optimized configuration for hosting in Azure, including the topics listed in *Table 12.3*:

Feature|Chapter|Topic
---|---|---
HTTP/2 in Kestrel|13|Classic ASP.NET versus modern ASP.NET Core
In-process hosting model|13|Creating an ASP.NET Core project
Endpoint routing|13|Understanding endpoint routing
Health Checks Middleware|14|Implementing health checks
Open API analyzers|14|Implementing Open API analyzers and conventions

*Table 12.3: Features of ASP.NET Core 2.2 covered in this book*

# ASP.NET Core 3.0, September 2019

Focused on fully leveraging .NET Core 3.0 and .NET Standard 2.1, which meant it could not support .NET Framework, introduced Blazor Server, and it added useful refinements, including the topics listed in *Table 12.4*:

Feature|Chapter|Topic
---|---|---
Static assets in Razor class libraries|13|Using Razor class libraries
New options for MVC service registration|*|Understanding ASP.NET Core MVC startup

*Table 12.4: Features of ASP.NET Core 3.0 covered in this book*

# ASP.NET Core 3.1, December 2019

Added refinements like partial class support for Razor components and a new `<component>` tag helper.

# Blazor WebAssembly 3.2, May 2020

It was a **Current** (now known as **STS**) release, meaning that projects had to be upgraded to the .NET 5 version within three months of the .NET 5 release. Microsoft finally delivered on the promise of full-stack web development with .NET.

# ASP.NET Core 5, November 2020

Focused on bug fixes, performance improvements, using caching for certificate authentication, HPACK dynamic compression of HTTP/2 response headers in Kestrel, nullable annotations for ASP.NET Core assemblies, and a reduction in container image sizes, including the topics listed in *Table 12.5*:

Feature|Chapter|Topic
---|---|---
Extension method to allow anonymous access to an endpoint|14|Securing web services
JSON extension methods for `HttpRequest` and `HttpResponse`|14|Getting customers as JSON in the controller

*Table 12.5: Features of ASP.NET Core 5 covered in this book*

# ASP.NET Core 6, November 2021

Added productivity improvements like minimizing code to implement basic websites and services, support for .NET Hot Reload, and new hosting options for Blazor, like hybrid apps using .NET MAUI, including the topics listed in *Table 12.6*:

Feature|Chapter|Topic
---|---|---
New empty web project template|13|Understanding the empty web template
Minimal APIs|14|Implementing minimal Web APIs
Blazor WebAssembly AOT|15|Enabling Blazor WebAssembly ahead-of-time compilation

*Table 12.6: Features of ASP.NET Core 6 covered in this book*

# ASP.NET Core 7, November 2022

Filled well-known gaps in functionality like HTTP/3 support, output caching, and many quality-of-life improvements to Blazor, including the topics listed in *Table 12.7*:

Feature|Chapter|Topic
---|---|---
HTTP request decompression|13|Enabling request decompression support
HTTP/3 support|13|Enabling HTTP/3 support
Output caching|*|Using a filter to cache output
W3C log additional headers|14|Support for logging additional request headers in W3CLogger
HTTP/3 client support|14|Enabling HTTP/3 support for HttpClient

*Table 12.7: Features of ASP.NET Core 7 covered in this book*

# ASP.NET Core 8, November 2023

Focused on unifying the Blazor hosting models, including the topics listed in *Table 12.8*:

Feature|Chapter|Topic
---|---|---
Route short-circuiting|14|Short-circuit routes in ASP.NET Core 8
Route tooling enhancements|14|Improved route tooling in ASP.NET Core 8
Unification of Blazor hosting|15|All of *Chapter 15, Building User Interfaces Using Blazor*.

*Table 12.8: Features of ASP.NET Core 8 covered in this book*
