using Microsoft.EntityFrameworkCore; // To use Include method.
using Northwind.EntityModels; // To use Northwind, Category, Product.
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use CollectionEntry.

partial class Program
{
  private static void QueryingCategories()
  {
    // Data context will be disposed at the end of the method.
    using NorthwindDb db = new();

    SectionTitle("Categories and how many products they have");

    // A query to get all categories and their related products.
    IQueryable<Category>? categories;
    //= db.Categories;
    //.Include(c => c.Products);

    db.ChangeTracker.LazyLoadingEnabled = false;

    Write("Enable eager loading? (Y/N): ");
    bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
    bool explicitLoading = false;
    WriteLine();

    if (eagerLoading)
    {
      categories = db.Categories?.Include(c => c.Products);
    }
    else
    {
      categories = db.Categories;
      Write("Enable explicit loading? (Y/N): ");
      explicitLoading = (ReadKey().Key == ConsoleKey.Y);
      WriteLine();
    }

    if (categories is null || !categories.Any())
    {
      Fail("No categories found.");
      return;
    }

    // Execute query and enumerate results.
    foreach (Category c in categories)
    {
      if (explicitLoading)
      {
        Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
        ConsoleKeyInfo key = ReadKey();
        WriteLine();

        if (key.Key == ConsoleKey.Y)
        {
          CollectionEntry<Category, Product> products =
            db.Entry(c).Collection(c2 => c2.Products);

          if (!products.IsLoaded) products.Load();
        }
      }

      WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
    }
  }

  private static void FilteredIncludes()
  {
    using NorthwindDb db = new();

    SectionTitle("Products with a minimum number of units in stock");

    string? input;
    int stock;

    do
    {
      Write("Enter a minimum for units in stock: ");
      input = ReadLine();
    } while (!int.TryParse(input, out stock));

    IQueryable<Category>? categories = db.Categories?
      .Include(c => c.Products.Where(p => p.Stock >= stock));

    if (categories is null || !categories.Any())
    {
      Fail("No categories found.");
      return;
    }

    Info($"ToQueryString: {categories.ToQueryString()}");

    foreach (Category c in categories)
    {
      WriteLine("{0} has {1} products with a minimum {2} units in stock.",
        arg0: c.CategoryName, arg1: c.Products.Count, arg2: stock);

      foreach (Product p in c.Products)
      {
        WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
      }
    }
  }

  private static void QueryingProducts()
  {
    using NorthwindDb db = new();

    SectionTitle("Products that cost more than a price, highest at top");

    string? input;
    decimal price;

    do
    {
      Write("Enter a product price: ");
      input = ReadLine();
    } while (!decimal.TryParse(input, out price));

    IQueryable<Product>? products = db.Products?
      .Where(product => product.Cost > price)
      .OrderByDescending(product => product.Cost);

    if (products is null || !products.Any())
    {
      Fail("No products found.");
      return;
    }

    Info($"ToQueryString: {products.ToQueryString()}");

    foreach (Product p in products)
    {
      WriteLine(
        "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
        p.ProductId, p.ProductName, p.Cost, p.Stock);
    }
  }

  private static void GettingOneProduct()
  {
    using NorthwindDb db = new();

    SectionTitle("Getting a single product");

    string? input;
    int id;

    do
    {
      Write("Enter a product ID: ");
      input = ReadLine();
    } while (!int.TryParse(input, out id));

    Product? product = db.Products?
      .First(product => product.ProductId == id);

    Info($"First: {product?.ProductName}");

    if (product is null) Fail("No product found using First.");

    product = db.Products?
      .Single(product => product.ProductId == id);

    Info($"Single: {product?.ProductName}");

    if (product is null) Fail("No product found using Single.");
  }

  private static void QueryingWithLike()
  {
    using NorthwindDb db = new();

    SectionTitle("Pattern matching with LIKE");

    Write("Enter part of a product name: ");
    string? input = ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
      Fail("You did not enter part of a product name.");
      return;
    }

    IQueryable<Product>? products = db.Products?
      .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

    if (products is null || !products.Any())
    {
      Fail("No products found.");
      return;
    }

    foreach (Product p in products)
    {
      WriteLine("{0} has {1} units in stock. Discontinued: {2}",
        p.ProductName, p.Stock, p.Discontinued);
    }
  }

  private static void GetRandomProduct()
  {
    using NorthwindDb db = new();

    SectionTitle("Get a random product");

    int? rowCount = db.Products?.Count();

    if (rowCount is null)
    {
      Fail("Products table is empty.");
      return;
    }

    Product? p = db.Products?.FirstOrDefault(
      p => p.ProductId == (int)(EF.Functions.Random() * rowCount));

    if (p is null)
    {
      Fail("Product not found.");
      return;
    }

    WriteLine($"Random product: {p.ProductId} - {p.ProductName}");
  }

  private static void LazyLoadingWithNoTracking()
  {
    using NorthwindDb db = new();

    SectionTitle("Lazy-loading with no tracking");

    IQueryable<Product>? products = db.Products?.AsNoTracking();

    if (products is null || !products.Any())
    {
      Fail("No products found.");
      return;
    }

    foreach (Product p in products)
    {
      WriteLine("{0} is in category named {1}.",
        p.ProductName, p.Category.CategoryName);
    }
  }
}
