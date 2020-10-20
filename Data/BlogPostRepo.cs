using DevAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevAssignment.Data
{
    public class BlogPostRepo : IBlogPost
    {
        public BlogPost GetBlogPostBySlug(string slug)
        {
            var posts = new List<BlogPost>
            {
                new BlogPost
                {
                    Slug = "augmented-reality-ios-application",
                    Title = "Augmented Reality iOS Applicaton",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    TagList = new string[] {"iOS", "AR"},
                    CreatedAt = new DateTime(2018, 05, 18, 03, 22, 56),
                    UpdatedAt = new DateTime(2018, 05, 18, 03, 48, 35)
                },
                new BlogPost
                {
                    Slug = "augmented-reality-ios-application-2",
                    Title = "Augmented Reality iOS Applicaton 2",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    TagList = new string[] {"iOS", "AR"},
                    CreatedAt = new DateTime(2018, 05, 18, 03, 22, 56),
                    UpdatedAt = new DateTime(2018, 05, 18, 03, 48, 35)
                }
            };
            var post = new BlogPost();
            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Slug == slug)
                    post = posts[i];
            }
            return post;
           
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            var posts = new List<BlogPost>
            {
                new BlogPost
                {
                    Slug = "augmented-reality-ios-application",
                    Title = "Augmented Reality iOS Applicaton",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    TagList = new string[] {"iOS", "AR"},
                    CreatedAt = new DateTime(2018, 05, 18, 03, 22, 56),
                    UpdatedAt = new DateTime(2018, 05, 18, 03, 48, 35)
                },
                new BlogPost
                {
                    Slug = "augmented-reality-ios-application-2",
                    Title = "Augmented Reality iOS Applicaton 2",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    TagList = new string[] {"iOS", "AR"},
                    CreatedAt = new DateTime(2018, 05, 18, 03, 22, 56),
                    UpdatedAt = new DateTime(2018, 05, 18, 03, 48, 35)
                }
            };
            return posts;
        }


    }
}
