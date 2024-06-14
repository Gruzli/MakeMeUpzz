using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class InsertMakeupFactory
    {
        public static Makeup Create(int id, string name, int price, int weight, int typeId, int brandId)
        {
            Makeup makeup = new Makeup();
            makeup.MakeupID = id;
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupTypeID = typeId;
            makeup.MakeupBrandID = brandId;

            return makeup;
        }
    }
}