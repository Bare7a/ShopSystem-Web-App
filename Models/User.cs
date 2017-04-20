namespace Models

{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<Message> sentMessages;
        private ICollection<Message> recievedMessages;
        private ICollection<Comment> comments;
        private ICollection<Feedback> sentFeedbacks;
        private ICollection<Feedback> recievedFeedbacks;

        public User()
        {
            this.sentMessages = new HashSet<Message>();
            this.recievedMessages = new HashSet<Message>();
            this.comments = new HashSet<Comment>();
            this.sentFeedbacks = new HashSet<Feedback>();
            this.recievedFeedbacks = new HashSet<Feedback>();
        }

        public byte[] ProfilePicture { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Facebook { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Skype { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        public DateTime RegisterDate { get; set; }

        public ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public ICollection<Message> RecievedMessages
        {
            get { return this.recievedMessages; }
            set { this.recievedMessages = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Feedback> SentFeedbacks
        {
            get { return this.sentFeedbacks; }
            set { this.sentFeedbacks = value; }
        }

        public virtual ICollection<Feedback> RecievedFeedbacks
        {
            get { return this.recievedFeedbacks; }
            set { this.recievedFeedbacks = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}