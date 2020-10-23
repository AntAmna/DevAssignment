using DevAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevAssignment.Data
{
    public class SqlBPRepo : IBlogPost
    {
        private readonly BlogPostContext _context;
       
        public SqlBPRepo(BlogPostContext context)
        {
            _context = context;
        }
        public BlogPost GetBlogPostBySlug(string slug)
        {
            return _context.BlogPosts.Include(blogPost => blogPost.BlogPostTags).FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Include(blogPost => blogPost.BlogPostTags).ThenInclude(blogPostTags => blogPostTags.Tag).ToList();
        }

        public void CreateBlogPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            _context.Update(blogPost);
            _context.SaveChanges();
        }
        public void DeleteBlogPost(BlogPost blogPost)
        {
            _context.Remove(blogPost);
            _context.SaveChanges();
        }
    }
}
