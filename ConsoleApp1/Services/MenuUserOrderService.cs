using ConsoleApp1.DAL.Entities;

namespace ConsoleApp1.Services
{
    public class MenuUserOrderService
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly UserAndOrderService _userAndOrderService;
        private readonly ProductService _productService;


        public MenuUserOrderService()
        {
            _userService = new UserService();
            _orderService = new OrderService();
            _userAndOrderService = new UserAndOrderService();
            _productService = new ProductService();
        }

        public void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View customer list");
            Console.WriteLine("2. View product list");
            Console.WriteLine("3. View order list");
            Console.WriteLine();
            Console.WriteLine("4. Add new customer");
            Console.WriteLine("5. Add new product");
            Console.WriteLine("6. Add new order");
            Console.WriteLine();
            Console.WriteLine("7. Edit customer information");
            Console.WriteLine("8. Edit product information");
            Console.WriteLine("9. Edit order information");
            Console.WriteLine();
            Console.WriteLine("10. Delete customer");
            Console.WriteLine("11. Delete product");
            Console.WriteLine("12. Delete order");
            Console.WriteLine();
            Console.WriteLine("13. Get the top 3 users with the most orders");
            Console.WriteLine("14. Find all orders made in the last 7 days");
            Console.WriteLine("15. Find users with no orders");
            Console.WriteLine("16. Create an order count for each user");
            Console.WriteLine("17. Order with the longest product name");
            Console.WriteLine("18. Delete all orders created more than a year ago");
            Console.WriteLine("19. Sort users by the date of their last order (including those with none)");
            Console.WriteLine("20. Exit");

            var option = GetValidString("Please enter your choice: ");

            switch (option)
            {
                case "1":
                    Console.Clear();
                    ViewCustomerList();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    ViewProductList();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    ViewOrderList();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    AddCustomer();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    AddProduct();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.Clear();
                    AddOrder();
                    Console.WriteLine();
                    break;
                case "7":
                    Console.Clear();
                    EditCustomerInformation();
                    Console.WriteLine();
                    break;
                case "8":
                    Console.Clear();
                    EditProductInformation();
                    Console.WriteLine();
                    break;
                case "9":
                    Console.Clear();
                    EditOrderInformation();
                    Console.WriteLine();
                    break;
                case "10":
                    Console.Clear();
                    DeleteCustomer();
                    break;
                case "11":
                    Console.Clear();
                    DeleteProduct();
                    Console.WriteLine();
                    break;
                case "12":
                    Console.Clear();
                    DeleteOrder();
                    Console.WriteLine();
                    break;
                case "13":
                    Console.Clear();
                    GetTop3UsersWithMostOrders();
                    Console.WriteLine();
                    break;
                case "14":
                    Console.Clear();
                    GetOrdersByLast7Days();
                    Console.WriteLine();
                    break;
                case "15":
                    Console.Clear();
                    GetUsersWithNoOrders();
                    Console.WriteLine();
                    break;
                case "16":
                    Console.Clear();
                    GetOrderCountByUser();
                    Console.WriteLine();
                    break;
                case "17":
                    Console.Clear();
                    GetOrderWithLongestProductName();
                    Console.WriteLine();
                    break;
                case "18":
                    Console.Clear();
                    DeleteOldOrders();
                    Console.WriteLine();
                    break;
                case "19":
                    Console.Clear();
                    SortUsersByLastOrderDate();
                    Console.WriteLine();
                    break;
                case "20":
                    Console.Clear();
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }

        // Customers methods
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
            var users = _userService.GetAllUsersByName(name).ToList();

            if (users == null || !users.Any())
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var user = users.Count() == 1 ? users.FirstOrDefault() : SelectUserFromList(users);
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid selection.");
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
            var users = _userService.GetAllUsersByName(name).ToList();

            if (users == null || !users.Any())
            {
                Console.Clear();
                Console.WriteLine("Customer not found.");
                return;
            }

