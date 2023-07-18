using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

public partial class NorthwindDb : DbContext
{
  public NorthwindDb()
  {
  }

  public NorthwindDb(DbContextOptions<NorthwindDb> options)
      : base(options)
  {
  }

  public virtual DbSet<Category> Categories { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseSqlite("Data Source=Northwind.db");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>(entity =>
    {
      entity.Property(e => e.CategoryId).ValueGeneratedNever();
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.Property(e => e.ProductId).ValueGeneratedNever();
      entity.Property(e => e.Discontinued).HasDefaultValueSql("0");
      entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");
      entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");
      entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");
      entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
