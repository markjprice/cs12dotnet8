// To use [Generator], ISourceGenerator, and so on.
using Microsoft.CodeAnalysis; 

namespace Packt.Shared;

[Generator]
public class ProgramSourceGenerator : ISourceGenerator
{
  public void Execute(GeneratorExecutionContext execContext)
  {
    IMethodSymbol? mainMethod = execContext.Compilation
      .GetEntryPoint(execContext.CancellationToken);
    
    string sourceCode = $@"// Source-generated class.
#nullable enable

using System.Globalization; // To use CultureInfo.

partial class {mainMethod?.ContainingType.Name}
{{
  private static CultureInfo? _computerCulture = null;

  public static void ConfigureConsole(
    string culture = ""en-US"",
    bool useComputerCulture = false,
    bool showCulture = true)
  {{
    // Store the original computer culture so we can reset it later.
    if (_computerCulture is null)
    {{
      _computerCulture = CultureInfo.CurrentCulture;
    }}

    // Enable special characters like Euro currency symbol.
    OutputEncoding = System.Text.Encoding.UTF8;

    if (useComputerCulture)
    {{
      CultureInfo.CurrentCulture = _computerCulture;
    }}
    else
    {{
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }}

    if (showCulture)
    {{
      WriteLine($""Current culture: {{CultureInfo.CurrentCulture.DisplayName}}."");
    }}
  }}
}}
";

    string fileName = $"{mainMethod?.ContainingType.Name}.Methods.g.cs";
    execContext.AddSource(fileName, sourceCode);
  }

  public void Initialize(GeneratorInitializationContext initContext)
  {
    // This source generator does not need any initialization.
  }
}
