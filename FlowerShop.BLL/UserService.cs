using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;

namespace FlowerShop.BLL
{
    public class UserService
    {
        private static UserRepo _userRepo = new();

        public User? login(string username, string password)
        {
            return _userRepo.GetUserByUsernameAndPassword(username, password);
        }

        public bool register(User user)
        {
            return _userRepo.CreateUser(user);
        }
        public User GetUser(int userId) => _userRepo.GetUserById(userId);
        public List<User> GetAllUsers() => _userRepo.GetAllUsers();
        public void add(User user) => _userRepo.AddUser(user);
        public bool update(User user) => _userRepo.UpdateUser(user);
        public bool delete(int userId) => _userRepo.DeleteUser(userId);
    }
}
