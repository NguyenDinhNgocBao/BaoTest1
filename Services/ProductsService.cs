using BaoTest1.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace BaoTest1.Services
{
    public class ProductsService
    {
        static List<Products> products;
        public ProductsService()
        {
            if(products == null)
            {
                products = new List<Products>();
                products.Add(new Products
                {
                    Id = 1,
                    Name = "Asustuf",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,
                });
                products.Add(new Products
                {
                    Id = 2,
                    Name = "Lenovo Thinkpad",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,
                });
                products.Add(new Products
                {
                    Id = 3,
                    Name = "Acer Nitro",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,
                });
                products.Add(new Products
                {
                    Id = 4,
                    Name = "Dell Insprie",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,
                });
                products.Add(new Products
                {
                    Id = 5,
                    Name = "Dp Plaviton",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,
                });
                products.Add(new Products
                {
                    Id = 6,
                    Name = "Macbook Air",
                    Description = "dsghdfgnkjfdsg;lfds",
                    Price = 1500,
                    Category = "Laptop",
                    ProductionDay = DateTime.Now,

                });
            }
        }


        /// <summary>
        /// Funtion to get products from ProductsService
        /// </summary>
        public List<Products> GetProducts(string? keyword)
        {
            var product = products;
            if (!string.IsNullOrEmpty(keyword))
            {
                product = product
                .Where(e =>
                    e.Name.ToLower().Contains(keyword.ToLower()) ||
                    e.Price.ToString() == keyword).ToList();
            }
            return product;
        }


        public Products GetById(int id)
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }
        public bool Delete(int id)
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            if(product != null)
            {
                products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Products product)
        {
            var p = products.Where(e => e.Id == product.Id).FirstOrDefault();
            if(p != null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddProduct(Products product)
        {
            products.Add(product);
        }
    }
}
