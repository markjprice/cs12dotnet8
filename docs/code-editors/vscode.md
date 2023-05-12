**Using Visual Studio Code**

In this article, I provide detailed step-by-step instuctions for using Visual Studio Code for topics like creating a solution with multiple projects and using debugging tools.

- [Chapter 1](#chapter-1)
- [Chapter 4](#chapter-4)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Decompiling using the ILSpy extension for Visual Studio Code](#decompiling-using-the-ilspy-extension-for-visual-studio-code)

# Chapter 1

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
