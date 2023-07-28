namespace Northwind.Mvc.Models;

public record ToDo(int Id, string? Title, DateOnly? DueBy, bool IsComplete);
