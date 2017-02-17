using System;
using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Models.Abstractions
{
    public abstract class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
