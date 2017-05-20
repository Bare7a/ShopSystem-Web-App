using System;

namespace Services.Models.ViewModels
{
    public class MessageDetailedViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public string SenderUsername { get; set; }

        public string AddresseeUsername { get; set; }
    }
}