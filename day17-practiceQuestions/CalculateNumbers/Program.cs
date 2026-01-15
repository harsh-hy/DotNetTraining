using System.Collections.Generic;
using System.Linq;
using System;
class Program
{
    public static List<int> NumberList = new List<int>();
    public void AddNumbers(int numbers)
    {
        NumberList.Add(numbers);
    }
    public double GetGpaScored()
    {
        if(NumberList.Count==0)
            return -1;
        double sum = 0;
        foreach(var num in NumberList)
            sum += num;
        return sum/NumberList.Count;
    }
    public char GetGpaGraded(double gpa)
    {
        if (gpa < 5 || gpa > 10)   
            return '\n';
        if(gpa == 10)
            return 'S';
        else if(gpa >= 9 && gpa < 10)
            return 'A';
        else if(gpa >= 8 && gpa < 9)
            return 'B';
        else if(gpa >= 7 && gpa < 8)
            return 'C';
        else if(gpa >= 6 && gpa < 7)
            return 'D';
        else if(gpa >= 5 && gpa < 6)
            return 'E';
        return '\n';
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of subjects");
        int numberOfSubjects = Convert.ToInt32(Console.ReadLine());
        Program p = new Program();
        for(int i = 0; i < numberOfSubjects; i++)
        {
            Console.WriteLine("Enter the marks scored in subject {0}", i+1);
            int marks = Convert.ToInt32(Console.ReadLine());
            p.AddNumbers(marks);
        }
        double gpa = p.GetGpaScored();
        char grade = p.GetGpaGraded(gpa);
        if (gpa == -1){
            Console.WriteLine("No Numbers Available");
            return;
        }
        Console.WriteLine("The GPA scored is {0}", gpa);
        if(grade == '\n')
            Console.WriteLine("Invalid GPA");
        else
            Console.WriteLine("The grade is {0}", grade);
    }
}