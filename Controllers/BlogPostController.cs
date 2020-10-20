
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<BlogPost>> GetAllBlogPosts()
        {
            var blogPosts = _repository.GetBlogPosts();
            return Ok(blogPosts);
        }

        //GET /api/posts/:slug
        [HttpGet("{slug}")]
        public ActionResult<BlogPost> GetBlogPost(string slug)
        {
            var blogPost = _repository.GetBlogPostBySlug(slug);
            return Ok(blogPost);
        }
    }
}
