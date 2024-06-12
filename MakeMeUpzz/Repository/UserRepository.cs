using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private Database1Entities2 db = new Database1Entities2();

        public int generateId()
        {
            int lastId = db.Users.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefault();
            return lastId + 1;
        }

        public void InputRegisterUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool Authentication(string username, string password)
        {
            var users = db.Users.Any(u => u.Username == username && u.UserPassword == password);
            return users;
        }

        public User getUserByUsername(string username)
        {
            var user = db.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }

        public User getUserById(int id)
        {
            var user = db.Users.Where(u => u.UserID == id).FirstOrDefault();
            return user;
        }

        public List<User> getAllUser()
        {
            var users = db.Users.ToList();
            return users;
        }
    }
}