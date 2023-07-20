using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared; // Northwind, Category, Product

WriteLine("Creating four files containing serialized categories and products.");

using (Northwind db = new())
{
  // a query to get all categories and their related products 
  IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

  if (categories is null)
  {
    WriteLine("No categories found.");
    return;
  }

  GenerateXmlFile(categories);
  GenerateXmlFile(categories, useAttributes: false);
  GenerateCsvFile(categories);
  GenerateJsonFile(categories);

  WriteLine($"Current directory: {Environment.CurrentDirectory}");
}
