using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== MVC Pattern Demo - Student Management ===\n");

        // Create model
        Student student = new Student("John Doe", "S001", "A");

        // Create view
        StudentView view = new StudentView();

        // Create controller
        StudentController controller = new StudentController(student, view);

        // Display initial student details
        Console.WriteLine("Initial student details:");
        controller.UpdateView();

        // Update student details through controller
        Console.WriteLine("Updating student details...");
        controller.SetStudentName("Jane Smith");
        controller.SetStudentId("S002");
        controller.SetStudentGrade("A+");

        // Display updated student details
        Console.WriteLine("\nUpdated student details:");
        controller.UpdateView();

        // Test error handling
        Console.WriteLine("Testing error handling:");
        controller.SetStudentName(""); // Should show error
        controller.SetStudentId(null);  // Should show error

        // Update multiple fields at once
        Console.WriteLine("\nBulk update:");
        controller.UpdateStudent("Alice Johnson", "S003", "B+");
        controller.UpdateView();

        // Test individual getters
        Console.WriteLine("Testing getters:");
        Console.WriteLine($"Student Name: {controller.GetStudentName()}");
        Console.WriteLine($"Student ID: {controller.GetStudentId()}");
        Console.WriteLine($"Student Grade: {controller.GetStudentGrade()}");
    }
}