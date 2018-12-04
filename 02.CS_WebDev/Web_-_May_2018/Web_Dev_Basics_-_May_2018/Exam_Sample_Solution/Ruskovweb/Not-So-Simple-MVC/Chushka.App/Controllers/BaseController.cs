namespace Chushka.App.Controllers
{
    using Chushka.App.Common;
    using SoftUni.WebServer.Mvc.Controllers;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.IO;
    using System.Text;

    public class BaseController : Controller
    {
        protected IActionResult RedirectToHome() => RedirectToAction("/home/index");

        protected IActionResult RedirectToLogin() => RedirectToAction("/users/login");

        protected void SetValidatorErrors()
        {
            var resultErrors = new StringBuilder();
            var errors = this.ParameterValidator.ModelErrors;
            foreach (var error in errors)
            {
                resultErrors.AppendLine($"<p>{string.Join(" ", error.Value)}</p>");
            }
            this.ViewData["alertDisplay"] = "block";
            this.ViewData["alertType"] = "danger";
            this.ViewData["alertMessage"] = resultErrors.ToString();
        }

        protected void ShowAlert(string type, string message)
        {
            this.ViewData["alertDisplay"] = "block";
            this.ViewData["alertType"] = type;
            this.ViewData["alertMessage"] = message;
        }

        private void HideAlert()
        {
            this.ViewData["alertDisplay"] = "none";
        }

        private void GenerateNavbar()
        {
            this.ViewData["adminNavbar"] = string.Empty;
            this.ViewData["guestNavbar"] = string.Empty;
            this.ViewData["logoutNavbar"] = string.Empty;

            if (this.User.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    this.ViewData["adminNavbar"] = File.ReadAllText(Constants.PathPrefix + "Views/Navbar/admin-navbar.html");
                }

                this.ViewData["logoutNavbar"] = File.ReadAllText(Constants.PathPrefix + "Views/Navbar/logout-navbar.html");
            }
            else
            {
                this.ViewData["guestNavbar"] = File.ReadAllText(Constants.PathPrefix + "Views/Navbar/guest-navbar.html");
            }
        }

        public override void OnAuthentication()
        {
            this.GenerateNavbar();
            this.HideAlert();

            base.OnAuthentication();
        }
    }
}
