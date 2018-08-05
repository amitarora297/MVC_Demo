using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Demo.Controllers
{
    public class EmployeeController : Controller 
    {
        public IActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employees = employeeContext.employees.FirstOrDefault(emp => emp.ID == id);
            return View(employees);
        }

        public IActionResult Index(int departmentid)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.employees.Where(emp => emp.DepartmentID == departmentid).ToList();
            return View(employees);
        }
    }
}