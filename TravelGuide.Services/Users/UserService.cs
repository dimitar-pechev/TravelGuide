using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Services.Users
{
    public class UserService : IUserService
    {
        private ITravelGuideContext context;

        public UserService(ITravelGuideContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = this.context.Users.ToList();
            return users;
        }

        public User GetById(Guid id)
        {
            var user = this.context.Users.Find(id);
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = this.context.Users.FirstOrDefault(x => x.UserName == username);
            return user;
        }
    }
}
