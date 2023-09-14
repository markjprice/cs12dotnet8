partial class Program
{
  private static void OutputCollection<T>(
    string title, IEnumerable<T> collection)
  {
    WriteLine($"{title}:");
    foreach (T item in collection)
    {
      WriteLine($"  {item}");
    }
  }

  private static void OutputPQ<TElement, TPriority>(string title,
    IEnumerable<(TElement Element, TPriority Priority)> collection)
  {
    WriteLine($"{title}:");
    foreach ((TElement, TPriority) item in collection)
    {
      WriteLine($"  {item.Item1}: {item.Item2}");
    }
  }

  private static void UseDictionary(
    IDictionary<string, string> dictionary)
  {
    // Do some work on dictionary that only requires read access.
    WriteLine($"Count before is {dictionary.Count}.");
    try
    {
      WriteLine("Adding new item with GUID values.");
      // Add method with return type of void.
      dictionary.Add(
        key: Guid.NewGuid().ToString(), 
        value: Guid.NewGuid().ToString()); 
    }
    catch (NotSupportedException)
    {
      WriteLine("This dictionary does not support the Add method.");
    }
    WriteLine($"Count after is {dictionary.Count}.");
  }
}
