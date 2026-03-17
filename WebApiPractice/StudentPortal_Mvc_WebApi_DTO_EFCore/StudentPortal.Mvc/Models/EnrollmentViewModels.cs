using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace StudentPortal.Mvc.Models;
public class EnrollmentVm
{
    public int EnrollmentId { get; set; }
    [Required] public int StudentId { get; set; }
    public string? StudentName { get; set; }
    [Required] public int CourseId { get; set; }
    public string? CourseTitle { get; set; }
    [Required] public DateOnly EnrollDate { get; set; }
    [Required, StringLength(20)] public string PaymentStatus { get; set; } = "Pending";
    [Range(0,999999)] public decimal PaidAmount { get; set; }
    public List<SelectListItem> Students { get; set; } = new();
    public List<SelectListItem> Courses { get; set; } = new();
}