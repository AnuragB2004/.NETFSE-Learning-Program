using System;
using EmployeeApp;

class Program
{
    static void Main()
    {
        EmployeeManager manager = new EmployeeManager();

        manager.AddEmployee(new Employee(1, "Alice", "Manager", 75000m));
        manager.AddEmployee(new Employee(2, "Bob", "Developer", 60000m));
        manager.AddEmployee(new Employee(3, "Charlie", "Designer", 55000m));

        manager.TraverseEmployees();

        Console.WriteLine("\nSearching for Employee ID 2...");
        var emp = manager.SearchEmployee(2);
        Console.WriteLine(emp != null ? emp.ToString() : "Not found");

        Console.WriteLine("\nDeleting Employee ID 2...");
        manager.DeleteEmployee(2);

        manager.TraverseEmployees();
    }
}
