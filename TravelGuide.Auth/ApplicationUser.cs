//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace TravelGuide.Auth
//{
//    public class ApplicationUser : IdentityUser
//    {
//        public string FirstName { get; set; }

//        public string LastName { get; set; }

//        public DateTime RegisteredOn { get; set; }

//        public virtual ICollection<Guid> ArticlesAdded { get; set; }

//        public virtual ICollection<Guid> GalleryImagesAdded { get; set; }

//        public virtual ICollection<string> StoriesAdded { get; set; }

//        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }

//        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
//        {
//            return Task.FromResult(GenerateUserIdentity(manager));
//        }
//    }
//}
