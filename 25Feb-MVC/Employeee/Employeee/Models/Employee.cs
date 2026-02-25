using System.ComponentModel.DataAnnotations;

namespace Employeee.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        [Display(Name = "Employee Department")]
        public string? Department { get; set; }

        [Display(Name = "Employee City")]
        public string? City { get; set; }
    }
}
