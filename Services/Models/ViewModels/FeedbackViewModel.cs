using System;

namespace Services.Models.ViewModels
{
    public class FeedbackViewModel
    {
        public string Username { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }
    }
}