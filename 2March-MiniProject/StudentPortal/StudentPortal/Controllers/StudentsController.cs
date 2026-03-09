using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;
public class StudentsController : Controller
{
    private readonly IStudentService _service;
    public StudentsController(IStudentService service)
    {
        _service = service;
    }
    // GET:     Students
    public async Task<IActionResult> Index(string? q)
    {
        ViewBag.Query = q;
        var students = await _service.SearchAsync(q);
        return View(students);
    }
    // GET: Students/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var student = await _service.GetAsync(id.Value);
        if (student == null) return NotFound();
        return View(student);
    }
    // GET: Students/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        var result = await _service.CreateAsync(student);
        if (!result.ok)
        {
            ModelState.AddModelError("", result.message);
            return View(student);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: Students/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var student = await _service.GetAsync(id.Value);
        if (student == null) return NotFound();
        return View(student);
    }
    // POST: Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.StudentId) return NotFound();
        await _service.UpdateAsync(student);
        return RedirectToAction(nameof(Index));
    }

    // GET: Students/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var student = await _service.GetAsync(id.Value);

        if (student == null) return NotFound();

        return View(student);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Search(string? q)
    {
        var students = await _service.SearchAsync(q);

        var result = students.Select(s => new
        {
            studentId = s.StudentId,
            fullName = s.FullName,
            email = s.Email,
            status = s.Status
        });

        return Json(result);
    }
}