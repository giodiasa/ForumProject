using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedRoles();
            builder.SeedUsers();
            builder.SeedUserRoles();
            builder.SeedTopics();
            builder.SeedComments();

            builder.Entity<Topic>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Topic)
                .HasForeignKey(c => c.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.IdentityUser)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
