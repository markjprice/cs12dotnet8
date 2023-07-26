// To use [Range], [Required], [EmailAddress].
using System.ComponentModel.DataAnnotations;

namespace Northwind.Mvc.Models;

public record Thing(
  [Range(1, 10)] int? Id,
  [Required] string? Color,
  [EmailAddress] string? Email
);
