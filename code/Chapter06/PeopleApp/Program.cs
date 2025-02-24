using Packt.Shared;

#region Implementing functionality using methods and operators

Person harry = new()
{
  Name = "Harry",
  Born = new(year: 2001, month: 3, day: 25,
    hour: 0, minute: 0, second: 0, 
    offset: TimeSpan.Zero)
};

harry.WriteToConsole();

// Implementing functionality using methods.
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

// Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);

// Call the static method to marry Lamech and Zillah.
// Person.Marry(lamech, zillah);

if (lamech + zillah)
{
  WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

// Call the static method to make a baby.
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

// Use the * operator to "multiply".
Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
  WriteLine(format: "  {0}'s child #{1} is named \"{2}\".",
    arg0: lamech.Name, arg1: i,
    arg2: lamech.Children[i].Name);
}

#endregion

#region Working with non-generic types

// Non-generic lookup collection.
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; // Look up the value that has 2 as its key.

WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupObject[key]);

// Look up the value that has harry as its key.
WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookupObject[harry]);

#endregion

#region Working with generic types

// Define a generic lookup collection.
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;

WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupIntString[key]);

#endregion

#region Defining and handling delegates

// Assign the method(s) to the Shout event delegate.
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;

// Call the Poke method that eventually raises the Shout event.
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

#endregion

#region Comparing objects when sorting

Person?[] people =
{
  null,
  new() { Name = "Simon" },
  new() { Name = "Jenny" },
  new() { Name = "Adam" },
  new() { Name = null },
  new() { Name = "Richard" }
};

OutputPeopleNames(people, "Initial list of people:");

Array.Sort(people);

OutputPeopleNames(people,
  "After sorting using Person's IComparable implementation:");

Array.Sort(people, new PersonComparer());

OutputPeopleNames(people,
  "After sorting using PersonComparer's IComparer implementation:");

#endregion

#region Equality of types

int a = 3;
int b = 3;
WriteLine($"a: {a}, b: {b}");
WriteLine($"a == b: {a == b}");

Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };
WriteLine($"p1: {p1}, p2: {p2}");
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1 == p2: {p1 == p2}");

Person p3 = p1;
WriteLine($"p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}");

// string is the only class reference type implemented to 
// act like a value type for equality.
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}");

#endregion

#region Defining struct types

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

DisplacementVector dv4 = new();
WriteLine($"({dv4.X}, {dv4.Y})");

DisplacementVector dv5 = new(3, 5);
WriteLine($"dv1.Equals(dv5): {dv1.Equals(dv5)}");
WriteLine($"dv1 == dv5: {dv1 == dv5}");

#endregion

#region Inheriting from classes

Employee john = new()
{
  Name = "John Jones",
  Born = new(year: 1990, month: 7, day: 28,
    hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)
};

john.WriteToConsole();

#endregion

#region Extending classes to add functionality

john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:yyyy-MM-dd}.");

#endregion

#region Overriding members

WriteLine(john.ToString());

#endregion

#region Understanding polymorphism

Employee aliceInEmployee = new()
  { Name = "Alice", EmployeeCode = "AA123" };

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

#endregion

#region Explicit casting

if (aliceInPerson is Employee)
{
  WriteLine($"{nameof(aliceInPerson)} is an Employee.");

  Employee explicitAlice = (Employee)aliceInPerson;

  // Safely do something with explicitAlice.
}

#endregion

#region Using as to cast a type

Employee? aliceAsEmployee = aliceInPerson as Employee;

if (aliceAsEmployee is not null)
{
  WriteLine($"{nameof(aliceInPerson)} as an Employee.");

  // Safely do something with aliceAsEmployee.
}

#endregion

#region Inheriting exceptions

try
{
  john.TimeTravel(when: new(1999, 12, 31));
  john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
  WriteLine(ex.Message);
}

#endregion

#region Using static methods to reuse functionality

string email1 = "pamela@test.com";
string email2 = "ian&test.com";

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: StringExtensions.IsValidEmail(email1));

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: StringExtensions.IsValidEmail(email2));

#endregion

#region Using extension methods to reuse functionality

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail());

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail());

#endregion

#region Mutability and records

C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill";

C2 c2 = new(Name: "Bob");
//c2.Name = "Bill"; // CS8852: Init-only property.

S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill";

S2 s2 = new(Name: "Bob");
s2.Name = "Bill";

S3 s3 = new(Name: "Bob");
//s3.Name = "Bill"; // CS8852: Init-only property.

#endregion
