using System;
using System.Collections.Generic;
using TravelGuide.Models;

namespace TravelGuide.Services.Users.Contracts
{
    public interface IUserService
    {
        User GetById(string id);

        User GetByUsername(string username);

        IEnumerable<User> GetAllUsers();

        void UpdateUserInfo(string id, string firstName, string lastName, string phone, string address);

        void DeleteUser(string userId);

        void ActivateAccount(string userId);
    }
}
