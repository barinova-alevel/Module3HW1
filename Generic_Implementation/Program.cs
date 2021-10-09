using System;
using System.Collections.Generic;

namespace Generic_Implementation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new MyList<int>(5) { 4, 7, 2, 9 };
            var array = new MyList<int> { 9, 8, 5, 6, 4, 3, 1, 4, 2 };
            Product[] rangeProducts = new Product[5]
        {
        new Product() { Name = "RangeProductName1", Price = 10.0, ProductId = 3 },
        new Product() { Name = "RangeProductName2", Price = 11.1, ProductId = 4 },
        new Product() { Name = "RangeProductName3", Price = 10000.5, ProductId = 5 },
        new Product() { Name = "RangeProductName4", Price = 0, ProductId = 6 },
        new Product() { Name = "RangeProductName5", Price = -7, ProductId = 7 }
        };
            var products = new List<Product>(6);
            products.Add(new Product() { Name = "Name1" });
            products.Add(new Product() { Name = "Name2", Price = 2.5 });
            products.Add(new Product() { Name = "Name3", Price = 10.5, ProductId = 1 });
            products.Add(new Product() { Name = "Name4", Price = 15.5, ProductId = 02 });

            myList.AddRange(array);

            myList.Capacity = 2;

            Console.WriteLine("Before remove");
            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }

            myList.Remove(4);
            myList.RemoveAt(4);

            myList.Sort(new IntComparer());

            Console.WriteLine();

            Console.WriteLine("After remove and sort");

            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine("List of products:");
            PrintArrayElements(products);

            products.AddRange(rangeProducts);
            Console.WriteLine();
            Console.WriteLine("After updating of the list with a range: ");
            PrintArrayElements(products);

            Console.WriteLine();
            Console.WriteLine("After removing: ");
            products.Remove(null);
            products.Remove(products[1]);
            products.RemoveAt(2);
            PrintArrayElements(products);
            Console.WriteLine();
            Console.WriteLine($"Access by index 4: {products[4].Name}");
            Console.WriteLine("Access by index 416: {products[416].Name}");

            Console.WriteLine("After sorting:");

            // products.Sort((IComparer<Product>)products);
            PrintArrayElements(products);
            void PrintArrayElements(List<Product> product)
            {
                foreach (Product p in product)
                {
                    Console.WriteLine($"Product id: {p.ProductId.ToString()}, Product name: {p.Name}, Price: {p.Price.ToString()}");
                }
            }

            Console.ReadKey();
        }
    }
}
