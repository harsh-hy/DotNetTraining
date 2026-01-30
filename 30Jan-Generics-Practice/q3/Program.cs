using System;
using System.Collections.Generic;
class Student
{
    public string name;
    public double average;
}
class Program
{
    public static void Main(string[] args)
    {
        //List of Studdents !!
        List<Student> li = new List<Student>
        {
            new Student {name = "Harsh", average=98},
            new Student {name = "Nevil", average=74},
            new Student {name = "Harry", average=82},
            new Student {name = "Ron  ", average=22},
            new Student {name = "James", average=78},
            new Student {name = "Remus", average=92},
        };
        //Action for printing the details of student !!
        Action<Student> printStudent = s =>Console.Write($"{s.name} - Avg: {s.average}");
        //Predicate for checking if the student failed or not !!
        Predicate<Student> isFailed = s => s.average < 40;
        //Function for remarks !!
        Func<Student, string> getRemark = s =>
        {
            if (s.average < 40) return "   Failed";
            if (s.average >= 90) return "   Distinction";
            return "   Passed";
        };
        Console.WriteLine("     ----------Student Details ---------     \n");
        foreach(var x in li)
        {
            printStudent(x);
            Console.Write(getRemark(x));
            if(isFailed(x))
            Console.Write(" Needs Inprovement");
            Console.WriteLine();
        }
    }
}