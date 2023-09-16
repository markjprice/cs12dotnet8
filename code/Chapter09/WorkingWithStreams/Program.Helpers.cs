// null namespace to merge with auto-generated Program.

partial class Program
{
  private static void SectionTitle(string title)
  {
    ConsoleColor previousColor = ForegroundColor;
    // Use a color that stands out on your system.
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"*** {title} ***");
    ForegroundColor = previousColor;
  }

  private static void OutputFileInfo(string path)
  {
    WriteLine("**** File Info ****");
    WriteLine($"File: {GetFileName(path)}");
    WriteLine($"Path: {GetDirectoryName(path)}");
    WriteLine($"Size: {new FileInfo(path).Length:N0} bytes.");
    WriteLine("/------------------");
    WriteLine(File.ReadAllText(path));
    WriteLine("------------------/");
  }
}
