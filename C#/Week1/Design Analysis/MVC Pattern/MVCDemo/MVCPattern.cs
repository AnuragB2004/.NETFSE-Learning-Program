using System;

// Model
public class Student
{
    private string _name;
    private string _id;
    private string _grade;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }

    public Student(string name, string id, string grade)
    {
        _name = name;
        _id = id;
        _grade = grade;
    }
}

// View
public class StudentView
{
    public void DisplayStudentDetails(string studentName, string studentId, string studentGrade)
    {
        Console.WriteLine("=== Student Details ===");
        Console.WriteLine($"Name: {studentName}");
        Console.WriteLine($"ID: {studentId}");
        Console.WriteLine($"Grade: {studentGrade}");
        Console.WriteLine("========================\n");
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void DisplayError(string error)
    {
        Console.WriteLine($"[ERROR] {error}");
    }
}

// Controller
public class StudentController
{
    private Student _model;
    private StudentView _view;

    public StudentController(Student model, StudentView view)
    {
        _model = model;
        _view = view;
    }

    public void SetStudentName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _view.DisplayError("Student name cannot be empty!");
            return;
        }
        _model.Name = name;
        _view.DisplayMessage($"Student name updated to: {name}");
    }

    public string GetStudentName()
    {
        return _model.Name;
    }

    public void SetStudentId(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            _view.DisplayError("Student ID cannot be empty!");
            return;
        }
        _model.Id = id;
        _view.DisplayMessage($"Student ID updated to: {id}");
    }

    public string GetStudentId()
    {
        return _model.Id;
    }

    public void SetStudentGrade(string grade)
    {
        if (string.IsNullOrWhiteSpace(grade))
        {
            _view.DisplayError("Student grade cannot be empty!");
            return;
        }
        _model.Grade = grade;
        _view.DisplayMessage($"Student grade updated to: {grade}");
    }

    public string GetStudentGrade()
    {
        return _model.Grade;
    }

    public void UpdateView()
    {
        _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
    }

    public void UpdateStudent(string name, string id, string grade)
    {
        SetStudentName(name);
        SetStudentId(id);
        SetStudentGrade(grade);
    }
}