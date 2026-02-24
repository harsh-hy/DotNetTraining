///
///    !!!! Where !!!!
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
        List<int> nums = new List<int>{5,12,7,20,3,18};
        var greaterThan10 = nums.Where(n => n>10);
        foreach(int num in greaterThan10)
            Console.WriteLine(num);
        List<Employee> emps =new List<Employee>()
        {
            new Employee("Ravi",25000),
            new Employee("Aman",50000),
            new Employee("Neha",30000),
            new Employee("Kiran",70000)
        };
        var greaterThan30K = emps.Where(s => s.Salary>30000);
        foreach(var emp in greaterThan30K)
            Console.WriteLine(emp.Name);
    }
}