            var user = users.Count() == 1 ? users.FirstOrDefault() : SelectUserFromList(users);
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid selection.");
                return;
            }

            _userService.DeleteUser(user);

            Console.Clear();
            Console.WriteLine("Customer deleted successfully.");
        }


        private void ViewProductList()
        {
            Console.Clear();

            var products = _productService.GetAllProducts();

            Console.Clear();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, \nName: {product.Name}, \nPrice: {product.Price}");
                Console.WriteLine();
            }
        }
        
        
        // Products methods
        private void AddProduct()
        {
            Console.Clear();

            var name = GetValidString("Enter product name: ");
            var price = GetValidDecimal("Enter product price: ");

            var product = new Product { Name = name, Price = price };
            _productService.AddProduct(product);

            Console.Clear();
            Console.WriteLine("Product added successfully.");
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
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var productName = GetValidString("Enter new product name: ");
            var productPrice = GetValidDecimal("Enter new product price: ");

            product.Name = productName;
            product.Price = productPrice;

            _productService.UpdateProduct(product);

            Console.Clear();
            Console.WriteLine("Product information updated successfully.");
        }


        private void EditProductByName()
        {
            Console.Clear();

            var productName = GetValidString("Enter product name to edit: ");
            var product = _productService.GetProductByName(productName);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var newProductName = GetValidString("Enter new product name: ");
            var newProductPrice = GetValidDecimal("Enter new product price: ");

            product.Name = newProductName;
            product.Price = newProductPrice;

            _productService.UpdateProduct(product);

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
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            _productService.DeleteProduct(product);

            Console.Clear();
            Console.WriteLine("Product deleted successfully.");
        }


        private void DeleteProductByName()
        {
            Console.Clear();

            var productName = GetValidString("Enter product name to delete: ");
            var product = _productService.GetProductByName(productName);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            _productService.DeleteProduct(product);

            Console.Clear();
            Console.WriteLine("Product deleted successfully.");
        }


        private void ViewOrderList()
        {
            Console.Clear();

            var orders = _orderService.GetAllOrders();

            Console.Clear();
            foreach (var order in orders)
            {
                var user = _userService.GetUserById(order.UserId);
                var product = _productService.GetProductById(order.ProductId);

                Console.WriteLine($"User: {user.Name}, \nProduct: {product.Name}, \nCreated Date: {order.CreatedDate}");
                Console.WriteLine();
            }
        }


        // Orders methods
        private void AddOrder()
        {
            Console.Clear();

            var userName = GetValidString("Enter user name: ");
            var users = _userService.GetAllUsersByName(userName);
            Console.WriteLine();

            if (users == null || !users.Any())
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("Available goods:");
            var products = _productService.GetAllProducts().ToList();

            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}, \nPrice: {products[i].Price}");
                Console.WriteLine();
            }

            var user = users.Count == 1 ? users.FirstOrDefault() : SelectUserFromList(users);

            var choice = GetValidInt("Enter the number of the product you want to buy: ");
            if (choice < 1 || choice > products.Count)
            {
                Console.Clear();
                Console.WriteLine("Invalid product number.");
                return;
            }

            var productBuy = products[choice - 1];
            var product = _productService.GetProductById(productBuy.Id);
            if (product == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            if (productBuy == null)
            {
                Console.Clear();
                Console.WriteLine("Product not found.");
                return;
            }

            var order = new Order
            {
                UserId = user.Id,
                ProductId = productBuy.Id,
                CreatedDate = DateTime.Now
            };


            _orderService.AddOrder(order);
            Console.Clear();
            Console.WriteLine("Order added successfully.");
        }


        private void EditOrderInformation()
        {
            Console.Clear();

            var userName = GetValidString("Enter name: ");
            var users = _userService.GetAllUsersByName(userName);

            if (users == null || !users.Any())
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                return;
            }

            var user = users.Count == 1 ? users.FirstOrDefault() : SelectUserFromList(users);

            var orders = _orderService.GetOrdersByUserId(user.Id);
            if (orders == null || !orders.Any())
            {
                Console.Clear();
                Console.WriteLine("You have no orders.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"User: {user.Name}");
            for (int i = 0; i < orders.Count; i++)
            {
                var product = _productService.GetProductById(orders[i].ProductId);
                Console.WriteLine($"{i + 1}. Product: {product?.Name ?? "Not found"}");
            }

            Console.Write($"Enter the number of the order you want to change (1-{orders.Count}): ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > orders.Count)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var selectedOrder = orders[index - 1];

            var newProductName = GetValidString("Enter new product name: ");
            var newProduct = _productService.GetProductByName(newProductName);

            if (newProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _orderService.DeleteOrder(selectedOrder);

            var newOrder = new Order
            {
                UserId = selectedOrder.UserId,
                ProductId = newProduct.Id,
                CreatedDate = selectedOrder.CreatedDate
            };

            _orderService.AddOrder(newOrder);

            Console.Clear();
            Console.WriteLine($"Order updated: old product replaced with {newProduct.Name}.");
        }

        private void DeleteOrder()
        {
            Console.Clear();

            var userName = GetValidString("Enter name: ");
            var users = _userService.GetAllUsersByName(userName);

            if (users == null || !users.Any())
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                return;
            }

            var user = users.Count == 1 ? users.FirstOrDefault() : SelectUserFromList(users);

            var orders = _orderService.GetOrdersByUserId(user.Id);
            if (orders == null || !orders.Any())
            {
                Console.Clear();
                Console.WriteLine("You have no orders.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"User: {user.Name}");
            for (int i = 0; i < orders.Count; i++)
            {
                var product = _productService.GetProductById(orders[i].ProductId);
                Console.WriteLine($"{i + 1}. Product: {product?.Name ?? "Not found"}");
            }

            Console.Write($"Enter the number of the order you want to delete (1-{orders.Count}): ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > orders.Count)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var selectedOrder = orders[index - 1];
            _orderService.DeleteOrder(selectedOrder);

            Console.Clear();
            Console.WriteLine("Orders deleted successfully.");
        }


        private void GetTop3UsersWithMostOrders()
        {
            Console.Clear();
            var users = _userAndOrderService.GetAllUsersWithOrders();
            var topUsers = users
                .OrderByDescending(u => u.Orders.Count)
                .Take(3)
                .ToList();
            Console.Clear();
            foreach (var user in topUsers)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Orders Count: {user.Orders.Count}");
            }
        }


        private void GetOrdersByLast7Days()
        {
            Console.Clear();
            var orders = _orderService.GetAllOrders()
                .Where(o => o.CreatedDate >= DateTime.Now.AddDays(-7))
                .ToList();
            Console.Clear();
            foreach (var order in orders)
            {
                var user = _userService.GetUserById(order.UserId);
                var product = _productService.GetProductById(order.ProductId);
                Console.WriteLine($"User: {user.Name}, \nProduct: {product.Name}, \nCreated Date: {order.CreatedDate}");
                Console.WriteLine();
            }
        }


        private void GetUsersWithNoOrders()
        {
            Console.Clear();
            var users = _userAndOrderService.GetAllUsersWithOrders()
                .Where(u => u.Orders.Count == 0)
                .ToList();
            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
            }
        }


        private void GetOrderCountByUser()
        {
            Console.Clear();
            var users = _userAndOrderService.GetAllUsersWithOrders()
                .Select(u => new { u.Name, OrderCount = u.Orders.Count })
                .ToList();
            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Order Count: {user.OrderCount}");
            }
        }


        private void GetOrderWithLongestProductName()
        {
            Console.Clear();
            var orders = _orderService.GetAllOrders()
                .Select(o => new
                {
                    o,
                    ProductName = _productService.GetProductById(o.ProductId)?.Name
                })
                .OrderByDescending(x => x.ProductName.Length)
                .FirstOrDefault();
            if (orders != null)
            {
                Console.WriteLine($"Product Name: {orders.ProductName}");
            }
        }


        private void DeleteOldOrders()
        {
            Console.Clear();
            var orders = _orderService.GetAllOrders()
                .Where(o => o.CreatedDate < DateTime.Now.AddYears(-1))
                .ToList();
            foreach (var order in orders)
            {
                _orderService.DeleteOrder(order);
            }
            Console.Clear();
            Console.WriteLine("Old orders deleted successfully.");
        }


        private void SortUsersByLastOrderDate()
        {
            Console.Clear();
            var users = _userAndOrderService.GetAllUsersWithOrders()
                .Select(u => new
                {
                    u,
                    LastOrderDate = u.Orders.OrderByDescending(o => o.CreatedDate).FirstOrDefault()?.CreatedDate
                })
                .OrderByDescending(x => x.LastOrderDate)
                .ToList();
            Console.Clear();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.u.Id}, Name: {user.u.Name}, Last Order Date: {user.LastOrderDate}");
            }
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


        private decimal GetValidDecimal(string message)
        {
            decimal result;
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out result) && result >= 0)
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

        private User SelectUserFromList(IEnumerable<User> users)
        {
            Console.Clear();

            Console.WriteLine("Multiple users found with the same name:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
            }

            var userIdToSelect = GetValidInt("Enter the ID of the user you want to select: ");
            return users.FirstOrDefault(u => u.Id == userIdToSelect);
        }
    }
}
