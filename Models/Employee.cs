using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation? Designation { get; set; }

        public int WorkingHourId { get; set; }

        [ForeignKey("WorkingHourId")]
        public virtual WorkingHour? WorkingHour { get; set; }

        public int PaymentRuleId { get; set; }

        [ForeignKey("PaymentRuleId")]
        public virtual PaymentRule? PaymentRule { get; set; }

    }
}
