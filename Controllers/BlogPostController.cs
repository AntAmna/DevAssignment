using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DevAssignment.Data;
using DevAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevAssignment.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPost _repository;
        public BlogPostController(IBlogPost repository)
        {
            _repository = repository;
        }

        //GET /api/posts
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetBlogPosts()
        {
            IEnumerable<BlogPost> blogPosts = _repository.GetBlogPosts();

            BlogPostResponse blogPostResponse = new BlogPostResponse
            {
                BlogPosts = blogPosts,
                CountBP = blogPosts.Count()
            };
            return Ok(blogPostResponse);
        }

        //GET /api/posts/:slug
        [HttpGet("{slug}")]
        public ActionResult<BlogPost> GetBlogPostBySlug(string slug)
        {
            var blogPost = _repository.GetBlogPostBySlug(slug);
            return Ok(blogPost);
        }

        //DELETE /api/posts/:slug

        //POST /api/posts
        [HttpPost]
        public ActionResult CreateBlogPost(BlogPost bp)
        {
            try
            {
                string slug = bp.Title.ToLower();
                slug = Regex.Replace(slug, @"[^a-z0-9\s]", "-");
                slug = Regex.Replace(slug, @"\s+", " ").Trim();
                slug = Regex.Replace(slug, @"\s", "-");
                BlogPost existingBlogPost = _repository.GetBlogPostBySlug(slug);
                DateTime date = DateTime.Now;

                if (existingBlogPost != null)
                {
                    return BadRequest();
                }
                bp.Slug = slug;
                bp.CreatedAt = date;
                bp.UpdatedAt = date;
                _repository.CreateBlogPost(bp);
                return Ok(bp);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }    
        }
    }
}
