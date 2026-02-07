using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application;

public class SchoolManager
{
    private List<Student> students = new List<Student>();
    private int idCounter = 0;

    public void AddStudent(string name, string gradeLevel)
    {
        idCounter++;
        students.Add(new Student
        {
            StudentId = idCounter,
            Name = name,
            GradeLevel = gradeLevel
        });
    }

    public void AddGrade(int studentId, string subject, double grade)
    {
        if (grade < 0 || grade > 100)
            return;

        Student student = students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null)
            return;

        student.Subjects[subject] = grade;
    }

    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        return new SortedDictionary<string, List<Student>>(
            students.GroupBy(s => s.GradeLevel)
                    .ToDictionary(g => g.Key, g => g.ToList())
        );
    }

    public double CalculateStudentAverage(int studentId)
    {
        Student student = students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null || student.Subjects.Count == 0)
            return 0;

        return student.Subjects.Values.Average();
    }

    public Dictionary<string, double> CalculateSubjectAverages()
    {
        return students
            .SelectMany(s => s.Subjects)
            .GroupBy(x => x.Key)
            .ToDictionary(g => g.Key, g => g.Average(x => x.Value));
    }

    public List<Student> GetTopPerformers(int count)
    {
        return students
            .Where(s => s.Subjects.Count > 0)
            .OrderByDescending(s => s.Subjects.Values.Average())
            .Take(count)
            .ToList();
    }
}
