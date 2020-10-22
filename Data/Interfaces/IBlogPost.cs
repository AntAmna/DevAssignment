using DevAssignment.Models;
using System;
using System.Collections.Generic;

namespace DevAssignment.Data
{
    public interface IBlogPost
    {
        IEnumerable<BlogPost> GetBlogPosts();
        BlogPost GetBlogPostBySlug(string slug);
        void CreateBlogPost(BlogPost blogPost);
        void UpdateBlogPost(BlogPost blogPost);
        void DeleteBlogPost(BlogPost blogPost);
    }
}
