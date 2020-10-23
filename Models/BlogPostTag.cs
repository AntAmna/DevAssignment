namespace DevAssignment.Models
{
    public class BlogPostTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}
