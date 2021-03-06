﻿using System;
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
        public ActionResult<IEnumerable<BlogPost>> GetBlogPosts(string tagName)
        {
            IEnumerable<BlogPost> blogPosts;
            if (tagName != null && tagName != "")
            {
                blogPosts = _repository.GetBlogPosts(tagName);
                return Ok(blogPosts);
            }
            blogPosts = _repository.GetBlogPosts();
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
        [HttpDelete("{slug}")]
       public ActionResult DeleteBlogPost(string slug)
       {
            BlogPost blogPost = _repository.GetBlogPostBySlug(slug);
            if (blogPost != null)
            {
                _repository.DeleteBlogPost(blogPost);
                return Ok(blogPost);
            }
            return NotFound();
       }

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

        //PUT /api/posts/:slug
        [HttpPut("{slug}")]
        public ActionResult UpdateBlogPost(string slug, BlogPost blogPost)
        {
            try
            {
                BlogPost blogPostToUpdate = _repository.GetBlogPostBySlug(slug);
                if (blogPostToUpdate == null)
                {
                    return BadRequest("Blog Post does not exist!");
                }

                if (blogPost.Title != null)
                {
                    slug = blogPost.Title.ToLower();
                    slug = Regex.Replace(slug, @"[^a-z0-9\s]", "-");
                    slug = Regex.Replace(slug, @"\s+", " ").Trim();
                    slug = Regex.Replace(slug, @"\s", "-");
                    BlogPost blogPostCheck = _repository.GetBlogPostBySlug(slug);
                    if (blogPostCheck != null)
                    {
                        return BadRequest("Blog post with this title already exists! Please change the name of the title");
                    }
                    blogPostToUpdate.Slug = slug;
                    blogPostToUpdate.Title = blogPost.Title;
                }
                if (blogPost.Description != null)
                {
                    blogPostToUpdate.Description = blogPost.Description;
                }
                if (blogPost.Body != null)
                {
                    blogPostToUpdate.Body = blogPost.Body;
                }
                DateTime updatedDate = DateTime.Now;
                blogPostToUpdate.UpdatedAt = updatedDate;
                _repository.UpdateBlogPost(blogPostToUpdate);
                return Ok(blogPostToUpdate);
            }
            catch(Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }

            
        }
    }
}
