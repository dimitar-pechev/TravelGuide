using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelGuide.Models.Articles;
using TravelGuide.Models.Requests;

namespace TravelGuide.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            this.IsDeleted = false;
            this.RegisteredOn = DateTime.Now;
            this.Requests = new HashSet<Request>();
            this.Articles = new HashSet<Article>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Id", this.Id));
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
