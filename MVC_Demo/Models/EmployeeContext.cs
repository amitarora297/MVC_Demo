

using Microsoft.EntityFrameworkCore;

namespace MVC_Demo.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=AMIT\AMITPC;Database=Employee;Trusted_Connection=True;");
            }
        }
    }
}
