using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyContacts.Models
{
    public class PhoneBook
    {
        public int ID { get; set;}

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }

        public int GroupingID { get; set; }
        public Grouping Grouping { get; set; }

    }
}
