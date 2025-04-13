using ConsoleApp1.DAL.Data;
using ConsoleApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL.Repositories
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;


        public OrderRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }


        public Order? GetOrderByProductName(string productName)
        {
            return _context.Orders.FirstOrDefault(o => o.ProductName == productName);
        }


        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }


        public void AddOrders(List<Order> orders)
        {
            _context.Orders.AddRange(orders);
            _context.SaveChanges();
        }


        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }


        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }


        public void DeleteAllOrders(List<Order> orders)
        {
            _context.Orders.RemoveRange(orders);
            _context.SaveChanges();
        }
    }
}
