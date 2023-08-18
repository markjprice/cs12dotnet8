namespace Packt.Shared;

// A mutable record class.
record class C1
{
  public string? Name { get; set; }
}

// An immutable record class.
record class C2(string? Name);

// A mutable record struct.
record struct S1
{
  public string? Name { get; set; }
}

// Another mutable record struct.
record struct S2(string? Name);

// An immutable record struct.
readonly record struct S3(string? Name);
