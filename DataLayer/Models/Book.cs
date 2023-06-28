using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Book
    {
        [Key]
        public Guid ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public Guid PressId { get; set; }
        public string AddressCity { get; set; }
        public virtual Address Address { get; set; }
        public virtual Press Press { get; set; }
    }
}
