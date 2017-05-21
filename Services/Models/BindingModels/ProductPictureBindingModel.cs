using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class ProductPictureBindingModel
    {
        [Required]
        public string Image { get; set; }
    }
}