using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using Services.Models.ViewModels;
using System.Text.RegularExpressions;

namespace Services.Controllers
{
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [Authorize]
        [Route("api/UserProducts")]
        public IHttpActionResult GetUserProducts([FromUri]GetUserProductsBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var products = this.Data.Products.Where(p => p.UserId == userId).AsQueryable();
            products = products.OrderByDescending(p => p.CreateDate).ThenBy(p => p.Id);

            int pageSize = 10;
            if (model.PageSize.HasValue)
            {
                pageSize = model.PageSize.Value;
            }

            int productsCount = products.Count();
            int numPages = (productsCount + pageSize - 1) / pageSize;

            if (model.StartPage.HasValue)
            {
                products = products.Skip(pageSize * (model.StartPage.Value - 1));
            }
            products = products.Take(pageSize);

            var productsToReturn = products.Select(p => new ProductsViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Condition = (p.Condition).ToString(),
                Quantity = p.Quantity,
                Description = p.Description,
                Category = p.Category.Name,
                CreateDate = p.CreateDate
            }).ToList();

            return this.Ok(
                new
                {
                    productsCount,
                    numPages,
                    products = productsToReturn
                }
            );
        }

        [HttpGet]
        [Authorize]
        [Route("api/UserProducts/{id}")]
        public IHttpActionResult GetUserProductById(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var product = this.Data.Products
                .Select(p => new UserProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ConditionId = (int) p.Condition,
                    Quantity = p.Quantity,
                    Description = p.Description,
                    CategoryId = p.Category.Id
                })
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public IHttpActionResult GetProducts([FromUri]GetProductsBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var products = this.Data.Products.AsQueryable();

            if (model.Name != null)
            {
                products = products.Where(p => p.Name.Contains(model.Name));
            }

            if (model.Description != null)
            {
                products = products.Where(p => p.Description.Contains(model.Description));
            }

            if (model.MinPrice != null)
            {
                products = products.Where(p => p.Price > model.MinPrice);
            }

            if (model.MaxPrice != null)
            {
                products = products.Where(p => p.Price < model.MaxPrice);
            }

            if (model.CategoryId.HasValue)
            {
                products = products.Where(p => p.Category.Id == model.CategoryId);
            }

            if (model.CityId.HasValue)
            {
                products = products.Where(p => p.User.CityId == model.CityId);
            }

            if (model.SortBy != null)
            {
                switch (model.SortBy)
                {
                    case "PriceAsc": products = products.OrderBy(p => p.Price).ThenByDescending(p => p.Id); break;
                    case "PriceDesc": products = products.OrderByDescending(p => p.Price).ThenByDescending(p => p.Id); break;
                    case "Feedback": products = products.OrderByDescending(p => (p.User.RecievedFeedbacks.Count == 0 ? 0.0 : p.User.RecievedFeedbacks.Sum(f => f.Score) / (double) p.User.RecievedFeedbacks.Count())).ThenByDescending(p => p.Id); break;
                    case "DateAsc": products = products.OrderBy(p => p.CreateDate).ThenByDescending(p => p.Id); break;
                    default: products = products.OrderByDescending(p => p.CreateDate).ThenBy(p => p.Id); break;
                }
            }
            else
            {
                products = products.OrderByDescending(p => p.CreateDate).ThenBy(p => p.Id);
            }

            products = products.Where(p => p.Quantity > 0);

            int pageSize = 10;
            if (model.PageSize.HasValue)
            {
                pageSize = model.PageSize.Value;
            }

            int productsCount = products.Count();
            int numPages = (productsCount + pageSize - 1) / pageSize;

            if (model.StartPage.HasValue)
            {
                products = products.Skip(pageSize * (model.StartPage.Value - 1));
            }
            products = products.Take(pageSize);

            var productsToReturn = products.Select(p => new ProductsListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Condition = (p.Condition).ToString(),
                Quantity = p.Quantity,
                Description = p.Description,
                Picture = p.Pictures.Select(pi => pi.Image).FirstOrDefault(),
                Submiter = p.User.UserName,
                Feedback = p.User.RecievedFeedbacks.Count == 0 ? 0.0 : Math.Round(p.User.RecievedFeedbacks.Sum(f => f.Score) / (double) p.User.RecievedFeedbacks.Count(), 2),
                City = p.User.City.Name,
                Category = p.Category.Name,
                CreateDate = p.CreateDate
            }).ToList();

            return this.Ok(
                new
                {
                    productsCount,
                    numPages,
                    products = productsToReturn
                }
            );
        }

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var product = this.Data.Products
                .Select(p => new DetailedProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Condition = (p.Condition).ToString(),
                    Quantity = p.Quantity,
                    Description = p.Description,

                    Category = p.Category.Name,
                    CreateDate = p.CreateDate,
                    Submiter = new SubmiterViewModel
                    {
                        Username = p.User.UserName,
                        Feedback = p.User.RecievedFeedbacks.Count == 0 ? 0.0 : Math.Round(p.User.RecievedFeedbacks.Sum(f => f.Score) / (double) p.User.RecievedFeedbacks.Count(), 2),
                        City = p.User.City.Name,
                        Facebook = p.User.Facebook,
                        PhoneNumber = p.User.PhoneNumber,
                        Skype = p.User.Skype
                    },
                })
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.NotFound();
            }

            return Ok(product);
        }

        [Authorize]
        [HttpPost]
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

            var category = this.Data.Categories.FirstOrDefault(c => c.Id == model.CategoryId);

            if (category == null)
            {
                return this.BadRequest("Category is not valid!");
            }

            if (model.pictures.Count() == 0)
            {
                return this.BadRequest("Product must have atleast 1 picture!");
            }

            ICollection<Picture> pictures = new HashSet<Picture>();
            foreach (var picture in model.pictures)
            {
                pictures.Add(new Picture
                {
                    Image = picture.Image
                });
            }

            Regex vbox7Regex = new Regex(@"play:([\d\w]*)");
            Regex vimeoRegex = new Regex(@"vimeo.com\/([\d]*)");
            Regex youtubeRegex = new Regex(@"watch\?v=([\d\w-_]*)");
            Regex youtubeShortRegex = new Regex(@"youtu.be\/([\d\w-_]*)");

            ICollection<Video> videos = new HashSet<Video>();
            foreach (var video in model.videos)
            {
                string urlAddress = "";
                Match match;

                if (video.VideoType == (int)VideoType.Vbox7)
                {
                    match = vbox7Regex.Match(video.UrlAddress);
                    urlAddress = match.Groups[1].Value;
                }
                else if (video.VideoType == (int)VideoType.Vimeo)
                {
                    match = vimeoRegex.Match(video.UrlAddress);
                    urlAddress = match.Groups[1].Value;
                }
                else if (video.VideoType == (int)VideoType.YouTube)
                {
                    match = youtubeRegex.Match(video.UrlAddress);
                    urlAddress = match.Groups[1].Value;

                    if (urlAddress == "")
                    {
                        match = youtubeShortRegex.Match(video.UrlAddress);
                        urlAddress = match.Groups[1].Value;
                    }
                }

                if (urlAddress == "")
                {
                    return BadRequest(String.Format("The video ({0}) was not valid!", video.UrlAddress));
                }

                videos.Add(new Video
                {
                    UrlAddress = urlAddress,
                    VideoType = (VideoType)video.VideoType
                });
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Condition = (Condition)model.ConditionId,
                Quantity = model.Quantity,
                Pictures = pictures,
                Videos = videos,
                CreateDate = DateTime.Now,
                CategoryId = model.CategoryId,
                UserId = userId
            };

            this.Data.Products.Add(product);
            this.Data.SaveChanges();

            return Ok("Product was successfully added!");
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult PutProduct(PutProductBindingModel model)
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

            var product = this.Data.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.BadRequest("This product does not exist!");
            }

            if (product.UserId != userId)
            {
                return this.Unauthorized();
            }

            var category = this.Data.Categories.FirstOrDefault(c => c.Id == model.CategoryId);

            if (category == null)
            {
                return this.BadRequest("Category is not valid!");
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.CategoryId = model.CategoryId;
            product.Condition = (Condition)model.ConditionId;

            this.Data.SaveChanges();

            return Ok("Product was successfully edited!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = this.Data.Products.FirstOrDefault(d => d.Id == id);
            if (product == null)
            {
                return this.BadRequest("Product #" + id + " not found!");
            }

            var userId = User.Identity.GetUserId();
            if (product.UserId != userId)
            {
                return this.Unauthorized();
            }

            this.Data.Products.Remove(product);

            this.Data.SaveChanges();

            return this.Ok("Product #" + id + " was deleted successfully.");
        }
    }
}