    using System;
    class Employee
    {
        public virtual void CalculateSalary()
        {
            Console.WriteLine("YO this sad thing isnt working cause it is getiing overridden");
        }
    }
    class Developer: Employee
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Developer Salary Calculated");
        }
    }
    class Tester: Employee
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Tester Salary Calculated");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Employee e1 = new Developer();
            Employee e2 = new Tester();
            e1.CalculateSalary();
            e2.CalculateSalary();
        }
    }
