using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class AddMessageBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string AddresseeUsername { get; set; }
    }
}