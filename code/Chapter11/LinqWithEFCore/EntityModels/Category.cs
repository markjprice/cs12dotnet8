// To use [Required] and [StringLength].
using System.ComponentModel.DataAnnotations;

namespace Northwind.EntityModels;

public class Category
{
  public int CategoryId { get; set; }

  [Required]
  [StringLength(15)]
  public string CategoryName { get; set; } = null!;

  public string? Description { get; set; }
}
