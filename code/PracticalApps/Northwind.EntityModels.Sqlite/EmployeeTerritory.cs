using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Keyless]
public partial class EmployeeTerritory
{
  [Column(TypeName = "INT")]
  public int EmployeeId { get; set; }

  [Column(TypeName = "nvarchar] (20")]
  [Required]
  public string TerritoryId { get; set; } = null!;
}
