using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class PatchCommentBindingModel
    {
        public int CommentId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Content { get; set; }
    }
}