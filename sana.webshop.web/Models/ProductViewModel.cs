using System.ComponentModel.DataAnnotations;

namespace sana.webshop.web.Models
{
    public class ProductViewModel
    {
        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public string Number { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public bool IsInMemory { get; set; }
    }
}
