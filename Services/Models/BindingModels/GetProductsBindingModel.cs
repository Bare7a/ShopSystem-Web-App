using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class GetProductsBindingModel
    {
        public GetProductsBindingModel()
        {
            this.StartPage = 1;
        }

        public int? CategoryId { get; set; }

        public int? CityId { get; set; }

        public string SortBy { get; set; }

        [Range(1, 100000, ErrorMessage = "Page number should be in range [1...100000].")]
        public int? StartPage { get; set; }

        [Range(1, 100, ErrorMessage = "Page size be in range [1...1000].")]
        public int? PageSize { get; set; }
    }
}