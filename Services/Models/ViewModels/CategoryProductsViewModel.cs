using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models.ViewModels
{
    public class CategoryProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Submiter { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
    }
}