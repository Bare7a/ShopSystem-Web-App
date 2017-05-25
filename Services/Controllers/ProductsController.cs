using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using Services.Models.ViewModels;

namespace Services.Controllers
{
    public class ProductsController : BaseApiController
    {
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

            if(model.SortBy != null)
            {
                switch(model.SortBy)
                {
                    case "PriceAsc": products = products.OrderBy(p => p.Price).ThenByDescending(p => p.Id); break;
                    case "PriceDesc": products = products.OrderByDescending(p => p.Price).ThenByDescending(p => p.Id); break;
                    case "FeedbackAsc": products = products.OrderBy(p => (p.User.RecievedFeedbacks.Count == 0? 0.0 : p.User.RecievedFeedbacks.Sum(f=>f.Score) / p.User.RecievedFeedbacks.Count())).ThenByDescending(p => p.Id); break;
                    case "FeedbackDesc": products = products.OrderByDescending(p => (p.User.RecievedFeedbacks.Count == 0? 0.0 : p.User.RecievedFeedbacks.Sum(f=>f.Score) / p.User.RecievedFeedbacks.Count())).ThenByDescending(p => p.Id); break;
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
            if(model.PageSize.HasValue)
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
                Picture = p.Pictures.Select(pi => pi.Image).FirstOrDefault(),
                Submiter = p.User.UserName,
                Feedback = p.User.RecievedFeedbacks.Count == 0 ? 0.0 : p.User.RecievedFeedbacks.Sum(f => f.Score) / p.User.RecievedFeedbacks.Count(),
                City = p.User.City.Name,
                Category = p.Category.Name,
                CreateDate = p.CreateDate,
                Comments = p.Comments.Count
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
                .Select(p=> new DetailedProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Condition = (p.Condition).ToString(),
                    Quantity = p.Quantity,
                    Description = p.Description,
                    Submiter = p.User.UserName,
                    Feedback = p.User.RecievedFeedbacks.Count == 0 ? 0.0 : p.User.RecievedFeedbacks.Sum(f => f.Score) / p.User.RecievedFeedbacks.Count(),
                    City = p.User.City.Name,
                    Category = p.Category.Name,
                    Pictures = p.Pictures.Select(pi => new PictureViewModel 
                    {
                        Id = pi.Id,
                        Image = pi.Image
                    }),
                    Videos = p.Videos.Select(v => new VideoViewModel
                    {
                        Id = v.Id,
                        UrlAddress = v.UrlAddress,
                        VideoType = (v.VideoType).ToString()
                    }),
                    Comments = p.Comments.Select(c => new CommentViewModel
                    {
                        Id = c.Id,
                        Content = c.Content,
                        CreateDate = c.CreateDate,
                        Username = c.User.UserName
                    }),
                    CreateDate = p.CreateDate
                   })
                .FirstOrDefault(p => p.Id == id);
           
            if(product == null)
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

            ICollection<Video> videos = new HashSet<Video>();
            foreach (var video in model.videos)
            {
                videos.Add(new Video
                {
                    UrlAddress = video.UrlAddress,
                    VideoType = (VideoType) video.VideoType
                });
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Condition = (ConditionType) model.Condition,
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

            var category = this.Data.Categories.FirstOrDefault(c => c.Id == model.CategoryId);

            if (category == null)
            {
                return this.BadRequest("Category is not valid!");
            }

            var product = this.Data.Products.FirstOrDefault(p => p.Id == model.Id);

            if(product == null)
            {
                return this.BadRequest("This product does not exist!");
            }

            if(product.UserId != userId)
            {
                return this.Unauthorized();
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.CategoryId = model.CategoryId;
            product.Condition = (ConditionType) model.Condition;

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