using System;
using DataStructuresAndAlgorithms;

class Program
{
    static void Main()
    {
        var manager = new InventoryManager();
        manager.AddProduct(new Product(1, "Laptop", 10, 999.99m));
        manager.AddProduct(new Product(2, "Mouse", 50, 19.99m));
        manager.UpdateProduct(1, 8, 949.99m);
        manager.DeleteProduct(3); // Non-existent product
        manager.DisplayInventory();
    }
}
