using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Department Name")]
        public DepartmentEnum? DepartmentName { get; set; }
    }
}
