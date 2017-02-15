using System;
using System.Collections.Generic;

namespace TravelGuide.Models
{
    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
            this.Comments = new HashSet<Comment>();
            this.Likes = new List<string>();
        }

        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }
        
        public virtual ICollection<string> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
