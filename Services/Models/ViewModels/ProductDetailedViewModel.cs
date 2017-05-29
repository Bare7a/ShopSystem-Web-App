using System;
using System.Collections.Generic;

namespace Services.Models.ViewModels
{
    public class DetailedProductViewModel : ProductsViewModel
    {
        public SubmiterViewModel Submiter { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<PictureViewModel> Pictures { get; set; }

        public IEnumerable<VideoViewModel> Videos { get; set; }
    }
}