using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}