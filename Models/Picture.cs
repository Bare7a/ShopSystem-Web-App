using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
