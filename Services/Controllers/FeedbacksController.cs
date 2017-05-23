using Microsoft.AspNet.Identity;
using Data.Models;
using Services.Models.BindingModels;
using System;
using System.Linq;
using System.Web.Http;
using Services.Models.ViewModels;

namespace Services.Controllers
{
    public class FeedbacksController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetFeedbacks(string id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = this.Data.Users.FirstOrDefault(u => u.UserName == id);

            if(user == null)
            {
                return this.BadRequest(String.Format("User with the username \"{0}\" was not found!", id));
            }

            var feedbacks = user.RecievedFeedbacks.Select(f => new FeedbackViewModel
            {
                Username = f.Sender.UserName,
                Score = f.Score,
                Comment = f.Comment,
                CreateDate = f.CreateDate
            });

            return Ok(feedbacks);
        }

        [HttpPost]
        public IHttpActionResult PostFeedback(AddFeedbackBindingModel model)
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

            var addressee = this.Data.Users.FirstOrDefault(u => u.UserName == model.AddresseeUsername);

            if (addressee == null)
            {
                return this.BadRequest("User was not valid!");
            }

            if (addressee.Id == userId)
            {
                return this.BadRequest("You cannot give feedback to yourself!");
            }

            var feedback = this.Data.Feedbacks.FirstOrDefault(f => f.AddresseeId == addressee.Id && f.SenderId == userId);

            if (feedback == null)
            {
                feedback = new Feedback
                {
                    Comment = model.Comment,
                    Score = model.Score,
                    AddresseeId = addressee.Id,
                    SenderId = userId,
                    CreateDate = DateTime.Now
                };

                this.Data.Feedbacks.Add(feedback);
            }
            else
            {
                feedback.Comment = model.Comment;
                feedback.Score = model.Score;
                feedback.CreateDate = DateTime.Now;
            }

            this.Data.SaveChanges();

            return Ok("Feedback was successfully added!");
        }

        [HttpDelete]
        public IHttpActionResult DeleteFeedback(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var feedback = this.Data.Feedbacks.FirstOrDefault(c => c.Id == id);

            if (feedback == null)
            {
                return this.BadRequest("Feedback is not valid!");
            }

            if (feedback.SenderId != userId)
            {
                return this.BadRequest("The feedback you are trying to delete is not yours!");
            }

            this.Data.Feedbacks.Remove(feedback);

            return Ok("Feedback was successfully removed!");
        }
    }
}