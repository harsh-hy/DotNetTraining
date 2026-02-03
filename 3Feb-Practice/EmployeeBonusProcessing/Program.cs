using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 ,10000, 20000,140000};
        int bonus = 700000;
        // 1. Loop through salaries
        // 2. Divide bonus by salary
        // 3. Handle DivideByZeroException
        // 4. Continue processing remaining employees
        foreach(int salary in salaries)
        {
            try
            {
                int x = bonus/salary;
                Console.WriteLine("Bonus/Salary = "+x);
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Salary cannot be 0 because a no (here bonus) be divided by 0");
            }
        }
        Console.WriteLine("Processing empoyees ended");
        
    }
}
