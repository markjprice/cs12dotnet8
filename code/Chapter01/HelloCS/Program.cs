// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, C#!");

string name = typeof(Program).Namespace ?? "None!";
Console.WriteLine($"Namespace: {name}");

throw new Exception();
int z;
