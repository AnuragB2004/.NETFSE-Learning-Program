using System;
using ECommerceSearch;

class Program
{
    static void Main()
    {
        SearchableProduct[] products = new SearchableProduct[]
        {
            new SearchableProduct(1, "Laptop", "Electronics"),
            new SearchableProduct(2, "Keyboard", "Electronics"),
            new SearchableProduct(3, "Chair", "Furniture"),
            new SearchableProduct(4, "Pen", "Stationery"),
            new SearchableProduct(5, "Notebook", "Stationery")
        };

        SearchEngine engine = new SearchEngine(products);

        Console.WriteLine("---- Linear Search ----");
        var result1 = engine.LinearSearch("Chair");
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

        Console.WriteLine("\n---- Binary Search ----");
        var result2 = engine.BinarySearch("Chair");
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");
    }
}
