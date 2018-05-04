﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PetClinic.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Age { get; set; }

        [Required]
        [ForeignKey("Passport")]
        public string PassportSerialNumber { get; set; }

        [Required]
        public Passport Passport { get; set; }

        //My Mistate
        //public Procedure Procedures { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}