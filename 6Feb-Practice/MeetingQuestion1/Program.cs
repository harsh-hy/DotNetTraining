using System;
using System.Collections.Generic;
public class Student
{
    public string Id {get;set;}
    public string Name {get;set;}
    public string Course {get;set;}
    public int Marks {get;set;}
}
public class StudentUtility
{
    public Dictionary<string, string> GetStudentDetails(string id)
    {
        Dictionary <string, string> result= new Dictionary<string,string>();
        foreach (var item in Program.studentDetails.Values)
        {
            if(item.Id.Equals(id))
            {
                result.Add(item.Id, item.Name+":"+item.Course);
                break;
            }
        }
        return result;
    }
    public Dictionary<string,Student> UpdateStudentMarks(string id, int marks)
    {
        Dictionary<string, Student> result = new Dictionary<string,Student>();
        foreach(var item in Program.studentDetails.Values)
        {
            if(item.Id.Equals(id))
            {
                item.Marks=marks;
                result.Add(item.Id, item);
                break;
            }
        }
        return result;
    }
}
public class Program
{
    public static Dictionary<int, Student> studentDetails;
    public static void Main()
    {
        studentDetails = new Dictionary<int , Student>();
        studentDetails.Add(1,new Student{ Id="001", Name="Harry Potter", Course="Dark Arts", Marks=100});
        studentDetails.Add(2,new Student{ Id="002", Name="Severus Snape", Course="Potions", Marks=98});
        studentDetails.Add(3,new Student{ Id="003", Name="John Lennon", Course="Music", Marks=100});
        
        StudentUtility utility=new StudentUtility();
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("1. Get Student Details");
            Console.WriteLine("2. Update Student Marks");
            Console.WriteLine("3. Exit");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter the Student ID");
                    string id = Console.ReadLine();
                    var details = utility.GetStudentDetails(id);
                    if(details.Count==0)
                    {
                        Console.WriteLine("No Student found");
                    }
                    else
                    {
                        foreach (var item in details)
                        {
                            Console.WriteLine(item.Key+" "+item.Value);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the Student ID");
                    string updateId = Console.ReadLine();
                    Console.WriteLine("Enter the Marks");
                    int marks = int.Parse(Console.ReadLine());
                    var updatedDetails = utility.UpdateStudentMarks(updateId, marks);
                    if(updatedDetails.Count == 0)
                    {
                        Console.WriteLine("No Student Found");
                    }
                    else
                    {
                        foreach (var item in updatedDetails)
                        {
                            Console.WriteLine(item.Key+" "+item.Value.Name+" "+item.Value.Course+" "+item.Value.Marks);
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Thank You");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}