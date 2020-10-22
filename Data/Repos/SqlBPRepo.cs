using DevAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
