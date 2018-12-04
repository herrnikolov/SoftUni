namespace Chushka.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Chushka.Models;

    public class ProductCardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public static Expression<Func<Product, ProductCardViewModel>> FromPost =>
            p => new ProductCardViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            };
    }
}
