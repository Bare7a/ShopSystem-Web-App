using Data.Models;
using Services.Models.BindingModels;
using System;
using System.Web.Http;

namespace Services.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseApiController
    {
        public IHttpActionResult PostCategory(AddCategoryBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            Category category = new Category()
            {
                Image = model.Image,
                Name = model.Name
            };

            this.Data.SaveChanges();

            return Ok(String.Format("Category with the name {0} was successfully created!", category.Name));
        }
    }
}