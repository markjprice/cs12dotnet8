using Packt.Shared; // To use Person.

// No namespace declaration so this extends the Program class
// in the null namespace.

partial class Program
{
  // A method to handle the Shout event received by the harry object.
  static void Harry_Shout(object? sender, EventArgs e)
  {
    // If no sender, then do nothing.
    if (sender is null) return;

    // If sender is not a Person, then do nothing.
    Person? p = sender as Person;
    if (p is null) return;

    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
  }

  // Another method to handle the Shout event received by the harry object.
  static void Harry_Shout_2(object? sender, EventArgs e)
  {
    WriteLine("Stop it!");
  }
}
