using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Pages.Groupings
{
    public class DeleteModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public DeleteModel(MyContacts.Data.MyContactsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grouping Grouping { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grouping = await _context.Grouping.FirstOrDefaultAsync(m => m.ID == id);

            if (Grouping == null)
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

            Grouping = await _context.Grouping.FindAsync(id);

            if (Grouping != null)
            {
                _context.Grouping.Remove(Grouping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
