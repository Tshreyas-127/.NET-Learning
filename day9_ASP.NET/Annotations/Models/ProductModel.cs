using System.ComponentModel.DataAnnotations;

namespace Annotation.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product Name is required.")]

        [StringLength(100)]

        public string? Name { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage ="price must between 0.01 to 10000")]

        public decimal Price { get; set; }

        [Range(0, 1000)]

        public int StockLevel {  get; set; }
    }
}
