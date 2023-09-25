using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using EFGetStarted.Data;
using EFGetStarted.Models;

using var db = new CompanyContext(); // < -- Ensures proper disposal adter usage...

//CREATE
Product exampleProduct = new Product()
{
    Name = "Example Product",
    Price = 9.99M
};
db.Products.Add(exampleProduct);

Product exampleProduct2 = new ()
{
    Name = "Example Product 2",
    Price = 19.99M
};
db.Add(exampleProduct2);

//READ
var products = db.Products.Where(p => p.Price > 10M).OrderBy(p => p.Name).ToList();

foreach (Product product in products)
{
    Console.WriteLine("Products: " + product.Name);
    Console.WriteLine("Price: " + product.Price);
}

//Update
Product? exampleProductUpdate = db.Products.Where(p => p.Name == "Example Product 2").FirstOrDefault();
if (exampleProductUpdate is Product)
{
    exampleProductUpdate.Price = 15.99M;
}

//Delete
Product? exampleProductDelete = db.Products.Where(p => p.Name == "Example Product 2").FirstOrDefault();
if (exampleProductDelete is Product)
{
    db.Remove(exampleProductDelete);
}

db.SaveChanges();





// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// // Create
// Console.WriteLine("Inserting a new blog");
// db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
// db.SaveChanges();

// // Read
// Console.WriteLine("Querying for a blog");
// var blog = db.Blogs
//     .OrderBy(b => b.BlogId)
//     .First();

// // Update
// Console.WriteLine("Updating the blog and adding a post");
// blog.Url = "https://devblogs.microsoft.com/dotnet";
// blog.Posts.Add(
//     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
// db.SaveChanges();

// // Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
// db.SaveChanges();