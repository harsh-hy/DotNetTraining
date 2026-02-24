///
///    !!!! Where + SELECT!!!!
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
        List<int> nums = new List<int>{10,3,7,1,20,15};
        var task = nums.OrderByDescending(n => n);
        foreach(int num in task)
            Console.WriteLine(num);
        
        Console.WriteLine();
        List<Employee> emps =new List<Employee>()
        {
            new Employee("Ravi",50000),
            new Employee("Aman",50000),
            new Employee("Neha",30000),
            new Employee("Kiran",70000)
        };
        var task2 = emps.OrderBy(s => s.Salary)
                        .ThenBy(s => s.Name);
        foreach(var emp in task2)
            Console.WriteLine(emp.Name+" "+emp.Salary);
    }
}