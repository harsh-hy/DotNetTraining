using Microsoft.AspNetCore.Mvc;
using Employeee.Models;

namespace Employeee.Controllers
{
    public class EmployeeController : Controller
    {
        // STATIC COLLECTION 
        private static List<Employee> empList = new List<Employee>();

        // READ ALL
        public IActionResult Index()
        {
            return View(empList);
        }

        // CREATE - GET
        public IActionResult AddEmployee()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            var exists = empList.Any(e => e.Id == emp.Id);

            if (exists)
            {
                ModelState.AddModelError("", "Employee ID already exists!");
                return View(emp);
            }

            empList.Add(emp);
            return RedirectToAction("Index");
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var emp = empList.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var oldEmp = empList.FirstOrDefault(e => e.Id == emp.Id);

            if (oldEmp != null)
            {
                oldEmp.Name = emp.Name;
                oldEmp.Department = emp.Department;
                oldEmp.City = emp.City;
            }

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var emp = empList.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                empList.Remove(emp);

            return RedirectToAction("Index");
        }
    }
}