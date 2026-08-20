using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var emp = dbContext.Employees.Find(id);
            if( emp == null)
            {
                return NotFound("Employee with given id not found");
            }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };


            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var emp = dbContext.Employees.Find(id);
            if( emp == null )
            {
                return NotFound("Employee with this id doesnot edxist");
            }
            emp.Email=updateEmployeeDto.Email;
            emp.Phone=updateEmployeeDto.Phone;
            emp.Salary=updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(emp);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emp = dbContext.Employees.Find(id);
            if(emp == null)
            {
                return NotFound($"Employee with id {id} is not foud");
            }
            dbContext.Employees.Remove(emp);
            dbContext.SaveChanges();
            return Ok($"Deleted Employee {emp.Name}");
        }
    }
}
