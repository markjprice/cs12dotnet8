using Packt.Shared; // To use Address.

int thisCannotBeNull = 4;
//thisCannotBeNull = null; // CS0037 compiler error!
WriteLine(thisCannotBeNull);

int? thisCouldBeNull = null;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

// The actual type of int? is Nullable<int>.
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

string firstName; // Allows null but gives warning when potentially null.
string? lastName; // Allows null and does not give warning if null.

Address address = new(city: "London")
{
  Building = null,
  Street = null!, // null-forgiving operator.
  Region = "UK"
};

WriteLine(address.Building?.Length);

if (address.Street is not null)
{
  WriteLine(address.Street.Length);
}
