﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravelGuide.Data;
using TravelGuide.Models;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Services.Users
{
    public class UserService : IUserService
    {
        protected ITravelGuideContext context;

        public UserService(ITravelGuideContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            this.context = context;
        }

        public void DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException();
            }

            var user = this.context.Users.Find(userId);

            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.IsDeleted = true;
            this.context.SaveChanges();
        }

        public void ActivateAccount(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException();
            }

            var user = this.context.Users.Find(userId);

            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.IsDeleted = false;
            this.context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = this.context.Users.ToList();
            return users;
        }

        public User GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var user = this.context.Users.Find(id);
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = this.context.Users.FirstOrDefault(x => x.UserName == username);
            return user;
        }

        public void UpdateUserInfo(string id, string firstName, string lastName, string phone, string address)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var user = this.context.Users.Find(id);

            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phone;
            user.Address = address;

            this.context.SaveChanges();
        }
    }
}
