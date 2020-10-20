using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DevAssignment.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; } 

        public ICollection<BlogPostTag> BlogPostTags { get; set; }
    }
}
