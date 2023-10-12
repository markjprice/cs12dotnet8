**Working with environment variables**

Environment variables are system and user-definable values that can affect the way running processes behave. They are commonly used to set options like toggling between development and production configurations in ASP.NET Core web projects, or to pass values needed by a process like service keys and passwords for database connection strings.

Environment variables on Windows can be set at three scope levels: machine (aka system), user, and process. The methods for setting and getting environment variables assume process scope level by default and have overloads to specify the `EnvironmentVariableTarget` of `Process`, `User`, and `Machine`, as shown in *Table 9.7*:

Method|Description
---|---
`GetEnvironmentVariables`|Returns an `IDictionary` of all environment variables at a specified scope level or for the current process by default.
`GetEnvironmentVariable`|Returns the value for a named environment variable.
`SetEnvironmentVariable`|Sets the value for a named environment variable.
`ExpandEnvironmentVariables`|Converts any environment variables in a string to their values identified with `%%`. For example, `"My computer is named %COMPUTER_NAME%"`.

*Table 9.7: Methods to work with environment variables*

# Reading all environment variables

Let's start by looking at how to list all current environment variables at various levels of scope:

1.	Use your preferred code editor to add a new **Console App** / `console` project named `WorkingWithEnvVars` to the `Chapter09` solution.
2.	In the project file, add a package reference for `Spectre.Console`, and then add elements to statically and globally import the `System.Console` and `System.Environment` classes, and finally import the namespaces to work with `Spectre.Console` and `System.Collections`, as shown in the following configuration:
```xml
<ItemGroup>
  <PackageReference Include="Spectre.Console" Version="0.47.0" />
</ItemGroup>

<ItemGroup>
  <Using Include="System.Console" Static="true" />
  <Using Include="System.Environment" Static="true" />
  <Using Include="Spectre.Console" />
  <Using Include="System.Collections" />
</ItemGroup>
```

3.	Add a new class file named `Program.Helpers.cs`.
4.	In `Program.Helpers.cs`, add a `partial Program` class with a `SectionTitle` and a `DictionaryToTable` method, as shown in the following code:
```cs
// null namespace to merge with auto-generated Program.

partial class Program
{
  private static void SectionTitle(string title)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"*** {title} ***");
    ForegroundColor = previousColor;
  }

  private static void DictionaryToTable(IDictionary dictionary)
  {
    Table table = new();
    table.AddColumn("Key");
    table.AddColumn("Value");

    foreach (string key in dictionary.Keys)
    {
      table.AddRow(key, dictionary[key]!.ToString()!);
    }

    AnsiConsole.Write(table);
  }
}
```

5.	In `Program.cs`, delete any existing statements, and write statements to show all the environment variables at the three different scopes, as shown in the following code:

```cs
SectionTitle("Reading all environment variables for process");
IDictionary vars = GetEnvironmentVariables();
DictionaryToTable(vars);

SectionTitle("Reading all environment variables for machine");
IDictionary varsMachine = GetEnvironmentVariables(
  EnvironmentVariableTarget.Machine);
DictionaryToTable(varsMachine);

SectionTitle("Reading all environment variables for user");
IDictionary varsUser = GetEnvironmentVariables(
  EnvironmentVariableTarget.User);
DictionaryToTable(varsUser);
```

6.	Run the code and view the result, as shown in the following partial output:
```
*** Reading all environment variables for process ***
┌─────────────────┬──────────────────────────────────────────────────┐
│ Key             │ Value                                            │
├─────────────────┼──────────────────────────────────────────────────┤
│ HOMEPATH        │ \Users\markj                                     │
...
└─────────────────┴──────────────────────────────────────────────────┘
```

# Expanding, setting, and getting an environment variables

Often you need to format a string that contains embedded environment variables. They are defined by surrounding the variable name with percent symbols, as shown in the following text:
```
My username is %USERNAME%. My CPU is %PROCESSOR_IDENTIFIER%.
```

To set an environment variable at the command prompt on Windows, use the `set` or `setx` commands, as shown in *Table 9.8*:

Scope Level|Command
---|---
Session/Shell|`set MY_ENV_VAR="Alpha"`
User|`setx MY_ENV_VAR "Beta"`
Machine|`setx MY_ENV_VAR "Gamma" /M`

