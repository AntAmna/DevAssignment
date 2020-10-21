using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevAssignment.Models
{
    public class BlogPost
    {
        [Key]
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; set; }
    }
}

