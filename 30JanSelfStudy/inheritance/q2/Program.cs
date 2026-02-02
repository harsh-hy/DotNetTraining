using System;
class Employee
{
    protected decimal salary;
    public Employee(decimal amount)
    {
        if(amount > 0)
            salary = amount;
    }
    public decimal GetSalary()
    {
        return salary;
    }
}
class Manager : Employee
{
    public Manager(decimal salary): base (salary)
    {

    }
    public void AddBonus(decimal bonus)
    {
        if (bonus>0)
            salary+=bonus;
    }
}
class Program
{
    public static void Main()
    {
        Manager mg = new Manager(20000);
        mg.AddBonus(20000);
        Console.WriteLine(mg.GetSalary());
    }
}