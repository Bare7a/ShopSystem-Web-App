using System;

namespace Services.Models.ViewModels
{
    public class ProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Condition { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime CreateDate { get; set; }
    }
}