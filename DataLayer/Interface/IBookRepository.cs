using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        bool Delete(Guid key);
        bool Update(Book book);
        bool Create (Book book);
    }
}
