using System.Linq;
using System.Collections.Generic;


public class Student
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int Marks {get;set;}
    public string Department {get;set;}
}
class Program
{
    public static void Main(){
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Ravi",Marks=80,Department="CS"},
            new Student{Id=2,Name="Aman",Marks=45,Department="IT"},
            new Student{Id=3,Name="Neha",Marks=70,Department="CS"},
            new Student{Id=4,Name="Kiran",Marks=30,Department="HR"}
        };

        Dictionary<int,Student> studentDict = students.ToDictionary(s=>s.Id,s=>s);
        var greaterThan50=studentDict.Values.Where(s=>s.Marks>50);
        foreach(var std in greaterThan50)
            Console.WriteLine($"{std.Name} | {std.Marks} | {std.Department}");
        var onlyNames=studentDict.Values.Select(s=>s.Name);
        foreach(var names in onlyNames)
            Console.WriteLine(names);
        var sortStd=studentDict.Values.OrderByDescending(s=>s.Marks);
        foreach(var std in sortStd)
            Console.WriteLine($"{std.Name} | {std.Marks} | {std.Department}");
        var stdn = studentDict.Values.FirstOrDefault(s => s.Id == 3);
        Console.WriteLine($"{stdn.Id} | {stdn.Name} | {stdn.Marks} | {stdn.Department}");
        var keys = studentDict.Keys;
        foreach(var k in keys)
        Console.WriteLine(k);

    }
}