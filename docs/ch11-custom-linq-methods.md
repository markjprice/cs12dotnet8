**Creating your own LINQ extension methods**

- [Introducing custom LINQ extension methods](#introducing-custom-linq-extension-methods)
- [Trying the chainable extension method](#trying-the-chainable-extension-method)
- [Trying the mode and median methods](#trying-the-mode-and-median-methods)

# Introducing custom LINQ extension methods

In *Chapter 6, Implementing Interfaces and Inheriting Classes*, you learned how to create your own extension methods. To create LINQ extension methods, all you must do is extend the `IEnumerable<T>` type.

> **Good Practice**: Put your own extension methods in a separate class library so that they can be easily deployed as their own assembly or NuGet package.

We will improve the `Average` extension method as an example. A well-educated child will tell you that the word *average* can mean one of three things:
- **Mean**: Sum the numbers and divide by the count.
- **Mode**: The most common number.
- **Median**: The number in the middle of the numbers when ordered.

Microsoft's implementation of the `Average` extension method calculates the *mean*. We might want to define our own extension methods for `Mode` and `Median`:

1.	Use your preferred code editor to add a new **Class Library** / `classlib` project named `PacktLinqExtensions` to the `Chapter11` solution that targets .NET Standard 2.0 and uses C# 12, as shown in the following markup:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <LangVersion>12</LangVersion>
  </PropertyGroup>

</Project>
```
2.	In the `PacktLinqExtensions` project, rename the class file `Class1.cs` to `LinqExtensions.cs`.
3.	Modify the class, as shown in the following code:
```cs
namespace System.Linq; // To extend Microsoft's namespace.

public static class LinqExtensions
{
  // This is a chainable LINQ extension method.
  public static IEnumerable<T> ProcessSequence<T>(
    this IEnumerable<T> sequence)
  {
    // You could do some processing here.
    return sequence;
  }

  public static IQueryable<T> ProcessSequence<T>(
    this IQueryable<T> sequence)
  {
    // You could do some processing here.
    return sequence;
  }

  // These are scalar LINQ extension methods.
  public static int? Median(
    this IEnumerable<int?> sequence)
  {
    var ordered = sequence.OrderBy(item => item);
    int middlePosition = ordered.Count() / 2;
    return ordered.ElementAt(middlePosition);
  }

  public static int? Median<T>(
    this IEnumerable<T> sequence, Func<T, int?> selector)
  {
    return sequence.Select(selector).Median();
  }

  public static decimal? Median(
    this IEnumerable<decimal?> sequence)
  {
    var ordered = sequence.OrderBy(item => item);
    int middlePosition = ordered.Count() / 2;
    return ordered.ElementAt(middlePosition);
  }

  public static decimal? Median<T>(
    this IEnumerable<T> sequence, Func<T, decimal?> selector)
  {
    return sequence.Select(selector).Median();
  }

  public static int? Mode(
    this IEnumerable<int?> sequence)
  {
    var grouped = sequence.GroupBy(item => item);
    var orderedGroups = grouped.OrderByDescending(
      group => group.Count());
    return orderedGroups.FirstOrDefault()?.Key;
  }

  public static int? Mode<T>(
    this IEnumerable<T> sequence, Func<T, int?> selector)
  {
    return sequence.Select(selector)?.Mode();
  }

  public static decimal? Mode(
    this IEnumerable<decimal?> sequence)
  {
    var grouped = sequence.GroupBy(item => item);
    var orderedGroups = grouped.OrderByDescending(
      group => group.Count());
    return orderedGroups.FirstOrDefault()?.Key;
  }

  public static decimal? Mode<T>(
    this IEnumerable<T> sequence, Func<T, decimal?> selector)
  {
    return sequence.Select(selector).Mode();
  }
}
```

Since this class is in a separate class library, to use your LINQ extension methods, you simply need to reference the class library project or assembly because the `System.Linq` namespace is already implicitly imported in most projects.

> **Warning!** All but one of the above extension methods cannot be used with `IQueryable` sequences like those used by **LINQ to SQLite** or **LINQ to SQL Server**, because we have not implemented a way to translate our code into the underlying query language like SQL.

# Trying the chainable extension method

First, we will try chaining the ProcessSequence method with other extension methods:

1.	In the `LinqWithEFCore` project, add a reference to the `PacktLinqExtensions` project, as shown in the following markup:
```xml
<ItemGroup>
  <ProjectReference Include="..\PacktLinqExtensions\PacktLinqExtensions.csproj" />
</ItemGroup>
```

2.  Build the `LinqWithEFCore` project.
3.	In the `LinqWithEFCore` project, in `Program.Functions.cs`, in the `FilterAndSort` method, modify the LINQ query for `Products` to call your custom chainable extension method, as shown highlighted in the following code:
```cs
DbSet<Product> allProducts = db.Products;

IQueryable<Product> processedProducts = allProducts.ProcessSequence();

IQueryable<Product> filteredProducts = processedProducts
  .Where(product => product.UnitPrice < 10M);
```

4.	In `Program.cs`, uncomment the `FilterAndSort` method and comment out any calls to other methods.
5.	Run the code and note that you see the same output as before because your method doesn't modify the sequence. But you now know how to extend a LINQ expression with your own functionality.

# Trying the mode and median methods

Next, we will try using the `Mode` and `Median` methods to calculate other kinds of average:

1.	In `Program.Functions.cs`, add a method to output the mean, median, and mode for the `UnitsInStock` and `UnitPrice` for products, using your custom extension methods and the built-in `Average` extension method, as shown in the following code:
```cs
static void CustomExtensionMethods()
{
  SectionTitle("Custom aggregate extension methods");

  using (NorthwindDb db = new())
  {
    WriteLine("{0,-25} {1,10:N0}",
      "Mean units in stock:",
      db.Products.Average(p => p.UnitsInStock));

    WriteLine("{0,-25} {1,10:$#,##0.00}",
      "Mean unit price:",
      db.Products.Average(p => p.UnitPrice));
      
    WriteLine("{0,-25} {1,10:N0}", 
      "Median units in stock:",
      db.Products.Median(p => p.UnitsInStock));
      
    WriteLine("{0,-25} {1,10:$#,##0.00}", 
      "Median unit price:",
      db.Products.Median(p => p.UnitPrice));
      
    WriteLine("{0,-25} {1,10:N0}", 
      "Mode units in stock:",
      db.Products.Mode(p => p.UnitsInStock));
      
    WriteLine("{0,-25} {1,10:$#,##0.00}", 
      "Mode unit price:",
      db.Products.Mode(p => p.UnitPrice));
  }
}
```

2.	In `Program.cs`, call the `CustomExtensionMethods` method.
3.	Run the code and view the result, as shown in the following output:
```
Mean units in stock:              41
Mean unit price:              $28.87
Median units in stock:            26
Median unit price:            $19.50
Mode units in stock:               0
Mode unit price:              $18.00
```

> To understand the `Mode` results remember that the *mode* is the most popular value. There are four products with a unit price of $18.00, more than any other unit price. There are five products with 0 units in stock, more than any other number of units in stock.
