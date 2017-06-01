using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using System.Linq;
using System.Web.Http;
using Services.Models.ViewModels;

namespace Services.Controllers
{
    public class PicturesController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetVideosByProductId(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var pictures = this.Data.Pictures
                .Where(p => p.ProductId == id).Select(v => new PictureViewModel
                {
                    Id = v.Id,
                    Image = v.Image
                }).OrderByDescending(p => p.Id);

            if (pictures == null)
            {
                return this.BadRequest("The product you are trying to retrive the comments from does not exist!");
            }

            return Ok(pictures);
        }

        [HttpPost]
        public IHttpActionResult PostPicture(AddPictureBindingModel model)
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

            var product = this.Data.Products.FirstOrDefault(p => p.Id == model.ProductId);

            if (product == null)
            {
                return this.BadRequest("Product is not valid!");
            }

            if (product.UserId != userId)
            {
                return this.Unauthorized();
            }

            var picture = new Picture
            {
                ProductId = model.ProductId,
                Image = model.Image
            };

            this.Data.Pictures.Add(picture);
            this.Data.SaveChanges();

            return Ok("The picture was added successfully!");
        }

        [HttpPut]
        public IHttpActionResult PutPicture(PutPictureBindingModel model)
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

            var picture = this.Data.Pictures.FirstOrDefault(p => p.Id == model.PictureId);

            if (picture == null)
            {
                return this.BadRequest("The picture is not valid!");
            }

            if (picture.Product.UserId != userId)
            {
                return this.BadRequest("The picture you are trying to modify is not yours!");
            }

            picture.Image = model.Image;

            this.Data.SaveChanges();

            return Ok("The picture was successfully modified!");
        }

        [HttpDelete]
        public IHttpActionResult DeletePictureById(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var picture = this.Data.Pictures.FirstOrDefault(p => p.Id == id && p.Product.UserId == userId);

            if (picture == null)
            {
                return this.BadRequest("The video you are trying to delete is not yours!");
            }

            this.Data.Pictures.Remove(picture);
            this.Data.SaveChanges();

            return Ok("The picture was successfully deleted!");
        }
    }
}