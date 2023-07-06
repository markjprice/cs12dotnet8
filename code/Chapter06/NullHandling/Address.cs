namespace Packt.Shared;

public class Address
{
  public string? Building;
  public string Street = string.Empty;
  public string City;
  public string Region;

  public Address()
  {
    City = string.Empty;
    Region = string.Empty;
  }

  // Call the default parameterless constructor
  // to ensure that Region is also set.

  public Address(string city) : this()
  { 
    City = city;
  }
}
