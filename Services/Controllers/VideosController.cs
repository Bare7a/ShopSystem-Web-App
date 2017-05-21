using Microsoft.AspNet.Identity;
using Models;
using Services.Models.BindingModels;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class VideosController : BaseApiController
    {
        [HttpPost]
        public IHttpActionResult PostVideo(AddVideoBindingModel model)
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

            var video = new Video
            {
                ProductId = model.ProductId,
                UrlAddress = model.UrlAddress,
                VideoType = (VideoType) model.VideoType
            };

            this.Data.Videos.Add(video);
            this.Data.SaveChanges();

            return Ok("The video was successfully added!");
        }

        [HttpPut]
        public IHttpActionResult PutVideo(PutVideoBindingModel model)
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

            var video = this.Data.Videos.FirstOrDefault(v => v.Id == model.VideoId);

            if (video == null)
            {
                return this.BadRequest("The video is not valid!");
            }

            if (video.Product.UserId != userId)
            {
                return this.BadRequest("The video you are trying to modify is not yours!");
            }

            video.UrlAddress = model.UrlAddress;
            video.VideoType = (VideoType) model.VideoType;

            this.Data.SaveChanges();

            return Ok("The video was successfully modified!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var video = this.Data.Videos.FirstOrDefault(v => v.Id == id);

            if (video == null)
            {
                return this.BadRequest("The video is not valid!");
            }

            if (video.Product.UserId != userId)
            {
                return this.BadRequest("The video you are trying to delete is not yours!");
            }

            this.Data.Videos.Remove(video);

            return Ok("The video was successfully deleted!");
        }
    }
}