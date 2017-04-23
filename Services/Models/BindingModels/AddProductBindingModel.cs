using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class AddProductBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<PictureBindingModel> pictures { get; set; }
        public ICollection<VideoBindingModel> videos { get; set; }
    }
}