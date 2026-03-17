using ClassLibDBFirst.Models;

namespace webApp1.Repository
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task CreateAsync(Student student);
        Task<Student> GetStudentById(int id);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
