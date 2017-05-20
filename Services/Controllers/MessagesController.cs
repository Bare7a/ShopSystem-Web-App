using Microsoft.AspNet.Identity;
using Models;
using Services.Models.BindingModels;
using Services.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    [Authorize]
    public class MessagesController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetMessages([FromUri]GetMessagesBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var messages = this.Data.Messages.AsQueryable();

            switch(model.Type)
            {
                case "Recieved": messages = messages.Where(m => m.AddresseeId == userId); break;
                case "Sent": messages = messages.Where(m => m.SenderId == userId); break;
                default: messages = messages.Where(m => m.AddresseeId == userId || m.SenderId == userId); break;
            }

            int pageSize = 10;
            if (model.PageSize.HasValue)
            {
                pageSize = model.PageSize.Value;
            }

            int messagesCount = messages.Count();
            int numPages = (messagesCount + pageSize - 1) / pageSize;

            if (model.StartPage.HasValue)
            {
                messages = messages.OrderByDescending(m => m.CreateDate).Skip(pageSize * (model.StartPage.Value - 1));
            }
            messages = messages.Take(pageSize);

            var messagesToReturn = messages.Select(p => new MessagesViewModel
            {
                Id = p.Id,
                Title = p.Title,
                CreateDate = p.CreateDate,
                IsSeen = p.IsSeen,
                AddresseeUsername = p.Addressee.UserName,
                SenderUsername = p.Sender.UserName
            });

            return Ok(new
                {
                    messagesCount,
                    numPages,
                    messages = messagesToReturn
                }
            );
        }

        [HttpGet]
        public IHttpActionResult GetMessageById(int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var message = this.Data.Messages.FirstOrDefault(m => m.Id == id && (m.AddresseeId == userId || m.Sender.Id == userId));

            if (message == null)
            {
                return this.NotFound();
            }

            if (message.AddresseeId == userId && !message.IsSeen)
            {
                message.IsSeen = true;
                this.Data.SaveChanges();
            }

            var returnMessage = new MessageDetailedViewModel
            {
                Title = message.Title,
                CreateDate = message.CreateDate,
                SenderUsername = message.Sender.UserName,
                AddresseeUsername = message.Addressee.UserName,
                Content = message.Content
            };

            return this.Ok(returnMessage); 
        }

        [HttpPost]
        public IHttpActionResult PostMessage(AddMessageBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            var user = this.Data.Users.FirstOrDefault(u => u.UserName == model.AdreseeUsername);

            if(user == null)
            {
                return this.BadRequest("The user you are trying to send message to doesn't exist!");
            }

            var message = new Message
            {
                Title = model.Title,
                Content = model.Content,
                CreateDate = DateTime.Now,
                IsSeen = false,
                AddresseeId = user.Id,
                SenderId = userId
            };

            this.Data.Messages.Add(message);
            this.Data.SaveChanges();

            return Ok("Message was sent successfully to " + user.UserName);
        }
    }
}