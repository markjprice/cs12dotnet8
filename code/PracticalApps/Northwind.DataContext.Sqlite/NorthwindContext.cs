using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public partial class NorthwindContext : DbContext
{
  public NorthwindContext()
  {
  }

  public NorthwindContext(DbContextOptions<NorthwindContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Category> Categories { get; set; }

  public virtual DbSet<Customer> Customers { get; set; }

  public virtual DbSet<Employee> Employees { get; set; }

  public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

  public virtual DbSet<Order> Orders { get; set; }

  public virtual DbSet<OrderDetail> OrderDetails { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  public virtual DbSet<Shipper> Shippers { get; set; }

  public virtual DbSet<Supplier> Suppliers { get; set; }

  public virtual DbSet<Territory> Territories { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      string database = "Northwind.db";
      string dir = Environment.CurrentDirectory;
      string path = string.Empty;

      if (dir.EndsWith("net8.0"))
      {
        // In the <project>\bin\<Debug|Release>\net8.0 directory.
        path = Path.Combine("..", "..", "..", "..", database);
      }
      else
      {
        // In the <project> directory.
        path = Path.Combine("..", database);
      }

      path = Path.GetFullPath(path); // Convert to absolute path.

      try
      {
        NorthwindContextLogger.WriteLine($"Database path: {path}");
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
      }

      if (!File.Exists(path))
      {
        throw new FileNotFoundException(
          message: $"{path} not found.", fileName: path);
      }

      optionsBuilder.UseSqlite($"Data Source={path}");

      optionsBuilder.LogTo(NorthwindContextLogger.WriteLine,
        new[] { Microsoft.EntityFrameworkCore
          .Diagnostics.RelationalEventId.CommandExecuting });
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Order>(entity =>
    {
      entity.Property(e => e.Freight).HasDefaultValueSql("0");
    });

    modelBuilder.Entity<OrderDetail>(entity =>
    {
      entity.Property(e => e.Quantity).HasDefaultValueSql("1");
      entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

      entity.HasOne(d => d.Order).WithMany(p => 
        p.OrderDetails).OnDelete(DeleteBehavior.ClientSetNull);

      entity.HasOne(d => d.Product).WithMany(p => 
        p.OrderDetails).OnDelete(DeleteBehavior.ClientSetNull);
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.Property(e => e.Discontinued).HasDefaultValueSql("0");
      entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");
      entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");
      entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");
      entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");

      entity.Property(product => product.UnitPrice)
        .HasConversion<double>();
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
