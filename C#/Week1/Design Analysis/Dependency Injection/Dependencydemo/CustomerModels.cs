using System;
using System.Collections.Generic;
using System.Linq;

// Customer Model
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Customer(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public override string ToString()
    {
        return $"Customer [ID: {Id}, Name: {Name}, Email: {Email}, Phone: {Phone}]";
    }
}

// Repository Interface
public interface ICustomerRepository
{
    Customer FindCustomerById(int id);
    List<Customer> GetAllCustomers();
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
}

// Concrete Repository Implementation
public class CustomerRepositoryImpl : ICustomerRepository
{
    private List<Customer> _customers;

    public CustomerRepositoryImpl()
    {
        // Initialize with some sample data
        _customers = new List<Customer>
        {
            new Customer(1, "John Doe", "john.doe@email.com", "123-456-7890"),
            new Customer(2, "Jane Smith", "jane.smith@email.com", "098-765-4321"),
            new Customer(3, "Bob Johnson", "bob.johnson@email.com", "555-123-4567"),
            new Customer(4, "Alice Brown", "alice.brown@email.com", "777-888-9999")
        };
        Console.WriteLine("CustomerRepositoryImpl: Repository initialized with sample data");
    }

    public Customer FindCustomerById(int id)
    {
        Console.WriteLine($"CustomerRepositoryImpl: Searching for customer with ID {id}");
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
        {
            Console.WriteLine($"CustomerRepositoryImpl: Customer found - {customer.Name}");
        }
        else
        {
            Console.WriteLine($"CustomerRepositoryImpl: No customer found with ID {id}");
        }
        return customer;
    }

    public List<Customer> GetAllCustomers()
    {
        Console.WriteLine($"CustomerRepositoryImpl: Retrieving all customers ({_customers.Count} total)");
        return new List<Customer>(_customers);
    }

    public void AddCustomer(Customer customer)
    {
        Console.WriteLine($"CustomerRepositoryImpl: Adding customer - {customer.Name}");
        _customers.Add(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        Console.WriteLine($"CustomerRepositoryImpl: Updating customer with ID {customer.Id}");
        var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
        if (existingCustomer != null)
        {
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            Console.WriteLine("CustomerRepositoryImpl: Customer updated successfully");
        }
        else
        {
            Console.WriteLine($"CustomerRepositoryImpl: Customer with ID {customer.Id} not found for update");
        }
    }

    public void DeleteCustomer(int id)
    {
        Console.WriteLine($"CustomerRepositoryImpl: Deleting customer with ID {id}");
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
        {
            _customers.Remove(customer);
            Console.WriteLine("CustomerRepositoryImpl: Customer deleted successfully");
        }
        else
        {
            Console.WriteLine($"CustomerRepositoryImpl: Customer with ID {id} not found for deletion");
        }
    }
}

// Service Class
public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    // Constructor Injection
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        Console.WriteLine("CustomerService: Service initialized with repository dependency");
    }

    public Customer GetCustomerById(int id)
    {
        Console.WriteLine($"CustomerService: Getting customer by ID {id}");
        if (id <= 0)
        {
            Console.WriteLine("CustomerService: Invalid customer ID provided");
            return null;
        }
        return _customerRepository.FindCustomerById(id);
    }

    public List<Customer> GetAllCustomers()
    {
        Console.WriteLine("CustomerService: Getting all customers");
        return _customerRepository.GetAllCustomers();
    }

    public void CreateCustomer(string name, string email, string phone)
    {
        Console.WriteLine($"CustomerService: Creating new customer - {name}");
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("CustomerService: Customer name is required");
            return;
        }

        // Generate new ID (simple implementation)
        var allCustomers = _customerRepository.GetAllCustomers();
        int newId = allCustomers.Count > 0 ? allCustomers.Max(c => c.Id) + 1 : 1;

        var newCustomer = new Customer(newId, name, email, phone);
        _customerRepository.AddCustomer(newCustomer);
        Console.WriteLine($"CustomerService: Customer created successfully with ID {newId}");
    }

    public void UpdateCustomer(int id, string name, string email, string phone)
    {
        Console.WriteLine($"CustomerService: Updating customer with ID {id}");
        var existingCustomer = _customerRepository.FindCustomerById(id);
        if (existingCustomer != null)
        {
            var updatedCustomer = new Customer(id, name, email, phone);
            _customerRepository.UpdateCustomer(updatedCustomer);
            Console.WriteLine("CustomerService: Customer update completed");
        }
        else
        {
            Console.WriteLine($"CustomerService: Cannot update - customer with ID {id} not found");
        }
    }

    public void DeleteCustomer(int id)
    {
        Console.WriteLine($"CustomerService: Deleting customer with ID {id}");
        var existingCustomer = _customerRepository.FindCustomerById(id);
        if (existingCustomer != null)
        {
            _customerRepository.DeleteCustomer(id);
            Console.WriteLine("CustomerService: Customer deletion completed");
        }
        else
        {
            Console.WriteLine($"CustomerService: Cannot delete - customer with ID {id} not found");
        }
    }

    public void DisplayCustomerInfo(int id)
    {
        var customer = GetCustomerById(id);
        if (customer != null)
        {
            Console.WriteLine("=== Customer Information ===");
            Console.WriteLine(customer.ToString());
            Console.WriteLine("============================");
        }
        else
        {
            Console.WriteLine("Customer not found!");
        }
    }
}

// Alternative Repository Implementation (for testing DI)
public class InMemoryCustomerRepository : ICustomerRepository
{
    private Dictionary<int, Customer> _customers;

    public InMemoryCustomerRepository()
    {
        _customers = new Dictionary<int, Customer>();
        Console.WriteLine("InMemoryCustomerRepository: In-memory repository initialized");
    }

    public Customer FindCustomerById(int id)
    {
        Console.WriteLine($"InMemoryCustomerRepository: Searching for customer with ID {id}");
        _customers.TryGetValue(id, out Customer customer);
        return customer;
    }

    public List<Customer> GetAllCustomers()
    {
        Console.WriteLine($"InMemoryCustomerRepository: Retrieving all customers ({_customers.Count} total)");
        return _customers.Values.ToList();
    }

    public void AddCustomer(Customer customer)
    {
        Console.WriteLine($"InMemoryCustomerRepository: Adding customer - {customer.Name}");
        _customers[customer.Id] = customer;
    }

    public void UpdateCustomer(Customer customer)
    {
        Console.WriteLine($"InMemoryCustomerRepository: Updating customer with ID {customer.Id}");
        if (_customers.ContainsKey(customer.Id))
        {
            _customers[customer.Id] = customer;
            Console.WriteLine("InMemoryCustomerRepository: Customer updated successfully");
        }
        else
        {
            Console.WriteLine($"InMemoryCustomerRepository: Customer with ID {customer.Id} not found for update");
        }
    }

    public void DeleteCustomer(int id)
    {
        Console.WriteLine($"InMemoryCustomerRepository: Deleting customer with ID {id}");
        if (_customers.Remove(id))
        {
            Console.WriteLine("InMemoryCustomerRepository: Customer deleted successfully");
        }
        else
        {
            Console.WriteLine($"InMemoryCustomerRepository: Customer with ID {id} not found for deletion");
        }
    }
}