using System;

namespace Services.Models.ViewModels
{
    public class UserProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ConditionId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}