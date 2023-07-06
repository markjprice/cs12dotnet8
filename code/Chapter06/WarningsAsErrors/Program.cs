// See https://aka.ms/new-console-template for more information
Console.Write("Enter a name: ");
string? name = Console.ReadLine();
if (name == null)
{
  Console.WriteLine("You did not enter a name.");
  return;
}
Console.WriteLine($"Hello, {name} has {name.Length} characters!");
