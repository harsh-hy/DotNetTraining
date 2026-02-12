public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}
public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}
// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
    {
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();
    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Rules:
        // - Course not at capacity
        // - Student not already enrolled
        // - Student semester >= course prerequisite (if any)
        // - Return success/failure with reason
        if (!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }
        var students = _enrollments[course];
                if (students.Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine($"{student.Name} already enrolled in {course.Title}");
            return false;
        }
        if (students.Count >= course.MaxCapacity)
        {
            Console.WriteLine($"{course.Title} is full");
            return false;
        }
        var prop = course.GetType().GetProperty("RequiredSemester");
        if (prop != null)
        {
            int requiredSemester = (int)prop.GetValue(course);
            if (student.Semester < requiredSemester)
            {
                Console.WriteLine($"{student.Name} does not meet prerequisite semester");
                return false;
            }
        }
        students.Add(student);
        Console.WriteLine($"{student.Name} enrolled in {course.Title}");
        return true;
    }
    
    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        // Return immutable list
        if (_enrollments.TryGetValue(course, out var students))
        {
            return students.AsReadOnly();
        }
        return new List<TStudent>().AsReadOnly();
    }
    
    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        // Return courses student is enrolled in
        foreach (var kvp in _enrollments)
        {
            if (kvp.Value.Any(s => s.StudentId == student.StudentId))
            {
                yield return kvp.Key;
            }
        }
    }
    
    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Sum(e => e.Key.Credits);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; } // Prerequisite
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    
    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        // Student must be enrolled in course
    }
    
    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        // Weighted by course credits
        // Return null if no grades
    }
    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        // Return student with highest grade
    }
}

// 4. TEST SCENARIO: Create a simulation
// a) Create 3 EngineeringStudent instances
// b) Create 2 LabCourse instances with prerequisites
// c) Demonstrate:
//    - Successful enrollment
//    - Failed enrollment (capacity, prerequisite)
//    - Grade assignment
//    - GPA calculation
//    - Top student per course
