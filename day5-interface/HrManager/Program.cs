using System;
using System.Collections.Generic;

public interface IEmployeeOperations
{
    void MarkAttendance();
    void ApplyLeave(int days);
    double CalculateSalary();
}

public abstract class Employee : IEmployeeOperations
{
    public int EmpId;
    public string Name;
    public double BaseSalary;

    protected Employee(int empId, string name, double baseSalary)
    {
        EmpId = empId;
        Name = name;
        BaseSalary = baseSalary;
    }

    public void MarkAttendance()
    {
        Console.WriteLine(Name + " attendance marked");
    }

    public void ApplyLeave(int days)
    {
        Console.WriteLine(Name + " applied for " + days + " days leave");
    }

    public abstract double CalculateSalary();
}

public class Developer : Employee
{
    double Bonus;

    public Developer(int id, string name, double salary, double bonus)
    : base(id, name, salary)
    {
        Bonus = bonus;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
}

public class Manager : Employee
{
    double Incentive;

    public Manager(int id, string name, double salary, double incentive)
    : base(id, name, salary)
    {
        Incentive = incentive;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + Incentive;
    }
}

public class Intern : Employee
{
    public Intern(int id, string name, double stipend)
    : base(id, name, stipend)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary;
    }
}

public class HRManager
{
    List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee e)
    {
        employees.Add(e);
        Console.WriteLine(e.Name + " added by HR");
    }

    public void MarkAttendance()
    {
        foreach (Employee e in employees)
            e.MarkAttendance();
    }

    public void ProcessPayroll()
    {
        foreach (Employee e in employees)
            Console.WriteLine(e.Name + " Salary: " + e.CalculateSalary());
    }
}

class Program
{
    public static void Main()
    {
        HRManager hr = new HRManager();

        Employee e1 = new Developer(101, "Amit", 50000, 10000);
        Employee e2 = new Manager(102, "Riya", 70000, 20000);
        Employee e3 = new Intern(103, "Kunal", 15000);

        hr.AddEmployee(e1);
        hr.AddEmployee(e2);
        hr.AddEmployee(e3);

        hr.MarkAttendance();
        hr.ProcessPayroll();
    }
}
