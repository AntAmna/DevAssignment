using DevAssignment.Models;
using System.Collections.Generic;

namespace DevAssignment.Data
{
    public interface IBlogPost
    {
        IEnumerable<BlogPost> GetBlogPosts();
        BlogPost GetBlogPostBySlug(string slug);
    }
}
