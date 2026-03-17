using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;
public class CourseVm
{
    public int CourseId { get; set; }
    [Required, StringLength(150)] public string Title { get; set; } = string.Empty;
    [Range(1,3650)] public int DurationDays { get; set; }
    [Range(0,999999)] public decimal Fee { get; set; }
    [Required, StringLength(30)] public string Level { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}