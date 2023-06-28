using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Press
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