*Table 9.8: Commands to set an environment variable on Windows*

The `set` command defines a temporary environment variable that can be read immediately in the current shell or session. Note that it uses an equal sign `=` to assign the value.

The `setx` command defines a permanent environment variable but after defining it, you must close the current shell or session and restart the shell for the environment variable to be read. Note that it does not use an equal sign to assign the value!

> **More Information**: You can learn more about the setx command here: https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/setx.

You can also manage environment variables with a user interface on Windows: Navigate to **Settings** | **System** | **About** | **Advanced system settings**, and then in the **System Properties** dialog box, click **Environment Variables**.

To temporarily set an environment variable at the command prompt or terminal on macOS or Linux, you can use the `export` command, as shown in the following command:
```
export MY_ENV_VAR=Delta
```

> **More Information**: You can learn more about the `export` command here: https://ss64.com/bash/export.html.

Let's see some examples of expanding, setting in various ways, and getting environment variables:

1.	In `Program.cs`, add statements to define a string that contains a couple of environment variables (if the ones I picked are not defined on your computer, then pick any other two that you do have defined) and then expand them and output them to the console, as shown in the following code:
```cs
string myComputer = "My username is %USERNAME%. My CPU is %PROCESSOR_IDENTIFIER%.";

WriteLine(ExpandEnvironmentVariables(myComputer));
```

2.	Run the code and view the result, as shown in the following output:
```
My username is markj. My CPU is Intel64 Family 6 Model 140 Stepping 1, GenuineIntel.
```

3.	In `Program.cs`, add statements to set a process scoped environment variable named `MY_PASSWORD` and then get it and output it, as shown in the following code:
```cs
string password_key = "MY_PASSWORD";

SetEnvironmentVariable(password_key, "Pa$$w0rd");

string? password = GetEnvironmentVariable(password_key);

WriteLine($"{password_key}: {password}");
```

4.	Run the code and view the result, as shown in the following output:
```
MY_PASSWORD: Pa$$w0rd
```

> In a real-world app, you might pass an argument to the console that is then used to set the process scope environment variable on startup for reading later in the process lifetime.

5.	In `Program.cs`, add statements to try to get an environment variable named `MY_PASSWORD` at all three potential scope levels, and then output them, as shown in the following code:
```cs
string secret_key = "MY_SECRET";

string? secret = GetEnvironmentVariable(secret_key, 
  EnvironmentVariableTarget.Process);
WriteLine($"Process - {secret_key}: {secret}");

secret = GetEnvironmentVariable(secret_key,
  EnvironmentVariableTarget.Machine);
WriteLine($"Machine - {secret_key}: {secret}");

secret = GetEnvironmentVariable(secret_key,
  EnvironmentVariableTarget.User);
WriteLine($"User    - {secret_key}: {secret}");
```

6.	If you are using Visual Studio 2022, then navigate to **Project** | **WorkingWithEnvVars Properties**, click the **Debug** tab, and then click **Open debug launch profiles UI**. In the **Environment variables** section, add an entry with **Name** `MY_SECRET` and Value of `Alpha`.
7.	In the `Properties` folder, open `launchSettings.json`, and note the configured environment variables, as shown in the following configuration:
```json
{
  "profiles": {
    "WorkingWithEnvVars": {
      "commandName": "Project",
      "environmentVariables": {
        "MY_SECRET": "Alpha"
      }
    }
  }
}
```

> If you are using a different code editor, then you can manually create the `launchSettings.json` file. Environment variables defined in the `launchSettings.json` file are set at process scope.

8.	At the command prompt or terminal with administrator permissions, set some environment variables at the user and machine scope levels on Windows, as shown in the following commands:
```
setx MY_SECRET "Beta"
setx MY_SECRET "Gamma" /M
```

9.	Note the result for each command, as shown in the following output:
```
SUCCESS: Specified value was saved.
```

> On macOS or Linux, use the `export` command instead. 

10.	Run the code and view the result, as shown in the following output:
```
Process - MY_SECRET: Alpha
Machine - MY_SECRET: Gamma
User    - MY_SECRET: Beta
```

Now that you have seen how to work with environment variables, we can use them in future chapters to set options like passwords rather than store those sensitive values in code.
