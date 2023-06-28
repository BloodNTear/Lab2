using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Address
    {
        [Key]
        public string City { get; set; }
        public string Street { get; set; }        
        public virtual ICollection<Book> Books { get; set; }
    }
}
