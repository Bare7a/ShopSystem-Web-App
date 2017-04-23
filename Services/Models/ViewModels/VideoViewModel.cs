using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        public string UrlAddress { get; set; }

        public string VideoType { get; set; }
    }
}