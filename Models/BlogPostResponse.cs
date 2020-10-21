using System.Collections.Generic;

namespace DevAssignment.Models
{
    public class BlogPostResponse
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public int CountBP { get; set; }
    }
}
