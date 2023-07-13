using Microsoft.Win32.SafeHandles; // To use SafeFileHandle.
using System.Text; // To use Encoding.

using SafeFileHandle handle =
  File.OpenHandle(path: "coffee.txt", 
    mode: FileMode.OpenOrCreate,
    access: FileAccess.ReadWrite);

// Write to the file.
string message = "Café £4.39";
ReadOnlyMemory<byte> buffer = new(Encoding.UTF8.GetBytes(message));
await RandomAccess.WriteAsync(handle, buffer, fileOffset: 0);

// Read from the file.
long length = RandomAccess.GetLength(handle);
Memory<byte> contentBytes = new(new byte[length]);
await RandomAccess.ReadAsync(handle, contentBytes, fileOffset: 0);
string content = Encoding.UTF8.GetString(contentBytes.ToArray());
WriteLine($"Content of file: {content}");
