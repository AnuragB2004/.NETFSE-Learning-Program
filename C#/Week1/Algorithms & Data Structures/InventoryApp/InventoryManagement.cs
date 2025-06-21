using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    // Exercise 1: Inventory Management System
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, int quantity, decimal price)
        {
            ProductId = id;
            ProductName = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: ${Price}";
        }
    }

    public class InventoryManager
    {
        // Using Dictionary for O(1) average case operations
        private Dictionary<int, Product> inventory;

        public InventoryManager()
        {
            inventory = new Dictionary<int, Product>();
        }

        // Time Complexity: O(1) average case
        public void AddProduct(Product product)
        {
            inventory[product.ProductId] = product;
            Console.WriteLine($"Added: {product}");
        }

        // Time Complexity: O(1) average case
        public bool UpdateProduct(int productId, int newQuantity, decimal newPrice)
        {
            if (inventory.ContainsKey(productId))
            {
                inventory[productId].Quantity = newQuantity;
                inventory[productId].Price = newPrice;
                Console.WriteLine($"Updated product {productId}");
                return true;
            }
            Console.WriteLine($"Product {productId} not found");
            return false;
        }

        // Time Complexity: O(1) average case
        public bool DeleteProduct(int productId)
        {
            if (inventory.Remove(productId))
            {
                Console.WriteLine($"Deleted product {productId}");
                return true;
            }
            Console.WriteLine($"Product {productId} not found");
            return false;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n--- Current Inventory ---");
            foreach (var product in inventory.Values)
            {
                Console.WriteLine(product);
            }
        }
    }
}