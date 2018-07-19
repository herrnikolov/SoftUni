using MyLibrary.Web.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Models.Author
{
    public class AuthorDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }
    }
}
