using System;

namespace Services.Models.ViewModels
{
    public class MessagesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsSeen { get; set; }

        public DateTime CreateDate { get; set; }

        public string SenderUsername { get; set; }

        public string AddresseeUsername { get; set; }
    }
}