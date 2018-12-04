namespace Chushka.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Chushka.Models;

    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public static Expression<Func<Product, ProductDetailsViewModel>> FromPost =>
            p => new ProductDetailsViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type.Name,
                Price = p.Price,
                Description = p.Description
            };
    }
}
