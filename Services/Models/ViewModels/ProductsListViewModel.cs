namespace Services.Models.ViewModels
{
    public class ProductsListViewModel : ProductsViewModel
    {
        public string Picture { get; set; }

        public double Feedback { get; set; }

        public string City { get; set; }

        public string Submiter { get; set; }
    }
}