namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Authors = new List<BookAuthor>();
            this.Statuses = new List<Status>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Url]
        public string ImageUrl { get; set; }


        public bool IsBorrowed { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}
