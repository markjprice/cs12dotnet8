#region Import namespaces
using Microsoft.AspNetCore.Identity; // To use IdentityUser.
using Microsoft.EntityFrameworkCore; // To use UseSqlServer method.
using Northwind.Mvc.Data; // To use ApplicationDbContext.
using Northwind.EntityModels; // To use AddNorthwindContext method.
#endregion

#region Configure the host web server including services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration
  .GetConnectionString("DefaultConnection") ??
  throw new InvalidOperationException(
    "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); // Or UseSqlite.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
  options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>() // Enable role management.
  .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

/*
// If you are using SQL Server.
string? sqlServerConnection = builder.Configuration
  .GetConnectionString("NorthwindConnection");

if (sqlServerConnection is null)
{
  Console.WriteLine("SQL Server database connection string is missing!");
}
else
{
  builder.Services.AddNorthwindContext(sqlServerConnection);
}
*/

// If you are using SQLite, default is "..\Northwind.db".
builder.Services.AddNorthwindContext();

builder.Services.AddOutputCache(options =>
{
  options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(20);
  options.AddPolicy("views", p => p.SetVaryByQuery("alertstyle"));
});

var app = builder.Build();

#endregion

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseOutputCache();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//  .CacheOutput(policyName: "views");

app.MapRazorPages();

app.MapGet("/notcached", () => DateTime.Now.ToString());
app.MapGet("/cached", () => DateTime.Now.ToString()).CacheOutput();

#endregion

#region Start the host web server listening for HTTP requests.
app.Run();  // This is a blocking call.
#endregion
