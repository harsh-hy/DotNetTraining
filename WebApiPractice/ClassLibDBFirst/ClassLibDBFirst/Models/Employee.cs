using System;
using System.Collections.Generic;

namespace ClassLibDBFirst.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FullName { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }
}
