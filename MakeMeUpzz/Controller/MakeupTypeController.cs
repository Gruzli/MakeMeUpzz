using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class MakeupTypeController
    {
        public static String checkMakeupTypeName(string name)
        {
            String response = "";
            if (string.IsNullOrEmpty(name))
            {
                response = "Makeup type name cannot be empty!";
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                response = "Makeup type name must be between 1 to 99 characters!";
            }

            return response;
        }
    }
}