///
///    !!!! SELECT !!!!
/// 

using System.Linq;
using System.Collections.Generic;

public class Employee
{
    public string Name{get;set;}
    public int Salary{get;set;}
    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }
}
public class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>{2,4,6,8};
        var doubleNum = nums.Select(n => n*2);
        foreach(int num in doubleNum)
            Console.WriteLine(num);
        List<Employee> emps = new List<Employee>()
        {
            new Employee("a",2000),
            new Employee("b",1000),
            new Employee("c",1200),
            new Employee("d",1900)
        };
        var proj=emps.Select(s=>s.Name + " earns " + s.Salary);
        foreach(var empProj in proj)
        {
            Console.WriteLine(empProj);
        }
    }
}