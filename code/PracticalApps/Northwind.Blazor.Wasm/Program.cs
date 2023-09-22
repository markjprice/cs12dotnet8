using System.Net.Http.Headers; // To use MediaTypeWithQualityHeaderValue.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient(name: "Northwind.WebApi",
  configureClient: options =>
  {
    options.BaseAddress = new Uri("https://localhost:5151/");
    options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue(
      mediaType: "application/json", quality: 1.0));
  });

builder.Services.AddTransient<INorthwindService,
  NorthwindServiceClientSide>();

await builder.Build().RunAsync();
