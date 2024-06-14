using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class InsertMakeupBrandFactory
    {
        public static MakeupBrand Create(int id, string name, int rating)
        {
            MakeupBrand brand = new MakeupBrand();
            brand.MakeupBrandID = id;
            brand.MakeupBrandName = name;
            brand.MakeupBrandRating = rating;

            return brand;
        }
    }
}