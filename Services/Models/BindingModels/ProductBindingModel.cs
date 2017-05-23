using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class ProductBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Range(0, 1)]
        public int Condition { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}