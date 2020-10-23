using DevAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DevAssignment.Data
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> opt) : base(opt)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTag> BlogPostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //blog post
            modelBuilder.Entity<BlogPost>()
                .HasKey(bp => bp.BlogPostId);

            //tag
            modelBuilder.Entity<Tag>()
                .HasKey(t => t.TagId);

            //blog post tag
            modelBuilder.Entity<BlogPostTag>()
                .HasKey(bc => new { bc.BlogPostId, bc.TagId });
            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bc => bc.BlogPost)
                .WithMany(b => b.BlogPostTags)
                .HasForeignKey(bc => bc.BlogPostId);
            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.BlogPostTags)
                .HasForeignKey(bc => bc.TagId);
        }

    }

}
