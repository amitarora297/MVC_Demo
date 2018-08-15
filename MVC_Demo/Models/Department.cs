using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Demo.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Employee> employess { get; set; }
    }
}
