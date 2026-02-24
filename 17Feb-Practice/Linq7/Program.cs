using System.Linq;
using System.Collections.Generic;
public class Employee
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int Salary {get;set;}
    public string Department {get;set;}
}
class Program
{
    public static void Main(){
        List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=1,Name="Ravi",Salary=70000,Department="IT"},
            new Employee{Id=2,Name="Aman",Salary=40000,Department="HR"},
            new Employee{Id=3,Name="Neha",Salary=80000,Department="IT"},
            new Employee{Id=4,Name="Kiran",Salary=30000,Department="Sales"}
        };
        SortedDictionary<int, Employee> sortedEmp =new SortedDictionary<int, Employee>(employees.ToDictionary(e => e.Id, e => e));
        var salGreaterThan60K=sortedEmp.Values.Where(s=>s.Salary>60000);
        foreach(var emp in salGreaterThan60K)
            Console.WriteLine($"{emp.Id} {emp.Name} {emp.Salary}");
        
        var onlyNames=sortedEmp.Values.Select(s=>s.Name);
        foreach(var x in onlyNames)
            Console.WriteLine($"{x} ");
        
        var itEmp = sortedEmp.Values.Where(s => s.Department == "IT");
        foreach(var x in itEmp)
            Console.WriteLine($"{x.Name} ");
        
        var higEmp = sortedEmp.Values.OrderByDescending(s=>s.Salary).FirstOrDefault();
        Console.WriteLine($"{higEmp.Name}");

    }
}