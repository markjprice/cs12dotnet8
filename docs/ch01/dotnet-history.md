**.NET History**

- [Understanding .NET Framework](#understanding-net-framework)
- [Understanding the Mono, Xamarin, and Unity projects](#understanding-the-mono-xamarin-and-unity-projects)
- [Understanding .NET Core](#understanding-net-core)
- [Understanding the journey to one .NET](#understanding-the-journey-to-one-net)
- [Understanding Blazor WebAssembly versioning](#understanding-blazor-webassembly-versioning)

# Understanding .NET Framework

**.NET Framework** is a development platform that includes a **Common Language Runtime (CLR)**, which manages the execution of code, and a **Base Class Library (BCL)**, which provides a rich library of classes to build applications from.

Microsoft originally designed .NET Framework to have the possibility of being cross-platform, but Microsoft put their implementation efforts into making it work best with Windows.

Since .NET Framework 4.5.2, it has been an official component of the Windows operating system. Components have the same support as their parent products, so 4.5.2 and later follow the life cycle policy of the Windows OS on which they are installed. .NET Framework is installed on over one billion computers, so it must change as little as possible. Even bug fixes can cause problems, so it is updated infrequently.

For .NET Framework 4.0 or later, all the apps on a computer written for .NET Framework share the same version of the CLR and libraries stored in the **Global Assembly Cache (GAC)**, which can lead to issues if some of them need a specific version for compatibility.

> **Good Practice**: Practically speaking, .NET Framework is Windows-only and a legacy platform. Do not create new apps using it.

# Understanding the Mono, Xamarin, and Unity projects

Third parties developed a .NET Framework implementation named the **Mono** project. Mono is cross-platform, but it fell behind the official implementation of .NET Framework.

Mono has found a niche as the foundation of the **Xamarin** mobile platform as well as cross-platform game development platforms like **Unity**.

Microsoft purchased Xamarin in 2016 and now gives away what used to be an expensive Xamarin extension for free with Visual Studio. Microsoft renamed the Xamarin Studio development tool, which could only create mobile apps, to Visual Studio for Mac, and gave it the ability to create other types of projects like console apps and web services. 

With Visual Studio 2022 for Mac, Microsoft has replaced parts of the Xamarin Studio editor with parts from Visual Studio 2022 for Windows to provide closer parity of experience and performance. Visual Studio 2022 for Mac was also rewritten to be a truly native macOS UI app to improve reliability and work with macOS's built-in assistive technologies.

Unfortunately, a lot of the user interface of Visual Studio 2022 for Mac is very different from Visual Studio 2022 for Windows so the screenshots in the book can be confusing. That is why I provide online step-by-step instructions for multiple [code editors](../code-editors/README.md).

# Understanding .NET Core

Today, we live in a truly cross-platform world where modern mobile and cloud development have made Windows, as an operating system, much less important. Because of that, Microsoft has been working since 2015 on an effort to decouple .NET from its close ties with Windows. While rewriting .NET Framework to be truly cross-platform, they've taken the opportunity to refactor and remove major parts that are no longer considered core.

This new modernized product was initially branded **.NET Core** and includes a cross-platform implementation of the CLR known as **CoreCLR** and a streamlined BCL known as **CoreFX**.

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

# Understanding Blazor WebAssembly versioning

.NET Core 3.1 included Blazor Server for building web components. Microsoft had also planned to include Blazor WebAssembly in that release, but it was delayed. Blazor WebAssembly was later released as an optional add-on for .NET Core 3.1. I include it in the table above because it was versioned as 3.2 to exclude it from the LTS of .NET Core 3.1. 
