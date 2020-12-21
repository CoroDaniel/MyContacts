using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Pages.PhoneBooks
{
    public class EditModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public EditModel(MyContacts.Data.MyContactsContext context)
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

            ViewData["GroupingID"] = new SelectList(_context.Set<Grouping>(), "ID", "GroupingName"); 
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PhoneBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookExists(PhoneBook.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhoneBookExists(int id)
        {
            return _context.PhoneBook.Any(e => e.ID == id);
        }
    }
}
