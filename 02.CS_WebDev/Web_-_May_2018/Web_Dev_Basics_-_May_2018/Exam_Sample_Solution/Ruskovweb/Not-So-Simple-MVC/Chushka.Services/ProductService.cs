namespace Chushka.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chushka.Data;
    using Chushka.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductService
    {
        public IEnumerable<Product> GetAll()
        {
            using (var context =new ChushkaDbContext())
            {
                return context.Products.ToList();
            }
        }

        public Product Find(int id)
        {
            using (var context = new ChushkaDbContext())
            {
                return context.Products
                    .Include(p => p.Type)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public Product Create(string name, decimal price, string description, string type)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(type))
            {
                return null;
            }

            try
            {
                using (var context = new ChushkaDbContext())
                {
                    var productType = context.ProductTypes.FirstOrDefault(t => t.Name == type);

                    if(productType == null)
                    {
                        return null;
                    }

                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        Type = productType,
                        Description = description
                    };

                    context.Products.Add(product);
                    context.SaveChanges();
                    return product;
                }
            }
            catch
            {
                return null;
            }
        }
        
        public bool Edit(int id, string name, decimal price, string description, string type)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                   string.IsNullOrWhiteSpace(description) ||
                   string.IsNullOrWhiteSpace(type))
            {
                return false;
            }

            using (var context = new ChushkaDbContext())
            {
                var product = context.Products.Find(id);

                if(product == null)
                {
                    return false;
                }

                var productType = context.ProductTypes.FirstOrDefault(t => t.Name == type);

                if(productType == null)
                {
                    return false;
                }

                product.Name = name;
                product.Price = price;
                product.Description = description;
                product.Type = productType;

                context.Update(product);
                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new ChushkaDbContext())
            {
                var product = context.Products.Find(id);

                if(product == null)
                {
                    return false;
                }
               
                context.Products.Remove(product);
                context.SaveChanges();

                return true;
            }
        }
    }
}
