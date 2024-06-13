using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private static Database1Entities2 db = DatabaseSingleton.GetInstance();

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

        public void UpdateDataUser(int id, string name, string gender, string password, string email, DateTime dob, string role)
        {
            User user = db.Users.Find(id);
            user.UserID = id;
            user.Username = name;
            user.UserGender = gender;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserRole = role;

            db.SaveChanges();
        }

        public void UpdatePasswordUser(int id, string new_password)
        {
            User user = db.Users.Find(id);
            user.UserID = id;
            user.UserPassword = new_password;

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