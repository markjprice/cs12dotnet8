**Common Mistakes and How to Fix Them** (7 items)

If you have suggestions for other common mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Missing property setter in entity model](#missing-property-setter-in-entity-model)
- [MSB3026/MSB3027 Cannot rebuild/compile a project](#msb3026msb3027-cannot-rebuildcompile-a-project)
- [Microsoft introduces a bug in a later version](#microsoft-introduces-a-bug-in-a-later-version)
- [Visual Studio removes a required file from the build process](#visual-studio-removes-a-required-file-from-the-build-process)
- [Service not started when you try to call it](#service-not-started-when-you-try-to-call-it)
- [Missing types and members in a utility class](#missing-types-and-members-in-a-utility-class)
  - [CS0103 The name 'DoSomething' does not exist in the current context](#cs0103-the-name-dosomething-does-not-exist-in-the-current-context)
  - [CS0122 'Util.DoSomething()' is inaccessible due to its protection level](#cs0122-utildosomething-is-inaccessible-due-to-its-protection-level)
- [Missing functions in the partial Program class](#missing-functions-in-the-partial-program-class)
  - [CS0103 The name 'DoSomethingElse' does not exist in the current context](#cs0103-the-name-dosomethingelse-does-not-exist-in-the-current-context)

# Missing property setter in entity model

When defining an entity model like `Category` with a navigation property like `Products`, make sure to define both `get` and `set` methods for the property, as shown in the following code:
```cs
using System.ComponentModel.DataAnnotations.Schema; // To use [Column].

namespace Northwind.EntityModels;

public class Category
{
  // These properties map to columns in the database.
  public int CategoryId { get; set; } // The primary key.

  public string CategoryName { get; set; } = null!;

  [Column(TypeName = "ntext")]
  public string? Description { get; set; }

  // Defines a navigation property for related rows.
  public virtual ICollection<Product> Products { get; set; }
    // To enable developers to add products to a Category, we must
    // initialize the navigation property to an empty collection.
    // This also avoids an exception if we get a member like Count.
    = new HashSet<Product>();
}
```

Some readers mistakenly only define a "getter" without a "setter", as shown in the following code:
```cs
public virtual ICollection<Product> Products { get; }
```

The side-affect of this mistake is that related entities will not be loaded or deserialized, as in this issue: https://github.com/markjprice/apps-services-net7/issues/30

# MSB3026/MSB3027 Cannot rebuild/compile a project

While actively working on a project, you often run an app, it "crashes", you make a code change, recompile, and run it again. Sometimes recompiling will fail with the following warning:
```
Warning	MSB3026	Could not copy "C:\cs11dotnet7\Chapter02\Ch02Ex03Numbers\obj\Debug\net7.0\apphost.exe" to "bin\Debug\net7.0\Ch02Ex03Numbers.exe". Beginning retry 1 in 1000ms. The process cannot access the file 'bin\Debug\net7.0\Ch02Ex03Numbers.exe' because it is being used by another process. The file is locked by: "Ch02Ex03Numbers (9728)"
```

By default, the warning repeats ten times and then you will see the following error:
```
Error	MSB3027	Could not copy "C:\cs11dotnet7\Chapter02\Ch02Ex03Numbers\obj\Debug\net7.0\apphost.exe" to "bin\Debug\net7.0\Ch02Ex03Numbers.exe". Exceeded retry count of 10. Failed. The file is locked by: "Ch02Ex03Numbers (9728)"
```

These messages tell you that you are still running the old console app process so that the build process cannot copy the new version over the old version. 

To solve this problem, close the running console app. 

If you cannot find the console app to close it, then it might still be running but not visible in the operating system. 

To solve this problem, reboot your computer.

> Although I use a console app (EXE) in the example above, this issue also applies to class libraries (DLL). You would need to shut down any processes that have the DLL loaded into memory before you can rebuild the class library.

# Microsoft introduces a bug in a later version

Although rare, it is possible that by using a later version of a NuGet package than the one I used to write the book, you experience different behavior, especially negative behavior if it is due to a bug. 

For example, in the `Microsoft.Extensions.Configuration.Binder` package, in version `7.0.3` or later, then they have fixed a bug, but the fix causes a regression in expected behavior which means that unless we change how we set the trace switch level an exception will be thrown. Previous versions from `7.0.0` to `7.0.2` did not have this bug fix.

You can read more this specific example here: https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/errata.md#page-178---reviewing-project-packages

If you add packages using the Visual Studio 2022 user interface or the `dotnet add package` command-line tool then it will use the most recent version by default which can cause this issue when Microsoft adds any bugs to any packages in future. If you have problems, try manually reverting to an older version.

You can output the assembly version using the following code:
```cs
Console.WriteLine("Microsoft.Extensions.Configuration.Binder version: {0}", 
  typeof(ConfigurationBinder).Assembly.GetCustomAttribute
  <AssemblyFileVersionAttribute>()?.Version);
```

If you reference the `Microsoft.Extensions.Configuration.Binder` package version `7.0.2`, then the preceding code will output the following:
```
Microsoft.Extensions.Configuration.Binder version: 7.0.222.60605
```

If you reference the `Microsoft.Extensions.Configuration.Binder` package version `7.0.4`, then the preceding code will output the following:
```
Microsoft.Extensions.Configuration.Binder version: 7.0.423.11508
```

> When changing a package version in the project file, you must **rebuild** the project when using Visual Studio, not just build it, otherwise it will try to be "smart" and not restore the correct packages!

# Visual Studio removes a required file from the build process

You might be working on any type of project, although it happens most often with ASP.NET Core projects, and you have added a new file. 

For example, you might have added a new Razor Page file in the `Pages` folder named `index.cshtml`. You start the web server but the page does not appear. Or you are working on a GraphQL service and you add a file named `seafoodProducts.graphql`. But when you run the GraphQL tool to auto-generate client-side proxies, it fails.

These are both common indications that Visual Studio 2022 has decided that the new file should not be part of the project. It has automatically added an entry to the project file to remove the file without telling you.

To solve this type of problem, review the project file for unexpected entries like the following, and delete them:
```xml
<ItemGroup>
  <Content Remove="Pages\index.cshtml" />
</ItemGroup>

<ItemGroup>
  <GraphQL Remove="seafoodProducts.graphql" />
</ItemGroup>
```

# Service not started when you try to call it

A common mistake is to start a client app that talks to service without first starting the service. When you do this, you will likely see the following error:
```
The [project_name] service is not responding. Exception: No connection could be made because the target machine actively refused it. (localhost:[port_number])
```

To fix the issue, start the service project first, then start the client project. 

If you use Visual Studio 2022 then you can configure multiple startup projects automatically by right-clicking a solution and choosing **Set Startup Projects...**.

# Missing types and members in a utility class

## CS0103 The name 'DoSomething' does not exist in the current context

You might create a utility class with a method, as shown in the following code:
```cs
namespace Common.Errors;

public class Util
{
  static void DoSomething()
  {
    Console.WriteLine("Doing something.");
  }
}
```

You try to call the method directly (without any class name prefix) in the `Program.cs` file, as shown in the following code:
```cs
using Common.Errors;

DoSomething(); // This causes: CS0103 The name 'DoSomething' does not exist in the current context.
```

The class is declared inside the `Common.Errors` namespace and you have imported the `Common.Errors` namespace in `Program.cs` so why can't it be found? 

First, you need to *statically import the class* rather than just import it's namespace, as shown in the following code:
```cs
using static Common.Errors.Util; // Statically import the class to call its static methods.
```

## CS0122 'Util.DoSomething()' is inaccessible due to its protection level

But now you get a different compiler error, as shown in the following code:
```cs
DoSomething(); // This causes: CS0122 'Util.DoSomething()' is inaccessible due to its protection level.
```

Next, by default members of a class are `private` so you must explicitly make the method `public` or `internal`, as shown in the following code:
```cs
namespace Common.Errors;

public class Util
{
  public static void DoSomething()
  {
    Console.WriteLine("Doing something.");
  }
}
```

Now the method call works.

# Missing functions in the partial Program class

## CS0103 The name 'DoSomethingElse' does not exist in the current context

In my book, I show how to define functions that can be easily called directly in the `Program.cs` file because you add them to the `partial Program` class definition. You can put these functions in a separate file, for example, `Program.Helpers.cs`, as shown in the following code:

```cs
// A file named Program.Helpers.cs.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Errors
{
  partial class Program
  {
    static void DoSomethingElse()
    {
      Console.WriteLine("Doing something else.");
    }
  }
}
```

> Note: The above file might have been created by the Visual Studio 2022 project item template. It imports five commonly used namespaces and wraps the class in a namespace that is the name of the project.

You try to call the method directly (without any class name prefix) in the `Program.cs` file, as shown in the following code:
```cs
DoSomethingElse(); // This causes: CS0103 The name 'DoSomethingElse' does not exist in the current context.
```

The class is declared as `Program` and uses the `partial` keyword so why doesn't it merge with the auto-generated `Program` class? Because it is a different namespace and therefore you now have two classes named `Program`. The fully qualified name of your class is `Common.Errors.Program`. The fully-qualified name of the auto-generated class is just `Program`.

To fix the problem, delete the explicit namespace (and you might as well remove the unncessary imported namespaces at the same time), as shown in the following code:
```cs
// A file named Program.Helpers.cs.
partial class Program
{
  static void DoSomethingElse()
  {
    Console.WriteLine("Doing something else.");
  }
}
```

> Note: The filename is not important and you can have as many files as you like, for example, `Program.Helpers.cs`, `Program.Functions.cs`, `Any.Thing.cs`, and even `Muppets.cs`.
