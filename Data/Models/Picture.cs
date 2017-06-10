using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
