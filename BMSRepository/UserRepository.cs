using BMSEntity;
using BMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSRepository
{
    public class UserRepository : IUserRepository
    {
        private BMSDBContext context = new BMSDBContext();

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(b => b.userId == id);
        }

        public User GetName(string name)
        {
            return context.Users.SingleOrDefault(b => b.user_name == name);
        }

        public int Insert(User bk)
        {
            context.Users.Add(bk);
            return context.SaveChanges();
        }

        public User Update(User user,int id)
        {
            User usr = context.Users.SingleOrDefault(b => b.userId == id);

            if (usr != null)
            {
                if(user.user_name!=null)
                    usr.user_name = user.user_name;
                if (user.password != null)
                    usr.password = user.password;
                if (user.image_link != null)
                    usr.image_link = user.image_link;
                if (user.BookCount != 0)
                    usr.BookCount = user.BookCount;
                if (user.AverageRating != 0)
                    usr.AverageRating = user.AverageRating;

                context.SaveChanges();

                return usr;
            }
            else
                return null;
            
        }

        public int Delete(int id)
        {
            User bk = context.Users.SingleOrDefault(b => b.userId == id);
            if (bk != null)
            {
                context.Users.Remove(bk);
            }
            return context.SaveChanges();
        }

        public bool GetEmailNdPass(string email, string password)
        {
            User bk = context.Users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            if (bk != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool DuplicateMail(string email)
        {
            //return context.Users.Any(u => u.email == us.email);
            if (context.Users.Any(u => u.email == email))
            {
                return true;
            }
            else
                return false;
        }
    }
}
