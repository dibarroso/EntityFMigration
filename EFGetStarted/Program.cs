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
