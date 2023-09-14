using Packt.Shared; // To use Person.

using Fruit = (string Name, int Number); // Aliasing a tuple type.

ConfigureConsole(); // Sets current culture to US English.

// Alternatives:
// ConfigureConsole(useComputerCulture: true); // Use your culture.
// ConfigureConsole(culture: "fr-FR"); // Use French culture.

#region Instantiating a class

// Person bob = new Person(); // C# 1 or later.
// var bob = new Person(); // C# 3 or later.

Person bob = new(); // C# 9 or later.
WriteLine(bob); // Implicit call to ToString().
// WriteLine(bob.ToString()); // Does the same thing.

#endregion

#region Setting and outputting field values

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
  year: 1965, month: 12, day: 22,
  hour: 16, minute: 28, second: 0,
  offset: TimeSpan.FromHours(-5)); // US Eastern Standard Time.

WriteLine(format: "{0} was born on {1:D}.", // Long date.
  arg0: bob.Name, arg1: bob.Born);

#endregion

#region Setting field values using object initializer syntax

Person alice = new()
{
  Name = "Alice Jones",
  Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
};

WriteLine(format: "{0} was born on {1:d}.", // Short date.
  arg0: alice.Name, arg1: alice.Born);

#endregion

#region Storing a value using an enum type

// Setting a single enum value works.
bob.FavoriteAncientWonder =
  WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

/*
// Setting multiple enum values throws an exception.
bob.FavoriteAncientWonder = 
  WondersOfTheAncientWorld.StatueOfZeusAtOlympia |
  WondersOfTheAncientWorld.GreatPyramidOfGiza;

// Setting an invalid enum value throws an exception.
bob.FavoriteAncientWonder = (WondersOfTheAncientWorld)128;
*/

WriteLine(
  format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
  arg0: bob.Name,
  arg1: bob.FavoriteAncientWonder,
  arg2: (int)bob.FavoriteAncientWonder);

#endregion

#region Storing multiple values using an enum type

bob.BucketList =
  WondersOfTheAncientWorld.HangingGardensOfBabylon
  | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

// bob.BucketList = (WondersOfTheAncientWorld)18;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

#endregion

#region Storing multiple values using collections

// Works with all versions of C#.
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

// Works with C# 3 and later.
bob.Children.Add(new Person { Name = "Bella" });

// Works with C# 9 and later.
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
  WriteLine($"> {bob.Children[childIndex].Name}");
}

/*
// Optional challenge to use foreach instead.
foreach (Person child in bob.Children)
{
  WriteLine($"> {child.Name}");
}
*/

#endregion

#region Making a field static

BankAccount.InterestRate = 0.012M; // Store a shared value in static field.

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
  arg0: jonesAccount.AccountName,
  arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
  arg0: gerrierAccount.AccountName,
  arg1: gerrierAccount.Balance * BankAccount.InterestRate);

#endregion

#region Making a field constant

// Constant fields are accessible via the type.
WriteLine($"{bob.Name} is a {Person.Species}.");

#endregion

#region Making a field read-only

// Read-only fields are accessible via the variable.
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");

#endregion

#region Requiring fields to be set during instantiation

/* 
// Instantiate a book using object initializer syntax.
Book book = new()
{
  Isbn = "978-1803237800",
  Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
};
*/

Book book = new(isbn: "978-1803237800",
  title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
  Author = "Mark J. Price",
  PageCount = 821
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
  book.Isbn, book.Title, book.Author, book.PageCount);

#endregion

#region Initializing fields with constructors

Person blankPerson = new();

WriteLine(format:
  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: blankPerson.Name,
  arg1: blankPerson.HomePlanet,
  arg2: blankPerson.Instantiated);

#endregion

#region Defining multiple constructors

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(format:
  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: gunny.Name,
  arg1: gunny.HomePlanet,
  arg2: gunny.Instantiated);

#endregion

#region Returning values from methods

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

#endregion

#region Defining and passing parameters to methods

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

#endregion

#region Passing optional parameters

WriteLine(bob.OptionalParameters(3));

WriteLine(bob.OptionalParameters(3, "Jump!", 98.5));

#endregion

#region Naming parameter values when calling methods

WriteLine(bob.OptionalParameters(3, number: 52.7, command: "Hide!"));

WriteLine(bob.OptionalParameters(3, "Poke!", active: false));

#endregion

#region Controlling how parameters are passed

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");

bob.PassingParameters(a, b, ref c, out d);

WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

int e = 50;
int f = 60;
int g = 70;
WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");

// Simplified C# 7 or later syntax for the out parameter.
bob.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

#endregion

#region Combining multiple returned values using tuples

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

#endregion

#region Naming the fields of a tuple

// Without an aliased tuple type.
//var fruitNamed = bob.GetNamedFruit();

// With an aliased tuple type.
Fruit fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

#endregion

#region Deconstructing tuples

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

#endregion

#region Deconstructing other types using tuples

var (name1, dob1) = bob; // Implicitly calls the Deconstruct method.
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

#endregion

#region Implementing functionality using local functions

// Change to -1 to make the exception handling code execute.
int number = 5;

try
{
  WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
}

#endregion

#region Defining read-only properties

Person sam = new()
{
  Name = "Sam",
  Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

#endregion

#region Defining settable properties

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

string color = "Black";

try
{
  sam.FavoritePrimaryColor = color;
  WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
}
catch (Exception ex)
{
  WriteLine("Tried to set {0} to '{1}': {2}",
    nameof(sam.FavoritePrimaryColor), color, ex.Message);
}

#endregion

#region Defining indexers

sam.Children.Add(new()
{
  Name = "Charlie",
  Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero)
});

sam.Children.Add(new()
{
  Name = "Ella",
  Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero)
});

// Get using Children list.
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");

// Get using the int indexer.
WriteLine($"Sam's first child is {sam[0].Name}.");
WriteLine($"Sam's second child is {sam[1].Name}.");

// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

#endregion

#region Pattern matching flight passengers

// An array containing a mix of passenger types.
Passenger[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
  new BusinessClassPassenger { Name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
  decimal flightCost = passenger switch
  {
    /* C# 8 syntax
    FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
    FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
    FirstClassPassenger _                          => 2_000M,*/

    // C# 9 or later syntax
    FirstClassPassenger p => p.AirMiles switch
    {
      > 35_000 => 1_500M,
      > 15_000 => 1_750M,
      _ => 2_000M
    },
    BusinessClassPassenger _ => 1_000M,
    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
    CoachClassPassenger _ => 650M,
    _ => 800M
  };
  WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

#endregion

#region Init-only properties

ImmutablePerson jeff = new()
{
  FirstName = "Jeff",
  LastName = "Winger"
};
//jeff.FirstName = "Geoff";

#endregion

#region Defining record types

ImmutableVehicle car = new()
{
  Brand = "Mazda MX-5 RF",
  Color = "Soul Red Crystal Metallic",
  Wheels = 4
};

ImmutableVehicle repaintedCar = car
  with
{ Color = "Polymetal Grey Metallic" };

WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

#endregion

#region Equality of record types

AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };

WriteLine($"ac1 == ac2: {ac1 == ac2}");

AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };

WriteLine($"ar1 == ar2: {ar1 == ar2}");

#endregion

#region Positional data members in records

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // Calls the Deconstruct method.
WriteLine($"{who} is a {what}.");

#endregion

#region Defining a primary constructor

Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}.");

Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");

Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}.");

#endregion