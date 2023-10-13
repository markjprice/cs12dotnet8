**New features in modern .NET**

If you already have some familiarity with older versions of .NET and are excited to find out about the new features in the most recent versions, then I have made it easier for you to jump around by listing modern .NET versions and their important new features below, along with the chapter number and topic title where you can learn about them.

- [.NET Core 1.0, June 2016](#net-core-10-june-2016)
- [.NET Core 1.1, November 2016](#net-core-11-november-2016)
- [.NET Core 2.0, August 2017](#net-core-20-august-2017)
- [.NET Core 2.1, May 2018](#net-core-21-may-2018)
- [.NET Core 2.2, December 2018](#net-core-22-december-2018)
- [.NET Core 3.0, September 2019](#net-core-30-september-2019)
- [.NET Core 3.1, December 2019](#net-core-31-december-2019)
- [.NET 5, November 2020](#net-5-november-2020)
- [.NET 6, November 2021](#net-6-november-2021)
- [.NET 7, November 2022](#net-7-november-2022)
- [.NET 8, November 2023](#net-8-november-2023)


# .NET Core 1.0, June 2016

Implemented an API suitable for building modern cross-platform apps, including web and cloud applications and services for Linux using ASP.NET Core.

# .NET Core 1.1, November 2016

Fixed bugs, increased the number of Linux distributions supported, supported .NET Standard 1.6, and improved performance, especially with ASP.NET Core for web apps and services.

# .NET Core 2.0, August 2017

Implemented .NET Standard 2.0, the ability to reference .NET Framework libraries, and added more performance improvements.

# .NET Core 2.1, May 2018

Focused on an extendable tooling system, added new types like `Span<T>`, new APIs for cryptography and compression, a Windows Compatibility Pack with an additional 20,000 APIs to help port old Windows applications, Entity Framework Core value conversions, LINQ `GroupBy` conversions, data seeding, query types, and even more performance improvements, including the topics listed in *Table 7.1*:

Feature|Chapter|Topic
---|---|---
Spans|8|Working with spans, indexes, and ranges
Brotli compression|9|Compressing with the Brotli algorithm
EF Core lazy loading|10|Enabling lazy loading
EF Core data seeding|10|Understanding data seeding

*Table 7.1: Features of .NET Core 2.1*

# .NET Core 2.2, December 2018

Focused on diagnostic improvements for the runtime, optional tiered compilation, and added new features to ASP.NET Core and Entity Framework Core like spatial data support using types from the NetTopologySuite (NTS) library, query tags, and collections of owned entities.

# .NET Core 3.0, September 2019

Added support for building Windows desktop applications using **Windows Forms**, **Windows Presentation Foundation (WPF)**, and Entity Framework 6.3. Also introduced side-by-side and app-local deployments; a fast JSON reader; serial port access and other pinout access for Internet of Things (IoT) solutions; and tiered compilation by default, including the topics listed in *Table 7.2*:

Feature|Chapter|Topic
---|---|---
Embedding .NET in-app|7|Publishing your applications for deployment
Index and Range|8|Working with spans, indexes, and ranges
System.Text.Json|9|High-performance JSON processing

*Table 7.2: Features of .NET Core 3.0*

# .NET Core 3.1, December 2019

Added bug fixes and refinements so that it could be a Long Term Support (LTS) release.

# .NET 5, November 2020

Unified the various .NET platforms except mobile, refined the platform, and improved performance, including the topics listed in *Table 7.3*:

Feature|Chapter|Topic
---|---|---
`Half` type|8|Working with numbers
Regular expression performance improvements|8|Regular expression performance improvements
`System.Text.Json` improvements|9|High-performance JSON processing
EF Core generated SQL|10|Getting the generated SQL
EF Core Filtered Include|10|Filtering included entities
EF Core Scaffold-DbContext now singularizes using Humanizer|10|Scaffolding models using an existing database

*Table 7.3: Features of .NET 5*

# .NET 6, November 2021

Added more features to EF Core for data management, new types for working with dates and times, and improved performance yet again, including the topics listed in *Table 7.4*:

Feature|Chapter|Topic
---|---|---
Check .NET SDK status|7|Checking your .NET SDKs for updates
Link trim mode as default|7|Reducing the size of apps using app trimming
`EnsureCapacity` for `List<T>`|8|Improving performance by ensuring the capacity of a collection
Low-level file API using `RandomAccess`|9|Reading and writing with random access handles
EF Core configuration conventions|10|Configuring preconvention models
New LINQ methods|11|Building LINQ expressions with the Enumerable class
`TryGetNonEnumeratedCount`|11|Aggregating sequences

*Table 7.4: Features of .NET 6*

# .NET 7, November 2022

Finally unified with the mobile platform, added more features like `string` syntax coloring and IntelliSense, support for creating and extracting Tar archives, and improving the performance of inserts and updates with EF Core, including the topics listed in *Table 7.5*:

Feature|Chapter|Topic
---|---|---
`[StringSyntax]` attribute|8|Activating regular expression syntax coloring
`[GeneratedRegex]` attribute|8|Improving regular expression performance with source generators
Tar archive support|9|Exercise 9.3 – Working with Tar archives
`ExecuteUpdate` and `ExecuteDelete`|10|More efficient updates and deletes
`Order` and `OrderDescending`|11|Sorting by the item itself

*Table 7.5: Features of .NET 7*

# .NET 8, November 2023

Improved native AOT (ahead-of-time) compilation support, and added some advanced features for library authors related to source generation, including the topics listed in *Table 7.6*:

Feature|Chapter|Topic
---|---|---
Terminal logger for build output and changed default publish configuration|7|Managing projects using the `dotnet` CLI
Simplified output paths|7|Controlling where build artifacts are created
Improved native AOT support|7|Native ahead-of-time compilation
New `Random` methods|8|Generating random numbers for games and similar apps
New array, collection, and span initialization syntax|8|Initializing collections using collection expressions
Frozen collections|8|Read-only, immutable, and frozen collections
New data validation attributes|10|Using EF Core annotation attributes to define the model

*Table 7.6: Features of .NET 8*
