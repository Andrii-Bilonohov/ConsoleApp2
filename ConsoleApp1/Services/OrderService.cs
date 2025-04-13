using ConsoleApp1.DAL.Entities;
using ConsoleApp1.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class OrderService
    {
        private OrderRepository _orderRepository;


        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }


        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().ToList();
        }


        public Order? GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }


        public Order? GetOrderByProductName(string productName)
        {
            return _orderRepository.GetOrderByProductName(productName);
        }


        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null");
            }
            _orderRepository.AddOrder(order);
        }


        public void AddOrders(List<Order> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders), "Order object cannot be null");
            }
            _orderRepository.AddOrders(orders);
        }


        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null");
            }
            _orderRepository.UpdateOrder(order);
        }

        public void UpdateProductName(int id, string productName)
        {
            var order = _orderRepository.GetAllOrders()
                                      .FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null");
            }
            order.ProductName = productName;
            _orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null");
            }
            _orderRepository.DeleteOrder(order);
        }

        public void DeleteOrderById(int id)
        {
            var order = _orderRepository.GetAllOrders()
                                      .FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null");
            }
            _orderRepository.DeleteOrder(order);
        }

        public void DeleteOrders(List<Order> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders), "Order object cannot be null");
            }
            foreach (var order in orders)
            {
                _orderRepository.DeleteOrder(order);
            }
        }
    }
}
