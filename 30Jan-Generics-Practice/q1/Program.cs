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
            Console.WriteLine("Marks1: ");
            s.marks1=double.Parse(Console.ReadLine());
            Console.WriteLine("Marks2: ");
            s.marks2=double.Parse(Console.ReadLine());
            s.average=(s.marks1+s.marks2)/2;
            ls.Add(s);
        }
        var rankedStudents = ls.OrderByDescending(s => s.average).ToList();
        Console.WriteLine(" ----Ranking ----");
        int rank=1;
        foreach(var x in rankedStudents)
        {
            Console.WriteLine($"Rank{rank++} - {x.name} with an average of {x.average}");
        }
    }
}