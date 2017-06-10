using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string UrlAddress { get; set; }

        [Required]
        public VideoType VideoType { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
