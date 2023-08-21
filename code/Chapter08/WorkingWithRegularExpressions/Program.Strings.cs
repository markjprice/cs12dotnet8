using System.Diagnostics.CodeAnalysis; // To use [StringSyntax].

partial class Program
{
  [StringSyntax(StringSyntaxAttribute.Regex)]
  private const string DigitsOnlyText = @"^\d+$";

  [StringSyntax(StringSyntaxAttribute.Regex)]
  private const string CommaSeparatorText =
    "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)";

  [StringSyntax(StringSyntaxAttribute.DateTimeFormat)]
  private const string FullDateTime = "dddd, d MMMM yyyy";
}
