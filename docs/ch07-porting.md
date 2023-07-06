**Porting from .NET Framework to modern .NET**

If you are an existing .NET Framework developer, then you may have existing applications that you think you should port to modern .NET. But you should carefully consider if porting is the right choice for your code, because sometimes, the best choice is not to port.

For example, you might have a complex website project that runs on .NET Framework 4.8 but is only visited by a small number of users. If it works and handles the visitor traffic on minimal hardware, then potentially spending months porting it to a modern .NET platform could be a waste of time. But if the website currently requires many expensive Windows servers, then the cost of porting could eventually pay off if you can migrate to fewer, less costly Linux servers.

- [Could you port?](#could-you-port)
- [Should you port?](#should-you-port)
- [Differences between .NET Framework and modern .NET](#differences-between-net-framework-and-modern-net)
- [.NET Portability Analyzer](#net-portability-analyzer)
- [.NET Upgrade Assistant](#net-upgrade-assistant)
- [Using non-.NET Standard libraries](#using-non-net-standard-libraries)


# Could you port?

Modern .NET has great support for the following types of applications on Windows, macOS, and Linux, so they are good candidates for porting:

- ASP.NET Core MVC websites
- ASP.NET Core Web API web services (REST/HTTP)
- ASP.NET Core SignalR services
- Console App command-line interfaces

Modern .NET has decent support for the following types of applications on Windows, so they are potential candidates for porting:

- Windows Forms applications
- Windows Presentation Foundation (WPF) applications

Modern .NET has good support for the following types of applications on cross-platform desktop and mobile devices:

- Xamarin apps for mobile iOS and Android
- .NET MAUI for desktop Windows and macOS, or mobile iOS and Android

Modern .NET does not support the following types of legacy Microsoft projects:

- ASP.NET Web Forms websites. These might be best reimplemented using ASP.NET Core Razor Pages or Blazor.
- Windows Communication Foundation (WCF) services (but there is an open-source project named CoreWCF that you might be able to use depending on requirements). WCF services might be better reimplemented using ASP.NET Core gRPC services.
- Silverlight applications. These might be best reimplemented using .NET MAUI.

Silverlight and ASP.NET Web Forms applications will never be able to be ported to modern .NET, but existing Windows Forms and WPF applications could be ported to .NET on Windows to benefit from the new APIs and faster performance.

Legacy ASP.NET MVC web applications and ASP.NET Web API web services currently on .NET Framework could be ported to modern .NET and then be hosted on Windows, Linux, or macOS.

# Should you port?

Even if you could port, should you? What benefits do you gain? Some common benefits include the following:

- Deployment to Linux, Docker, or Kubernetes for websites and web services: These OSes are lightweight and cost-effective as website and web service platforms, especially when compared to the more costly Windows Server.
- Removal of dependency on IIS and System.Web.dll: Even if you continue to deploy to Windows Server, ASP.NET Core can be hosted on lightweight, higher-performance Kestrel (or other) web servers.
- Command-line tools: Tools that developers and administrators use to automate their tasks are often built as console applications. The ability to run a single tool cross-platform is very useful.

# Differences between .NET Framework and modern .NET

There are three key differences, as shown in the following table:

Modern .NET|.NET Framework
---|---
Distributed as NuGet packages, so each application can be deployed with its own app-local copy of the version of .NET that it needs.|Distributed as a system-wide, shared set of assemblies (literally, in the Global Assembly Cache (GAC)).
Split into small, layered components, so a minimal deployment can be performed.|Single, monolithic deployment.
Removes older technologies, such as ASP.NET Web Forms, and non-cross-platform features, such as AppDomains, .NET Remoting, and binary serialization.|As well as some similar technologies to those in modern .NET like ASP.NET Core MVC, it also retains some older technologies, such as ASP.NET Web Forms.

# .NET Portability Analyzer

Microsoft has a useful tool that you can run against your existing applications to generate a report for porting. You can watch a demonstration of the tool at the following link: https://learn.microsoft.com/en-us/shows/seth-juarez/brief-look-net-portability-analyzer.

# .NET Upgrade Assistant

Microsoft's latest tool for upgrading legacy projects to modern .NET is the **.NET Upgrade Assistant**.

For my day job, I used to work for a company named Optimizely. They have an enterprise-scale Digital Experience Platform (DXP) based on .NET comprising a Content Management System (CMS) and a Digital Commerce platform. Microsoft needed a challenging migration project to design and test the .NET Upgrade Assistant with, so we worked with them to build a great tool.

Currently, it supports the following .NET Framework project types and more will be added later:

- ASP.NET MVC
- Windows Forms
- WPF
- Console Application
- Class Library

It is installed as a global `dotnet` tool, as shown in the following command:
```
dotnet tool install -g upgrade-assistant
```

> You can read more about this tool and how to use it at the following link: https://docs.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-overview.

# Using non-.NET Standard libraries

Most existing NuGet packages can be used with modern .NET, even if they are not compiled for .NET Standard or a modern version like .NET 8. If you find a package that does not officially support .NET Standard, as shown on its nuget.org web page, you do not have to give up. You should try it and see if it works.

For example, there is a package of custom collections for handling matrices created by Dialect Software LLC, documented at the following link: https://www.nuget.org/packages/DialectSoftware.Collections.Matrix/

This package was last updated in 2013, which was long before .NET Core or .NET 8 existed, so this package was built for .NET Framework. If an assembly package like this only uses APIs available in .NET Standard, it can be used in a modern .NET project.

Let's try using it and see if it works:

1.	In the `AssembliesAndNamespaces` project, add a package reference for Dialect Software's package, as shown in the following markup:
```xml
<PackageReference
  Include="dialectsoftware.collections.matrix"
  Version="1.0.0" />
```

2.	Build the `AssembliesAndNamespaces` project to restore packages.
3.	In `Program.cs`, add statements to import the `DialectSoftware.Collections` and `DialectSoftware.Collections.Generics` namespaces.
4.	Add statements to create instances of `Axis` and `Matrix<T>`, populate them with values, and output them, as shown in the following code:
```cs
Axis x = new("x", 0, 10, 1);
Axis y = new("y", 0, 4, 1);
Matrix<long> matrix = new(new[] { x, y });

for (int i = 0; i < matrix.Axes[0].Points.Length; i++)
{
  matrix.Axes[0].Points[i].Label = $"x{i}";
}

for (int i = 0; i < matrix.Axes[1].Points.Length; i++)
{
  matrix.Axes[1].Points[i].Label = $"y{i}";
}

foreach (long[] c in matrix)
{
  matrix[c] = c[0] + c[1];
}

foreach (long[] c in matrix)
{
  WriteLine("{0},{1} ({2},{3}) = {4}",
    matrix.Axes[0].Points[c[0]].Label,
    matrix.Axes[1].Points[c[1]].Label,
    c[0], c[1], matrix[c]);
}
```

5.	Run the code, noting the warning message and the results, as shown in the following partial output:
```
warning NU1701: Package 'DialectSoftware.Collections.Matrix
1.0.0' was restored using '.NETFramework,Version=v4.6.1,
.NETFramework,Version=v4.6.2, .NETFramework,Version=v4.7,
.NETFramework,Version=v4.7.1, .NETFramework,Version=v4.7.2,
.NETFramework,Version=v4.8' instead of the project target framework 'net8.0'. This package may not be fully compatible with your project.
x0,y0 (0,0) = 0
x0,y1 (0,1) = 1
x0,y2 (0,2) = 2
x0,y3 (0,3) = 3
...
```

Even though this package was created before modern .NET existed, and the compiler and runtime have no way of knowing if it will work and therefore show warnings, because it happens to only call .NET Standard-compatible APIs, it works.
