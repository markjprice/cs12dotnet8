using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

[Index("CustomerId", Name = "CustomerId")]
[Index("CustomerId", Name = "CustomersOrders")]
[Index("EmployeeId", Name = "EmployeeId")]
[Index("EmployeeId", Name = "EmployeesOrders")]
[Index("OrderDate", Name = "OrderDate")]
[Index("ShipPostalCode", Name = "ShipPostalCode")]
[Index("ShippedDate", Name = "ShippedDate")]
[Index("ShipVia", Name = "ShippersOrders")]
public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    [StringLength(5)]
    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    [Column(TypeName = "money")]
    public decimal? Freight { get; set; }

    [StringLength(40)]
    public string? ShipName { get; set; }

    [StringLength(60)]
    public string? ShipAddress { get; set; }

    [StringLength(15)]
    public string? ShipCity { get; set; }

    [StringLength(15)]
    public string? ShipRegion { get; set; }

    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [StringLength(15)]
    public string? ShipCountry { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Orders")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("ShipVia")]
    [InverseProperty("Orders")]
    public virtual Shipper? ShipViaNavigation { get; set; }
}
