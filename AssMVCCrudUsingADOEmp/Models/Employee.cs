using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssMVCCrudUsingADOEmp.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Required")]
        [DataType(DataType.Text)]
        [Display(Name ="Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Salary Required")]
        public int Salary { get; set; }
    }
}
