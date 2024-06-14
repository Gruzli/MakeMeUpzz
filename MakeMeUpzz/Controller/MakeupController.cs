using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class MakeupController
    {
        public static String checkMakeupName(string name)
        {
            String response = "";
            if (string.IsNullOrEmpty(name))
            {
                response = "Makeup name cannot be empty!";
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                response = "Makeup name must be between 1 to 99 characters!";
            }

            return response;
        }

        public static String checkMakeupPrice(string price)
        {
            String response = "";
            bool isNumeric = int.TryParse(price, out int n);
            if (price.Length < 1)
            {
                response = "Makeup price cannot be empty!";
            }
            else if(!isNumeric)
            {
                response = "Makeup price must be a number!";
            }
            else
            {
                int intPrice = Int32.Parse(price);
                if (intPrice < 1)
                {
                    response = "Makeup price must greater or equals than 1!";
                }
            }

            return response;
        }

        public static String checkMakeupWeight(string weight)
        {
            String response = "";
            bool isNumeric = int.TryParse(weight, out int n);
            if (weight.Length < 1)
            {
                response = "Makeup weight cannot be empty!";
            }
            else if (!isNumeric)
            {
                response = "Makeup weight must be a number!";
            }
            else
            {
                int intWeight = Int32.Parse(weight);
                if (intWeight < 1 || intWeight > 1500)
                {
                    response = "Makeup weight must greater than 0 and must less than 1500 grams!";
                }
            }

            return response;
        }

        public static String checkMakeupTypeID(int typeId)
        {
            String response = "";
            if (typeId < 1)
            {
                response = "Makeup type ID cannot be empty!";
            }

            return response;
        }

        public static String checkMakeupBrandID(int brandId)
        {
            String response = "";
            if (brandId < 1)
            {
                response = "Makeup brand ID cannot be empty!";
            }

            return response;
        }
    }
}