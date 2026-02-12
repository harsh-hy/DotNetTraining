using System;
public class Employee
{
    public string Id{get;set;}
    public string Name{get;set;}
    public string Email{get;set;}
    public int Salary{get;set;}

    public Employee(string id, string name, string email, int salary)
    {
        Id = id;
        Name = name;
        Email = email;
        if(!email.Contains("@"))
            Email = "unknown@company.com";
        Salary=salary;
        if(salary<=0)
            Salary = 30000;
    }
    public static void Main()
    {
        Employee e1 = new Employee("123","ankit","ashish@gmail.com",40000);
        Console.WriteLine(e1.Id + " " + e1.Name + " " + e1.Email + " " + e1.Salary);
        Employee e2 = new Employee("124", "kamaljeet", "kamal.com", 32000);
        Console.WriteLine(e2.Id + " " + e2.Name + " " + e2.Email + " " + e2.Salary);
        Employee e3 = new Employee("125", "neil","neil@gmail.com", 20000);
        Console.WriteLine(e3.Id + " " + e3.Name + " " + e3.Email + " " + e3.Salary);
    }
}
