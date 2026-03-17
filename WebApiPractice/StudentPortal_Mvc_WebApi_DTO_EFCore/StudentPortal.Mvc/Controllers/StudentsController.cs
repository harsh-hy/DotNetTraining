using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
namespace StudentPortal.Mvc.Controllers;
public class StudentsController : Controller
{
    private readonly ApiClientService _api;
    public StudentsController(ApiClientService api) => _api = api;
    public async Task<IActionResult> Index() => View(await _api.GetListAsync<StudentVm>("students") ?? new List<StudentVm>());
    public IActionResult Create() => View(new StudentVm { JoinDate = DateOnly.FromDateTime(DateTime.Today), Status = "Active" });
    [HttpPost] public async Task<IActionResult> Create(StudentVm model) { if (!ModelState.IsValid) return View(model); var r = await _api.PostAsync("students", model); if (!r.Success) { ModelState.AddModelError("", r.Message); return View(model);} TempData["Success"] = "Student created successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) => (await _api.GetAsync<StudentVm>($"students/{id}")) is { } m ? View(m) : NotFound();
    [HttpPost] public async Task<IActionResult> Edit(StudentVm model) { if (!ModelState.IsValid) return View(model); var r = await _api.PutAsync($"students/{model.StudentId}", model); if (!r.Success) { ModelState.AddModelError("", r.Message); return View(model);} TempData["Success"] = "Student updated successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) => (await _api.GetAsync<StudentVm>($"students/{id}")) is { } m ? View(m) : NotFound();
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { var r = await _api.DeleteAsync($"students/{id}"); TempData[r.Success ? "Success" : "Error"] = r.Message; return RedirectToAction(nameof(Index)); }
}