using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string UrlAddress { get; set; }

        public VideoType VideoType { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
