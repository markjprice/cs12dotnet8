using Northwind.EntityModels; // To use NorthwindDb, Category, Product.
using Microsoft.EntityFrameworkCore; // To use DbSet<T>.
using System.Xml.Linq; // To use XElement, XAttribute.

partial class Program
{
  static void FilterAndSort()
  {
    SectionTitle("Filter and sort");

    using NorthwindDb db = new();

    DbSet<Product> allProducts = db.Products;

    IQueryable<Product> processedProducts = allProducts.ProcessSequence();

    IQueryable<Product> filteredProducts =
      processedProducts.Where(product => product.UnitPrice < 10M);

    IOrderedQueryable<Product> sortedAndFilteredProducts =
      filteredProducts.OrderByDescending(product => product.UnitPrice);

    var projectedProducts = sortedAndFilteredProducts
      .Select(product => new // Anonymous type.
      {
        product.ProductId,
        product.ProductName,
        product.UnitPrice
      });

    WriteLine("Products that cost less than $10:");
    WriteLine(projectedProducts.ToQueryString());

    foreach (var p in projectedProducts)
    {
      WriteLine("{0}: {1} costs {2:$#,##0.00}",
        p.ProductId, p.ProductName, p.UnitPrice);
    }
    WriteLine();
  }

  static void JoinCategoriesAndProducts()
  {
    SectionTitle("Join categories and products");

    using NorthwindDb db = new();

    // Join every product to its category to return 77 matches.
    var queryJoin = db.Categories.Join(
      inner: db.Products,
      outerKeySelector: category => category.CategoryId,
      innerKeySelector: product => product.CategoryId,
      resultSelector: (c, p) =>
        new { c.CategoryName, p.ProductName, p.ProductId })
      .OrderBy(cp => cp.CategoryName);

    foreach (var item in queryJoin)
    {
      WriteLine("{0}: {1} is in {2}.",
        arg0: item.ProductId,
        arg1: item.ProductName,
        arg2: item.CategoryName);
    }
  }

  static void GroupJoinCategoriesAndProducts()
  {
    SectionTitle("Group join categories and products");

    using NorthwindDb db = new();

    // Group all products by their category to return 8 matches.
    var queryGroup = db.Categories.AsEnumerable().GroupJoin(
      inner: db.Products,
      outerKeySelector: category => category.CategoryId,
      innerKeySelector: product => product.CategoryId,
      resultSelector: (c, matchingProducts) => new
      {
        c.CategoryName,
        Products = matchingProducts.OrderBy(p => p.ProductName)
      });

    foreach (var category in queryGroup)
    {
      WriteLine("{0} has {1} products.",
        arg0: category.CategoryName,
        arg1: category.Products.Count());

      foreach (var product in category.Products)
      {
        WriteLine($" {product.ProductName}");
      }
    }
  }

  static void ProductsLookup()
  {
    SectionTitle("Products lookup");

    using NorthwindDb db = new();

    // Join all products to their category to return 77 matches.
    var productQuery = db.Categories.Join(
      inner: db.Products,
      outerKeySelector: category => category.CategoryId,
      innerKeySelector: product => product.CategoryId,
      resultSelector: (c, p) =>
        new { c.CategoryName, p });

    ILookup<string, Product> productLookup = productQuery
      .ToLookup(keySelector: cp => cp.CategoryName,
      elementSelector: cp => cp.p);

    foreach (IGrouping<string, Product> group in productLookup)
    {
      // Key is Beverages, Condiments, and so on.
      WriteLine("{0} has {1} products.",
        arg0: group.Key, arg1: group.Count());

      foreach (Product product in group)
      {
        WriteLine($" {product.ProductName}");
      }
    }

    // We can look up the products by a category name.
    Write("Enter a category name: ");
    string categoryName = ReadLine()!;
    WriteLine();
    WriteLine($"Products in {categoryName}:");
    IEnumerable<Product> productsInCategory = productLookup[categoryName];
    foreach (Product product in productsInCategory)
    {
      WriteLine($"  {product.ProductName}");
    }
  }

