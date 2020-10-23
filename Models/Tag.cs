using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevAssignment.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; } 

        public virtual ICollection<BlogPostTag> BlogPostTags { get; set; }
    }
}
