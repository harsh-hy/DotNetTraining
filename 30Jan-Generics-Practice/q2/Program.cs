using System;
using System.Collections.Generic;
using System.Linq;
class Student
{
    public string name;
    public double marks1;
    public double marks2;
    public double average;
}
delegate string remarkMsg(Student s);
class Program
{
    public static void Main()
    {
        List<Student> ls = new List<Student>();
        Console.WriteLine("Enter the no of students");
        int n=int.Parse(Console.ReadLine());
        for(int i=0;i<n;i++)
        {
            Student s = new Student();
            Console.WriteLine($"Details of Student {i+1}");
            Console.Write("Name: ");
            s.name=Console.ReadLine();            
            Console.Write("Marks1: ");
            s.marks1=double.Parse(Console.ReadLine());
            Console.Write("Marks2: ");
            s.marks2=double.Parse(Console.ReadLine());
            s.average=(s.marks1+s.marks2)/2;
            ls.Add(s);
        }
        var rankedStudents = ls.OrderByDescending(s => s.average).ToList();
        Console.WriteLine(" ----------------------Ranking ----------------------");
        int rank=1;
        remarkMsg rm = remark;

        foreach(var x in rankedStudents)
        {
            string str=rm(x);
            Console.WriteLine($"Rank{rank++} - {x.name} with an average of {x.average} Remark: {str}");
        }
    }
    static string remark(Student s)
    {
        if(s.average<40)
            return "Failed Need Improvement";
        else if (s.average>90)
            return "Passed With Distinction";
        return "Passed with average marks";
    }
}