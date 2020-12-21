using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyContacts.Models;

namespace MyContacts.Data
{
    public class MyContactsContext : DbContext
    {
        public MyContactsContext (DbContextOptions<MyContactsContext> options)
            : base(options)
        {
        }

        public DbSet<MyContacts.Models.PhoneBook> PhoneBook { get; set; }

        public DbSet<MyContacts.Models.Grouping> Grouping { get; set; }
    }
}
