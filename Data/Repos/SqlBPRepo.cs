using DevAssignment.Models;
using Microsoft.AspNetCore.Mvc;
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
            return _context.BlogPosts.FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.ToList().OrderByDescending(b => b.CreatedAt);
        }
    }
}
