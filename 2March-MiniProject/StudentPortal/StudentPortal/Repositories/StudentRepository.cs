using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;

        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync(string? q = null)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(s =>
                    s.FullName.Contains(q) ||
                    s.Email.Contains(q));
            }

            return await query.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student != null)
            {
                // Remove related enrollments first
                _context.Enrollments.RemoveRange(student.Enrollments);

                // Then remove student
                _context.Students.Remove(student);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null)
        {
            return await _context.Students
                .AnyAsync(s =>
                    s.Email == email &&
                    (!ignoreStudentId.HasValue || s.StudentId != ignoreStudentId));
        }
    }
}