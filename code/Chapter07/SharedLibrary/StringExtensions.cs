using System.Text.RegularExpressions; // To use Regex.

namespace Packt.Shared;

public static class StringExtensions
{
  public static bool IsValidXmlTag(this string input)
  {
    return Regex.IsMatch(input,
      @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
  }

  public static bool IsValidPassword(this string input)
  {
    // Minimum of eight valid characters.
    return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
  }

  public static bool IsValidHex(this string input)
  {
    // Three or six valid hex number characters.
    return Regex.IsMatch(input,
      "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
  }
}
