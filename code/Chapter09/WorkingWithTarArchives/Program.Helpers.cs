partial class Program
{
  private static void WriteError(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"FAIL: {message}");
    ForegroundColor = previousColor;
  }

  private static void WriteWarning(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"WARN: {message}");
    ForegroundColor = previousColor;
  }

  private static void WriteInformation(string message)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Blue;
    WriteLine($"INFO: {message}");
    ForegroundColor = previousColor;
  }
}
