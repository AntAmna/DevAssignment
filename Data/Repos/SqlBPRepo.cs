using DevAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<BlogPost> GetBlogPosts(string tagFilter = "")
        {
            //return _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Include(blogPost => {
            //blogPost.BlogPostTags.Select(tag => tag.Tag.TagName)).ToList();

            if (tagFilter != "" && tagFilter != null)
            {
                return _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Include(b => b.BlogPostTags).ThenInclude(tag => tag.Tag).Where(bp => bp.BlogPostTags.Any(t => t.Tag.TagName == tagFilter)).ToList();
            }
            return _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Include(blogPost => blogPost.BlogPostTags).ThenInclude(blogPostTags => blogPostTags.Tag).ToList();
            //var blogPosts = _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Select(bpt => new BPTResponse
            //{
            //    BlogPostId = bpt.BlogPostId,
            //    Slug = bpt.Slug,
            //    Title = bpt.Title,
            //    Description = bpt.Description,
            //    Body = bpt.Body,
            //    CreatedAt = bpt.CreatedAt,
            //    UpdatedAt = bpt.UpdatedAt,
            //    Tags = bpt.BlogPostTags.Select(t => t.Tag).ToList()
            //}).ToList();
            //return (IEnumerable<BlogPost>) blogPosts;
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
