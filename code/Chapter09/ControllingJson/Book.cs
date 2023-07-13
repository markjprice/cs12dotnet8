using System.Text.Json.Serialization; // To use [JsonInclude].

namespace Packt.Shared;

public class Book
{
  // Constructor to set non-nullable property.
  public Book(string title)
  {
    Title = title;
  }

  // Properties.
  public string Title { get; set; }
  public string? Author { get; set; }

  // Fields.
  [JsonInclude] // Include this field.
  public DateTime PublishDate;

  [JsonInclude] // Include this field.
  public DateTimeOffset Created;

  public ushort Pages;
}
