using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
  public DbSet<Customer> Customers { get; set; } = null!;

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    string database = "Northwind.db";
    string path = Path.Combine(Environment.CurrentDirectory, database);
    if (!File.Exists(path))
    {
      throw new FileNotFoundException($"Could not find database file: {path}");
    }
    string connection = $"Data Source={path}";
    optionsBuilder.UseSqlite(connection);
  }
}
