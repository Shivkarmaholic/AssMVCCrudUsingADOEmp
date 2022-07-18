using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssMVCCrudUsingADOEmp.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        [DataType(DataType.Text)]
        [Display(Name ="Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Salary Required")]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
    }
}
