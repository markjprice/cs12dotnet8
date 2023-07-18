**Working with LINQ to XML**

- [Introducing LINQ to XML](#introducing-linq-to-xml)
- [Generating XML using LINQ to XML](#generating-xml-using-linq-to-xml)
- [Reading XML using LINQ to XML](#reading-xml-using-linq-to-xml)


# Introducing LINQ to XML

LINQ to XML is a LINQ provider that allows you to query and manipulate XML.

# Generating XML using LINQ to XML

Let's create a method to convert the Products table into XML:

1.	In the `LinqWithEFCore` project, in `Program.Functions.cs`, import the `System.Xml.Linq` namespace, as shown in the following code:
```cs
using System.Xml.Linq; // To use XElement, XAttribute.
```

2.	In `Program.Functions.cs`, add a method to output the products in XML format, as shown in the following code:
```cs
static void OutputProductsAsXml()
{
  SectionTitle("Output products as XML");

  using (NorthwindDb db = new())
  {
    Product[] productsArray = db.Products.ToArray();

    XElement xml = new("products",
      from p in productsArray
      select new XElement("product",
        new XAttribute("id",  p.ProductId),
        new XAttribute("price", p.UnitPrice ?? 0),
       new XElement("name", p.ProductName)));

    WriteLine(xml.ToString());
  }
}
```

3.	In `Program.cs`, call the `OutputProductsAsXml` method.
4.	Run the project, view the result, and note that the structure of the XML generated matches the elements and attributes that the LINQ to XML statement declaratively described in the preceding code, as shown in the following partial output:
```xml
<products>
  <product id="1" price="18">
    <name>Chai</name>
  </product>
  <product id="2" price="19">
    <name>Chang</name>
  </product>
...
```

# Reading XML using LINQ to XML

You might want to use LINQ to XML to easily query or process XML files:

1.	In the `LinqWithEFCore` project, add a file named `settings.xml`.
2.	Modify its contents, as shown in the following markup:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<appSettings>
  <add key="color" value="red" />
  <add key="size" value="large" />
  <add key="price" value="23.99" />
</appSettings>
```

> **Warning!** If you are using Visual Studio 2022, then the compiled application executes in the `LinqWithEFCore\bin\Debug\net8.0` folder so it will not find the `settings.xml` file unless we indicate that it should always be copied to the output directory. Select the `settings.xml` file and set its **Copy to Output Directory** property to **Copy always**.

3.	In `Program.Functions.cs`, add a method to complete these tasks, as shown in the following code:
    - Load the XML file.
    - Use LINQ to XML to search for an element named `appSettings` and its descendants named `add`.
    - Project the XML into an array of an anonymous type with `Key` and `Value` properties.
    - Enumerate through the array to show the results:
```cs
static void ProcessSettings()
{
  string path = Path.Combine(
    Environment.CurrentDirectory, "settings.xml");

  WriteLine($"Settings file path: {path}");
  XDocument doc = XDocument.Load(path);

  var appSettings = doc.Descendants("appSettings")
    .Descendants("add")
    .Select(node => new
    {
      Key = node.Attribute("key")?.Value,
      Value = node.Attribute("value")?.Value
    }).ToArray();

  foreach (var item in appSettings)
  {
    WriteLine($"{item.Key}: {item.Value}");
  }
}
```

4.	In `Program.cs`, call the `ProcessSettings` method.
5.	Run the console app and view the result, as shown in the following output:
```
Settings file path: C:\cs12dotnet8\Chapter11\LinqWithEFCore\bin\Debug\net8.0\settings.xml
color: red 
size: large 
price: 23.99
```
