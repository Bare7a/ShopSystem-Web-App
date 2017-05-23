namespace Data
{
    using Data.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ShopContext : IdentityDbContext<User>
    {
        public ShopContext()
            : base("ShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Feedback> Feedbacks { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Addressee)
                .WithMany(t => t.RecievedMessages)
                .HasForeignKey(m => m.AddresseeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.SentFeedbacks)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(m => m.Addressee)
                .WithMany(t => t.RecievedFeedbacks)
                .HasForeignKey(m => m.AddresseeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}