using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class EmployeeModel

    {
        [Key]
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public DepartmentModel Department { get; set; } = default!;

    }
}