  static void AggregateProducts()
  {
    SectionTitle("Aggregate products");

    using NorthwindDb db = new();

    // Try to get an efficient count from EF Core DbSet<T>.
    if (db.Products.TryGetNonEnumeratedCount(out int countDbSet))
    {
      WriteLine("{0,-25} {1,10}",
        arg0: "Product count from DbSet:",
        arg1: countDbSet);
    }
    else
    {
      WriteLine("Products DbSet does not have a Count property.");
    }

    // Try to get an efficient count from a List<T>.
    List<Product> products = db.Products.ToList();

    if (products.TryGetNonEnumeratedCount(out int countList))
    {
      WriteLine("{0,-25} {1,10}",
        arg0: "Product count from list:",
        arg1: countList);
    }
    else
    {
      WriteLine("Products list does not have a Count property.");
    }

    WriteLine("{0,-25} {1,10}",
      arg0: "Product count:",
      arg1: db.Products.Count());

    WriteLine("{0,-27} {1,8}", // Note the different column widths.
      arg0: "Discontinued product count:",
      arg1: db.Products.Count(product => product.Discontinued));

    WriteLine("{0,-25} {1,10:$#,##0.00}",
      arg0: "Highest product price:",
      arg1: db.Products.Max(p => p.UnitPrice));

    WriteLine("{0,-25} {1,10:N0}",
      arg0: "Sum of units in stock:",
      arg1: db.Products.Sum(p => p.UnitsInStock));

    WriteLine("{0,-25} {1,10:N0}",
      arg0: "Sum of units on order:",
      arg1: db.Products.Sum(p => p.UnitsOnOrder));

    WriteLine("{0,-25} {1,10:$#,##0.00}",
      arg0: "Average unit price:",
      arg1: db.Products.Average(p => p.UnitPrice));

    WriteLine("{0,-25} {1,10:$#,##0.00}",
      arg0: "Value of units in stock:",
      arg1: db.Products
        .Sum(p => p.UnitPrice * p.UnitsInStock));
  }

  static void OutputTableOfProducts(Product[] products,
    int currentPage, int totalPages)
  {
    string line = new('-', count: 73);
    string lineHalf = new('-', count: 30);

    WriteLine(line);
    WriteLine("{0,4} {1,-40} {2,12} {3,-15}",
      "ID", "Product Name", "Unit Price", "Discontinued");
    WriteLine(line);

    foreach (Product p in products)
    {
      WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}",
        p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
    }
    WriteLine("{0} Page {1} of {2} {3}",
      lineHalf, currentPage + 1, totalPages + 1, lineHalf);
  }

  static void OutputPageOfProducts(IQueryable<Product> products,
    int pageSize, int currentPage, int totalPages)
  {
    // We must order data before skipping and taking to ensure
    // the data is not randomly sorted in each page.
    var pagingQuery = products.OrderBy(p => p.ProductId)
      .Skip(currentPage * pageSize).Take(pageSize);

    Clear(); // Clear the console/screen.

    SectionTitle(pagingQuery.ToQueryString());

    OutputTableOfProducts(pagingQuery.ToArray(),
      currentPage, totalPages);
  }

  static void PagingProducts()
  {
    SectionTitle("Paging products");

    using NorthwindDb db = new()


      int pageSize = 10;
    int currentPage = 0;
    int productCount = db.Products.Count();
    int totalPages = productCount / pageSize;

    while (true) // Use break to escape this infinite loop.
    {
      OutputPageOfProducts(db.Products, pageSize, currentPage, totalPages);

      Write("Press <- to page back, press -> to page forward, any key to exit.");
      ConsoleKey key = ReadKey().Key;

      if (key == ConsoleKey.LeftArrow)
        if (currentPage == 0)
          currentPage = totalPages;
        else
          currentPage--;
      else if (key == ConsoleKey.RightArrow)
        if (currentPage == totalPages)
          currentPage = 0;
        else
          currentPage++;
      else
        break; // Break out of the while loop.

      WriteLine();
    }
  }

  static void OutputProductsAsXml()
  {
    SectionTitle("Output products as XML");

    using NorthwindDb db = new();

    Product[] productsArray = db.Products.ToArray();

    XElement xml = new("products",
      from p in productsArray
      select new XElement("product",
        new XAttribute("id", p.ProductId),
        new XAttribute("price", p.UnitPrice ?? 0),
       new XElement("name", p.ProductName)));

    WriteLine(xml.ToString());
  }

  static void ProcessSettings()
  {
    string path = Path.Combine(
      Environment.CurrentDirectory, "settings.xml");

    WriteLine($"Settings file path: {path}");
    XDocument doc = XDocument.Load(path);

    var appSettings = doc.Descendants("appSettings")
      .Descendants("add")
      .Select(node => new
      {
        Key = node.Attribute("key")?.Value,
        Value = node.Attribute("value")?.Value
      }).ToArray();

    foreach (var item in appSettings)
    {
      WriteLine($"{item.Key}: {item.Value}");
    }
  }

  static void CustomExtensionMethods()
  {
    SectionTitle("Custom aggregate extension methods");

    using NorthwindDb db = new();

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
