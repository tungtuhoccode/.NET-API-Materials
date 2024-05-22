# API allow us to interact with databases 
# Model in .NET is like a row in a database 

# Useful shortcut
Type "prop" + Tab
Result: public int MyProperty { get; set; } 

ctor + TAB create a constructor

# Linking by convention in C#
This approach leverages naming conventions and patterns to reduce the amount of boilerplate code and configuration needed.

# Entity Framework Code First Conventions
Entity Framework (EF) Code First uses conventions to infer the schema of the database from the classes you define.

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

By convention:
	•	The Student class name will be the table name.
	•	The StudentId property will be the primary key.
	•	The Name and EnrollmentDate properties will be columns in the Student table.

