using System;
using System.Collections.Generic;
using System.Linq;
class Employee
{
    public string name { get; set; }
    public int salary { get; set; }

}
class Program
{
    public static void Main()
    {
        List<Employee> empL = new List<Employee>()
        {
            new Employee { name = "harsh", salary=1000000 },
            new Employee { name = "yash" , salary=100000}
        };
        var ans = empL.OrderByDescending(e => e.salary).First();
        Console.WriteLine(ans.name+" has the heighest salary");
    }
}
 
 