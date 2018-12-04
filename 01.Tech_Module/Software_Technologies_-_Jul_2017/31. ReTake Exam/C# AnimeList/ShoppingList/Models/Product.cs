using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingList.Models
{
    public class Product
    {
        //TODO: Implement me ...
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Priority { get; set; }

        [Required]
        [AllowHtml]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public string Quantity { get; set; }

        [Required]
        public string Status { get; set; }
    }
}