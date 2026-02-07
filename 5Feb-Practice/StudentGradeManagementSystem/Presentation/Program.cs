using System;
using Application;

namespace Presentation;

class Program
{
    static void Main()
    {
        SchoolManager manager = new SchoolManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Display Students Grouped by Grade Level");
            Console.WriteLine("4. Calculate Student Average");
            Console.WriteLine("5. Subject-wise Averages");
            Console.WriteLine("6. Top Performers");
            Console.WriteLine("7. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Grade Level (9th/10th/11th/12th): ");
                    string grade = Console.ReadLine();

                    manager.AddStudent(name, grade);
                    Console.WriteLine("Student added.");
                    break;

                case "2":
                    Console.Write("Student ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Subject: ");
                    string subject = Console.ReadLine();

                    Console.Write("Grade (0-100): ");
                    double marks = double.Parse(Console.ReadLine());

                    manager.AddGrade(id, subject, marks);
                    Console.WriteLine("Grade added.");
                    break;

                case "3":
                    var grouped = manager.GroupStudentsByGradeLevel();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nGrade Level: {g.Key}");
                        foreach (var s in g.Value)
                        {
                            Console.WriteLine($"{s.StudentId} - {s.Name}");
                        }
                    }
                    break;

                case "4":
                    Console.Write("Student ID: ");
                    int sid = int.Parse(Console.ReadLine());

                    double avg = manager.CalculateStudentAverage(sid);
                    Console.WriteLine($"Average Marks: {avg:F2}");
                    break;

                case "5":
                    var subjectAvgs = manager.CalculateSubjectAverages();
                    foreach (var s in subjectAvgs)
                    {
                        Console.WriteLine($"{s.Key} : {s.Value:F2}");
                    }
                    break;

                case "6":
                    Console.Write("How many top students?: ");
                    int count = int.Parse(Console.ReadLine());

                    var toppers = manager.GetTopPerformers(count);
                    foreach (var s in toppers)
                    {
                        Console.WriteLine($"{s.StudentId} - {s.Name} | Avg: {s.Subjects.Values.Average():F2}");
                    }
                    break;

                case "7":
                    return;
            }
        }
    }
}
