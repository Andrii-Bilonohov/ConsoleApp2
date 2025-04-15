using ConsoleApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class MenuUserOrderService
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;


        public MenuUserOrderService()
        {
            _userService = new UserService();
            _orderService = new OrderService();
        }

        public void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View customer list");
            Console.WriteLine("2. Add new customer");
            Console.WriteLine("3. Edit customer information");
            Console.WriteLine("4. Delete customer");
            Console.WriteLine("5. View product list");
            Console.WriteLine("6. Add new product");
            Console.WriteLine("7. Edit product information");
            Console.WriteLine("8. Delete product");
            Console.WriteLine("9. View all customers with orders");
            Console.WriteLine("10. Exit");

            var option = GetValidString("Please enter your choice: ");

            switch (option)
            {
                case "1":
                    ViewCustomerList();
                    Console.WriteLine();
                    break;
                case "2":
                    AddCustomer();
                    Console.WriteLine();
                    break;
                case "3":
                    EditCustomerInformation();
                    Console.WriteLine();
                    break;
                case "4":
                    DeleteCustomer();
                    Console.WriteLine();
                    break;
                case "5":
                    ViewProductList();
                    Console.WriteLine();
                    break;
                case "6":
                    AddNewProduct();
                    Console.WriteLine();
                    break;
                case "7":
                    EditProductInformation();
                    Console.WriteLine();
                    break;
                case "8":
                    DeleteProduct();
                    Console.WriteLine();
                    break;
                case "9":
                    ViewCustomerWithOrders();
                    Console.WriteLine();
                    break;
                case "10":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }


        private void ViewCustomerWithOrders()
        {
            Console.Clear();

            var users = _userService.GetAllUsersWithOrders();
            
            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, \nName: {user.Name}");
                foreach (var order in user.Orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product Name: {order.ProductName}");
                }
                Console.WriteLine();
            }
        }


        private void ViewCustomerList()
        {
            Console.Clear();

            var users = _userService.GetAllUsers();

            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, \nName: {user.Name}");
                Console.WriteLine();
            }
        }


        private void AddCustomer()
        {
            Console.Clear();

            var name = GetValidString("Enter customer name: ");

            var user = new User { Name = name };
            _userService.AddUser(user);

            Console.Clear();
            Console.WriteLine("Customer added successfully.");
        }


        private void EditCustomerInformation()
        {
            Console.Clear();

            Console.WriteLine("Choose an option to edit customer information:");
            Console.WriteLine("1. Edit by ID");
            Console.WriteLine("2. Edit by Name");
            var choice = GetValidInt("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    EditCustomerById();
                    break;
                case 2:
                    EditCustomerByName();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void EditCustomerById()
        {
            Console.Clear();

            var id = GetValidInt("Enter customer ID to edit: ");

            var user = _userService.GetUserById(id);
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var name = GetValidString("Enter new customer name: ");
            user.Name = name;

            _userService.UpdateUser(user);

            Console.Clear();
            Console.WriteLine("Customer information updated successfully.");
        }


        private void EditCustomerByName()
        {
            Console.Clear();

            var name = GetValidString("Enter customer name to edit: ");
            var user = _userService.GetUserByName(name);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var newName = GetValidString("Enter new customer name: ");
            user.Name = newName;

            _userService.UpdateUser(user);

            Console.Clear();
            Console.WriteLine("Customer information updated successfully.");
        }


        private void DeleteCustomer()
        {
            Console.Clear();

            Console.WriteLine("Choose an option to delete customer:");
            Console.WriteLine("1. Delete by ID");
            Console.WriteLine("2. Delete by Name");

            var choice = GetValidInt("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    DeleteCustomerById();
                    break;
                case 2:
                    DeleteCustomerByName();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void DeleteCustomerById()
        {
            Console.Clear();

            var id = GetValidInt("Enter customer ID to delete: ");
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            _userService.DeleteUser(user);
            
            Console.Clear();
            Console.WriteLine("Customer deleted successfully.");
        }


        private void DeleteCustomerByName()
        {
            Console.Clear();

            var name = GetValidString("Enter customer name to delete: ");
            var user = _userService.GetUserByName(name);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            _userService.DeleteUser(user);

            Console.Clear();
            Console.WriteLine("Customer deleted successfully.");
        }
        

        private void ViewProductList()
        {
            Console.Clear();

            var orders = _orderService.GetAllOrders();

            Console.Clear();
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, \nProduct Name: {order.ProductName}");
                Console.WriteLine();
            }
        }


        private void AddNewProduct()
        {
            Console.Clear();

            Console.WriteLine("What kind of buyer is buying?");

            Console.WriteLine("Enter your ID or name");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Name");

            var choice = GetValidString("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    AddProductToCustomerById();
                    break;
                case "2":
                    AddProductToCustomerByName();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }
        }


        private void AddProductToCustomerById()
        {
            Console.Clear();

            var customerId = GetValidInt("Enter customer Id: ");
            var user = _userService.GetUserById(customerId);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var productName = GetValidString("Enter product name: ");
            var product = _orderService.GetOrderByProductName(productName);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var order = new Order
            {
                UserId = customerId,
                ProductName = productName,
                CreatedDate = DateTime.Now
            };

            _orderService.AddOrder(order);

            Console.Clear();
            Console.WriteLine("Product successfully added to customer.");
        }


        private void AddProductToCustomerByName()
        {
            Console.Clear();

            var customerName = GetValidString("Enter customer name: ");
            var user = _userService.GetUserByName(customerName);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var productName = GetValidString("Enter product name: ");
            var product = _orderService.GetOrderByProductName(productName);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var order = new Order
            {
                UserId = user.Id,
                ProductName = productName,
                CreatedDate = DateTime.Now
            };

            _orderService.AddOrder(order);

            Console.Clear();
            Console.WriteLine("Product successfully added to customer.");
        }


        private void EditProductInformation()
        {
            Console.Clear();

            Console.WriteLine("Choose an option to edit product information:");
            Console.WriteLine("1. Edit by ID");
            Console.WriteLine("2. Edit by Name");

            var choice = GetValidInt("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    EditProductById();
                    break;
                case 2:
                    EditProductByName();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        private void EditProductById()
        {
            Console.Clear();

            var id = GetValidInt("Enter product ID to edit: ");
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var productName = GetValidString("Enter new product name: ");
            order.ProductName = productName;

            _orderService.UpdateOrder(order);

            Console.Clear();
            Console.WriteLine("Product information updated successfully.");
        }


        private void EditProductByName()
        {
            Console.Clear();

            var productName = GetValidString("Enter product name to edit: ");
            var order = _orderService.GetOrderByProductName(productName);

            if (order == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var newProductName = GetValidString("Enter new product name: ");
            order.ProductName = newProductName;

            _orderService.UpdateOrder(order);

            Console.Clear();
            Console.WriteLine("Product information updated successfully.");
        }


        private void DeleteProduct()
        {
            Console.Clear();

            Console.WriteLine("Choice an option to delete product: ");
            Console.WriteLine("1. Delete by ID");
            Console.WriteLine("2. Delete by Name");

            var choice = GetValidInt("Enter your choice: ");
            switch (choice)
            {
                case 1:
                    DeleteProductById();
                    break;
                case 2:
                    DeleteProductByName();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        private void DeleteProductById()
        {
            Console.Clear();

            var id = GetValidInt("Enter product ID to delete: ");
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            _orderService.DeleteOrder(order);

            Console.Clear();
            Console.WriteLine("Product deleted successfully.");
        }


        private void DeleteProductByName()
        {
            Console.Clear();

            var productName = GetValidString("Enter product name to delete: ");
            var order = _orderService.GetOrderByProductName(productName);

            if (order == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            _orderService.DeleteOrder(order);

            Console.Clear();
            Console.WriteLine("Product deleted successfully.");
        }



        private int GetValidInt(string message)
        {
            int result;

            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) && result >= 0)
                {
                    return result;
                }

                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
            }
        }


        private string GetValidString(string message)
        {
            string result;

            while (true)
            {
                Console.Write(message);
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }

                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
