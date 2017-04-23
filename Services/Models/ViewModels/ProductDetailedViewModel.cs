using System;
using System.Collections.Generic;

namespace Services.Models.ViewModels
{
    public class DetailedProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Submiter { get; set; }

        public double Feedback { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<PictureViewModel> Pictures { get; set; }

        public IEnumerable<VideoViewModel> Videos { get; set; }

        public DateTime CreateDate { get; set; }
    }
}