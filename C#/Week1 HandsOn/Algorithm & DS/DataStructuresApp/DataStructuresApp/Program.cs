using System;
using System.Collections.Generic;

namespace DataStructuresApp
{
    // --- Exercise 1: Inventory Management ---
    public class Product
    {
        public int Id;
        public string Name;
        public int Quantity;
        public decimal Price;

        public Product(int id, string name, int quantity, decimal price)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString() => $"{Id} - {Name} (Qty: {Quantity}, Price: ${Price})";
    }

    public class InventoryManager
    {
        private Dictionary<int, Product> inventory = new();

        public void AddProduct(Product product) => inventory[product.Id] = product;

        public void UpdateProduct(int id, int quantity, decimal price)
        {
            if (inventory.ContainsKey(id))
            {
                inventory[id].Quantity = quantity;
                inventory[id].Price = price;
            }
        }

        public void DeleteProduct(int id) => inventory.Remove(id);

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in inventory.Values)
                Console.WriteLine(item);
        }
    }

    // --- Exercise 2: Financial Forecasting ---
    public class FinancialForecaster
    {
        private Dictionary<int, decimal> memo = new();

        public decimal CalculateFutureValue(decimal presentValue, decimal growthRate, int years)
        {
            if (years == 0) return presentValue;
            if (memo.ContainsKey(years)) return memo[years];
            decimal futureValue = presentValue * (1 + growthRate) * CalculateFutureValue(1, growthRate, years - 1);
            memo[years] = futureValue;
            return futureValue;
        }

        public decimal CalculateFutureValueIterative(decimal presentValue, decimal growthRate, int years)
        {
            decimal result = presentValue;
            for (int i = 0; i < years; i++) result *= (1 + growthRate);
            return result;
        }

        public decimal CalculateFutureValueFormula(decimal presentValue, decimal growthRate, int years)
        {
            return presentValue * (decimal)Math.Pow((double)(1 + growthRate), years);
        }
    }

    // --- Main Program ---
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Simplified Data Structures App ===");

            // Inventory Management Test
            Console.WriteLine("\n--- Inventory ---");
            var inventory = new InventoryManager();
            inventory.AddProduct(new Product(1, "Laptop", 5, 899.99m));
            inventory.AddProduct(new Product(2, "Mouse", 10, 29.99m));
            inventory.UpdateProduct(1, 4, 850.00m);
            inventory.DisplayInventory();
            inventory.DeleteProduct(2);
            inventory.DisplayInventory();

            // Financial Forecast Test
            Console.WriteLine("\n--- Financial Forecasting ---");
            var forecaster = new FinancialForecaster();
            decimal presentValue = 1000m, growthRate = 0.05m;
            int years = 5;

            Console.WriteLine($"Present Value: ${presentValue}, Growth Rate: {growthRate:P}, Years: {years}");
            Console.WriteLine($"Recursive: ${forecaster.CalculateFutureValue(presentValue, growthRate, years):F2}");
            Console.WriteLine($"Iterative: ${forecaster.CalculateFutureValueIterative(presentValue, growthRate, years):F2}");
            Console.WriteLine($"Formula: ${forecaster.CalculateFutureValueFormula(presentValue, growthRate, years):F2}");
        }
    }
}
