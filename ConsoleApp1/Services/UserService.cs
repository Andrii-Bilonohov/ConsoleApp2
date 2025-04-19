using ConsoleApp1.DAL.Entities;
using ConsoleApp1.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;


        public UserService()
        {
            _userRepository = new UserRepository();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<User> GetAllUsersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }
            return _userRepository
                .GetAllUsers()
                .Where(u => u.Name == name)
                .ToList();
        }


        public User? GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            }
            return _userRepository
                .GetAllUsers()
                .FirstOrDefault(u => u.Id == id);
        }


        public User? GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }
            return _userRepository
                .GetAllUsers()
                .FirstOrDefault(u => u.Name == name);
        }


        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            _userRepository.AddUser(user);
        }


        public void AddUsers(List<User> users)
        {
            if (users == null || users.Count == 0)
            {
                throw new ArgumentNullException(nameof(users), "Users cannot be null or empty");
            }

            _userRepository.AddUsers(users);
        }


        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            _userRepository.UpdateUser(user);
        }


        public void UpdateName(int id, string name)
        {
            var user = _userRepository.GetAllUsers()
                                      .FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            user.Name = name;
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _userRepository.DeleteUser(user);
        }


        public void DeleteUserById(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _userRepository.DeleteUser(user);
        }


        public void DeleteUserByName(string name)
        {
            var user = GetUserByName(name);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _userRepository.DeleteUser(user);
        }


        public void DeleteAllUsers()
        {
            var users = GetAllUsers();
            if (users == null || !users.Any())
            {
                throw new ArgumentNullException(nameof(users), "Users cannot be null or empty");
            }
            _userRepository.DeleteUser(users.First());
        }
    }
}
