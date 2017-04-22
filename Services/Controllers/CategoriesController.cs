using Models;
using Services.Models.BindingModels;
using Services.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Services.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/categories")]
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

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/categories")]
        public IHttpActionResult GetCategories()
        {
            var category = this.Data.Cateogries.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image
            });

            return Ok(category);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/categories/{categoryName}/{pageNumber}")]
        public IHttpActionResult GetProductsByCategory(string categoryName, int pageNumber)
        {
            int productsToShow = 2;

            var products = this.Data.Products.Where(p=> p.Category.Name == categoryName)
                .Select(p => new CategoryProductsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Submiter = p.User.UserName,
                    Picture = p.Pictures.Select(pi=> pi.Image).FirstOrDefault(),
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CreateDate = p.CreateDate
                })
                .OrderBy(p=>p.CreateDate)
                .Skip(pageNumber * productsToShow).Take(productsToShow);

            return Ok(products);
        }
    }
}