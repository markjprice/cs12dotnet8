using System.Text.RegularExpressions; // To use Regex.

namespace Packt.Shared;

public static class StringExtensions
{
  public static bool IsValidEmail(this string input)
  {
    // Use a simple regular expression to check
    // that the input string is a valid email.

    return Regex.IsMatch(input,
      @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
  }
}
