using Crud.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
                
        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DepartmentModel>  Departments { get; set; }
        [NotMapped]
        public DbSet<EmployeeDeparmentviewmodel> EmployeeDeparmentviewmodels { get; set; }

    }
}
