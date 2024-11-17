﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turc_Ana_Lab2.Data;
using Turc_Ana_Lab2.Models;

namespace Turc_Ana_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Turc_Ana_Lab2.Data.Turc_Ana_Lab2Context _context;

        public DetailsModel(Turc_Ana_Lab2.Data.Turc_Ana_Lab2Context context)
        {
            _context = context;
        }
        public BookData BookD { get; set; }
        public Book Book { get; set; } = default!;
        public int CategoryID { get; set; }

        public int AuthorID { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                  .Include(b => b.Publisher)
                  .Include(b => b.Author)
                  .Include(b => b.BookCategories)
                  .ThenInclude(b => b.Category)
                  .AsNoTracking()
                  .OrderBy(b => b.Title)
                  .ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();

        }
    }
}
