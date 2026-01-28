using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int id { get; set; }
    public string name { get; set; }
}
class Program
{
    static void Main()
    {
        List<Employee> empL = new List<Employee>()
        {
            new Employee { id = 1, name = "harsh" },
            new Employee { id = 2, name = "yash" }
        };
        Console.WriteLine("Enter the id to search");
        int n = Convert.ToInt32(Console.ReadLine());

        var emp = empL.FirstOrDefault(e => e.id == n);

        if (emp != null)
            Console.WriteLine(emp.name);
        else
            Console.WriteLine("Not Found");
    }
}
