using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class DatabaseSingleton
    {
        private static Database1Entities2 db = null;

        private DatabaseSingleton()
        {
            
        }

        public static Database1Entities2 GetInstance()
        {
            if (db == null)
            {
                db = new Database1Entities2();
            }
            return db;
        }
    }
}