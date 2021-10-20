using System;
using System.Collections.Generic;
using Equipment.Models;

namespace Equipment.Repository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(int userId, User user);
        IEnumerable<User> GetUsersByConditions(string username);
        void Save();
    }
}
