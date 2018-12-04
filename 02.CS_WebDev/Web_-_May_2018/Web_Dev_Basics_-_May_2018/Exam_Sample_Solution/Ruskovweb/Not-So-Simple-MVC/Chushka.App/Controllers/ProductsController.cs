namespace Chushka.App.Controllers
{
    using Chushka.App.Common;
    using Chushka.App.Models.BindingModels;
    using Chushka.App.Models.ViewModels;
    using Chushka.Services;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.IO;

    public class ProductsController : BaseController
    {
        private ProductService productService;

        public ProductsController()
        {
            this.productService = new ProductService();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if(!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateBindingModel model)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.SetValidatorErrors();
                return this.View();
            }

            var product = this.productService.Create(
                model.Name, 
                model.Price, 
                model.Description, 
                model.Type);

            if(product == null)
            {
                this.ShowAlert("danger", $"Something wrong!");
                return this.View();
            }

            this.ShowAlert("success", $"Product {product.Name} is created successful!");
            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            var product = this.productService.Find(id);

            if(product == null)
            {
                return this.RedirectToHome();
            }

            this.ViewData["id"] = product.Id.ToString();
            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("F2");
            this.ViewData["description"] = product.Description;
            this.ViewData[$"{product.Type.Name.ToLower()}Check"] = "checked";

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(ProductEditBindingModel model)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowAlert("danger", $"Input data is not valid!");

                return this.View();
            }

            var isEdited = this.productService.Edit(model.Id, model.Name, model.Price, model.Description, model.Type);

            if (!isEdited)
            {
                this.ShowAlert("danger", $"Something wrong!");

                return this.RedirectToHome();
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            var product = this.productService.Find(id);

            if (product == null)
            {
                return this.View();
            }

            this.ViewData["id"] = product.Id.ToString();
            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("F2");
            this.ViewData["description"] = product.Description;
            this.ViewData[$"{product.Type.Name.ToLower()}Check"] = "checked";

            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(ProductDeleteBindingModel model)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToLogin();
            }

            bool isDeleted = this.productService.Delete(model.Id);

            if (!isDeleted)
            {
                this.ShowAlert("danger", $"Something wrong!");

                return this.RedirectToHome();
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var product = this.productService.Find(id);

            if(product == null)
            {
                return this.RedirectToHome();
            }

            this.ViewData["adminButtons"] = string.Empty;
            if (this.User.IsInRole("Admin"))
            {
                this.ViewData["adminButtons"] = File.ReadAllText(Constants.PathPrefix + "Views/Products/admin-buttons.html");
            }

            var productViewModel = new ProductDetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type.Name,
                Price = product.Price,
                Description = product.Description
            };

            this.ViewData["id"] = productViewModel.Id.ToString();
            this.ViewData["name"] = productViewModel.Name;
            this.ViewData["type"] = productViewModel.Type;
            this.ViewData["price"] = productViewModel.Price.ToString("F2");
            this.ViewData["description"] = productViewModel.Description;

            return this.View();
        }
    }
}
