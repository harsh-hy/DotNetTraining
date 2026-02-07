namespace Domain;
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department{ get; set; }= string.Empty;
    public double Salary{ get; set; }
    public DateTime JoiningDate{ get; set; }
}