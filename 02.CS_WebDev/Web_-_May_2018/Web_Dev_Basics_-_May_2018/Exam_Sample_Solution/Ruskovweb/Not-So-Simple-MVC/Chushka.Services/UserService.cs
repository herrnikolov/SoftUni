namespace Chushka.Services
{
    using System;
    using System.Linq;

    using Chushka.Data;
    using Chushka.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService
    {
        public User Create(string username, string password, string email, string fullName)
        {
            if(string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }

            try
            {
                using (var context = new ChushkaDbContext())
                {
                    User user = new User()
                    {
                        Username = username,
                        Password = password,
                        Email = email,
                        FullName = fullName,
                        Role = context.Users.Any() ? context.Roles.Find(1) : context.Roles.Find(2)
                    };

                    context.Add(user);
                    context.SaveChanges();
                    return user;
                }
            }
            catch
            {
                return null;
            }            
        }

        public User Find(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            using (var context = new ChushkaDbContext())
            {
                var user = context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => 
                        string.Equals(u.Username, username, StringComparison.CurrentCulture) && 
                        string.Equals(u.Password, password, StringComparison.CurrentCulture));

                return user;
            }
        }

        public bool Contains(string username)
        {
            using (var context = new ChushkaDbContext())
            {
                return context.Users
                    .Any(u => string.Equals(u.Username, username, StringComparison.CurrentCulture));
            }
        }
    }
}
