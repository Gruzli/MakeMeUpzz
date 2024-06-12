using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UserController
    {
        public static String checkUsername(string username)
        {
            String response = "";
            if(string.IsNullOrEmpty(username))
            {
                response = "Username cannot be empty";
            }
            else if(username.Length < 5 ||  username.Length > 15)
            {
                response = "Username must be between 5 to 15 characters!";
            }

            return response;
        }

        public static String checkEmail(string email)
        {
            String response = "";
            if (string.IsNullOrEmpty(email))
            {
                response = "Email cannot be empty!";
            }
            else if (!email.Contains(".com"))
            {
                response = "Email must end with .com";
            }

            return response;
        }

        public static String checkGender(bool gender1, bool gender2)
        {
            String response = "";
            if(!gender1 && !gender2)
            {
                response = "Gender must be chosen and cannot be empty";
            }

            return response;
        }

        public static String checkPassword(string password)
        {
            String response = "";
            if (string.IsNullOrEmpty(password))
            {
                response = "Password cannot be empty!";
            }

            return response;
        }

        public static String checkConfirmPassword(string confirmpassword, string password)
        {
            String response = "";
            if(string.IsNullOrEmpty(confirmpassword))
            {
                response = "Confirmation password cannot be empty!";
            }
            else if(confirmpassword != password)
            {
                response = "Passwords must match!";
            }

            return response;
        }

        public static String checkDOB(string dob)
        {
            String response = "";
            if(string.IsNullOrEmpty(dob))
            {
                response = "Date of birth cannot be empty";
            }

            return response;
        }



    }
}