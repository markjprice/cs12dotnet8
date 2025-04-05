using Northwind.EntityModels; // To use Customer.
using System.Net.Http.Json; // To use GetFromJsonAsync.

namespace Northwind.Blazor.Services;

public class NorthwindServiceClientSide : INorthwindService
{
  private readonly HttpClient _http;

  public NorthwindServiceClientSide(HttpClient httpClient)
  {
    _http = httpClient;
  }

  public Task<List<Customer>> GetCustomersAsync()
  {
    return _http.GetFromJsonAsync
      <List<Customer>>("api/customers")!;
  }

  public Task<List<Customer>> GetCustomersAsync(string country)
  {
    return _http.GetFromJsonAsync
      <List<Customer>>($"api/customers/in/{country}")!;
  }

  public Task<Customer?> GetCustomerAsync(string id)
  {
    return _http.GetFromJsonAsync
      <Customer>($"api/customers/{id}");
  }

  public async Task<Customer>
    CreateCustomerAsync(Customer c)
  {
    HttpResponseMessage response = await
      _http.PostAsJsonAsync("api/customers", c);

    return (await response.Content
      .ReadFromJsonAsync<Customer>())!;
  }

  public async Task<Customer> UpdateCustomerAsync(Customer c)
  {
    HttpResponseMessage response = await
      _http.PutAsJsonAsync("api/customers", c);

    return (await response.Content
      .ReadFromJsonAsync<Customer>())!;
  }

  public async Task DeleteCustomerAsync(string id)
  {
    HttpResponseMessage response = await
      _http.DeleteAsync($"api/customers/{id}");
  }

  public List<string?> GetCountries()
  {
    return _http.GetFromJsonAsync<List<string?>>("api/countries")!.Result!;
  }
}
