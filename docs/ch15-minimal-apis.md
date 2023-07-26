**Building web services using Minimal APIs**

- [Native AOT for ASP.NET Core](#native-aot-for-aspnet-core)
- [Enabling JSON serialization with native AOT](#enabling-json-serialization-with-native-aot)
- [Example](#example)
- [Testing the minimal weather service](#testing-the-minimal-weather-service)
- [Adding weather forecasts to the Northwind website home page](#adding-weather-forecasts-to-the-northwind-website-home-page)


For .NET 6, Microsoft put a lot of effort into adding new features to the C# 10 language and simplifying the ASP.NET Core libraries to enable the creation of web services using **Minimal APIs**. Minimal APIs are designed to enable the creation of HTTP APIs with minimum lines of code. Minimal APIs are covered in more detail in my companion book, **Apps and Services with .NET 8**.

# Native AOT for ASP.NET Core

.NET 7 only supported native AOT with console apps and class libraries on Windows or Linux. It did not support macOS or ASP.NET Core. .NET 8 is the first version to support macOS and parts of ASP.NET Core.

The following ASP.NET Core features are fully supported: gRPC, CORS, HealthChecks, HttpLogging, Localization, OutputCaching, RateLimiting, RequestDecompression, ResponseCaching, ResponseCompression, Rewrite, StaticFiles, WebSockets.

The following ASP.NET Core features are partially supported: Minimal APIs.

The following ASP.NET Core features are not supported (yet): MVC, Blazor Server, SignalR, Authentication (except JWT), Session, SPA.

You implement an ASP.NET Core Minimal APIs web service by mapping an HTTP request to a lambda expression, for example, as shown in the following code:
```cs
app.MapGet("/", () => "Hello World!");
```
At runtime, ASP.NET Core uses the **RequestDelegateFactory (RDF)** class to convert your `MapX` calls into `RequestDelegate` instances. But this is dynamic code so is not compatible with native AOT.

In ASP.NET Core 8, when native AOT is enabled, the runtime use of RDF is replaced with a source generator named **Request Delegate Generator (RDG)** that performs similar work but at compile time. This makes sure the code generated is statically analyzable by the native AOT publish process.

> **More Information**: You can learn how to create your own source generator at the following link: https://github.com/markjprice/apps-services-net8/blob/main/docs/ch01-dynamic-code.md#creating-source-generators

# Enabling JSON serialization with native AOT

JSON serialization with native AOT requires the use of the `System.Text.Json` source generator. All model types passed as parameters or return values must be registered with a JsonSerializerContext, as shown in the following code:
```cs
[JsonSerializable(typeof(Product)] // A single Product.
[JsonSerializable(typeof(Product[]))] // An array of Products.
public partial class MyJsonSerializerContext : JsonSerializerContext { }
```
Your custom JSON serializer context must be added to the service dependencies, as shown in the following code:
```cs
builder.Services.ConfigureHttpJsonOptions(options =>
{
  options.SerializerOptions.AddContext<MyJsonSerializerContext>();
});
```

# Example

You might remember the weather forecast service that is provided in the Web API project template. It shows the use of a controller class to return a five-day weather forecast using faked data. We will now recreate that weather service using Minimal APIs.

It will listen on port 5152 and only `GET` requests are allowed:

1.	Use your preferred code editor to open the `PracticalApps` solution and then add a new project, as defined in the following list:
    - Project template: **ASP.NET Core API** / `api`
    - Project file and folder: `Northwind.MinimalApi`
    - Solution file and folder: `PracticalApps`
    - Authentication Type: None.
    - Enable Docker: Cleared.
    - Enable OpenAPI support: Selected.
    - Do not use top-level statements: Cleared.

> **Good Practice**: For faster startup time and minimal memory footprint by using native AOT publish, choose the **ASP.NET Core API** project template instead of the older **ASP.NET Core Web API** project template.

2.	Review `Program.cs`, as shown in the following code:
```cs
var builder = WebApplication.CreateSlimBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
     new WeatherForecast
     (
         DateTime.Now.AddDays(index),
         Random.Shared.Next(-20, 55),
         summaries[Random.Shared.Next(summaries.Length)]
     ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```
Note the following:
- A record named `WeatherForecast` is defined at the bottom of `Program.cs` with three data store properties: `Date`, `TemperatureC`, `Summary`, and one calculated property: `TemperatureF`.
- The call to `MapGet` registers a handler for incoming `GET` requests to the relative path `/weatherforecast`. It returns five `WeatherForecast` instances with random values for the `TemperatureC` and `Summary` properties.
- There is no `Controllers` folder and no controller classes.

> **Good Practice**: For simple web services, avoid creating a controller class, and instead use Minimal APIs to put all the configuration and implementation in one place, `Program.cs`.

2.	In the `Properties` folder, in `launchSettings.json`, configure the `http` profile to launch the browser using port `5152` in the URL and the relative API path, as shown in the following markup:
```json
"applicationUrl": "http://localhost:5152",
```

# Testing the minimal weather service

Before creating a client for the service, let's test that it returns forecasts as JSON:

1.	Start the `Northwind.MinimalApi` web service project using the `http` launch profile.
2.	If you are not using Visual Studio 2022, start Chrome and navigate to http://localhost:5152/weatherforecast.
3.	Note the Minimal API service should return a JSON document with five random weather forecast objects in an array.
4.	Close Chrome and shut down the web server.

# Adding weather forecasts to the Northwind website home page

Finally, let's add an HTTP client to the Northwind website so that it can call the weather service and show forecasts on the home page:

1.	In the `Northwind.Mvc` project, in the `Models` folder, add a class file named `WeatherForecast.cs`, as shown in the following code:
```cs
namespace Northwind.Mvc.Models;

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```
2.	In `Program.cs`, before the call to `Build`, add a statement to configure an HTTP client to call the minimal service on port `5152`, as shown in the following code:
```cs
builder.Services.AddHttpClient(name: "Northwind.MinimalApi",
  configureClient: options =>
  {
    options.BaseAddress = new Uri("https://localhost:5152/");
    options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue(
      "application/json", 1.0));
  });
```
3.	In `HomeController.cs`, in the `Index` action method, before the call to `View`, add statements to get and use an HTTP client to call the weather service to get forecasts and store them in `ViewData`, as shown in the following code:
```cs
try
{
  HttpClient client = clientFactory.CreateClient(
    name: "Northwind.MinimalApi");

  HttpRequestMessage request = new(
    method: HttpMethod.Get, requestUri: "weatherforecast");

  HttpResponseMessage response = await client.SendAsync(request);

  ViewData["weather"] = await response.Content
    .ReadFromJsonAsync<WeatherForecast[]>();
}
catch (Exception ex)
{
  _logger.LogWarning(
    $"The Minimal.WebApi service is not responding. Exception: {ex.Message}");

  ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
}
```
4.	In `Views/Home`, in `Index.cshtml`, in the top code block, get the weather forecasts from the `ViewData`` dictionary, as shown in the following markup:
```cs
@{
  ViewData["Title"] = "Home Page";
  string currentItem = "";
  WeatherForecast[]? weather = ViewData["weather"] as WeatherForecast[];
}
```
5.	In the first `<div>`, after rendering the current time, add markup to enumerate the weather forecasts unless there aren't any, and render them in a table, as shown in the following markup:
```html
<p>
  <h4>Five-Day Weather Forecast</h4>
  @if ((weather is null) || (!weather.Any()))
  {
    <p>No weather forecasts found.</p>
  }
  else
  {
  <table class="table table-info">
    <tr>
      @foreach (WeatherForecast w in weather)
      {
        <td>@w.Date.ToString("ddd d MMM") will be @w.Summary</td>
      }
    </tr>
  </table>
  }
</p>
```
6.	Start the `Northwind.MinimalApi` web service project using the `http` launch profile.
7.	Start the `Northwind.Mvc` website project using the `https` launch profile.
8.	Navigate to https://localhost:5151/ and note the weather forecast, as shown in *Figure 15B.1*:

![A five-day weather forecast on the home page of the Northwind website](assets/B19586_15B_01.png) 
*Figure 15B.1: A five-day weather forecast on the home page of the Northwind website*

9.	In the command prompt or terminal for the MVC website, note the info messages that indicate a request was sent to the Minimal APIs web service `api/weather` endpoint in about 83 ms, as shown in the following output:
```
info: System.Net.Http.HttpClient.Northwind.MinimalApi.LogicalHandler[100]
      Start processing HTTP request GET http://localhost:5152/weatherforecast
info: System.Net.Http.HttpClient.Northwind.MinimalApi.ClientHandler[100]
      Sending HTTP request GET https://localhost:5152/weatherforecast
info: System.Net.Http.HttpClient.Northwind.MinimalApi.ClientHandler[101]
      Received HTTP response headers after 76.8963ms - 200
info: System.Net.Http.HttpClient.Northwind.MinimalApi.LogicalHandler[101]
      End processing HTTP request after 82.9515ms – 200
```
10.	Stop the `Northwind.MinimalApi` service, refresh the browser, and note that after a few seconds the MVC website home page appears without weather forecasts because the web service is not responding.
11.	Close Chrome and shut down the web server.
