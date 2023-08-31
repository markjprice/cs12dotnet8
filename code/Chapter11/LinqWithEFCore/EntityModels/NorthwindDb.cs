using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use DbContext, DbSet<T>.

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    #region To use SQLite

    string database = "Northwind.db";
    string dir = Environment.CurrentDirectory;
    string path = string.Empty;

    // The database file will stay in the project folder.
    // We will automatically adjust the relative path to 
    // account for running in VS2022 or from terminal.

    if (dir.EndsWith("net8.0"))
    {
      // Running in the <project>\bin\<Debug|Release>\net8.0 directory.
      path = Path.Combine("..", "..", "..", database);
    }
    else
    {
      // Running in the <project> directory.
      path = database;
    }

    path = Path.GetFullPath(path); // Convert to absolute path.
    WriteLine($"SQLite database path: {path}");

    if (!File.Exists(path))
    {
      throw new FileNotFoundException(
        message: $"{path} not found.", fileName: path);
    }

    // To use SQLite.
    optionsBuilder.UseSqlite($"Data Source={path}");

    #endregion

    #region To use SQL Server

    SqlConnectionStringBuilder builder = new();

    builder.DataSource = ".";
    builder.InitialCatalog = "Northwind";
    builder.IntegratedSecurity = true;
    builder.Encrypt = true;
    builder.TrustServerCertificate = true;
    builder.MultipleActiveResultSets = true;

    string connection = builder.ConnectionString;
    // WriteLine($"SQL Server connection: {connection}");

    // To use SQL Server.
    // optionsBuilder.UseSqlServer(connection);

    #endregion
  }

  protected override void OnModelCreating(
    ModelBuilder modelBuilder)
  {
    if (Database.ProviderName is not null &&
      Database.ProviderName.Contains("Sqlite"))
    {
      modelBuilder.Entity<Product>()
        .Property(product => product.UnitPrice)
        .HasConversion<double>();
    }
  }
}
