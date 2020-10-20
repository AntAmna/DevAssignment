using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevAssignment.Models
{
    public class BlogPostTag
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BlogPost")]
        public string BlogPostSlug { get; set; }
        public BlogPost BlogPost { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
