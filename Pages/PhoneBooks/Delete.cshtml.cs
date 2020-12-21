using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Pages.PhoneBooks
{
    public class DeleteModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public DeleteModel(MyContacts.Data.MyContactsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhoneBook PhoneBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhoneBook = await _context.PhoneBook.FirstOrDefaultAsync(m => m.ID == id);

            if (PhoneBook == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhoneBook = await _context.PhoneBook.FindAsync(id);

            if (PhoneBook != null)
            {
                _context.PhoneBook.Remove(PhoneBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
