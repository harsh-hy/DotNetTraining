using System;
using System.Collections.Generic;

interface IExam
{
    string Subject { get; }
    string Examiner { get; }
    DateTime Date { get; }
    int Semester { get; }
    void Display();
}

interface IExamScheduler
{
    void ScheduleExam(string subject, string examiner, DateTime date, int semester);
    void ShowAllExams();
}
class Exam : IExam
{
    public string Subject { get; }
    public string Examiner { get; }
    public DateTime Date { get; }
    public int Semester { get; }

    public Exam(string subject, string examiner, DateTime date, int semester)
    {
        Subject = subject;
        Examiner = examiner;
        Date = date;
        Semester = semester;
    }

    public void Display()
    {
        Console.WriteLine($"Subject   : {Subject}");
        Console.WriteLine($"Examiner  : {Examiner}");
        Console.WriteLine($"Date      : {Date.ToShortDateString()}");
        Console.WriteLine($"Semester  : {Semester}");
        Console.WriteLine("--------------------------------");
    }
}
class ExamScheduler : IExamScheduler
{
    List<IExam> exams = new List<IExam>();

    public void ScheduleExam(string subject, string examiner, DateTime date, int semester)
    {
        IExam exam = new Exam(subject, examiner, date, semester);
        exams.Add(exam);
        Console.WriteLine("Exam Scheduled Successfully\n");
    }

    public void ShowAllExams()
    {
        if (exams.Count == 0)
        {
            Console.WriteLine("No exams scheduled.\n");
            return;
        }

        foreach (IExam e in exams)
            e.Display();
    }
}
class Program
{
    static void Main()
    {
        IExamScheduler scheduler = new ExamScheduler();
        int choice;

        do
        {
            Console.WriteLine("===== EXAM SCHEDULER =====");
            Console.WriteLine("1. Schedule Exam");
            Console.WriteLine("2. View Exam Schedule");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Subject: ");
                    string subject = Console.ReadLine();

                    Console.Write("Examiner: ");
                    string examiner = Console.ReadLine();

                    Console.Write("Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Semester: ");
                    int semester = int.Parse(Console.ReadLine());

                    scheduler.ScheduleExam(subject, examiner, date, semester);
                    break;

                case 2:
                    scheduler.ShowAllExams();
                    break;

                case 3:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice\n");
                    break;
            }
        }
        while (choice != 3);
    }
}