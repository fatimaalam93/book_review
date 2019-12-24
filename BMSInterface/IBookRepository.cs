using BMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSInterface
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int id);
        int Insert(Book bk);
        Book Update(Book book,int id);
        int Delete(int id);
    }
}
