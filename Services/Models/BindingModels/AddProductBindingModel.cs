using System.Collections.Generic;

namespace Services.Models.BindingModels
{
    public class AddProductBindingModel : ProductBindingModel
    {
        public IEnumerable<ProductPictureBindingModel> pictures { get; set; }
        public IEnumerable<ProductVideoBindingModel> videos { get; set; }
    }
}