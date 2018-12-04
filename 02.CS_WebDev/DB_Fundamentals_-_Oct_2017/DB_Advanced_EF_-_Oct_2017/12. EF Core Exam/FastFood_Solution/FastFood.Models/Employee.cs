using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
	public class Employee
	{

	    //public Employee()
	    //{
	    //    this.Orders = new HashSet<Order>();
	    //}

        [Key]
        public int Id { get; set; }

        [Required]
        //[MinLength(3)]
        //[MaxLength(30)]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

	    [Required]
        //[MinLength(15)]
        //[MaxLength(80)]
	    [Range(15, 80)]
        public int Age { get; set; }

	    public int PositionId { get; set; }

        [Required]
        public Position Position { get; set; }

	    public ICollection<Order> Orders { get; set; }
    }
}