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
    public class DetailsModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public DetailsModel(MyContacts.Data.MyContactsContext context)
        {
            _context = context;
        }

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
    }
}
