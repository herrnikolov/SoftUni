namespace Chushka.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
