using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //var blogPosts = _repository.GetBlogPosts();
            //Console.WriteLine(blogPosts.)

            IEnumerable<BlogPost> blogPosts = _repository.GetBlogPosts();

            BlogPostResponse blogPostResponse = new BlogPostResponse();
            blogPostResponse.BlogPosts = blogPosts;
            blogPostResponse.CountBP = blogPosts.Count();
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
        /*[HttpPost]
         public async ActionResult<BlogPost> PostBlogPost(BlogPost blogPost)
         {
             _context.TodoItems.Add(blogPost);
             await _context.SaveChangesAsync();

             //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
             //return CreatedAtAction(nameof(GetBlogPostBySlug), new { slug = blogPost. }, blogPost);
         }*/
    }
}
