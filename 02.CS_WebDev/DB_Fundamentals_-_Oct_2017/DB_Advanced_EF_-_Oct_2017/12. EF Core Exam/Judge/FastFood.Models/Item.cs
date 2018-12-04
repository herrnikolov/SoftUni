﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        // - from exam prep
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}