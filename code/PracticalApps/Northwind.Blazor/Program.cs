using Northwind.Blazor;
using Northwind.Blazor.Services; // To use INorthwindService.

var builder = WebApplication.CreateBuilder(args);

//// temporary fix
//builder.Services.Configure<Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions>(options =>
//{
//  options.AllowSynchronousIO = true;
//});

// Add services to the container.
builder.Services.AddRazorComponents()
  .AddServerComponents();
//  .AddWebAssemblyComponents();

builder.Services.AddNorthwindContext();

builder.Services.AddTransient<INorthwindService,
  NorthwindServiceServerSide>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>();

app.Run();
