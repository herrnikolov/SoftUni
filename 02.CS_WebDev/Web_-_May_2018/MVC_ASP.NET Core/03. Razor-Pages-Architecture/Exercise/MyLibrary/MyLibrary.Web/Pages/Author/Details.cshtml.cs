namespace MyLibrary.Web.Pages.Author
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Web.Models.Author;
    using MyLibrary.Web.Models.Book;
    using System.Linq;
    using System.Threading.Tasks;

    public class DetailsModel : PageModel
    {
        private readonly MyLibraryDBContext db;

        public DetailsModel(MyLibraryDBContext db)
        {
            this.db = db;
        }

        public AuthorDetailsViewModel Author { get; set; }

        [HttpGet("{id}")]
        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.Author = await this.db
                 .Authors
                 .Where(a => a.Id == id)
                 .Select(a => new AuthorDetailsViewModel
                 {
                     Name = a.Name,
                     Books = a.Books
                     .Select(b => new BookConciseViewModel
                     {
                         Id = b.BookId,
                         Title = b.Book.Title,
                         Status = b.Book.IsBorrowed ? "Borrowed" : "At home"
                     })
                     .ToArray()
                 })
                 .FirstOrDefaultAsync();

            if (this.Author == null)
            {
                return RedirectToPage("/Home/Index");
            }

            return Page();
        }
    }
}