using System.ComponentModel.DataAnnotations;


namespace Services.Models.BindingModels
{
    public class GetUserProductsBindingModel
    {
        public GetUserProductsBindingModel()
        {
            this.StartPage = 1;
        }

        [Range(1, 100000, ErrorMessage = "Page number should be in range [1...100000].")]
        public int? StartPage { get; set; }

        [Range(1, 100, ErrorMessage = "Page size be in range [1...1000].")]
        public int? PageSize { get; set; }
    }
}