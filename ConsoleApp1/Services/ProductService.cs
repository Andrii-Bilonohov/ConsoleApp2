using ConsoleApp1.DAL.Entities;
using ConsoleApp1.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;


        public ProductService()
        {
            _productRepository = new ProductRepository();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }


        public Product? GetProductById(int id)
        {
            return _productRepository
                .GetAllProducts()
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            }

            return _productRepository
                .GetAllProducts()
                .Where(p => p.Id == id)
                .ToList();
        }


        public Product? GetProductByName(string name)
        {
            return _productRepository
                .GetAllProducts()
                .FirstOrDefault(p => p.Name == name);
        }


        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }


        public void AddProducts(List<Product> products)
        {
            _productRepository.AddProducts(products);
        }


        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }


        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }


        public void DeleteProducts(List<Product> products)
        {
            _productRepository.DeleteProducts(products);
        }
    }
}
