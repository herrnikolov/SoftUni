namespace Chushka.App.Controllers
{
    using Chushka.App.Models.BindingModels;
    using Chushka.Services;
    using SoftUni.WebServer.Common;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;

    public class UsersController : BaseController
    {
        private UserService userService;

        public UsersController()
        {
            this.userService = new UserService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.SetValidatorErrors();
                return this.View();
            }
            
            var user = this.userService.Find(
                model.Username, 
                PasswordUtilities.GetPasswordHash(model.Password));

            if(user == null)
            {
                this.ShowAlert("danger", "Invalid username or password!");
                return this.View();
            }

            this.SignIn(user.Username, user.Id, new[] { user.Role.Name });

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.SetValidatorErrors();
                return this.View();
            }

            if (this.userService.Contains(model.Username))
            {
                this.ShowAlert("danger", "Username already exists!");
                return this.View();
            }

            var user = this.userService.Create(
                model.Username,
                PasswordUtilities.GetPasswordHash(model.Password),
                model.Email,
                model.FullName);
            
            if(user == null)
            {
                this.ShowAlert("danger", "Something wrong!");
                return this.View();
            }

            this.SignIn(user.Username, user.Id, new[] { user.Role.Name });

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            this.SignOut();

            return this.RedirectToHome();
        }
    }
}
