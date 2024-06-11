using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeMeUpzz.Model;

namespace MakeMeUpzz.Factory
{
    public class RegisterUserFactory
    {
        public static User Create(int id, string username, string gender, string password, string email, DateTime dob, string role)
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