using BMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSInterface
{
    public interface IUserBookRepository
    {
        List<UserBook> GetAll();
        UserBook Get(int id);
        int Insert(UserBook bk);
        UserBook Update(UserBook book, int id);
        int Delete(int id);
    }
}
