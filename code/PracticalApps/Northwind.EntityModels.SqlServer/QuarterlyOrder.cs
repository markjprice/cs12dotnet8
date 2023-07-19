using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Keyless]
public partial class QuarterlyOrder
{
    [StringLength(5)]
    public string? CustomerId { get; set; }

    [StringLength(40)]
    public string? CompanyName { get; set; }

    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(15)]
    public string? Country { get; set; }
}
