using ConsoleApp10.Context;
using ConsoleApp10.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Applecationdbcontext context = new Applecationdbcontext();

            List<Product> products = new List<Product>
    {
        new Product() { Name = "Laptop", Price = 1500.0 },
        new Product() { Name = "Smartphone", Price = 800.0 },
        new Product() { Name = "Tablet", Price = 300.0 },
        new Product() { Name = "Monitor", Price = 200.0 },
        new Product() { Name = "Keyboard", Price = 50.0 }
    };
            List<Order> orders = new List<Order>
    {
        new Order() { Address = "123 Main St" },
        new Order() { Address = "456 Elm St" },
        new Order() { Address = "789 Oak St" },
        new Order() { Address = "101 Pine St" },
        new Order() { Address = "202 Maple St" }
    };




            context.Products.AddRange(products);
            context.orders.AddRange(orders);


            var e = context.Products.ToList();
            foreach (var item in e)
            {
                Console.WriteLine(item.Id + "    " + item.Name + "    " + item.Price);
            }

            Console.WriteLine("-----------------------------");

            var a = context.orders.ToList();
            foreach (var item in a)
            {
                Console.WriteLine(item.Id + "     " + item.Address + "     " + item.createdAt);
            }

            var b = context.orders.First(a => a.Id == 1);
            b.createdAt = DateTime.Now.AddHours(2);

            var c = context.Products.First(a => a.Id == 3);
            c.Name = "Iphone";



            var d = context.orders.First(a => a.Id == 3);

            context.orders.Remove(d);


            var f = context.Products.First(a => a.Id == 2);
            context.Products.Remove(f);

            context.SaveChanges();

        }
    }
}
