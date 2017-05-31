using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using Services.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class CommentsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetCommentByProductId(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var comments = this.Data.Comments
                .Where(c => c.ProductId == id).Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreateDate = c.CreateDate,
                    Username = c.User.UserName
                }).OrderByDescending(c => c.CreateDate);

            if (comments == null)
            {
                return this.BadRequest("The product you are trying to retrive the comments from does not exist!");
            }

            return Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult PostComment(AddCommentBindingModel model)
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

            var comment = new Comment
            {
                Content = model.Content,
                ProductId = model.ProductId,
                UserId = userId,
                CreateDate = DateTime.Now
            };

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            return Ok("Comment was successfully added!");
        }

        [HttpPatch]
        public IHttpActionResult PatchComment(PatchCommentBindingModel model)
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

            var comment = this.Data.Comments.FirstOrDefault(c => c.Id == model.CommentId);

            if (comment == null)
            {
                return this.BadRequest("Comment is not valid!");
            }

            if (comment.UserId != userId)
            {
                return this.BadRequest("The comment you are trying to modify is not yours!");
            }

            comment.Content = model.Content;
            comment.CreateDate = DateTime.Now;

            this.Data.SaveChanges();

            return Ok("Comment was successfully modified!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var comment = this.Data.Comments.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return this.BadRequest("Comment is not valid!");
            }

            if (comment.UserId != userId)
            {
                return this.BadRequest("The comment you are trying to delete is not yours!");
            }

            this.Data.Comments.Remove(comment);

            return Ok("Comment was successfully removed!");
        }
    }
}