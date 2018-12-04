using System;
using System.ComponentModel.DataAnnotations;

namespace FDMC.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,99)]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
