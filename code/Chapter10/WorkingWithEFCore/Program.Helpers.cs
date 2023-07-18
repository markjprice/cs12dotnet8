using System.Globalization;

partial class Program
{
  static void ConfigureConsole(string culture = "en-US",
    bool useComputerCulture = false)
  {
    // To enable Unicode characters like Euro symbol in the console.
    OutputEncoding = System.Text.Encoding.UTF8;

    if (!useComputerCulture)
    {
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }
    WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
  }

  static void SectionTitle(string title)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"*** {title} ***");
    ForegroundColor = previousColor;
  }

  static void Fail(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"Fail > {message}");
    ForegroundColor = previousColor;
  }

  static void Info(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Cyan;
    WriteLine($"Info > {message}");
    ForegroundColor = previousColor;
  }
}
