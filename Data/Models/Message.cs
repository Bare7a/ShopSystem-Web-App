﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Message
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
        public bool IsSeen { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string AddresseeId { get; set; }

        public virtual User Addressee { get; set; }
    }
}
