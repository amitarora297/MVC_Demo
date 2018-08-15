using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_Demo.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVC_Demo.Controllers
{

    public class EmployeeController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public IActionResult LoadAllEmployee()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee emp = employeeContext.employees.Single(e => e.ID == id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult UpdateEmployee()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee postedEmployee = new Employee();
            Employee existingEmployee;

            TryUpdateModelAsync(postedEmployee);

            existingEmployee = employeeContext.employees.Single(e => e.ID == postedEmployee.ID);

            existingEmployee.Name=  postedEmployee.Name;
            existingEmployee.Country = postedEmployee.Country ;
            existingEmployee.City = postedEmployee.City;
            existingEmployee.DepartmentID = postedEmployee.DepartmentID;

            if (ModelState.IsValid)
            {
                employeeContext.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.employees.Single(e => e.ID == id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Create")]
        public IActionResult SaveEmployee()
        {
            Employee emp = new Employee();
            TryUpdateModelAsync(emp);
            if (ModelState.IsValid)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                emp.ID  = employeeContext.employees.Count() == 0 ? 1 : employeeContext.employees.Max(e => e.ID) + 1;
                employeeContext.employees.Add(emp);
                employeeContext.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult RemoveEmployee(int id)
        {
                EmployeeContext employeeContext = new EmployeeContext();
                Employee emp = employeeContext.employees.Single(e=> e.ID  == id);
                employeeContext.employees.Remove(emp);
                employeeContext.SaveChanges();
                return RedirectToAction("All");
            
        }

    }
}