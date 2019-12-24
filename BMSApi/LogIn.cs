using BMSEntity;
using BMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSApi
{
    public class LogIn
    {
        public static bool Login(string email, string password)
        {
            UserRepository repo = new UserRepository();
            return repo.GetEmailNdPass(email, password);
        }
    }
}