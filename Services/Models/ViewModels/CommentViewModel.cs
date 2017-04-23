using System;

namespace Services.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public string Username { get; set; }
    }
}