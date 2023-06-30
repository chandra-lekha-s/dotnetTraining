using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class WorkingHour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CompanyMonthlyWorkingHour { get; set; }
        [Required]
        public int EmployeeMonthlyWorkingHour { get; set; }

    }
}
