using ExamSchedule.Model;
using System.Collections.Generic;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        public static List<Student> Students = new List<Student>();
        public static List<StudentSession> StudentSessions = new List<StudentSession>();

        static DataBank()
        {
            Students.Add(new Student { StudentId = 1, Name = "Alice" , age = 20 });
            Students.Add(new Student { StudentId = 2, Name = "Bob" , age = 22 });
            Students.Add(new Student { StudentId = 3, Name = "Charlie" , age = 21 });
            StudentSessions.Add(new StudentSession { StudentSessionId = "SS1", StudentId = 1 });
            StudentSessions.Add(new StudentSession { StudentSessionId = "SS1", StudentId = 2 });
            StudentSessions.Add(new StudentSession { StudentSessionId = "SS3", StudentId = 3 });
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }
        public static List<StudentSession> GetStudentSessions()
        {
            return StudentSessions;
        }
    }
}
