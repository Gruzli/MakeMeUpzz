using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class TransactionController
    {
        public static String checkTransaction(int total)
        {
            String response = "";
            if (total <= 0)
            {
                response = "Total must be more than 0!";
            }

            return response;
        }
    }
}