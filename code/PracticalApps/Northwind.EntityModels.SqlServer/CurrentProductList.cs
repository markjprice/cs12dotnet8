using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Keyless]
public partial class CurrentProductList
{
    public int ProductId { get; set; }

    [StringLength(40)]
    public string ProductName { get; set; } = null!;
}
