using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class AddProductBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }



    //public class AddProductVideoBindingModel
    //{
    //    [Required]
    //    [MinLength(3)]
    //    [MaxLength(100)]
    //    public string UrlAddress { get; set; }

    //    [Required]
    //    public VideoType VideoType { get; set; }
    //}

}