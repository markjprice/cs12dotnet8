using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Blazor.Services; // To use INorthwindService and implementations.

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
  BaseAddress = new Uri("https://localhost:5151/")
});

builder.Services.AddTransient<INorthwindService,
  NorthwindServiceClientSide>();

await builder.Build().RunAsync();
