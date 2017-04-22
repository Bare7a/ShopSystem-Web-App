using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class AddProductVideoBindingModel
    {
        [Required]
        public string UrlAddress { get; set; }

        [Required]
        public int VideoType { get; set; }
    }
}