using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class AddFeedbackBindingModel
    {
        [Range(1, 5)]
        public int Score { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public string AddresseeUsername { get; set; }
    }
}