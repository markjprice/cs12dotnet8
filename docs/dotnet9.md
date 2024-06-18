**Eighth Edition's support for .NET 9**

- [.NET 9 downloads and announcements](#net-9-downloads-and-announcements)
- [How to switch from .NET 8 to .NET 9](#how-to-switch-from-net-8-to-net-9)
  - [Upgrading the target framework for a project](#upgrading-the-target-framework-for-a-project)
  - [Upgrading packages for a project](#upgrading-packages-for-a-project)
- [What's New in .NET 9 and where will I cover those new features?](#whats-new-in-net-9-and-where-will-i-cover-those-new-features)
- [.NET 10 downloads and announcements](#net-10-downloads-and-announcements)

# .NET 9 downloads and announcements

Microsoft will release previews of .NET 9 regularly starting in February 2024 until the final version on Tuesday, November 12, 2024, one week after the US Presidential Election on November 5.

- [Download .NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [.NET 9 Release Index](https://github.com/dotnet/core/discussions/9234)
- February 13, 2024: [Our Vision for .NET 9](https://devblogs.microsoft.com/dotnet/our-vision-for-dotnet-9/)
- March 12, 2024: [.NET 9 Preview 2](https://github.com/dotnet/core/discussions/9217)
- April 11, 2024: [.NET 9 Preview 3](https://github.com/dotnet/core/discussions/9271)
- May 21, 2024: [.NET 9 Preview 4](https://github.com/dotnet/core/discussions/9318)
- June 11, 2024: [.NET 9 Preview 5](https://github.com/dotnet/core/discussions/9350)
- July, 2024: .NET 9 Preview 6
- August, 2024: .NET 9 Preview 7
- September, 2024: .NET 9 Release Candidate 1
- October, 2024: .NET 9 Release Candidate 2
- November 12, 2024: .NET 9.0 GA (general availability)

# How to switch from .NET 8 to .NET 9

After [downloading](https://dotnet.microsoft.com/download/dotnet/9.0) and installing .NET 9.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 9.0 as the target framework. 

## Upgrading the target framework for a project

To upgrade a project in the GitHub repository from .NET 8.0 to .NET 9.0 just requires a target framework change in your project file.

Change this:

```xml
<TargetFramework>net8.0</TargetFramework>
```

To this:

```xml
<TargetFramework>net9.0</TargetFramework>
```

## Upgrading packages for a project

For projects that reference additional NuGet packages, use the latest NuGet package version instead of the version given in the book. For example, on page 208, you must reference two packages, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="8.0.0" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Json"
    Version="8.0.0" />
</ItemGroup>
```

To use .NET 9 Preview 2 packages, search https://www.nuget.org for the package and find its latest preview version number. For example, for Preview 2, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="9.0.0-preview.2.24128.5" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Json"
    Version="9.0.0-preview.2.24128.5" />
</ItemGroup>
```

To always use latest .NET 9 preview, release candidate, or patch version package, use a version number wildcard, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="9.0-*" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Json"
    Version="9.0-*" />
</ItemGroup>
```

> You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder#versions-body-tab.

# What's New in .NET 9 and where will I cover those new features?

Official page: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview

Preview updates: https://github.com/dotnet/core/discussions

The following new features will be covered in the 9th edition to be published in November 2024:
- JSON serialization options: `System.Text.Json` now has extra features like [indentation options](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#indentation-options) and [default web options](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#default-web-options).
- LINQ: [New extension methods](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#linq): `CountBy`, `AggregateBy`, and `Index`.
- [PriorityQueue.Remove() method](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#priorityqueueremove-method).

The following new features will be mentioned in the 1st edition of *Tools and Skills for .NET 8* to be published in Summer 2024:
- [New reflection features](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#reflection)
- [New cryptography features](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#cryptography)

# .NET 10 downloads and announcements

Microsoft will release previews of .NET 10 regularly starting in February 2025 until the final version on Tuesday, November 11, 2025.

- [Download .NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). **Warning!** This link will not activate until February 2025.
- August 2024 to January 2025: [Download alpha versions of .NET 10](https://github.com/dotnet/installer#table). **Warning!** This link will not show .NET 10 downloads until July/August 2024.
- February, 2025: .NET 10 Preview 1
- March, 2025: .NET 10 Preview 2
- April, 2025: .NET 10 Preview 3
- May, 2025: .NET 10 Preview 4
- June, 2025: .NET 10 Preview 5
- July, 2025: .NET 10 Preview 6
- August, 2025: .NET 10 Preview 7
- September, 2025: .NET 10 Release Candidate 1
- October, 2025: .NET 10 Release Candidate 2
- November, 2025: .NET 10.0
