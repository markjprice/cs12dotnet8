> **IMPORTANT!** [Information for Technical Reviewers](docs/reviewers.md)

[Common Mistakes, Improvements, and Errata aka list of corrections](docs/errata/README.md)

# C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals, Eighth Edition

Repository for the Packt Publishing book titled "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals" by Mark J. Price

This book is expected to publish in November 2023.

My author page on Amazon: https://www.amazon.com/Mark-J-Price/e/B071DW3QGN/ 

All of my books on Packt's website: https://subscription.packtpub.com/search?query=mark+j.+price

## Code solutions for Visual Studio 2022 and Visual Studio Code

Visual Studio Code now has an extension named **C# Dev Kit** that includes a solution explorer so it can better work with Visual Studio 2022 solution files. Visual Studio 2022 for Windows, Visual Studio 2022 for Mac, and Visual Studio Code + C# Dev Kit can now use the same code solution files and projects for each chapter, found here: [/code](/code). 

> **For Visual Studio Code:** To use the chapter solution files with Visual Studio Code, install the **C# Dev Kit** extension. Then in Visual Studio Code, open the `ChapterNN` folder that contains a `ChapterNN.sln` solution file and wait for the **SOLUTION EXPLORER** pane to appear at the bottom of the **EXPLORER**. You can drag and drop to reorder the panes to put **SOLUTION EXPLORER** at the top. Learn more about C# Dev Kit at the following link: https://devblogs.microsoft.com/visualstudio/announcing-csharp-dev-kit-for-visual-studio-code/

> **Warning!** If you use both Visual Studio 2022 and Visual Studio Code to open these solutions, be aware that the build process can conflict. This is because Visual Studio 2022 has its own non-standard build server that is different from the standard build server used by .NET SDK CLI. My recommendation is to only have a solution open in one code editor at any time. You should also clean the solutions between opening in different code editors. For example, after closing the solution in one code editor, I delete the `bin` and `obj` folders before then opening in a different code editor.

## Chapters and code solutions

**Introduction**
- Chapter 1 Hello C#, Welcome .NET! [code/Chapter01](code/Chapter01)

**Language**
- Chapter 2 Speaking C#: [code/Chapter02](code/Chapter02)
- Chapter 3 Controlling Flow, Converting Types, and Handling Exceptions: [code/Chapter03](code/Chapter03)
- Chapter 4 Writing, Debugging, and Testing Functions: [code/Chapter04](code/Chapter04)
- Chapter 5 Building Your Own Types with Object-Oriented Programming: [code/Chapter05](code/Chapter05)
- Chapter 6 Implementing Interfaces and Inheriting Classes: [code/Chapter06](code/Chapter06)

**Libraries**
- Chapter 7 Packaging and Distributing .NET Types: [code/Chapter07](code/Chapter07)
- Chapter 8 Working with Common .NET Types: [code/Chapter08](code/Chapter08)
- Chapter 9 Working with Files, Streams, and Serialization: [code/Chapter09](code/Chapter09)
- Chapter 10 Working with Data Using Entity Framework Core: [code/Chapter10](code/Chapter10)
- Chapter 11 Querying and Manipulating Data Using LINQ: [code/Chapter11](code/Chapter11)

**ASP.NET Core web development**
- Chapter 12 Introducing Web Development Using ASP.NET Core: [code/Chapter12](code/Chapter12)
- Chapter 13 Building Websites Using ASP.NET Core Razor Pages: [code/Chapter13](code/Chapter13)
- Chapter 14 Building Websites Using the Model-View-Controller Pattern: [code/Chapter14](code/Chapter14)
- Chapter 15 Building and Consuming Web Services: [code/Chapter15](code/Chapter15)
- Chapter 16 Building User Interface Components Using Blazor: [code/Chapter16](code/Chapter16)

## Bonus content

The appendix and color figures are available to download as PDFs:

- Appendix A, Answers to the Test Your Knowledge Questions: coming November 2023.
- Color images of the screenshots/diagrams used in this book: coming November 2023.

## Important
Corrections for typos and other mistakes and improvements like refactoring code. Useful links to other related material. 
- [Command-Lines](docs/command-lines.md) page lists all commands as a single line that can be copied and pasted to make it easier to enter commands at the prompt.
- [Book Links](docs/book-links.md)
- [Common Mistakes, Improvements, and Errata aka list of corrections](docs/errata/README.md)
- [Eighth edition's support for .NET 9](docs/dotnet9.md)

## Companion Book

I have written a componanion book titled, *[Apps and Services with .NET 8](https://github.com/markjprice/apps-services-net8)*, that is designed to follow on from where this book ends. You can also jump to chapters in the second book, as shown in the following diagram:

![](docs/assets/B19586_17_03.png)

## Microsoft Certifications
Microsoft used to have exams and certifications for developers that covered skills like C# and ASP.NET. Sadly, they have retired them all. These days, the only developer-adjacent exams and certifications are for Azure or Power Platform, as you can see from the certification poster: https://aka.ms/traincertposter

## Microsoft .NET community support
- [.NET Developer Community](https://dotnet.microsoft.com/platform/community)
- [.NET Tech Community Forums for topic discussions](https://techcommunity.microsoft.com/t5/net/ct-p/dotnet)
- [Q&A for .NET to get your questions answered](https://learn.microsoft.com/en-us/answers/products/dotnet)
- [Technical questions about the C# programming language](https://learn.microsoft.com/en-us/answers/topics/dotnet-csharp.html)
- [If you'd like to apply to be a reviewer](https://authors.packtpub.com/reviewers/)

## Interviews with me
Podcast interviews with me:
- [The .NET Core Podcast - March 3, 2023](https://dotnetcore.show/episode-117-our-perspectives-on-the-future-of-net-with-mark-j-price/)
- [Yet Another Podcast with Jesse Liberty - December 2022](https://jesseliberty.com/2022/12/10/mark-price-on-c-11-fixed/)
- [The .NET Core Podcast - February 4, 2022](https://dotnetcore.show/episode-91-c-sharp-10-and-dotnet-6-with-mark-j-price/)
- [Yet Another Podcast with Jesse Liberty - May 2021](http://jesseliberty.com/2021/05/16/mark-price-on-c9-and-net-6/)
- [The .NET Core Podcast - February 7, 2020](https://dotnetcore.show/episode-44-learning-net-core-with-mark-j-price/)
- [Yet Another Podcast with Jesse Liberty - February 2020](http://jesseliberty.com/2020/02/23/mark-price-c-net-core/)
- [Packt Podcasts](https://soundcloud.com/packt-podcasts/csharp-8-dotnet-core-3-the-evolution-of-the-microsoft-ecosystem)

Written interviews with me:
- [C# 9 and .NET 5: Book Review and Q&A](https://www.infoq.com/articles/book-interview-mark-price/?itm_source=infoq&itm_campaign=user_page&itm_medium=link)
- [Q&A with Episerver's Mark J. Price, author of C# 9 and .NET 5 - Modern Cross-Platform Development](https://www.episerver.com/articles/q-and-a-with-mark-price)
