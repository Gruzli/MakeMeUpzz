using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class UserFactory
    {
        public static User Create(int id, string username, string email, string gender, string password, DateTime dob, string role)
        {
            User user = new User();
            user.UserID = id;
            user.Username = username;
            user.UserGender = gender;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserRole = role;

            return user;
        }
    }
}