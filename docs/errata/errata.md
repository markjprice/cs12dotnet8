**Errata** (6 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Page 10 - Installing other extensions](#page-10---installing-other-extensions)
- [Page 15 - Understanding .NET runtime and .NET SDK versions](#page-15---understanding-net-runtime-and-net-sdk-versions)
- [Page 43 - Configuring inline aka inlay hints](#page-43---configuring-inline-aka-inlay-hints)
- [Page 58 - Showing the compiler version](#page-58---showing-the-compiler-version)
- [Page 87 - Comparing double and decimal types](#page-87---comparing-double-and-decimal-types)
- [Page 383 - Creating a console app to publish](#page-383---creating-a-console-app-to-publish)

# Page 10 - Installing other extensions

> Thanks to [Muhammad Faisal Siddiqui](https://github.com/devcloud-ops) for raising [this issue on November 20, 2023](https://github.com/markjprice/cs12dotnet8/issues/3).

At the time of publishing, the Polyglot Notebooks extension has a dependency on .NET 7. The extension will soon be updated to use .NET 8 but for now you must install .NET 7 SDK. Hopefully the team will also update the extension to use the **.NET Install Tool** that ensures a correct version of a required .NET SDK is installed so users do not have to manually install it.

# Page 15 - Understanding .NET runtime and .NET SDK versions

> Thanks to a reader who contacted my publisher Packt on November 16, 2023 about this issue.

I wrote, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are tied to the runtime version it is matched with. The patch number follows a convention that indicates 
the major and minor versions of the SDK."

But the patch number is not created from the major and minor versions of the SDK. It is created from the minor and patch versions of the SDK.

I should have written, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are tied to the runtime version it is matched with. The third number follows a convention that indicates the minor and patch versions of the SDK. The third number starts at `100` for the initial version (equivalent to `0.0` for minor and patch number). The first digit increments with minor increments, and the other two digits increment with patch increments."

# Page 43 - Configuring inline aka inlay hints

> Thanks to [TheFumblebee](https://github.com/TheFumblebee) for raising [this issue on November 30, 2023](https://github.com/markjprice/cs12dotnet8/issues/5).

In the bullet for Visual Studio 2022, I wrote the label for the check box was **Display inline parameter hint names**. I should have written **Display inline parameter name hints**.

# Page 58 - Showing the compiler version

In Step 3, the code should have been styled as `Code` (monospace black-on-light-gray text) instead of `Command Line` (monospace white-on-black).

# Page 87 - Comparing double and decimal types

> Thanks to Yousef Imran who raised this issue via email on December 15, 2023.

At the top of page 87, I end the section describing a few special values associated with real numbers that are available as constants in the `float` and `double` types. I wrote, "`NaN` represents not-a-number (for example, the result of dividing by zero)," but that sentence is missing a "zero". It should be, "`NaN` represents not-a-number (for example, the result of dividing zero by zero),". In the next edition I will fix this mistake. 

> Please also note a [related improvement](https://github.com/markjprice/cs12dotnet8/blob/main/docs/errata/improvements.md#page-87---comparing-double-and-decimal-types).

# Page 383 - Creating a console app to publish

> Thanks to `mdj._` in the book's Discord channel for raising this issue on December 18, 2023.

In Step 5, I tell the reader to "add the runtime identifiers (RIDs) to target five operating systems" including Windows 10 or later. The legacy RID was `win10-x64` but in .NET 8 RC1 this changed to `win-x64`. The RID for MacOS/OS X also changed.

The book lists the RIDs as shown in the following markup:
```xml
<RuntimeIdentifiers>
  win10-x64;osx-x64;osx.11.0-arm64;linux-x64;linux-arm64
</RuntimeIdentifiers>
```

The RIDs should be as shown in the following markup:
```xml
<RuntimeIdentifiers>
  win-x64;osx-x64;osx-arm64;linux-x64;linux-arm64
</RuntimeIdentifiers>
```

In the next edition, as well as fixing the RID values, I will link to the official documentation so that readers can confirm the current valid values. For example, for known RIDs: https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#known-rids.
