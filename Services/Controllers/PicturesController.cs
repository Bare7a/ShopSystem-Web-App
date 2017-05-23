using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class PicturesController : BaseApiController
    {
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
        public IHttpActionResult DeletePicture(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var picture = this.Data.Pictures.FirstOrDefault(p => p.Id == id);

            if (picture == null)
            {
                return this.BadRequest("The picture is not valid!");
            }

            if (picture.Product.UserId != userId)
            {
                return this.BadRequest("The picture you are trying to delete is not yours!");
            }

            if (picture.Product.Pictures.Count == 1)
            {
                return this.BadRequest("Add atleast one more picture before removing this one!");
            }

            this.Data.Pictures.Remove(picture);

            return Ok("The picture was successfully deleted!");
        }
    }
}