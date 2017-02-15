using System;

namespace TravelGuide.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
