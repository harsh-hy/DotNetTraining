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
        List<int> nums = new List<int>{3,6,9,12,15,18};
        var task = nums.Where(n => n%3==0 && n>10)
                        .Select(n=>n*2);
        foreach(int num in task)
            Console.WriteLine(num);
        
        Console.WriteLine();
        List<Employee> emps =new List<Employee>()
        {
            new Employee("Ravi",25000),
            new Employee("Aman",50000),
            new Employee("Neha",30000),
            new Employee("Kiran",70000)
        };
        var greaterThan30K = emps.Where(s => s.Salary>=30000)
                                 .Select(s => s.Name.ToUpper());
        foreach(var emp in greaterThan30K)
            Console.WriteLine(emp);
    }
}