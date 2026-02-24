using System;
using System.Linq;
using System.Collections.Generic;

// =========================
// Model
// =========================
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public string Department { get; set; }
}
public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Ravi",Marks=80,Department="CS"},
            new Student{Id=2,Name="Aman",Marks=45,Department="IT"},
            new Student{Id=3,Name="Neha",Marks=70,Department="CS"},
            new Student{Id=4,Name="Kiran",Marks=30,Department="HR"},
            new Student{Id=5,Name="Arjun",Marks=60,Department="IT"}
        };
        
    }
}
