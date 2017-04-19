using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

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
