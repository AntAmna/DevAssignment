using DevAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace DevAssignment.Data
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> opt) : base(opt)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }

}
