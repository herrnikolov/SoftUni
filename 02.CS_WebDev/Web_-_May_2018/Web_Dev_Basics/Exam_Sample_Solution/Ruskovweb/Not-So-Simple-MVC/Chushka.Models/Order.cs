namespace Chushka.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        [Required]
        public int ClientId { get; set; }
        public User Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
