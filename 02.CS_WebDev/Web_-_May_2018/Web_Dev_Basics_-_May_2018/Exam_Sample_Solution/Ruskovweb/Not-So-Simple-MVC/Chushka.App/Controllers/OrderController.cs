namespace Chushka.App.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using Chushka.App.Common;
    using Chushka.App.Models.ViewModels;
    using Chushka.Services;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;

    public class OrderController : BaseController
    {
        private OrderService orderService;

        public OrderController()
        {
            this.orderService = new OrderService();
        }

        [HttpGet]
        public IActionResult Make(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            bool isOrdered = this.orderService.MakeOrder(id, this.User.Id);

            if (!isOrdered)
            {
                this.ShowAlert("danger", "Something wrong!");
                return this.RedirectToHome();
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            var orders = this.orderService
                .GetAll()
                .AsQueryable()
                .Select(OrderViewModel.FromPost)
                .ToList();

            string format = File.ReadAllText(Constants.PathPrefix + "Views/Order/order-row.html");

            var ordersAsHtml = orders
                .Select((o, i) => string.Format(format,
                    i + 1,
                    o.OrderId,
                    o.Customer,
                    o.Product,
                    o.OrderedOn
                ))
                .ToList();

            this.ViewData["orders"] = string.Join(Environment.NewLine, ordersAsHtml);

            return this.View();
        }
    }
}
