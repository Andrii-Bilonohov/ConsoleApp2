using ConsoleApp1.DAL.Entities;
using ConsoleApp1.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class UserAndOrderService
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;


        public UserAndOrderService()
        {
            _userService = new UserService();
            _orderService = new OrderService();
        }


        public IEnumerable<User> GetAllUsersWithOrders()
        {
            var users = _userService.GetAllUsers();
            var orders = _orderService.GetAllOrders();

            foreach (var user in users)
            {
                user.Orders = orders.Where(o => o.UserId == user.Id).ToList();
            }
            return users;
        }


        public User? GetUserByIdAndOrders(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            }

            var user = _userService.GetUserById(id);

            if (user != null)
            {
                user.Orders = _orderService.GetOrdersByUserId(id);
            }

            return user;
        }


        public User? GetUserByNameAndOrders(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }

            var user = _userService.GetUserByName(name);
            if (user != null)
            {
                user.Orders = _orderService.GetOrdersByUserId(user.Id);
            }

            return user;
        }
    }
}
