using MyLibrary.Web.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Models.Book
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public List<AuthorViewModel> Authors { get; set; }
    }
}
