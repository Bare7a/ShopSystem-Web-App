using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class AddProductPictureBindingModel
    {
        [Required]
        public string Image { get; set; }
    }
}