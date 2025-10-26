using System.ComponentModel.DataAnnotations;

namespace Pro1.Models
{
        public class EmployeeModel
        {
            [Required(ErrorMessage = "Employee Name is required.")]

            [StringLength(100)]

            public string? Name { get; set; }

            [Required]
            [Range(0.01, 10000.00, ErrorMessage = "salary must between 250000 to 100000")]

            public decimal Salary { get; set; }

            
        }
    
}
