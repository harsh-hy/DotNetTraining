

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
        List<int> nums = new List<int>{5,12,7,20,3,18,9};
        var task = nums.GroupBy(n => n%3);
        foreach(var g in task){
            Console.Write("Group Key: "+g.Key);
            foreach(var no in g)
            {
                Console.Write(" "+no);
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
        List<Employee> emps =new List<Employee>()
        {
            new Employee("Ravi",50000),
            new Employee("Aman",50000),
            new Employee("Neha",30000),
            new Employee("Kiran",70000),
            new Employee("Karan",30000)
        };
        var task2 = emps.GroupBy(s => s.Salary);
        foreach(var keys in task2)
        {
            Console.Write("Key: "+keys.Key+" ");
            foreach(var x in keys)
                Console.Write(x.Name+" ");
            Console.WriteLine();
        }
    }
}