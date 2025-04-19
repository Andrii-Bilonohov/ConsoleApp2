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
    }
}
