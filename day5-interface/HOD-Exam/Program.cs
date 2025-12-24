using System;
using System.Collections.Generic;

public interface IExamOperations
{
    void ScheduleExam(DateTime date);
    void AssignExaminer(string examinerName);
}

public abstract class Exam : IExamOperations
{
    public string Subject;
    public DateTime ExamDate;
    public string Examiner;

    protected Exam(string subject)
    {
        Subject = subject;
    }

    public void ScheduleExam(DateTime date)
    {
        ExamDate = date;
        Console.WriteLine(Subject + " exam scheduled on " + date.ToShortDateString());
    }

    public void AssignExaminer(string examinerName)
    {
        Examiner = examinerName;
        Console.WriteLine(examinerName + " assigned to " + Subject + " exam");
    }
}

public class SemesterExam : Exam
{
    public int Semester;

    public SemesterExam(int semester, string subject)
    : base(subject)
    {
        Semester = semester;
    }
}

public class HOD
{
    List<SemesterExam> exams = new List<SemesterExam>();

    public void CreateExam(SemesterExam exam)
    {
        exams.Add(exam);
        Console.WriteLine("Exam created for Semester " + exam.Semester);
    }

    public void ScheduleAllExams(DateTime date)
    {
        foreach (var exam in exams)
            exam.ScheduleExam(date);
    }

    public void AssignExaminer(SemesterExam exam, string examiner)
    {
        exam.AssignExaminer(examiner);
    }
}

class Program
{
    static void Main()
    {
        HOD hod = new HOD();

        Console.WriteLine("Enter number of exams to create:");
        int n = int.Parse(Console.ReadLine());

        List<SemesterExam> examList = new List<SemesterExam>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter Semester number:");
            int semester = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject name:");
            string subject = Console.ReadLine();

            SemesterExam exam = new SemesterExam(semester, subject);
            hod.CreateExam(exam);
            examList.Add(exam);
        }

        Console.WriteLine("\nEnter exam date (yyyy-mm-dd):");
        DateTime examDate = DateTime.Parse(Console.ReadLine());

        hod.ScheduleAllExams(examDate);

        foreach (SemesterExam exam in examList)
        {
            Console.WriteLine("\nEnter examiner for " + exam.Subject + ":");
            string examiner = Console.ReadLine();
            hod.AssignExaminer(exam, examiner);
        }
        Console.WriteLine("\nAll exams scheduled and examiners assigned.");
    }
}
