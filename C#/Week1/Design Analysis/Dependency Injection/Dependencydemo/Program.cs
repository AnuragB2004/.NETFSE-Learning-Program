using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Dependency Injection Pattern Demo ===\n");

        // Demonstrate Dependency Injection with different repository implementations

        Console.WriteLine("1. Using CustomerRepositoryImpl:");
        Console.WriteLine(new string('-', 50));
        
        // Create repository and inject it into service
        ICustomerRepository repository1 = new CustomerRepositoryImpl();
        CustomerService customerService1 = new CustomerService(repository1);

        // Test service operations
        customerService1.DisplayCustomerInfo(1);
        customerService1.DisplayCustomerInfo(2);
        customerService1.DisplayCustomerInfo(999); // Non-existent customer

        Console.WriteLine("\nCreating a new customer:");
        customerService1.CreateCustomer("Charlie Wilson", "charlie.wilson@email.com", "444-555-6666");

        Console.WriteLine("\nAll customers:");
        var allCustomers1 = customerService1.GetAllCustomers();
        foreach (var customer in allCustomers1)
        {
            Console.WriteLine($"  {customer}");
        }

        Console.WriteLine("\n" + new string('=', 60) + "\n");

        Console.WriteLine("2. Using InMemoryCustomerRepository (Different Implementation):");
        Console.WriteLine(new string('-', 50));

        // Use different repository implementation with same service class
        ICustomerRepository repository2 = new InMemoryCustomerRepository();
        CustomerService customerService2 = new CustomerService(repository2);

        // Add some customers to the in-memory repository
        customerService2.CreateCustomer("David Lee", "david.lee@email.com", "111-222-3333");
        customerService2.CreateCustomer("Eva Garcia", "eva.garcia@email.com", "999-888-7777");

        Console.WriteLine("\nAll customers in in-memory repository:");
        var allCustomers2 = customerService2.GetAllCustomers();
        foreach (var customer in allCustomers2)
        {
            Console.WriteLine($"  {customer}");
        }

        Console.WriteLine("\nUpdating a customer:");
        customerService2.UpdateCustomer(1, "David Lee Jr.", "david.lee.jr@email.com", "111-222-4444");

        Console.WriteLine("\nCustomer after update:");
        customerService2.DisplayCustomerInfo(1);

        Console.WriteLine("\nDeleting a customer:");
        customerService2.DeleteCustomer(2);

        Console.WriteLine("\nAll customers after deletion:");
        var remainingCustomers = customerService2.GetAllCustomers();
        foreach (var customer in remainingCustomers)
        {
            Console.WriteLine($"  {customer}");
        }

        Console.WriteLine("\n" + new string('=', 60) + "\n");

        Console.WriteLine("3. Demonstrating the power of Dependency Injection:");
        Console.WriteLine("   - Same CustomerService class works with different repository implementations");
        Console.WriteLine("   - Easy to swap implementations without changing service code");
        Console.WriteLine("   - Promotes loose coupling and testability");
        Console.WriteLine("   - Repository implementations can be easily mocked for unit testing");
    }
}