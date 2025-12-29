using System.Collections.Generic;

namespace ExamSchedule.Model
{
    public class StudentAndSession
    {
        public string StudentSessionId { get; set; }
        public List<Student> Students { get; set; }

        public StudentAndSession()
        {
            Students = new List<Student>();
        }
    }
}
