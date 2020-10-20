using DevAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevAssignment.Data
{
    public class SqlDARepo : IBlogPost
    {
        private readonly BlogPostContext _context;
        public SqlDARepo(BlogPostContext context)
        {
            _context = context;
        }
        public BlogPost GetBlogPostBySlug(string slug)
        {
            return _context.BlogPosts.FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.ToList();
        }
    }
}
