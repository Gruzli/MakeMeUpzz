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

        public User addUser(User user)
        {
            return db.Users.Add(user);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public User ValidateUser(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
        }
    }
}