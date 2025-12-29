using System;
using ExamSchedule.Data;

namespace ExamSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = DataBank.GetStudents();
            var sessions = DataBank.GetStudentSessions();

            foreach (var student in students)
            {
                foreach (var session in sessions)
                {
                    if (student.StudentId == session.StudentId)
                    {
                        Console.WriteLine(
                            $"Student ID: {student.StudentId}, " +
                            $"Name: {student.Name}, " +
                            $"Age: {student.age}, " +
                            $"Session: {session.StudentSessionId}"
                        );
                    }
                }
            }
        }
    }
}
