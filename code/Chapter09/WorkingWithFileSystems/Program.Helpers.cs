// null namespace to merge with auto-generated Program.

partial class Program
{
  private static void SectionTitle(string title)
  {
    WriteLine();
    ConsoleColor previousColor = ForegroundColor;
    // Use a color that stands out on your system.
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"*** {title} ***");
    ForegroundColor = previousColor;
  }
}
