partial class Program
{
  private static void DeferredExecution(string[] names)
  {
    SectionTitle("Deferred execution");

    // Question: Which names end with an M?
    // (using a LINQ extension method)
    var query1 = names.Where(name => name.EndsWith("m"));

    // Question: Which names end with an M?
    // (using LINQ query comprehension syntax)
    var query2 = from name in names where name.EndsWith("m") select name;

    // Answer returned as an array of strings containing Pam and Jim.
    string[] result1 = query1.ToArray();

    // Answer returned as a list of strings containing Pam and Jim.
    List<string> result2 = query2.ToList();

    // Answer returned as we enumerate over the results.
    foreach (string name in query1)
    {
      WriteLine(name); // Outputs Pam.

      names[2] = "Jimmy"; // Change Jim to Jimmy.
      // On the second iteration Jimmy does not
      // end with an m so it does not get output.
    }
  }

  private static void FilteringUsingWhere(string[] names)
  {
    SectionTitle("Filtering entities using Where");

    // Explicitly creating the required delegate.
    // var query = names.Where(
    //   new Func<string, bool>(NameLongerThanFour));

    // The compiler creates the delegate automatically.
    // var query = names.Where(NameLongerThanFour);

    // Using a lambda expression instead of a named method.
    IOrderedEnumerable<string> query = names
      .Where(name => name.Length > 4)
      .OrderBy(name => name.Length)
      .ThenBy(name => name);

    foreach (string item in query)
    {
      WriteLine(item);
    }
  }

  private static bool NameLongerThanFour(string name)
  {
    // Returns true for a name longer than four characters.
    return name.Length > 4;
  }

  private static void FilteringByType()
  {
    SectionTitle("Filtering by type");

    List<Exception> exceptions = new()
    {
      new ArgumentException(), new SystemException(),
      new IndexOutOfRangeException(), new InvalidOperationException(),
      new NullReferenceException(), new InvalidCastException(),
      new OverflowException(), new DivideByZeroException(),
      new ApplicationException()
    };

    IEnumerable<ArithmeticException> arithmeticExceptionsQuery =
      exceptions.OfType<ArithmeticException>();

    foreach (ArithmeticException exception in arithmeticExceptionsQuery)
    {
      WriteLine(exception);
    }
  }

  private static void Output(IEnumerable<string> cohort, string description = "")
  {
    if (!string.IsNullOrEmpty(description))
    {
      WriteLine(description);
    }
    Write(" ");
    WriteLine(string.Join(", ", cohort.ToArray()));
    WriteLine();
  }

  private static void WorkingWithSets()
  {
    string[] cohort1 =
      { "Rachel", "Gareth", "Jonathan", "George" };

    string[] cohort2 =
      { "Jack", "Stephen", "Daniel", "Jack", "Jared" };

    string[] cohort3 =
      { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

    SectionTitle("The cohorts");

    Output(cohort1, "Cohort 1");
    Output(cohort2, "Cohort 2");
    Output(cohort3, "Cohort 3");

    SectionTitle("Set operations");

    Output(cohort2.Distinct(), "cohort2.Distinct()");
    Output(cohort2.DistinctBy(name => name.Substring(0, 2)),
      "cohort2.DistinctBy(name => name.Substring(0, 2)):");
    Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
    Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)");
    Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)");
    Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)");
    Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"),
      "cohort1.Zip(cohort2)");
  }
}
