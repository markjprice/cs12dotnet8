# README for C# 12 and .NET 8 Shared Library

# About

This is a shared library that readers build in the book, 
*C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals*.

## How to Use

The static class extends the string type with three extenstion methods:
- `IsValidHex()`
- `IsValidXmlTag()`
- `IsValidPassword()`

```cs
Write("Enter a color value in hex: "); 
string? hex = ReadLine(); // or "00ffc8"
WriteLine("Is {0} a valid color value? {1}",
  arg0: hex, arg1: hex.IsValidHex());

Write("Enter a XML element: "); 
string? xmlTag = ReadLine(); // or "<h1 class=\"<\" />"
WriteLine("Is {0} a valid XML element? {1}", 
  arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());

Write("Enter a password: "); 
string? password = ReadLine(); // or "secretsauce"
WriteLine("Is {0} a valid password? {1}",
  arg0: password, arg1: password.IsValidPassword());
```
