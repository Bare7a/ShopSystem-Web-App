using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class PictureBindingModel
    {
        [Required]
        public string Image { get; set; }
    }
}