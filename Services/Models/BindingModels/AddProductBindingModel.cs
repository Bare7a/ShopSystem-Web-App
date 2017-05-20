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

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Range(0,1)]
        public int Condition { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<PictureBindingModel> pictures { get; set; }
        public IEnumerable<VideoBindingModel> videos { get; set; }
    }
}