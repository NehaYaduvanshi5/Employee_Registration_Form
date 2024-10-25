using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DeparmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }

    }
}
