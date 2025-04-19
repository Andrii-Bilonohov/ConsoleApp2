using ConsoleApp1.DAL.Data;
using ConsoleApp1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DAL.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;


        public UserRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void AddUsers(List<User> users)
        {
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


        public void DeleteAllUsers()
        {
            var users = GetAllUsers();
            _context.Users.RemoveRange(users);
            _context.SaveChanges();
        }
    }
}
