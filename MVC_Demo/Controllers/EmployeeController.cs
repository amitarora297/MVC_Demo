using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVC_Demo.Models;
using System.Linq;

namespace MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDetails(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee =employeeContext.employees.FirstOrDefault(emp => emp.ID == id);
            return View(employee);
        }
    }
}