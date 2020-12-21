using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyContacts.Models
{
    public class Grouping
    {

        public int ID { get; set; }

        [Display(Name ="Grouping Name")]
        public string GroupingName { get; set; }
        public ICollection<PhoneBook> PhoneBooks { get; set; }
    }
}
