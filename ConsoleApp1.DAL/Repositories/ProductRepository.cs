using ConsoleApp1.DAL.Data;
using ConsoleApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }


        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public void AddProducts(List<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }


        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }


        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }


        public void DeleteProducts(List<Product> products)
        {
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
        }
    }
}
