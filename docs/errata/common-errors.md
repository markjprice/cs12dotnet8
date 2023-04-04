**Common Errors and How to Fix Them** (3 items)

If you have suggestions for other common errors, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Missing types and members in a utlity class](#missing-types-and-members-in-a-utlity-class)
  - [CS0103 The name 'DoSomething' does not exist in the current context](#cs0103-the-name-dosomething-does-not-exist-in-the-current-context)
  - [CS0122 'Util.DoSomething()' is inaccessible due to its protection level](#cs0122-utildosomething-is-inaccessible-due-to-its-protection-level)
- [Missing types and members in the Program class](#missing-types-and-members-in-the-program-class)
- [Microsoft introduces a bug in a later version](#microsoft-introduces-a-bug-in-a-later-version)

# Missing types and members in a utlity class

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

# Missing types and members in the Program class

In my book, I show how to define functions that can be easily called directly in the `Program.cs` file because you add them to the `partial Program` class definition. You can put these functions in a separate file, for example, `Program.Helpers.cs`, as shown in the following code:

> Note: The filename is not important and you can have as many files as you like, for example, `Program.Helpers.cs`, `Program.Functions.cs`, `Any.Thing.cs`, and even `Muppets.cs`.

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

> Note: The above file was created by the Visual Studio 2022 project item template. It imports five commonly used namespaces and wraps the class in a namespace that uses the name of the project.

You try to call the method directly (without any class name prefix) in the `Program.cs` file, as shown in the following code:
```cs
DoSomethingElse(); // This causes: CS0103 The name 'DoSomething' does not exist in the current context.
```

The class is declared as `Program` and uses the `partial` keyword so why doesn't it merge with the auto-generated `Program` class? Because it is a different namespace and therefore you now have two classes named `Program`. The fully qualified name of your class is `Common.Errors.Program`. The fully-qualified name of the auto-generated class is just `Program`.

To fix the problem, delete the explicit namespace (and remove the unncessary imported namespaces too), as shown in the following code:
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

# Microsoft introduces a bug in a later version

Although rare, it is possible that by using a later version of a NuGet package than the one I used to write the book, you experience different behavior, especially negative behavior if it is due to a bug. 

For example, in the `Microsoft.Extensions.Configuration.Binder` package, version `7.0.3` has a bug. Previous versions from `7.0.0` to `7.0.0` do not have the bug.

You can read more here: https://github.com/markjprice/cs11dotnet7/blob/main/docs/errata/errata.md#page-178---reviewing-project-packages

If you add packages using the Visual Studio 2022 user interface or the `dotnet add package` command-line tool then it will use the most recent version. If you have problems, try manually reverting to an older version.
