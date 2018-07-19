using MyLibrary.Web.Models.Author;
using MyLibrary.Web.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Models.Search
{
    public class SearchResultViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
