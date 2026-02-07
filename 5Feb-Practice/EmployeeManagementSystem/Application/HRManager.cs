using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application;

public class HRManager
{
    public List<Employee> emps = new List<Employee>();
    public int idCounter=0;
    public void AddEmployee(string name, string dept, double salary)
    {
        idCounter++;
        emps.Add(new  Employee
        {
            EmployeeId = idCounter,
            Name = name,
            Department = dept,
            Salary = salary,
            JoiningDate = DateTime.Now
        });
    }
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        return new SortedDictionary<string, List<Employee>>(
               emps.GroupBy(e => e.Department)
               .ToDictionary(g => g.Key , g => g.ToList())
            );
    }
    public double CalculateDepartmentSalary(string department)
    {
        return emps
               .Where (e=>e.Department.Equals(department , StringComparison.OrdinalIgnoreCase))
               .Sum(e => e.Salary);
    }
    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        return emps
               .Where(e => e.JoiningDate>date)
               .ToList();
    }
}