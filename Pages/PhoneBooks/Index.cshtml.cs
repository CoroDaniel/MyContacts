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
    public class IndexModel : PageModel
    {
        private readonly MyContacts.Data.MyContactsContext _context;

        public IndexModel(MyContacts.Data.MyContactsContext context)
        {
            _context = context;
        }

        public IList<PhoneBook> PhoneBook { get;set; }

        public async Task OnGetAsync()
        {
            PhoneBook = await _context.PhoneBook.Include(b=>b.Grouping).ToListAsync(); 
        }
    }
}
