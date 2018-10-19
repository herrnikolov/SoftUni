namespace Chushka.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
