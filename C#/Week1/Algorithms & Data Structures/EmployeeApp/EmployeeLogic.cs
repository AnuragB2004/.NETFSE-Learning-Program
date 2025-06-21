namespace EmployeeApp
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string position, decimal salary)
        {
            EmployeeId = id;
            Name = name;
            Position = position;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: ${Salary}";
        }
    }

    public class EmployeeManager
    {
        private Employee[] employees;
        private int count;
        private int capacity;

        public EmployeeManager(int capacity = 10)
        {
            this.capacity = capacity;
            employees = new Employee[capacity];
            count = 0;
        }

        public void AddEmployee(Employee employee)
        {
            if (count >= capacity)
            {
                ResizeArray();
            }
            employees[count++] = employee;
            Console.WriteLine($"Added employee: {employee.Name}");
        }

        public Employee SearchEmployee(int employeeId)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == employeeId)
                {
                    return employees[i];
                }
            }
            return null;
        }

        public void TraverseEmployees()
        {
            Console.WriteLine("\n--- All Employees ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            for (int i = 0; i < count; i++)
            {
                if (employees[i].EmployeeId == employeeId)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        employees[j] = employees[j + 1];
                    }
                    count--;
                    Console.WriteLine($"Deleted employee with ID: {employeeId}");
                    return true;
                }
            }
            Console.WriteLine($"Employee with ID {employeeId} not found");
            return false;
        }

        private void ResizeArray()
        {
            capacity *= 2;
            Employee[] newArray = new Employee[capacity];
            Array.Copy(employees, newArray, count);
            employees = newArray;
        }
    }
}
