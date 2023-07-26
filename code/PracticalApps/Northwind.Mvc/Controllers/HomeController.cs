using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using System.Diagnostics;
using Northwind.EntityModels; // To use NorthwindContext.
// To use the Include and ToListAsync extension methods.
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; // To use [Authorize].

namespace Northwind.Mvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext _db;

    public HomeController(ILogger<HomeController> logger,
      NorthwindContext db)
    {
      _logger = logger;
      _db = db;
    }

    [ResponseCache(Duration = 10 /* seconds */,
      Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index()
    {
      _logger.LogError("This is a serious error (not really!)");
      _logger.LogWarning("This is your first warning!");
      _logger.LogWarning("Second warning!");
      _logger.LogInformation("I am in the Index method of the HomeController.");

      HomeIndexViewModel model = new
      (
        VisitorCount: Random.Shared.Next(1, 1001),
        Categories: await _db.Categories.ToListAsync(),
        Products: await _db.Products.ToListAsync()
      );

      return View(model); // Pass the model to the view.
    }

    [Route("private")]
    [Authorize(Roles = "Administrators")]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> ProductDetail(int? id,
      string alertstyle = "success")
    {
      ViewData["alertstyle"] = alertstyle;

      if (!id.HasValue)
      {
        return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
      }

      Product? model = _db.Products.Include(p => p.Category)
        .SingleOrDefault(p => p.ProductId == id);

      if (model is null)
      {
        return NotFound($"ProductId {id} not found.");
      }

      return View(model); // Pass model to view and then return result.
    }

    // This action method will handle GET and other requests except POST.
    public IActionResult ModelBinding()
    {
      return View(); // The page with a form to submit.
    }

    [HttpPost] // This action method will handle POST requests.
    public IActionResult ModelBinding(Thing thing)
    {
      HomeModelBindingViewModel model = new(
        Thing: thing, HasErrors: !ModelState.IsValid,
        ValidationErrors: ModelState.Values
          .SelectMany(state => state.Errors)
          .Select(error => error.ErrorMessage)
      );

      return View(model); // Show the model bound thing.
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
      if (!price.HasValue)
      {
        return BadRequest("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
      }

      IEnumerable<Product> model = _db.Products
        .Include(p => p.Category)
        .Include(p => p.Supplier)
        .Where(p => p.UnitPrice > price);

      if (!model.Any())
      {
        return NotFound(
          $"No products cost more than {price:C}.");
      }

      ViewData["MaxPrice"] = price.Value.ToString("C");

      return View(model);
    }
  }
}