using Northwind.EntityModels; // To use NorthwindContext.

namespace Northwind.UnitTests;

public class ControllerUnitTests
{
  [Fact]
  public void ControllerTest()
  {
    using NorthwindContext db = new();
    Assert.True(db.Database.CanConnect());
  }
}