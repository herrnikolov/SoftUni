﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FastFood.Models
{
    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
