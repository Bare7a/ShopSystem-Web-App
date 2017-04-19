﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Score { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string AddresseeId { get; set; }

        public virtual User Addressee { get; set; }
    }
}