using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class PaymentRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RuleName { get; set; }
    }
}
