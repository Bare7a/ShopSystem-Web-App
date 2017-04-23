using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class VideoBindingModel
    {
        [Required]
        public string UrlAddress { get; set; }

        [Required]
        public int VideoType { get; set; }
    }
}