using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
