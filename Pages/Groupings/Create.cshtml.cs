using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Pages.Groupings
{
    public class CreateModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public CreateModel(MyContacts.Data.MyContactsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grouping Grouping { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grouping.Add(Grouping);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
