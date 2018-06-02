namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using System;
    using HTTPServer.ByTheCakeApplication.Data;
    using HTTPServer.ByTheCakeApplication.Utilities;
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class AccountController : Controller
    {

        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string fromNameKey = "name";
            const string fromUsernameKey = "username";
            const string fromPasswordKey = "password";
            const string fromConfirmPasswordKery = "confirm-password";

            if (!req.FormData.ContainsKey(fromNameKey)
                || !req.FormData.ContainsKey(fromUsernameKey)
                || !req.FormData.ContainsKey(fromPasswordKey))
            {
                return new BadRequestResponse();
            }
            
            string name = req.FormData[fromNameKey];
            string username = req.FormData[fromNameKey];
            string password = req.FormData[fromPasswordKey];
            string confirmPassword = req.FormData[fromConfirmPasswordKery];

            if (fromConfirmPasswordKery != confirmPassword)
            {
                return new BadRequestResponse();
            }

            var user = new User()
            {
                Name = req.FormData[fromNameKey],
                Username = req.FormData[fromUsernameKey],
                PasswordHash = PasswordUtilities.ComputerHash(password),
                RegistrationDate = DateTime.UtcNow
            };

            var context = new ByTheCakeContext();
            context.Users.Add(user);
            context.SaveChanges();
            return null;
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\login");
            }

            req.Session.Add(SessionStore.CurrentUserKey, name);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }
    }
}
