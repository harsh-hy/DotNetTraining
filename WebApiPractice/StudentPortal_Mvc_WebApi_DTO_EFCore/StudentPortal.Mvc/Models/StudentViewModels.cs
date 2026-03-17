using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;
public class StudentVm
{
    public int StudentId { get; set; }
    [Required, StringLength(120)] public string FullName { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(180)] public string Email { get; set; } = string.Empty;
    [StringLength(30)] public string? Phone { get; set; }
    [Required, StringLength(20)] public string Status { get; set; } = "Active";
    [Required] public DateOnly JoinDate { get; set; }
}