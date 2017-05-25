using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class GetProductsBindingModel
    {
        public GetProductsBindingModel()
        {
            this.StartPage = 1;
        }


        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public int? CityId { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string SortBy { get; set; }

        [Range(1, 100000, ErrorMessage = "Page number should be in range [1...100000].")]
        public int? StartPage { get; set; }

        [Range(1, 100, ErrorMessage = "Page size be in range [1...1000].")]
        public int? PageSize { get; set; }
    }
}