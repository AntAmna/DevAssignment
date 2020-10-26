using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevAssignment.Models
{
    public class BPTResponse
    {
        public int BlogPostId { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
