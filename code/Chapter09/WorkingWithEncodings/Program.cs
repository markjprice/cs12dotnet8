using System.Text; // To use Encoding.

WriteLine("Encodings");
WriteLine("[1] ASCII");
WriteLine("[2] UTF-7");
WriteLine("[3] UTF-8");
WriteLine("[4] UTF-16 (Unicode)");
WriteLine("[5] UTF-32");
WriteLine("[6] Latin1");
WriteLine("[any other key] Default encoding");
WriteLine();

Write("Press a number to choose an encoding.");
ConsoleKey number = ReadKey(intercept: true).Key;
WriteLine(); WriteLine();

Encoding encoder = number switch
{
  ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
  ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
  ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
  ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
  ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
  ConsoleKey.D6 or ConsoleKey.NumPad6 => Encoding.Latin1,
  _ => Encoding.Default
};

// Define a string to encode
string message = "Café £4.39";
WriteLine($"Text to encode: {message}  Characters: {message.Length}.");

// Encode the string into a byte array.
byte[] encoded = encoder.GetBytes(message);

// Check how many bytes the encoding needed.
WriteLine("{0} used {1:N0} bytes.",
  encoder.GetType().Name, encoded.Length);
WriteLine();

// Enumerate each byte.
WriteLine("BYTE | HEX | CHAR");
foreach (byte b in encoded)
{
  WriteLine($"{b,4} | {b,3:X} | {(char)b,4}");
}

// Decode the byte array back into a string and display it.
string decoded = encoder.GetString(encoded);
WriteLine($"Decoded: {decoded}");
