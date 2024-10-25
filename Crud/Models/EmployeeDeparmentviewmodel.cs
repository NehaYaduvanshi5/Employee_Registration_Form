using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class EmployeeDeparmentviewmodel
    {

        [Key]
        public int EmployeeId { get; set; }
        [Range(1,10000,ErrorMessage = "Please select  Department")]
        public int DeparmentId { get; set; }
        [Display(Name = "First Name :")]
        [Required(ErrorMessage ="Please Enter first name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name :")]
        [Required(ErrorMessage = "Please Enter last name")]
        public string? LastName { get; set; }
        [Display(Name = "Full Name :")]
        public string? FullName 
        {

            get
            {
                return FirstName+ "  " + LastName;
            }

        }

        [Display(Name = "Gender :")]

        [Required(ErrorMessage = "Please select gender")]
        public string? Gender { get; set; }
        [Display(Name = "Department Name :")]
        [Required(ErrorMessage = "Please select department name")]
        public string? DepartmentName { get; set; }
        [Display(Name = "Department code :")]

        [Required(ErrorMessage = "Please select department code")]
        public string? DepartmentCode { get; set; }
        



    }
}
