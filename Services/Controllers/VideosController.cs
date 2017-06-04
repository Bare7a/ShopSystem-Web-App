using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using System.Linq;
using System.Web.Http;
using System.Text.RegularExpressions;
using Services.Models.ViewModels;

namespace Services.Controllers
{
    public class VideosController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetVideosByProductId(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var videos = this.Data.Videos
                .Where(v => v.ProductId == id).Select(v => new VideoViewModel
                {
                    Id = v.Id,
                    UrlAddress = v.UrlAddress,
                    VideoType = v.VideoType.ToString()
                }).OrderByDescending(v => v.Id);

            if (videos == null)
            {
                return this.BadRequest("The product you are trying to retrive the comments from does not exist!");
            }

            return Ok(videos);
        }

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

            Regex vbox7Regex = new Regex(@"play:([\d\w]*)");
            Regex vimeoRegex = new Regex(@"vimeo.com\/([\d]*)");
            Regex youtubeRegex = new Regex(@"watch\?v=([\d\w-_]*)");
            Regex youtubeShortRegex = new Regex(@"youtu.be\/([\d\w-_]*)");


            string urlAddress = "";
            Match match;

            if (model.VideoType == (int)VideoType.Vbox7)
            {
                match = vbox7Regex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;
            }
            else if (model.VideoType == (int)VideoType.Vimeo)
            {
                match = vimeoRegex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;
            }
            else if (model.VideoType == (int)VideoType.YouTube)
            {
                match = youtubeRegex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;

                if (urlAddress == "")
                {
                    match = youtubeShortRegex.Match(model.UrlAddress);
                    urlAddress = match.Groups[1].Value;
                }
            }

            if (urlAddress == "")
            {
                return BadRequest("The video was not valid!");
            }


            var video = new Video
            {
                ProductId = model.ProductId,
                UrlAddress = urlAddress,
                VideoType = (VideoType)model.VideoType
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

            Regex vbox7Regex = new Regex(@"play:([\d\w]*)");
            Regex vimeoRegex = new Regex(@"vimeo.com\/([\d]*)");
            Regex youtubeRegex = new Regex(@"watch\?v=([\d\w-_]*)");


            string urlAddress = "";
            Match match;

            if (model.VideoType == (int)VideoType.Vbox7)
            {
                match = vbox7Regex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;
            }
            else if (model.VideoType == (int)VideoType.Vimeo)
            {
                match = vimeoRegex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;
            }
            else if (model.VideoType == (int)VideoType.YouTube)
            {
                match = youtubeRegex.Match(model.UrlAddress);
                urlAddress = match.Groups[1].Value;
            }

            if (urlAddress == "")
            {
                return BadRequest("The video was not valid!");
            }

            video.UrlAddress = urlAddress;
            video.VideoType = (VideoType)model.VideoType;

            this.Data.SaveChanges();

            return Ok("The video was successfully modified!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteVideoById(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var video = this.Data.Videos.FirstOrDefault(v => v.Id == id && v.Product.UserId == userId);

            if (video == null)
            {
                return this.BadRequest("The video you are trying to delete is not yours!");
            }

            this.Data.Videos.Remove(video);
            this.Data.SaveChanges();

            return Ok("The video was successfully deleted!");
        }
    }
}