
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PetClinic.Models
{
    public class Vet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [StringLength(65, MinimumLength = 22)]
        public int Age { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }


    }
}
