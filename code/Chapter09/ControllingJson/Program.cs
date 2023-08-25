using Packt.Shared; // To use Book.
using System.Text.Json; // To use JsonSerializer.

Book csharpBook = new(title:
  "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
  Author = "Mark J Price",
  PublishDate = new(year: 2023, month: 11, day: 7),
  Pages = 823,
  Created = DateTimeOffset.UtcNow,
};

JsonSerializerOptions options = new()
{
  IncludeFields = true, // Includes all fields.
  //PropertyNameCaseInsensitive = true,
  //WriteIndented = true,
  //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

string path = Combine(CurrentDirectory, "book.json");

using (Stream fileStream = File.Create(path))
{
  JsonSerializer.Serialize(
    utf8Json: fileStream, value: csharpBook, options);
}

WriteLine("**** File Info ****");
WriteLine($"File: {GetFileName(path)}");
WriteLine($"Path: {GetDirectoryName(path)}");
WriteLine($"Size: {new FileInfo(path).Length:N0} bytes.");
WriteLine("/------------------");
WriteLine(File.ReadAllText(path));
WriteLine("------------------/");
