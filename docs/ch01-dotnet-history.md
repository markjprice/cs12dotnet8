**.NET History**

- [Understanding .NET platforms](#understanding-net-platforms)
  - [Understanding .NET Framework](#understanding-net-framework)
  - [Understanding the Mono, Xamarin, and Unity projects](#understanding-the-mono-xamarin-and-unity-projects)
  - [Understanding .NET Core](#understanding-net-core)
- [Understanding the journey to one .NET](#understanding-the-journey-to-one-net)
  - [Understanding Blazor WebAssembly versioning](#understanding-blazor-webassembly-versioning)
- [What is different about modern .NET?](#what-is-different-about-modern-net)
  - [Windows desktop development](#windows-desktop-development)
  - [Web development](#web-development)
  - [Database development](#database-development)
- [Understanding .NET Standard](#understanding-net-standard)
- [.NET platforms and tools used by the C# and .NET book editions](#net-platforms-and-tools-used-by-the-c-and-net-book-editions)
- [Topics covered by Apps and Services with .NET 8](#topics-covered-by-apps-and-services-with-net-8)

# Understanding .NET platforms

One of the confusing aspects of .NET is that there are multiple implementations of it over the past couple of decades.

## Understanding .NET Framework

**.NET Framework** is a development platform that includes a **Common Language Runtime (CLR)**, which manages the execution of code, and a **Base Class Library (BCL)**, which provides a rich library of classes to build applications from.

Microsoft originally designed .NET Framework to have the possibility of being cross-platform, but Microsoft put their implementation efforts into making it work best with Windows.

Since .NET Framework 4.5.2, it has been an official component of the Windows operating system. Components have the same support as their parent products, so 4.5.2 and later follow the life cycle policy of the Windows OS on which they are installed. .NET Framework is installed on over one billion computers, so it must change as little as possible. Even bug fixes can cause problems, so it is updated infrequently.

For .NET Framework 4.0 or later, all the apps on a computer written for .NET Framework share the same version of the CLR and libraries stored in the **Global Assembly Cache (GAC)**, which can lead to issues if some of them need a specific version for compatibility.

> **Good Practice**: Practically speaking, .NET Framework is Windows-only and a legacy platform. Do not create new apps using it.

## Understanding the Mono, Xamarin, and Unity projects

Third parties developed a .NET Framework implementation named the **Mono** project. Mono is cross-platform, but it fell behind the official implementation of .NET Framework.

Mono has found a niche as the foundation of the **Xamarin** mobile platform as well as cross-platform game development platforms like **Unity**.

Microsoft purchased Xamarin in 2016 and now gives away what used to be an expensive Xamarin extension for free with Visual Studio. Microsoft renamed the Xamarin Studio development tool, which could only create mobile apps, to Visual Studio for Mac, and gave it the ability to create other types of projects like console apps and web services. 

With Visual Studio 2022 for Mac, Microsoft has replaced parts of the Xamarin Studio editor with parts from Visual Studio 2022 for Windows to provide closer parity of experience and performance. Visual Studio 2022 for Mac was also rewritten to be a truly native macOS UI app to improve reliability and work with macOS's built-in assistive technologies.

Unfortunately, a lot of the user interface of Visual Studio 2022 for Mac is very different from Visual Studio 2022 for Windows so the screenshots in the book can be confusing. That is why I provide online step-by-step instructions for multiple [code editors](../code-editors/README.md).

## Understanding .NET Core

Today, we live in a truly cross-platform world where modern mobile and cloud development have made Windows, as an operating system, much less important. Because of that, Microsoft has been working since 2015 on an effort to decouple .NET from its close ties with Windows. While rewriting .NET Framework to be truly cross-platform, they've taken the opportunity to refactor and remove major parts that are no longer considered core.

This new modernized product was initially branded **.NET Core** and includes a cross-platform implementation of the CLR known as **CoreCLR** and a streamlined BCL originally known as **CoreFX** but now better known as `dotnet/runtime`.

Scott Hunter, Microsoft Partner Director Program Manager for .NET, has said that "Forty percent of our .NET Core customers are brand-new developers to the platform, which is what we want with .NET Core. We want to bring new people in."

.NET Core is fast-moving, and because it can be deployed side by side with an app, it can change frequently, knowing those changes will not affect other .NET Core apps on the same machine. Most improvements that Microsoft makes to .NET Core and modern .NET cannot be easily added to .NET Framework.

# Understanding the journey to one .NET

At the Microsoft Build developer conference in May 2020, the .NET team announced that their plans for the unification of .NET had been delayed. They said that .NET 5 would be released on November 10, 2020, and it would unify all the various .NET platforms except mobile. It would not be until .NET 6 in November 2021 that mobile would also be supported by the unified .NET platform. 

Unfortunately, in September 2021 they had to announce a six-month delay to .NET MAUI, their new cross-platform platform for mobile and desktop app development. .NET MAUI finally released to General Availability (GA) in May 2022. You can read the announcement at the following link:
https://devblogs.microsoft.com/dotnet/introducing-dotnet-maui-one-codebase-many-platforms/

.NET Core has been renamed .NET and the major version number has skipped 4 to avoid confusion with .NET Framework 4.x. Microsoft plans on annual major version releases every November, rather like Apple does major version number releases of iOS every September.

The following table shows when the key versions of modern .NET were released, when future releases are planned, and which version is used by the published editions of this book:

Modern .NET Version|Released|Edition|Published
---|---|---|---
.NET Core RC1|November 2015|First|March 2016
.NET Core 1.0|June 2016||
.NET Core 1.1|November 2016||
.NET Core 1.0.4 and .NET Core 1.1.1|March 2017|Second|March 2017
.NET Core 2.0|August 2017||
.NET Core for UWP in Windows 10 Fall Creators Update|October 2017|Third|November 2017
.NET Core 2.1 (LTS)|May 2018||
.NET Core 2.2 (Current)|December 2018||
.NET Core 3.0 (Current)|September 2019|Fourth|October 2019
.NET Core 3.1 (LTS)|December 2019||
Blazor WebAssembly 3.2 (Current)|May 2020||
.NET 5 (Current)|November 2020|Fifth|November 2020
.NET 6 (LTS)|November 2021|Sixth|November 2021
.NET 7 (STS)|November 2022|Seventh|November 2022
.NET 8 (LTS)|November 2023|Eighth|November 2023
.NET 9 (STS)|November 2024|Ninth|November 2024
.NET 10 (LTS)|November 2025|Tenth|November 2025

## Understanding Blazor WebAssembly versioning

.NET Core 3.1 included Blazor Server for building web components. Microsoft had also planned to include Blazor WebAssembly in that release, but it was delayed. Blazor WebAssembly was later released as an optional add-on for .NET Core 3.1. I include it in the table above because it was versioned as 3.2 to exclude it from the LTS of .NET Core 3.1. 

# What is different about modern .NET?

Modern .NET is modularized compared to the legacy .NET Framework, which is monolithic. It is open source and Microsoft makes decisions about improvements and changes in the open. Microsoft has put particular effort into improving the performance of modern .NET.

Modern .NET can be smaller than the last version of .NET Framework due to the removal of legacy and non-cross-platform technologies. For example, workloads such as **Windows Forms** and **Windows Presentation Foundation (WPF)** can be used to build graphical user interface (GUI) applications, but they are tightly bound to the Windows ecosystem, so they are not included with .NET on macOS and Linux.

## Windows desktop development

One of the features of modern .NET is support for running old Windows Forms and WPF desktop applications using the **Windows Desktop Pack** that is included with the Windows version of .NET Core 3.1 or later. This is why it is bigger than the SDKs for macOS and Linux. You can make changes to your legacy Windows desktop app, and then rebuild it for modern .NET to take advantage of new features and performance improvements. 

> I do not cover Windows desktop development in this book. 

## Web development

**ASP.NET Web Forms** and **Windows Communication Foundation (WCF)** are old web application and service technologies that fewer developers are choosing to use for new development projects today, so they have also been removed from modern .NET. Instead, developers prefer to use **ASP.NET MVC**, **ASP.NET Web API**, **SignalR**, and **gRPC**. These technologies have been refactored and combined into a platform that runs on modern .NET, named **ASP.NET Core**. 

You'll learn about the web development technologies in *Chapter 12, Introducing Web Development Using ASP.NET Core*, *Chapter 13, Building Websites Using ASP.NET Core Razor Pages*, *Chapter 14, Building Websites Using the Model-View-Controller Pattern*, *Chapter 15, Building and Consuming Web Services*, and *Chapter 16, Building User Interfaces Using Blazor*.

> **More Information**: Some .NET Framework developers are upset that ASP.NET Web Forms, WCF, and Windows Workflow (WF) are missing from modern .NET and would like Microsoft to change their minds. There are open-source projects to enable WCF and WF to migrate to modern .NET. You can read more at the following link: https://devblogs.microsoft.com/dotnet/supporting-the-community-with-wf-and-wcf-oss-projects/. **CoreWCF** version 1.0 was released in April 2022: https://devblogs.microsoft.com/dotnet/corewcf-v1-released/. There is an open-source project for Blazor Web Forms components at the following link: https://github.com/FritzAndFriends/BlazorWebFormsComponents.

## Database development

**Entity Framework (EF) 6** is an object-relational mapping technology that is designed to work with data that is stored in relational databases such as Oracle and SQL Server. It has gained baggage over the years, so the cross-platform API has been slimmed down, has been given support for non-relational databases like Azure Cosmos DB, and has been renamed **Entity Framework Core**. You will learn about it in *Chapter 10, Working with Data Using Entity Framework Core*.

If you have existing apps that use the old EF, then version 6.3 is supported on .NET Core 3.0 or later.

# Understanding .NET Standard

The situation with .NET in 2019 was that there were three forked .NET platforms controlled by Microsoft, as shown in the following list:

- .NET Core: For cross-platform and new apps.
- .NET Framework: For legacy apps.
- Xamarin: For mobile apps.

Each had strengths and weaknesses because they were all designed for different scenarios. This led to the problem that a developer had to learn three platforms, each with annoying quirks and limitations.

Because of that, Microsoft defined **.NET Standard** – a specification for a set of APIs that all .NET platforms could implement to indicate what level of compatibility they have. For example, basic support is indicated by a platform being compliant with .NET Standard 1.4.

With .NET Standard 2.0 and later, Microsoft made all three platforms converge on a modern minimum standard, which made it much easier for developers to share code between any flavor of .NET.

For .NET Core 2.0 and later, this added most of the missing APIs that developers need to port old code written for .NET Framework to the cross-platform .NET Core. However, some APIs are implemented but throw an exception to indicate to a developer that they should not actually be used! This is usually due to differences in the operating system on which you run .NET. You'll learn how to handle these platform-specific exceptions in *Chapter 2, Speaking C#*.

It is important to understand that .NET Standard is just a standard. You are not able to install .NET Standard in the same way that you cannot install HTML5. To use HTML5, you must install a web browser that implements the HTML5 standard. To use .NET Standard, you must install a .NET platform that implements the .NET Standard specification. 

The last .NET Standard, version 2.1, is implemented by .NET Core 3.0, Mono, and Xamarin. Some features of C# 8.0 require .NET Standard 2.1. .NET Standard 2.1 is not implemented by .NET Framework 4.8.

With the release of .NET 6 and later, the need for .NET Standard has reduced significantly because there is now a single .NET for all platforms, including mobile. Modern .NET has a single BCL and two CLRs: CoreCLR is optimized for server or desktop scenarios like websites and Windows desktop apps, and the Mono runtime is optimized for mobile and web browser apps that have limited resources.

In August 2021, Stephen Toub (Partner Software Engineer, .NET) wrote the article “Performance Improvements in .NET 6.” It has a section about Blazor and Mono where he wrote:
The runtime is itself compiled to WASM, downloaded to the browser, and used to execute the application and library code on which the app depends. I say “the runtime” here, but in reality, there are actually multiple incarnations of a runtime for .NET. In .NET 6, all of the .NET core libraries for all of the .NET app models, whether it be console apps or ASP.NET Core or Blazor WASM or mobile apps, come from the same source in dotnet/runtime, but there are actually two runtime implementations in dotnet/runtime: “coreclr” and “mono.”
Read more about the two runtimes at the following link: https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#blazor-and-mono.

Even now, apps and websites created for .NET Framework will need to be supported, so it is important to understand that you can create .NET Standard 2.0 class libraries that are backward compatible with legacy .NET platforms.

.NET Standard is now officially legacy. There will be no new versions of .NET Standard so its GitHub repository is archived, as you can read about in the following tweet: https://twitter.com/dotnet/status/1569725004690128898

# .NET platforms and tools used by the C# and .NET book editions

For the first edition of this book, which was published in March 2016, I focused on .NET Core functionality but used .NET Framework when important or useful features had not yet been implemented in .NET Core. That was necessary because it was before the final release of .NET Core 1.0. Visual Studio 2015 was used for most examples, with Visual Studio Code shown only briefly.

The second edition was (almost) completely purged of all .NET Framework code examples so that readers were able to focus on .NET Core 1.1 examples that truly run cross-platform and it was an LTS release.

The third edition completed the switch. It was rewritten so that all the code was pure .NET Core 2.0. But giving step-by-step instructions for both Visual Studio Code and Visual Studio 2017 for all tasks added complexity.

The fourth edition continued the trend by only showing coding examples using Visual Studio Code for all but the last two chapters. In Chapter 20, Building Windows Desktop Apps, it used Visual Studio running on Windows 10, and in Chapter 21, Building Cross-Platform Mobile Apps, it used Visual Studio for Mac.

In the fifth edition, Chapter 20, Building Windows Desktop Apps, was moved to an online-only Appendix B to make space for a new Chapter 20, Building Web User Interfaces Using Blazor. Blazor projects can be created using Visual Studio Code.

In the sixth edition, Chapter 19, Building Mobile and Desktop Apps Using .NET MAUI, was updated to show how mobile and desktop cross-platform apps can be created using Visual Studio 2022 and .NET MAUI (Multi-platform App UI).

In the seventh and eighth editions, I refocused the book on three areas: language, libraries, and web development fundamentals. Readers can use Visual Studio Code for all examples in the book, or any other code editor of their choice.

For .NET MAUI, readers can purchase my other book, Apps and Services with .NET 8. 

# Topics covered by Apps and Services with .NET 8

The following topics are available in a new book, Apps and Services with .NET 8:

- Data: SQL Server, Azure Cosmos DB.
- Libraries: Dates, times, time zones, and internationalization; reflection and source code generators; third-party libraries for image handling, logging, mapping, generating PDFs; multitasking and concurrency; and so on.
- Services: gRPC, OData, GraphQL, Azure Functions, SignalR, Minimal Web APIs.
- User Interfaces: ASP.NET Core, Blazor WebAssembly, .NET MAUI.
