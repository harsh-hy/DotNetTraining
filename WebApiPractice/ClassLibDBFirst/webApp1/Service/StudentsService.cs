using ClassLibDBFirst.Models;
using webApp1.Repository;

namespace webApp1.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _repository;

        public StudentsService(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task CreateStudent(Student student)
        {
            await _repository.CreateAsync(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repository.UpdateStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            await _repository.DeleteStudent(id);
        }
    }
}