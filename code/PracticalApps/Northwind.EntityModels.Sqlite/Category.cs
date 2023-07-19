using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Index("CategoryName", Name = "CategoryName")]
public partial class Category
{
  [Key]
  public int CategoryId { get; set; }

  [Column(TypeName = "nvarchar (15)")]
  [StringLength(15)]
  [Required]
  public string CategoryName { get; set; } = null!;

  [Column(TypeName = "ntext")]
  public string? Description { get; set; }

  [Column(TypeName = "image")]
  public byte[]? Picture { get; set; }

  [InverseProperty("Category")]
  public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
