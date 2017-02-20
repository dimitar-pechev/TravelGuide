using System;
using TravelGuide.Models.Store;

namespace TravelGuide.Models.Requests
{
    public class Request
    {
        public Request()
        {
            this.Id = Guid.NewGuid();
            this.Status = "Awaiting confirmation";
            this.CreatedOn = DateTime.Now;
        }

        public Request(Guid itemId, StoreItem item, Guid userId, User user)
            : this()
        {
            this.StoreItemId = itemId;
            this.StoreItem = item;
            this.UserId = userId;
            this.User = user;
        }

        public Guid Id { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid StoreItemId { get; set; }

        public virtual StoreItem StoreItem { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
