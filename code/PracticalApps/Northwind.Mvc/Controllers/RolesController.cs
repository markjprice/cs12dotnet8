using Microsoft.AspNetCore.Identity; // To use RoleManager, UserManager.
using Microsoft.AspNetCore.Mvc; // To use Controller, IActionResult.

using static System.Console;

namespace Northwind.Mvc.Controllers;

public class RolesController : Controller
{
  private string _adminRole = "Administrators";
  private string _adminUserEmail = "admin@example.com";
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly UserManager<IdentityUser> _userManager;

  public RolesController(RoleManager<IdentityRole> roleManager,
    UserManager<IdentityUser> userManager)
  {
    _roleManager = roleManager;
    _userManager = userManager;
  }

  public async Task<IActionResult> Index()
  {
    if (!(await _roleManager.RoleExistsAsync(_adminRole)))
    {
      await _roleManager.CreateAsync(new IdentityRole(_adminRole));
    }

    IdentityUser? user = await _userManager
      .FindByEmailAsync(_adminUserEmail);

    if (user is null)
    {
      user = new()
      {
        UserName = _adminUserEmail,
        Email = _adminUserEmail
      };

      IdentityResult result = await _userManager
        .CreateAsync(user, "Pa$$w0rd");

      if (result.Succeeded)
      {
        WriteLine($"User {user.UserName} created successfully.");
      }
      else
      {
        foreach (IdentityError error in result.Errors)
        {
          WriteLine(error.Description);
        }
      }
    }

    if (!user.EmailConfirmed)
    {
      string token = await _userManager
        .GenerateEmailConfirmationTokenAsync(user);

      IdentityResult result = await _userManager
        .ConfirmEmailAsync(user, token);

      if (result.Succeeded)
      {
        WriteLine($"User {user.UserName} email confirmed successfully.");
      }
      else
      {
        foreach (IdentityError error in result.Errors)
        {
          WriteLine(error.Description);
        }
      }
    }

    if (!(await _userManager.IsInRoleAsync(user, _adminRole)))
    {
      IdentityResult result = await _userManager
        .AddToRoleAsync(user, _adminRole);

      if (result.Succeeded)
      {
        WriteLine($"User {user.UserName} added to {_adminRole} successfully.");
      }
      else
      {
        foreach (IdentityError error in result.Errors)
        {
          WriteLine(error.Description);
        }
      }
    }
    return Redirect("/");
  }
}
