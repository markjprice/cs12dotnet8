using System.Collections.Frozen; // To use FrozenDictionary<T, T>.
using System.Collections.Immutable; // To use ImmutableDictionary<T, T>.

// Define an alias for a dictionary with string key and string value.
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;

#region Working with lists

// Simple syntax for creating a list and adding three items.
List<string> cities = new();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

/* Alternative syntax that is converted by the compiler into
   the three Add method calls above.
List<string> cities = new()
  { "London", "Paris", "Milan" }; */

/* Alternative syntax that passes an array
   of string values to AddRange method.
List<string> cities = new(); 
cities.AddRange(new[] { "London", "Paris", "Milan" }); */

OutputCollection("Initial list", cities);
WriteLine($"The first city is {cities[0]}.");
WriteLine($"The last city is {cities[cities.Count - 1]}.");

cities.Insert(0, "Sydney");
OutputCollection("After inserting Sydney at index 0", cities);

cities.RemoveAt(1);
cities.Remove("Milan");
OutputCollection("After removing two cities", cities);

#endregion

#region Working with dictionaries

// Declare a dictionary without the alias.
// Dictionary<string, string> keywords = new();

// Use the alias to declare the dictionary.
StringDictionary keywords = new();

// Add using named parameters.
keywords.Add(key: "int", value: "32-bit integer data type");

// Add using positional parameters.
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
  { "int", "32-bit integer data type" },
  { "long", "64-bit integer data type" },
  { "float", "Single precision floating point number" },
}; */

/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
  ["int"] = "32-bit integer data type",
  ["long"] = "64-bit integer data type",
  ["float"] = "Single precision floating point number",
}; */

OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);

WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in keywords)
{
  WriteLine($"  {item.Key}: {item.Value}");
}

// Look up a value using a key.
string key = "long";
WriteLine($"The definition of {key} is {keywords[key]}.");

#endregion

#region Sets, stacks, and queues

HashSet<string> names = new();

foreach (string name in
  new[] { "Adam", "Barry", "Charlie", "Barry" })
{
  bool added = names.Add(name);
  WriteLine($"{name} was added: {added}.");
}

WriteLine($"names: {string.Join(',', names)}");

Queue<string> coffee = new();

coffee.Enqueue("Damir"); // Front of the queue.
coffee.Enqueue("Andrea");
coffee.Enqueue("Ronald");
coffee.Enqueue("Amin");
coffee.Enqueue("Irina"); // Back of the queue.

OutputCollection("Initial queue from front to back", coffee);

// Server handles next person in queue.
string served = coffee.Dequeue();
WriteLine($"Served: {served}.");

// Server handles next person in queue.
served = coffee.Dequeue();
WriteLine($"Served: {served}.");
OutputCollection("Current queue from front to back", coffee);

WriteLine($"{coffee.Peek()} is next in line.");
OutputCollection("Current queue from front to back", coffee);

PriorityQueue<string, int> vaccine = new();

// Add some people.
// 1 = High priority people in their 70s or poor health.
// 2 = Medium priority e.g. middle-aged.
// 3 = Low priority e.g. teens and twenties.

vaccine.Enqueue("Pamela", 1);
vaccine.Enqueue("Rebecca", 3);
vaccine.Enqueue("Juliet", 2);
vaccine.Enqueue("Ian", 1);

OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

WriteLine("Adding Mark to queue with priority 2.");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

#endregion

#region Read-only, immutable, and frozen collections

//UseDictionary(keywords);
//UseDictionary(keywords.AsReadOnly());
//UseDictionary(keywords.ToImmutableDictionary());

ImmutableDictionary<string, string> immutableKeywords = 
  keywords.ToImmutableDictionary();

// Call the Add method with a return value.
ImmutableDictionary<string, string> newDictionary = 
  immutableKeywords.Add(
    key: Guid.NewGuid().ToString(),
    value: Guid.NewGuid().ToString());

OutputCollection("Immutable keywords dictionary", immutableKeywords);
OutputCollection("New keywords dictionary", newDictionary);

// Creating a frozen collection has an overhead to perform the
// sometimes complex optimizations.
FrozenDictionary<string, string> frozenKeywords =
  keywords.ToFrozenDictionary();

OutputCollection("Frozen keywords dictionary", frozenKeywords);

// Lookups are faster in a frozen dictionary.
WriteLine($"Define long: {frozenKeywords["long"]}");

#endregion
