namespace MyLibrary.Web.Pages.Book
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BorrowModel : PageModel
    {
        private readonly MyLibraryDBContext db;

        public BorrowModel(MyLibraryDBContext db)
        {
            this.db = db;
        }

        public string ErrorMessage { get; set; }

        [BindProperty]
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }

        [BindProperty]
        public string SelectedBorrowerId { get; set; }

        [BindProperty]
        public DateTime DateBorrowed { get; set; }

        [BindProperty]
        public DateTime ExpirationDate { get; set; }

        public async Task OnGetAsync(int id, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.ErrorMessage = errorMessage;
            }

            this.BookId = id;
            var book = await this.db.Books.FirstOrDefaultAsync(b => b.Id == id);
            this.BookTitle = book.Title;
            this.DateBorrowed = DateTime.Today;
            this.ExpirationDate = DateTime.Today.AddMonths(1);

            this.Borrowers = await this.db
                .Borrowers
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.DateBorrowed >= this.ExpirationDate)
            {
                var errorMessage = "Expiration date should be after date of borrowing!";
                return RedirectToPage("/books/borrow", new { id = this.BookId, errorMessage = errorMessage });
            }

            var status = new Status
            {
                BookId = this.BookId,
                BorrowerId = int.Parse(this.SelectedBorrowerId),
                DateBorrowed = this.DateBorrowed,
                ExpirationDate = this.ExpirationDate
            };

            var book = await this.db.Books.FindAsync(this.BookId);
            book.IsBorrowed = true;
            this.db.Books.Update(book);

            await this.db.Statuses.AddAsync(status);
            await this.db.SaveChangesAsync();

            return RedirectToPage($"/books/details", new { id = this.BookId });
        }
    }
}