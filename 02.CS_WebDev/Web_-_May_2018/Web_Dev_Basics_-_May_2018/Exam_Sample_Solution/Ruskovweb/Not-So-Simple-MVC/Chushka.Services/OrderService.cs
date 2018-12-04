namespace Chushka.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Chushka.Data;
    using Chushka.Models;
    using Microsoft.EntityFrameworkCore;

    public class OrderService
    {
        public bool MakeOrder(int productId, int userId)
        {
            using (var context = new ChushkaDbContext())
            {
                var user = context.Users.Find(userId);

                if(user == null)
                {
                    return false;
                }

                var product = context.Products.Find(productId);

                if(product == null)
                {
                    return false;
                }

                var order = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    Client = user,
                    Product = product,
                    OrderedOn = DateTime.UtcNow
                };

                context.Orders.Add(order);
                context.SaveChanges();

                return true;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (var context = new ChushkaDbContext())
            {
                return context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Product)
                    .ToList();
            }
        }
    }
}
