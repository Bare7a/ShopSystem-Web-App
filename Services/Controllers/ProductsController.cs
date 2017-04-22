using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models;

namespace Services.Controllers
{
    public class ProductsController : BaseApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/products")]
        public IHttpActionResult PostProduct(AddProductBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            var category = this.Data.Cateogries.FirstOrDefault(c => c.Id == model.CategoryId);

            if (category == null)
            {
                return this.BadRequest("Category is not valid!");
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                CreateDate = DateTime.Now,
                CategoryId = model.CategoryId,
                UserId = userId
            };

            this.Data.Products.Add(product);
            this.Data.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("api/products/{productId}/picture")]
        public IHttpActionResult PostPictureProduct(int productId, AddProductPictureBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            Product product = this.Data.Products.Where(p => p.Id == productId && p.UserId == userId).FirstOrDefault();

            if (product == null)
            {
                return Unauthorized();
            }

            Picture picture = new Picture()
            {
                Image = model.Image
            };

            product.Pictures.Add(picture);
            this.Data.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("api/products/{productId}/video")]
        public IHttpActionResult PostVideoProduct(int productId, AddProductVideoBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            Product product = this.Data.Products.Where(p => p.Id == productId && p.UserId == userId).FirstOrDefault();

            if (product == null)
            {
                return Unauthorized();
            }

            Video video = new Video()
            {
                UrlAddress = model.UrlAddress,
                VideoType = (VideoType)model.VideoType,
            };

            product.Videos.Add(video);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}