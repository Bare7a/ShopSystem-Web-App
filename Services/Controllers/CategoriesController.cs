using Services.Models.ViewModels;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = this.Data.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            });

            return Ok(categories);
        }
    }
}