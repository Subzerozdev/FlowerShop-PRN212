using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;

namespace FlowerShop.DAL.Repos
{
    public class UserRepo
    {
        private static ExContext _context;
        public UserRepo()
        {
            _context = new ExContext();
        }
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
        }
        public bool CreateUser(User user)
        {
            bool result = false;
            User? userExisted = _context.Users.FirstOrDefault(u => u.Username.Equals(user.Username)||u.Phone.Equals(user.Phone));
            if (userExisted == null)
            {
                user.IsActive = true;
                user.CreatedAt = DateTime.Now;
                user.RoleId = 1;
                _context.Users.Add(user);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
