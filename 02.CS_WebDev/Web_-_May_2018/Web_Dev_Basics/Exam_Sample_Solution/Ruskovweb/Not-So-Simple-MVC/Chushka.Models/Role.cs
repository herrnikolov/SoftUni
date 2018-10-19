namespace Chushka.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
