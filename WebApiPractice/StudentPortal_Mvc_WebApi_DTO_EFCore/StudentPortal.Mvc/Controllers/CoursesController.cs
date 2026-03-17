using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
namespace StudentPortal.Mvc.Controllers;
public class CoursesController : Controller
{
    private readonly ApiClientService _api;
    public CoursesController(ApiClientService api) => _api = api;
    public async Task<IActionResult> Index() => View(await _api.GetListAsync<CourseVm>("courses") ?? new List<CourseVm>());
    public IActionResult Create() => View(new CourseVm());
    [HttpPost] public async Task<IActionResult> Create(CourseVm model) { if (!ModelState.IsValid) return View(model); var r = await _api.PostAsync("courses", model); if (!r.Success) { ModelState.AddModelError("", r.Message); return View(model);} TempData["Success"] = "Course created successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) => (await _api.GetAsync<CourseVm>($"courses/{id}")) is { } m ? View(m) : NotFound();
    [HttpPost] public async Task<IActionResult> Edit(CourseVm model) { if (!ModelState.IsValid) return View(model); var r = await _api.PutAsync($"courses/{model.CourseId}", model); if (!r.Success) { ModelState.AddModelError("", r.Message); return View(model);} TempData["Success"] = "Course updated successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) => (await _api.GetAsync<CourseVm>($"courses/{id}")) is { } m ? View(m) : NotFound();
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { var r = await _api.DeleteAsync($"courses/{id}"); TempData[r.Success ? "Success" : "Error"] = r.Message; return RedirectToAction(nameof(Index)); }
}