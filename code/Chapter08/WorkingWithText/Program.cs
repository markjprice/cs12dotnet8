using System.Globalization; // To use CultureInfo.

OutputEncoding = System.Text.Encoding.UTF8; // Enable Euro symbol.

#region Getting the length of a string

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");

#endregion

#region Getting the characters of a string

WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

#endregion

#region Splitting a string

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";

string[] citiesArray = cities.Split(',');

WriteLine($"There are {citiesArray.Length} items in the array:");

foreach (string item in citiesArray)
{
  WriteLine($"  {item}");
}

#endregion

#region Getting part of a string

string fullName = "Alan Shore";

int indexOfTheSpace = fullName.IndexOf(' ');

string firstName = fullName.Substring(
  startIndex: 0, length: indexOfTheSpace);

string lastName = fullName.Substring(
  startIndex: indexOfTheSpace + 1);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

#endregion

#region Checking a string for content

string company = "Microsoft";
WriteLine($"Text: {company}");
WriteLine("Starts with M: {0}, contains an N: {1}", 
  arg0: company.StartsWith("M"),
  arg1: company.Contains("N"));

#endregion

#region Comparing string values

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

string text1 = "Mark";
string text2 = "MARK";

WriteLine($"text1: {text1}, text2: {text2}");

WriteLine("Compare: {0}.", string.Compare(text1, text2));

WriteLine("Compare (ignoreCase): {0}.",
  string.Compare(text1, text2, ignoreCase: true));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}.",
  string.Compare(text1, text2, 
  StringComparison.InvariantCultureIgnoreCase));

// German string comparisons

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

text1 = "Strasse";
text2 = "Straße";

WriteLine($"text1: {text1}, text2: {text2}");

WriteLine("Compare: {0}.", string.Compare(text1, text2, 
  CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace));

WriteLine("Compare (IgnoreCase, IgnoreNonSpace): {0}.",
  string.Compare(text1, text2, CultureInfo.CurrentCulture, 
  CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}.",
  string.Compare(text1, text2,
  StringComparison.InvariantCultureIgnoreCase));

#endregion

#region Joining, formatting, and other string members

string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;

//CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

WriteLine($"Interpolated:  {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}.",
  arg0: fruit, arg1: price, arg2: when));

#endregion
