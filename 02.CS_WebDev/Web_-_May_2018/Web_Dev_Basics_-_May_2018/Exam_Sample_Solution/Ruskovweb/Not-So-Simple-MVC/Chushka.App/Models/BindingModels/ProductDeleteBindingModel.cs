namespace Chushka.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDeleteBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}
