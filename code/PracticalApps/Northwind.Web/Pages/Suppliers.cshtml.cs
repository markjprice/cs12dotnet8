using Microsoft.AspNetCore.Mvc.RazorPages; // To use PageModel.
using Northwind.EntityModels; // To use NorthwindContext.
using Microsoft.AspNetCore.Mvc; // To use [BindProperty], IActionResult.

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
  private NorthwindContext _db;

  public SuppliersModel(NorthwindContext db)
  {
    _db = db;

    // Initialize the Supplier property to avoid null warnings in the view.
    Supplier = new();
  }

  public IEnumerable<Supplier>? Suppliers { get; set; }

  public void OnGet()
  {
    ViewData["Title"] = "Northwind B2B - Suppliers";

    Suppliers = _db.Suppliers
      .OrderBy(c => c.Country)
      .ThenBy(c => c.CompanyName);
  }

  [BindProperty]
  public Supplier Supplier { get; set; }

  public IActionResult OnPost()
  {
    if (Supplier is not null && ModelState.IsValid)
    {
      _db.Suppliers.Add(Supplier);
      _db.SaveChanges();
      return RedirectToPage("/suppliers");
    }
    else
    {
      return Page(); // Return to original page.
    }
  }
}
