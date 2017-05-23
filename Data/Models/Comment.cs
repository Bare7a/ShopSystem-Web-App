using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
