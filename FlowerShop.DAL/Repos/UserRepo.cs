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
        private EventflowerexchangeContext? _context;
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
        }
        public void AddUser(User user)
        {
            _context=new();
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public bool CreateUser(User user)
        {
            _context=new();
            bool result = false;
            User? userExisted = _context.Users.FirstOrDefault(u => u.Username.Equals(user.Username) || u.Phone.Equals(user.Phone));
            if (userExisted == null)
            {
                user.IsActive = true;
                user.CreateAt = DateTime.Now;
                user.RoleId = 1;
                _context.Users.Add(user);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public List<User> GetAllUsers()
        {
            _context = new();
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }
        public bool UpdateUser(User user)
        {
            _context = new();
            bool result = false;
            User? userExisted = _context.Users.FirstOrDefault(u => u.Id.Equals(user.Id));
            if (userExisted != null)
            {
                _context = new();
                DateTime dateTime = (DateTime)userExisted.CreateAt;
                _context.Users.Update(user);
                user.CreateAt = dateTime;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteUser(int userId)
        {
            _context = new();
            bool result = false;
            User? userExisted = _context.Users.FirstOrDefault(u => u.Id.Equals(userId));
            if (userExisted != null)
            {
                _context = new();
                _context.Users.Remove(userExisted);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
