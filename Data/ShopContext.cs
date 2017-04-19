namespace Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ShopContext : IdentityDbContext<User>
    {
        public ShopContext()
            : base("ShopContext")
        {
        }

        public virtual DbSet<Category> Cateogries { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

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

            base.OnModelCreating(modelBuilder);
        }
    }

    
}