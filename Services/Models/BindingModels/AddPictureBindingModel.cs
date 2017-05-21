using System.ComponentModel.DataAnnotations;

namespace Services.Models.BindingModels
{
    public class AddPictureBindingModel : ProductPictureBindingModel
    {
        public int ProductId { get; set; }
    }
}