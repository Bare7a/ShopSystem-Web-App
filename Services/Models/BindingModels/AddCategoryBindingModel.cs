using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class AddCategoryBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
    }
}