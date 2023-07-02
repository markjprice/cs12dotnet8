**Using Visual Studio Code**

In this article, I provide detailed step-by-step instuctions for using Visual Studio Code for topics like creating a solution with multiple projects and using debugging tools.

- [Chapter 1](#chapter-1)
  - [Downloading and installing Visual Studio Code](#downloading-and-installing-visual-studio-code)
    - [Installing other extensions](#installing-other-extensions)
    - [Managing Visual Studio Code extensions at the command prompt](#managing-visual-studio-code-extensions-at-the-command-prompt)
    - [Understanding Microsoft Visual Studio Code versions](#understanding-microsoft-visual-studio-code-versions)
    - [Keyboard shortcuts for Visual Studio Code](#keyboard-shortcuts-for-visual-studio-code)
  - [Building console apps using Visual Studio Code](#building-console-apps-using-visual-studio-code)
    - [Writing code using Visual Studio Code](#writing-code-using-visual-studio-code)
    - [Compiling and running code using the dotnet CLI](#compiling-and-running-code-using-the-dotnet-cli)
  - [Adding a second project using Visual Studio Code](#adding-a-second-project-using-visual-studio-code)
  - [Summary of steps for Visual Studio Code](#summary-of-steps-for-visual-studio-code)
- [Chapter 4](#chapter-4)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Decompiling using the ILSpy extension for Visual Studio Code](#decompiling-using-the-ilspy-extension-for-visual-studio-code)

# Chapter 1

## Downloading and installing Visual Studio Code

Visual Studio Code has rapidly improved over the past couple of years and has pleasantly surprised Microsoft with its popularity. If you are brave and like to live on the bleeding edge, then there is an **Insiders** edition, which is a daily build of the next version.

Even if you plan to only use Visual Studio 2022 for Windows for development, I recommend that you download and install Visual Studio Code and try the coding tasks in this chapter using it, and then decide if you want to stick with just using Visual Studio 2022 for the rest of the book.

Let's now download and install Visual Studio Code, the .NET SDK, and the C# Dev Kit extension:
1.	Download and install either the Stable build or the Insiders edition of Visual Studio Code from the following link: https://code.visualstudio.com/.

> **More Information**: If you need more help installing Visual Studio Code, you can read the official setup guide at the following link: https://code.visualstudio.com/docs/setup/setup-overview.

2.	Download and install the .NET SDKs for version 8.0 and at least one other version like 6.0 or 7.0 from the following link: https://www.microsoft.com/net/download.

> To fully learn how to control .NET SDKs, we need multiple versions installed. .NET 6, .NET 7, and .NET 8 are supported versions at the time of publishing in November 2023. You can safely install multiple SDKs side by side. The most recent SDK will be used to build your projects.

3.	To install the **C# Dev Kit** extension, you must first launch the Visual Studio Code application.
4.	In Visual Studio Code, click the **Extensions** icon or navigate to **View** | **Extensions**.
5.	**C# Dev Kit** is one of the most popular extensions available, so you should see it at the top of the list, and you can enter C# in the search box.

> **C# Dev Kit** has a dependency on the **C#** extension version 2.x, so you do not have to install the C# extension separately. Note that C# extension version 2.x no longer uses OmniSharp since it has a new **Language Service Protocol (LSP)** host. **C# Dev Kit** also has dependencies on the **.NET Install Tool for Extension Authors** and **IntelliCode for C# Dev Kit** extensions so they will be installed too.

6.	Click **Install** and wait for supporting packages to download and install.

> **Good Practice**: Be sure to read the license agreement for the **C# Dev Kit**. It has a more restrictive license than the **C#** extension: https://aka.ms/vs/csdevkit/license.

### Installing other extensions

In later chapters of this book, you will use more Visual Studio Code extensions. If you want to install them now, all the extensions that we will use are shown in the following table:

Extension name and identifier|Description
---|---
C# Dev Kit<br/>`ms-dotnettools.csdevkit`|Official C# extension from Microsoft. Manage your code with a solution explorer and test your code with integrated unit test discovery and execution. Includes the C# and IntelliCode for C# Dev Kit extensions.
C#<br/>`ms-dotnettools.csharp`|C# editing support, including syntax highlighting, IntelliSense, Go To Definition, Find All References, debugging support for .NET, and support for csproj projects on Windows, macOS, and Linux.
IntelliCode for C# Dev Kit<br/>`ms-dotnettools.vscodeintellicode-csharp`|Provides AI-assisted development features for Python, TypeScript/JavaScript, C# and Java developers.
MSBuild project tools<br/>`tintoy.msbuild-project-tools`|Provides IntelliSense for MSBuild project files, including autocomplete for <PackageReference> elements.
Polyglot Notebooks<br/>`ms-dotnettools.dotnet-interactive-vscode`|This extension adds support for using .NET and other languages in a notebook. It has a dependency on the Jupyter extension (`ms-toolsai.jupyter`) that itself has dependencies.
ilspy-vscode<br/>`icsharpcode.ilspy-vscode`|Decompile MSIL assemblies – support for modern .NET, .NET Framework, .NET Core, and .NET Standard.
REST Client<br/>`humao.rest-client`|Send an HTTP request and view the response directly in Visual Studio Code.

### Managing Visual Studio Code extensions at the command prompt

You can install a Visual Studio Code extension at the command prompt or terminal, as shown in the following table:

Command|Description
---|---
`code --list-extensions`|List installed extensions.
`code --install-extension <extension-id>`|Install the specified extension.
`code --uninstall-extension <extension-id>`|Uninstall the specified extension.

For example, to install the **C# Dev Kit** extension, enter the following at the command prompt:
```
code --install-extension ms-dotnettools.csdevkit
```

I have created PowerShell scripts to install and uninstall the Visual Studio Code extensions in the preceding table. You can find them at the following link: https://github.com/markjprice/cs12dotnet8/tree/main/scripts/extension-scripts/.

### Understanding Microsoft Visual Studio Code versions

Microsoft releases a new feature version of Visual Studio Code (almost) every month and bug fix versions more frequently. For example:

- Version 1.79.0, May 2023 feature release
- Version 1.79.1, May 2023 bug fix release

The version used in this book is 1.82.0, August 2023 feature release, but the version of Visual Studio Code is less important than the version of the C# Dev Kit or C# extension that you install. I recommend C# extension v2.0.238 or later.

While the C# extension is not required, it provides IntelliSense as you type, code navigation, and debugging features, so it's something that's very handy to install and keep updated to support the latest C# language features.

### Keyboard shortcuts for Visual Studio Code

If you want to customize your keyboard shortcuts for Visual Studio Code, then you can, as shown at the following link: https://code.visualstudio.com/docs/getstarted/keybindings.

I recommend that you download a PDF of Visual Studio Code keyboard shortcuts for your operating system from the following list:

- Windows: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-windows.pdf
- macOS: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-macos.pdf
- Linux: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-linux.pdf

## Building console apps using Visual Studio Code

The goal of this section is to showcase how to build a console app using Visual Studio Code and the `dotnet` command-line interface (CLI).

Both the instructions and screenshots in this section are for Windows, but the same actions will work with Visual Studio Code on the macOS and Linux variants.

The main differences will be native command-line actions such as deleting a file: both the command and the path are likely to be different on Windows or macOS and Linux. Luckily, the `dotnet` CLI tool itself and its commands are identical on all platforms.

### Writing code using Visual Studio Code

Let's get started writing code!

1. Start your favorite tool for working with the filesystem, for example, **File Explorer** on Windows or **Finder** on Mac.
2.	Navigate to your `C:` drive on Windows, your user folder on macOS (mine is named `markjprice`), or any directory or drive in which you want to save your projects.
3.	Create a new folder named `cs12dotnet8`. (If you completed the section for Visual Studio 2022, then this folder will already exist.)
4.	In the `cs12dotnet8` folder, create a new folder named `Chapter01-vscode`.

> If you did not complete the section for Visual Studio 2022, then you could name this folder `Chapter01`, but I will assume you will want to complete both sections and therefore need to use a non-conflicting name.

5.	In the `Chapter01-vscode` folder, open the command prompt or terminal.
6.	At the command prompt or terminal, use the dotnet CLI to create a new solution named `Chapter01`, as shown in the following command:
```
dotnet new sln --name Chapter01
```

> You can use either `-n` or `--name` as the switch to specify a name. The default would match the name of the folder, for example, `Chapter01-vscode`.

7.	Note the result, as shown in the following output:
```
The template "Solution File" was created successfully.
```

8.	At the command prompt or terminal, use the `dotnet` CLI to create a new subfolder and project for a console app named `HelloCS`, as shown in the following command:
```
dotnet new console --output HelloCS
```

> You can use either `-o` or `--output` as the switch. The `dotnet new console` command targets your latest .NET SDK version by default. To target a different version, use the `-f` or `--framework` switch to specify a target framework, for example .NET 6, as shown in the following command: `dotnet new console -f net6.0`.

9.	At the command prompt or terminal, use the dotnet CLI to add the project to the solution, as shown in the following command:
```
dotnet sln add HelloCS
```

10.	Note the results, as shown in the following output:
```
Project `HelloCS\HelloCS.csproj` added to the solution.
```

11.	At the command prompt or terminal, start Visual Studio Code and open the current folder indicated with a `.` (dot), as shown in the following command:
```
code .
```

12.	In Visual Studio Code, in **EXPLORER**, in the **CHAPTER01-VSCODE** folder view, expand the **HelloCS** project, and you will see that the `dotnet` command-line tool created a new console app project for you, with two files created, `HelloCS.csproj` and `Program.cs`, and `bin` and `obj` folders, as shown in *Figure 1.11*:

![EXPLORER shows that two files and a folder have been created](assets/vscode/B19586_01_11.png) 
*Figure 1.11: EXPLORER shows that two files and a folder have been created*

13.	Navigate to **View** | **Output**.
14.	In the **OUTPUT** pane, select **C# Dev Kit** and note the tool has recognized and processed the solution, as shown in *Figure 1.12*:

![C# Dev Kit processing a solution file](assets/vscode/B19586_01_12.png) 
*Figure 1.12: C# Dev Kit processing a solution file*

15.	At the bottom of **EXPLORER**, note the **SOLUTION EXPLORER**.
16.	Drag **SOLUTION EXPLORER** to the top of the **EXPLORER** pane and expand it.
17.	In **SOLUTION EXPLORER**, click on the file named `Program.cs` to open it in the editor window.
18.	In `Program.cs`, modify line 2 so that the text that is being written to the console says `Hello, C#!`

> **Good Practice**: Navigate to **File** | **Auto Save**. This toggle will save the annoyance of remembering to save before rebuilding your application each time.

### Compiling and running code using the dotnet CLI

The next task is to compile and run the code:
1.	In **SOLUTION EXPLORER**, right-click on any file in the `HelloCS` project and choose **Open in Integrated Terminal**.
2.	In **TERMINAL**, enter the following command: `dotnet run`.
3.	The output in the **TERMINAL** window will show the result of running your application, as shown in *Figure 1.13*:

![The output of running your first console app](assets/vscode/B19586_01_13.png) 
*Figure 1.13: The output of running your first console app*

4.	In `Program.cs`, after the statement that outputs the message, add statements to get the name of the namespace of the `Program` class, write it to the console, and then throw a new exception, as shown in the following code:
```cs
string name = typeof(Program).Namespace ?? "None!";
Console.WriteLine($"Namespace: {name}");

throw new Exception();
```

5.	In **TERMINAL**, enter the following command: `dotnet run`.

> In **TERMINAL**, you can press the up and down arrows to loop through previous commands and then press the left and right arrows to edit the command before pressing *Enter* to run them.

6.	The output in the **TERMINAL** window will show the result of running your application, including that a hidden `Program` class was defined by the compiler with a method named `<Main>$` that has a parameter named `args` for passing in arguments, and that it does not have a namespace, as shown in the following output:
```
Hello, C#!
Namespace: None!
Unhandled exception. System.Exception: Exception of type 'System.Exception' was thrown.
   at Program.<Main>$(String[] args) in C:\cs12dotnet8\Chapter01-vscode\HelloCS\Program.cs:line 7
```

## Adding a second project using Visual Studio Code

Let's add a second project to explore how to work with multiple projects:
1.	In **TERMINAL**, switch to a terminal in the `Chapter01-vscode` folder, and then enter the command to create a new console app project named `AboutMyEnvironment` using the older non-top-level program style, as shown in the following command:
```
dotnet new console -o AboutMyEnvironment --use-program-main
```

> **Good Practice**: Be careful when entering commands in **TERMINAL**. Be sure that you are in the correct folder before entering potentially destructive commands!

2.	In **TERMINAL**, use the `dotnet` CLI to add the new project folder to the solution, as shown in the following command:
```
dotnet sln add AboutMyEnvironment
```

3.	Note the results, as shown in the following output:
```
Project `AboutMyEnvironment\AboutMyEnvironment.csproj` added to the solution.
```

4.	In **SOLUTION EXPLORER**, in the `AboutMyEnvironment` project, open `Program.cs` and then in the `Main` method, change the existing statement to output the current directory, the operating system version string, and the namespace of the `Program` class, as shown in the following code:
```cs
Console.WriteLine(Environment.CurrentDirectory);
Console.WriteLine(Environment.OSVersion.VersionString);
Console.WriteLine("Namespace: {0}", typeof(Program).Namespace);
```

5.	In **SOLUTION EXPLORER**, right-click on any file in the `AboutMyEnvironment` project and choose **Open in Integrated Terminal**.
6.	In **TERMINAL**, enter the command to run the project, as shown in the following command: `dotnet run`.
7.	Note the output in the **TERMINAL** window, as shown in the following output and in *Figure 1.14*:
```
C:\cs12dotnet8\Chapter01-vscode\AboutMyEnvironment
Microsoft Windows NT 10.0.22621.0
Namespace: AboutMyEnvironment
```

![Running a console app in Visual Studio Code with two projects](assets/vscode/B19586_01_14.png)
*Figure 1.14: Running a console app in Visual Studio Code with two projects*

Note that once you open multiple terminal windows, you can toggle between them by clicking their names in the panel on the right-side of **TERMINAL**. By default, the name will be `pwsh` (PowerShell) followed by the active folder. Right-click and choose rename to assign something else.

When using Visual Studio Code, or more accurately, the `dotnet` CLI, to run a console app, it executes the app from the `<projectname>` folder. When using Visual Studio 2022 for Windows, it executes the app from the `<projectname>\bin\Debug\net8.0` folder. It will be important to remember this when we work with the filesystem in later chapters. 

If you were to run the program on macOS Big Sur, the environment operating system would be different, as shown in the following output:
```
Unix 11.2.3
```

> **Good Practice**: Although the source code, like the `.csproj` and `.cs` files, is identical, the `bin` and `obj` folders that are automatically generated by the compiler could have content mismatches that give you errors. If you want to open the same project in both Visual Studio 2022 and Visual Studio Code, delete the temporary `bin` and `obj` folders before opening the project in the other code editor. This potential problem is why I asked you to create a different folder for the Visual Studio Code projects in this chapter.

## Summary of steps for Visual Studio Code

Follow these steps to create a solution and projects using Visual Studio Code:
1.	Create a folder for the solution, for example, `Chapter01`.
2.	Create a solution file in the folder: `dotnet new sln`.
3.	Create a folder and project: `dotnet new console -o HelloCS`.
4.	Add the folder to the solution: `dotnet sln add HelloCS`.
5.	Repeat steps 4 and 5 to create and add any other projects.
6.	Open the folder containing the solution using Visual Studio Code: `code .`

**Console Apps** (`dotnet new console`) are just one type of project template. In this book you will also create **Class Libraries** (`dotnet new classlib`), empty websites (`dotnet new web`), MVC websites (`dotnet new mvc`), Web API services (`dotnet new webapi`), Blazor websites (`dotnet new blazor`), and so on.

# Chapter 4

# Chapter 7 - Packaging and Distributing .NET Types

## Decompiling using the ILSpy extension for Visual Studio Code

A similar capability is available cross-platform as an extension for Visual Studio Code.

1.	If you have not already installed the ILSpy .NET Decompiler extension for Visual Studio Code, then search for it and install it now.
2.	On macOS or Linux the extension has a dependency on Mono so you will also need to install Mono from the following link: https://www.mono-project.com/download/stable/.
3.	In Visual Studio Code, navigate to **View** | **Command Palette…**.
4.	Type `ilspy` and then select **ILSpy: Pick assembly from file system**.
5.	Navigate to the following folder:
`cs11dotnet7/Chapter07/DotNetEverywhere/bin/Release/net7.0/linux-x64`
6.	Select the `System.IO.FileSystem.dll` assembly and click **Select assembly**. Nothing will appear to happen, but you can confirm that ILSpy is working by viewing the **Output** window, selecting **ILSpy Extension** in the dropdown list, and seeing the processing, as shown in Figure 7.6:
![]()
*Figure 7.6: ILSpy extension output when selecting an assembly to decompile*

7.	In **EXPLORER**, expand **ILSPY DECOMPILED MEMBERS**, select the assembly, and close the **Output** window.
8.	
9.	Click the **Output language** button, select **IL**, and note the edit window now shows assembly attributes using C# code and external DLL and assembly references using IL code, as shown in *Figure 7.7*:

*Figure 7.7: Expanding ILSPY DECOMPILED MEMBERS*

10.	In the IL code on the right side, note the reference to the `System.Runtime` assembly, including the version number, as shown in the following code:
```
.module extern libSystem.Native
.assembly extern System.Runtime
{
  .publickeytoken = (
    b0 3f 5f 7f 11 d5 0a 3a
  )
  .ver 6:0:0:0
}
.module extern lib
```
`System.Native` means this assembly makes function calls to Linux system APIs as you would expect from code that interacts with the filesystem. If we had decompiled the Windows equivalent of this assembly, it would use `.module extern kernel32.dll` instead, which is a Win32 API.

11.	In **EXPLORER**, in **ILSPY DECOMPILED MEMBERS**, expand the assembly, expand the `System.IO` namespace, select `Directory`, and note the two edit windows that open showing the decompiled `Directory` class using C# code on the left and IL code on the right, as shown in *Figure 7.8*:
 
*Figure 7.8: The decompiled Directory class in C# and IL code*

12.	Compare the C# source code for the `GetParent` method, shown in the following code:
```cs
public static DirectoryInfo? GetParent(string path)
{
  if (path == null)
  {
    throw new ArgumentNullException("path");
  }
  if (path.Length == 0)
  {
    throw new ArgumentException(SR.Argument_PathEmpty, "path");
  }
  string fullPath = Path.GetFullPath(path);
  string directoryName = Path.GetDirectoryName(fullPath);
  if (directoryName == null)
  {
    return null;
  }
  return new DirectoryInfo(directoryName);
}
```
13.	With the equivalent IL source code of the `GetParent` method, as shown in the following code:
```
.method /* 06000067 */ public hidebysig static 
  class System.IO.DirectoryInfo GetParent (
    string path
  ) cil managed
{
  .param [0]
    .custom instance void System.Runtime.CompilerServices
    .NullableAttribute::.ctor(uint8) = ( 
      01 00 02 00 00
    )
  // Method begins at RVA 0x62d4
  // Code size 64 (0x40)
  .maxstack 2
  .locals /* 1100000E */ (
    [0] string,
    [1] string
  )
  IL_0000: ldarg.0
  IL_0001: brtrue.s IL_000e
  IL_0003: ldstr "path" /* 700005CB */
  IL_0008: newobj instance void [System.Runtime]
    System.ArgumentNullException::.ctor(string) /* 0A000035 */
  IL_000d: throw
  IL_000e: ldarg.0
  IL_000f: callvirt instance int32 [System.Runtime]
    System.String::get_Length() /* 0A000022 */
  IL_0014: brtrue.s IL_0026
  IL_0016: call string System.SR::get_Argument_PathEmpty() /* 0600004C */
  IL_001b: ldstr "path" /* 700005CB */
  IL_0020: newobj instance void [System.Runtime]
    System.ArgumentException::.ctor(string, string) /* 0A000036 */
  IL_0025: throw IL_0026: ldarg.0
  IL_0027: call string [System.Runtime.Extensions]
    System.IO.Path::GetFullPath(string) /* 0A000037 */
  IL_002c: stloc.0 IL_002d: ldloc.0
  IL_002e: call string [System.Runtime.Extensions]
    System.IO.Path::GetDirectoryName(string) /* 0A000038 */
  IL_0033: stloc.1
  IL_0034: ldloc.1
  IL_0035: brtrue.s IL_0039 IL_0037: ldnull
  IL_0038: ret IL_0039: ldloc.1
  IL_003a: newobj instance void 
    System.IO.DirectoryInfo::.ctor(string) /* 06000097 */
  IL_003f: ret
} // end of method Directory::GetParent
```
> **Good Practice**: The IL code is not especially useful unless you get very advanced with C# and .NET development when knowing how the C# compiler translates your source code into IL code can be important. The much more useful edit windows contain the equivalent C# source code written by Microsoft experts. You can learn a lot of good practices from seeing how professionals implement types. For example, the `GetParent` method shows how to check arguments for `null` and other argument exceptions.
14.	Close the edit windows without saving changes.
15.	In **EXPLORER**, in **ILSPY DECOMPILED MEMBERS**, right-click the assembly and choose **Unload Assembly**.
