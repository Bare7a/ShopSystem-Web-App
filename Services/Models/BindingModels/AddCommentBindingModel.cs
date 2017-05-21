using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class AddCommentBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Content { get; set; }

        public int ProductId { get; set; }
    }
}