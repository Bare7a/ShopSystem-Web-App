using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models.BindingModels
{
    public class GetMessagesBindingModel
    {
        public GetMessagesBindingModel()
        {
            this.StartPage = 1;
        }

        [MinLength(3)]
        [MaxLength(10)]
        public string Type { get; set; }

        [Range(1, 100000, ErrorMessage = "Page number should be in range [1...100000].")]
        public int? StartPage { get; set; }

        [Range(1, 100, ErrorMessage = "Page size be in range [1...1000].")]
        public int? PageSize { get; set; }
    }
}