using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course already exists");
            // 2. Create Course object
            AvailableCourses[code] = new Course(code, name, credits, maxCapacity, prerequisites);
            // 3. Add to AvailableCourses
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            if (Students.ContainsKey(id))
                throw new ArgumentException("Student already exists");
            // 2. Create Student object
            Students[id] = new Student(id, name, major, maxCredits, completedCourses);
            // 3. Add to Students dictionary

        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            if (!Students.ContainsKey(studentId))
                throw new ArgumentException("Student not found");
            // 2. Call student.AddCourse(course)
            if (!AvailableCourses.ContainsKey(courseCode))
                throw new ArgumentException("Course not found");
            var student = Students[studentId];
            var course = AvailableCourses[courseCode];
            bool result = student.AddCourse(course);
            // 3. Display meaningful messages
            Console.WriteLine(result ? "Registration successful" : "Registration failed");
            return result;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            if (!Students.ContainsKey(studentId))
                throw new ArgumentException("Student not found");
            // 2. Call student.DropCourse(courseCode)
            bool result = Students[studentId].DropCourse(courseCode);
            Console.WriteLine(result ? "Course dropped" : "Drop failed");
            return result;
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if (!AvailableCourses.Any())
            {
                Console.WriteLine("No courses available");
                return;
            }
            foreach (var c in AvailableCourses.Values)
            {
                Console.WriteLine($"{c.CourseCode} - {c.CourseName}  Credits:{c.Credits}  Enrolled:{c.GetEnrollmentInfo()}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if (!Students.ContainsKey(studentId))
                throw new ArgumentException("Student not found");
            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            Console.WriteLine("Summary!!");
        }
    }
}
