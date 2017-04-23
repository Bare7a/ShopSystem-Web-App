using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models.ViewModels
{
    public class PictureViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }
    }
}