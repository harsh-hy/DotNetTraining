using DbFirstDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class StudentsController : Controller
{
    private readonly TrainingDBContext _db;

    public StudentsController(TrainingDBContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.Students
                    .Include(s => s.Enrollments)
                        .ThenInclude(e => e.Course)
                    .AsNoTracking()
                    .ToListAsync();
        return View(list);

        // var list = await _db.Students
        //                     .AsNoTracking()
        //                     .OrderBy(s => s.StudentId)
        //                     .ToListAsync();

        // return View(list);
    }
}