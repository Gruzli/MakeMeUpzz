using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Reposiitory
{
    public class UserRepository
    {
        private Database1Entities2 db = new Database1Entities2();

        public int generateId()
        {
            int lastId = db.Users.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefault();
            return lastId + 1;
        }

        public void InsertDataUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool isAuthenticate(string username, string password)
        {
            var user = db.Users.Any(u => u.Username == username && u.UserPassword == password);
            return user;
        }
    }
}