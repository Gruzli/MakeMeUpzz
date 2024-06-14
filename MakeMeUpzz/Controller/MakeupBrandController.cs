using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class MakeupBrandController
    {
        public static string checkMakeupBrandName(string name)
        {
            String response = "";
            if (string.IsNullOrEmpty(name))
            {
                response = "Makeup brand name cannot be empty!";
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                response = "Makeup brand name must be between 1 to 99 characters!";
            }

            return response;
        }

        public static string checkMakeupBrandRating(string rating)
        {
            String response = "";
            bool isNumeric = int.TryParse(rating, out int n);
            if (rating.Length < 1)
            {
                response = "Rating cannot be empty!";
            }
            else if (!isNumeric)
            {
                response = "Rating must be a number!";
            }
            else
            {
                int intRating = Int32.Parse(rating);
                if (intRating < 0 || intRating > 100)
                {
                    response = "Rating must be between 0 - 100!";
                }
            }

            return response;
        }
    }
}