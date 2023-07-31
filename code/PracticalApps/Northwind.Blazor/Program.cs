using Northwind.Blazor;
using Northwind.Blazor.Services; // To use INorthwindService.
using System.Net.Http.Headers; // To use MediaTypeWithQualityHeaderValue.

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<Microsoft.AspNetCore.Server
//  .Kestrel.Core.KestrelServerOptions>(options =>
//{
//  options.AllowSynchronousIO = true;
//});

// Add services to the container.
builder.Services.AddRazorComponents()
  .AddServerComponents();
//  .AddWebAssemblyComponents(); // Doesn't exist yet?

builder.Services.AddNorthwindContext();

builder.Services.AddHttpClient(name: "Northwind.WebApi",
  configureClient: options =>
  {
    options.BaseAddress = new Uri("https://localhost:5151/");
    options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue(
      mediaType: "application/json", quality: 1.0));
  });

builder.Services.AddTransient<INorthwindService,
  NorthwindServiceServerSide>();
//builder.Services.AddTransient<INorthwindService,
//  NorthwindServiceClientSide>();

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

app.MapRazorComponents<App>()
  .AddServerRenderMode();
//  .AddWebAssemblyRenderMode();

app.Run();
