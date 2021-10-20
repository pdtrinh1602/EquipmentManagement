using System;
using System.Collections.Generic;
using System.Linq;
using Equipment.Models;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        public EquipmentDBContext context;

        public UserRepository(EquipmentDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public IEnumerable<User> GetUsersByConditions(string username)
        {
            return context.Users.Where(user => user.UserName.Contains(username)).ToList();
        }

        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            User student = context.Users.Find(userId);
            context.Users.Remove(student);
        }

        public void UpdateUser(int userId, User user)
        {
            User targetUser = context.Users.Find(userId);
            targetUser.UserName = user.UserName;
            targetUser.IsAdmin = user.IsAdmin;
            context.Users.Update(targetUser);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
