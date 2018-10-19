namespace Chushka.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Chushka.App.Common;
    using Chushka.App.Models.ViewModels;
    using Chushka.Services;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;

    public class HomeController : BaseController
    {
        private ProductService productService;

        public HomeController()
        {
            this.productService = new ProductService();
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            this.ViewData["homeContent"] = string.Empty;
            string homeContent = string.Empty;

            if (!this.User.IsAuthenticated)
            {
                homeContent = File.ReadAllText(Constants.PathPrefix + "Views/Home/guest-home.html");
            }
            else
            {
                homeContent = File.ReadAllText(Constants.PathPrefix + "Views/Home/user-home.html");

                this.ViewData["username"] = this.User.Name;

                List<ProductCardViewModel> products = this.productService
                    .GetAll()
                    .AsQueryable()
                    .Select(ProductCardViewModel.FromPost)
                    .ToList();

                this.ViewData["products"] = string.Empty;
                if (products.Any())
                {
                    var format = File.ReadAllText(Constants.PathPrefix + "Views/Home/product-card.html");

                    var productsAsHtml = products
                        .Select(p => string.Format(format, 
                        p.Id,
                        p.Name, 
                        p.Description.Length > 50 ? p.Description.Substring(0, 50) + "..." : p.Description, 
                        p.Price.ToString("F2")))
                        .ToList();

                    this.ViewData["products"] = string.Join(Environment.NewLine, productsAsHtml);
                }
            }

            this.ViewData["homeContent"] = homeContent;

            return this.View();
        }
    }
}
