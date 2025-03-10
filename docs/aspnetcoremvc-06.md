# Practicing and exploring

Test your knowledge and understanding by answering some questions, getting some hands-on practice, and exploring this chapter's topics with deeper research.

- [Practicing and exploring](#practicing-and-exploring)
  - [Exercise 14.1 – Test your knowledge](#exercise-141--test-your-knowledge)
  - [Exercise 14.2 – Practice implementing MVC by implementing a category detail page](#exercise-142--practice-implementing-mvc-by-implementing-a-category-detail-page)
  - [Exercise 14.3 – Practice improving scalability by understanding and implementing async action methods](#exercise-143--practice-improving-scalability-by-understanding-and-implementing-async-action-methods)
  - [Exercise 14.4 – Practice unit testing MVC controllers](#exercise-144--practice-unit-testing-mvc-controllers)
  - [Exercise 14.5 – Using a filter to control authorization](#exercise-145--using-a-filter-to-control-authorization)
  - [Exercise 14.6 – Explore topics](#exercise-146--explore-topics)
- [Summary](#summary)


## Exercise 14.1 – Test your knowledge

Answer the following questions:

1.	What do the files with the special names `_ViewStart` and `_ViewImports` do when created in the `Views` folder?
2.	What are the names of the three segments defined in the default ASP.NET Core MVC route, what do they represent, and which are optional?
3.	What does the default model binder do, and what data types can it handle?
4.	In a shared layout file like `_Layout.cshtml`, how do you output the content of the current view?
5.	In a shared layout file like `_Layout.cshtml`, how do you output a section that the current view can supply content for, and how does the view supply the contents for that section?
6.	When calling the `View` method inside a controller's action method, what paths are searched for the view by convention?
7.	How can you instruct the visitor's browser to cache the response for 24 hours?
8.	Why might you enable Razor Pages even if you are not creating any yourself?
9.	How does ASP.NET Core MVC identify classes that can act as controllers?
10.	In what ways does ASP.NET Core MVC make it easier to test a website?

## Exercise 14.2 – Practice implementing MVC by implementing a category detail page

The `Northwind.Mvc` project has a home page that shows categories, but when the **View** button is clicked, the website returns a `404 Not Found` error, for example, for the following URL:

https://localhost:5141/home/categorydetail/1

Extend the `Northwind.Mvc` project by adding the ability to show a detail page for a category.

For example, add an action method to the HomeController class, as shown in the following code:
```cs
public async Task<IActionResult> CategoryDetail(int? id)
{
  if (!id.HasValue)
  {
    return BadRequest("You must pass a category ID in the route, for example, /Home/CategoryDetail/6");
  }

  Category? model = await _db.Categories.Include(p => p.Products)
    .SingleOrDefaultAsync(p => p.CategoryId == id);

  if (model is null)
  {
    return NotFound($"CategoryId {id} not found.");
  }

  return View(model); // Pass model to view and then return result.
}
```

And create a view that matches the name `CategoryDetail.cshtml`, as shown in the following markup:
```html
@model Northwind.EntityModels.Category
@{
  ViewData["Title"] = "Category Detail - " + Model.CategoryName;
}
<h2>Category Detail</h2>
<div>
  <dl class="dl-horizontal">
    <dt>Category Id</dt>
    <dd>@Model.CategoryId</dd>
    <dt>Product Name</dt>
    <dd>@Model.CategoryName</dd>
    <dt>Products</dt>
    <dd>@Model.Products.Count</dd>
    <dt>Description</dt>
    <dd>@Model.Description</dd>
  </dl>
</div>
```

## Exercise 14.3 – Practice improving scalability by understanding and implementing async action methods

Almost a decade ago, Stephen Cleary wrote an excellent article for MSDN Magazine explaining the scalability benefits of implementing async action methods for ASP.NET. The same principles apply to ASP.NET Core, but even more so, because unlike the old ASP.NET as described in the article, ASP.NET Core supports asynchronous filters and other components.

Read the article at the following link:
https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/october/async-programming-introduction-to-async-await-on-asp-net

## Exercise 14.4 – Practice unit testing MVC controllers

Controllers are where the business logic of your website runs, so it is important to test the correctness of that logic using unit tests, as you learned in *Chapter 4, Writing, Debugging, and Testing Functions*.

Write some unit tests for HomeController.

> **Good Practice**: You can read more about how to unit test controllers at the following link: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/testing.

## Exercise 14.5 – Using a filter to control authorization

In this chapter, you learned about cross-functional filters like `[Route]` and `[ResponseCache]`. To learn how to secure parts of a website using the `[Authorize]` attribute, you can read an optional online-only section at the following link:
https://github.com/markjprice/cs12dotnet8/blob/main/docs/ch13-authorization.md

## Exercise 14.6 – Explore topics

Use the links on the following page to learn more about the topics covered in this chapter:
https://github.com/markjprice/cs12dotnet8/blob/main/docs/book-links.md#chapter-14---building-websites-using-the-model-view-controller-pattern

# Summary

In this chapter, you learned how to build large, complex websites in a way that is easy to unit test by registering and injecting dependency services like database contexts and loggers. You learned about:
- Configuration
- Routes
- Models
- Views
- Controllers
- Caching
