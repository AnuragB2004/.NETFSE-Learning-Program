using System;
using OrderSorting;

class Program
{
    static void Main()
    {
        Order[] orders = new Order[]
        {
            new Order(101, "Alice", 199.99m),
            new Order(102, "Bob", 89.50m),
            new Order(103, "Charlie", 299.00m),
            new Order(104, "Diana", 150.75m)
        };

        Console.WriteLine("--- Original Orders ---");
        foreach (var order in orders)
            Console.WriteLine(order);

        Console.WriteLine("\n--- Sorted by Bubble Sort ---");
        OrderSorter.BubbleSort(orders);
        foreach (var order in orders)
            Console.WriteLine(order);

        // Reset for Quick Sort
        orders = new Order[]
        {
            new Order(101, "Alice", 199.99m),
            new Order(102, "Bob", 89.50m),
            new Order(103, "Charlie", 299.00m),
            new Order(104, "Diana", 150.75m)
        };

        Console.WriteLine("\n--- Sorted by Quick Sort ---");
        OrderSorter.QuickSort(orders, 0, orders.Length - 1);
        foreach (var order in orders)
            Console.WriteLine(order);
    }
}
