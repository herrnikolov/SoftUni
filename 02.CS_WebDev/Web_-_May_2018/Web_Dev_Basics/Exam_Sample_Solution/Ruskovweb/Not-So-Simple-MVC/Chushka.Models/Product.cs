namespace Chushka.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

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
        public int TypeId { get; set; }
        public ProductType Type { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
