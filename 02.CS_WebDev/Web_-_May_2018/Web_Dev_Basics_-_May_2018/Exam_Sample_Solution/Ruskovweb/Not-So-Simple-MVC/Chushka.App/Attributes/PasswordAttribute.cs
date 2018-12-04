namespace Chushka.App.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
            {
                return true;
            }

            this.ErrorMessage = "Password must contains at least 6 characters, one digit, one lowercase letter, one upper letter!";
                        
            return password.Any(char.IsDigit)
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsLower)
                   && password.Length >= 6;
        }
    }
}
