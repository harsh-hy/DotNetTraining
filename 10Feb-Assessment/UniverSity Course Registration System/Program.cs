using System;

namespace University_Course_Registration_System
{
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;
            Console.WriteLine("Welcome to University Course Registration System");
            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Course Code: ");
                            var ccode = Console.ReadLine();
                            Console.Write("Course Name: ");
                            var cname = Console.ReadLine();
                            Console.Write("Credits: ");
                            var ccredits = int.Parse(Console.ReadLine());
                            system.AddCourse(ccode, cname, ccredits);
                            Console.WriteLine("Course added");
                            break;
                        case "2":
                            Console.Write("Student Id: ");
                            var sid = Console.ReadLine();
                            Console.Write("Name: ");
                            var sname = Console.ReadLine();
                            Console.Write("Major: ");
                            var major = Console.ReadLine();
                            system.AddStudent(sid, sname, major);
                            Console.WriteLine("Student added");
                            break;
                        case "3":
                            Console.Write("Student Id: ");
                            sid = Console.ReadLine();
                            Console.Write("Course Code: ");
                            ccode = Console.ReadLine();
                            system.RegisterStudentForCourse(sid, ccode);
                            break;
                        case "4":
                            Console.Write("Student Id: ");
                            sid = Console.ReadLine();
                            Console.Write("Course Code: ");
                            ccode = Console.ReadLine();
                            system.DropStudentFromCourse(sid, ccode);
                            break;
                        case "5":
                            system.DisplayAllCourses();
                            break;
                        case "6":
                            Console.Write("Student Id: ");
                            sid = Console.ReadLine();
                            system.DisplayStudentSchedule(sid);
                            break;
                        case "7":
                            system.DisplaySystemSummary();
                            break;
                        case "8":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
