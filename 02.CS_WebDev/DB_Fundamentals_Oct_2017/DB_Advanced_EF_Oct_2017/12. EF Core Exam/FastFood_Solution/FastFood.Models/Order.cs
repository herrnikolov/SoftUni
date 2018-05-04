﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FastFood.Models.Enums;

namespace FastFood.Models
{
    public class Order
    {
        //public Order()
        //{
        //    this.OrderItems = new HashSet<OrderItem>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [DefaultValue("ForHere")]
        public OrderType Type { get; set; }

        //[Required]
        //public OrderType Type { get; set; } = OrderType.ForHere;

        [NotMapped]
        //public decimal TotalPrice { get; set; }
        // my mistake
        public decimal TotalPrice
        {
            get { return this.OrderItems.Select(oi => oi.Item.Price * oi.Quantity).Sum();}
            //get; set; 
        }
        
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

