using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
namespace StudentPortal.Mvc.Controllers;
public class EnrollmentsController : Controller
{
    private readonly ApiClientService _api;
    public EnrollmentsController(ApiClientService api) => _api = api;
    public async Task<IActionResult> Index() => View(await _api.GetListAsync<EnrollmentVm>("enrollments") ?? new List<EnrollmentVm>());
    public async Task<IActionResult> Create() { var vm = new EnrollmentVm { EnrollDate = DateOnly.FromDateTime(DateTime.Today), PaymentStatus = "Pending" }; await LoadDropDownsAsync(vm); return View(vm); }
    [HttpPost] public async Task<IActionResult> Create(EnrollmentVm model) { if (!ModelState.IsValid) { await LoadDropDownsAsync(model); return View(model);} var r = await _api.PostAsync("enrollments", model); if (!r.Success) { ModelState.AddModelError("", r.Message); await LoadDropDownsAsync(model); return View(model);} TempData["Success"] = "Enrollment created successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var vm = await _api.GetAsync<EnrollmentVm>($"enrollments/{id}"); if (vm is null) return NotFound(); await LoadDropDownsAsync(vm); return View(vm); }
    [HttpPost] public async Task<IActionResult> Edit(EnrollmentVm model) { if (!ModelState.IsValid) { await LoadDropDownsAsync(model); return View(model);} var r = await _api.PutAsync($"enrollments/{model.EnrollmentId}", model); if (!r.Success) { ModelState.AddModelError("", r.Message); await LoadDropDownsAsync(model); return View(model);} TempData["Success"] = "Enrollment updated successfully."; return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) => (await _api.GetAsync<EnrollmentVm>($"enrollments/{id}")) is { } m ? View(m) : NotFound();
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { var r = await _api.DeleteAsync($"enrollments/{id}"); TempData[r.Success ? "Success" : "Error"] = r.Message; return RedirectToAction(nameof(Index)); }
    private async Task LoadDropDownsAsync(EnrollmentVm model)
    {
        var students = await _api.GetListAsync<StudentVm>("students") ?? new();
        var courses = await _api.GetListAsync<CourseVm>("courses") ?? new();
        model.Students = students.Select(s => new SelectListItem { Value = s.StudentId.ToString(), Text = $"{s.StudentId} - {s.FullName}" }).ToList();
        model.Courses = courses.Select(c => new SelectListItem { Value = c.CourseId.ToString(), Text = $"{c.CourseId} - {c.Title}" }).ToList();
    }
}