using Microsoft.AspNetCore.Mvc.RazorPages; // To use PageModel.
using Northwind.EntityModels; // To use Employee, NorthwindContext.

namespace PacktFeatures.Pages;

public class EmployeesListPageModel : PageModel
{
  private NorthwindContext _db;

  public EmployeesListPageModel(NorthwindContext db)
  {
    _db = db;
  }

  public Employee[] Employees { get; set; } = null!;

  public void OnGet()
  {
    ViewData["Title"] = "Northwind B2B - Employees";

    Employees = _db.Employees.OrderBy(e => e.LastName)
      .ThenBy(e => e.FirstName).ToArray();
  }
}