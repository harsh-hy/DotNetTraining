
//   Reading Members (Methods, Properties, Fields)

using System;
using System.Reflection;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Salary { get; private set; }
    private string secretCode = "X9Z";
    public Employee() { }
    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }
    public void GiveRaise(decimal amount)
    {
        Salary += amount;
    }
    private string GetSecretCode() => secretCode;
}
class Program
{
    static void Main()
    {
        Employee emp = new Employee(101, "Arun", 45000);

        Type t1 = typeof(Employee);     // compile-time
        Type t2 = emp.GetType();        // runtime
        Console.WriteLine(t1.FullName);
        Console.WriteLine(t2.FullName);

        Console.WriteLine("\n\n Methods:");
        var methods = t1.GetMethods();
        foreach (var m in methods)
        {
            Console.WriteLine($"{m.ReturnType.Name} {m.Name}()");
        }

        Console.WriteLine("\n\n Public Properties:");
        var properties=t1.GetProperties();
        foreach (var p in properties)
        {
            Console.WriteLine($"{p.PropertyType.Name} {p.Name} (CanRead={p.CanRead}, CanWrite={p.CanWrite})");
        }

        Console.WriteLine("\n\n Field Info:");
        //this is not goona work coz secretCode here because it is private
        // var fields=t1.GetFields();
        // foreach (var f in fields)
        // {
        //     Console.WriteLine($"{f.FieldType.Name} {f.Name}");
        // }
        var fields = t1.GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public
            );
        foreach (var f in fields)
        {
            Console.WriteLine($"{f.FieldType.Name} {f.Name}");
        }
    }
}
