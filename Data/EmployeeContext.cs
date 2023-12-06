
using Employees_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees_CRUD.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Emloyee> Employees { get; set; }
    }
}
