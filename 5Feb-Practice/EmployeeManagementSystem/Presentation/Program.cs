using System;
using Application;

namespace Presentation;

class Program
{
    static void Main()
    {
        HRManager hr = new HRManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Display Employees Grouped by Department");
            Console.WriteLine("3. Calculate Department Salary");
            Console.WriteLine("4. Find Employees Joined After Date");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Department (HR/IT/Sales): ");
                    string dept = Console.ReadLine();

                    Console.Write("Salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    hr.AddEmployee(name, dept, salary);
                    Console.WriteLine("Employee added.");
                    break;

                case "2":
                    var grouped = hr.GroupEmployeesByDepartment();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nDepartment: {g.Key}");
                        foreach (var e in g.Value)
                        {
                            Console.WriteLine($"{e.EmployeeId} - {e.Name} - ₹{e.Salary}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Department: ");
                    string department = Console.ReadLine();

                    double total = hr.CalculateDepartmentSalary(department);
                    Console.WriteLine($"Total Salary for {department}: ₹{total}");
                    break;

                case "4":
                    Console.Write("Enter date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    var recent = hr.GetEmployeesJoinedAfter(date);
                    foreach (var e in recent)
                    {
                        Console.WriteLine($"{e.EmployeeId} - {e.Name} ({e.JoiningDate:d})");
                    }
                    break;

                case "5":
                    return;
            }
        }
    }
}
