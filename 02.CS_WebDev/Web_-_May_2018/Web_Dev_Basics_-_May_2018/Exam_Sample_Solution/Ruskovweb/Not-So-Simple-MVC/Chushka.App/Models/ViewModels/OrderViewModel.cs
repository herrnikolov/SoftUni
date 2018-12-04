namespace Chushka.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Chushka.Models;

    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string Customer { get; set; }

        public string Product { get; set; }

        public string OrderedOn { get; set; }

        public static Expression<Func<Order, OrderViewModel>> FromPost =>
            o => new OrderViewModel()
            {
                OrderId = o.Id,
                Customer = o.Client.Username,
                Product = o.Product.Name,
                OrderedOn = o.OrderedOn.ToString()
            };
    }
}
