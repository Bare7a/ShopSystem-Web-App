using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class VideoBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string UrlAddress { get; set; }

        [Range(0,2)]
        public int VideoType { get; set; }
    }
}