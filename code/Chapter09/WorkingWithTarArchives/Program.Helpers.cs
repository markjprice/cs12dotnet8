partial class Program
{
  static void WriteError(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"FAIL: {message}");
    ForegroundColor = previousColor;
  }

  static void WriteWarning(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"WARN: {message}");
    ForegroundColor = previousColor;
  }

  static void WriteInformation(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Blue;
    WriteLine($"INFO: {message}");
    ForegroundColor = previousColor;
  }
}
