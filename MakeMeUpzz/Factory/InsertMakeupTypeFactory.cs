using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class InsertMakeupTypeFactory
    {
        public static MakeupType Create(int id, string name)
        {
            MakeupType type = new MakeupType();
            type.MakeupTypeID = id;
            type.MakeupTypeName = name;

            return type;
        }
    }
}