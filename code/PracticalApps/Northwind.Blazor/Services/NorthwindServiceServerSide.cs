using Microsoft.EntityFrameworkCore; // To use ToListAsync<T>.

namespace Northwind.Blazor.Services;

public class NorthwindServiceServerSide : INorthwindService
{
  private readonly NorthwindContext _db;

  public NorthwindServiceServerSide(NorthwindContext db)
  {
    _db = db;
  }
  
  public Task<List<Customer>> GetCustomersAsync()
  {
    return _db.Customers.ToListAsync();
  }
  
  public Task<List<Customer>> GetCustomersAsync(string country)
  {
    return _db.Customers.Where(c => c.Country == country).ToListAsync();
  }
  
  public Task<Customer?> GetCustomerAsync(string id)
  {
    return _db.Customers.FirstOrDefaultAsync
      (c => c.CustomerId == id);
  }
  
  public Task<Customer> CreateCustomerAsync(Customer c)
  {
    _db.Customers.Add(c);
    _db.SaveChangesAsync();
    return Task.FromResult(c);
  }
  public Task<Customer> UpdateCustomerAsync(Customer c)
  {
    _db.Entry(c).State = EntityState.Modified;
    _db.SaveChangesAsync();
    return Task.FromResult(c);
  }

  public Task DeleteCustomerAsync(string id)
  {
    Customer? customer = _db.Customers.FirstOrDefaultAsync
    (c => c.CustomerId == id).Result;
    if (customer == null)
    {
      return Task.CompletedTask;
    }
    else
    {
      _db.Customers.Remove(customer);
      return _db.SaveChangesAsync();
    }
  }

  public List<string?> GetCountries()
  {
    return _db.Customers.Select(c => c.Country)
    .Distinct().OrderBy(country => country).ToList();
  }
}
