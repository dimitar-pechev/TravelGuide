using System;
using System.Collections.Generic;
using TravelGuide.Models;

namespace TravelGuide.Services.Users.Contracts
{
    public interface IUserService
    {
        User GetById(Guid id);

        User GetByUsername(string username);

        IEnumerable<User> GetAllUsers();
    }
}
