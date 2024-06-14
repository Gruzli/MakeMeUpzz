using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MakeMeUpzz.Repositories
{
    public class MakeupBrandRepository
    {
        private static Database1Entities2 db = DatabaseSingleton.GetInstance();

        public List<MakeupBrand> GetAllMakeupBrands()
        {
            // Return all makeup brands descending based on rating
            return db.MakeupBrands.OrderByDescending(x => x.MakeupBrandRating).ToList();
        }

        public MakeupBrand GetMakeupBrandById(int id)
        {
            return db.MakeupBrands.Find(id);
        }

        public void AddMakeupBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
        }

        public void UpdateMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            makeupBrand.MakeupBrandName = name;
            makeupBrand.MakeupBrandRating = rating;

            db.SaveChanges();
        }

        public string DeleteMakeupBrand(int id)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            String response = "";
            bool isUsed = db.Makeups.Any(x => x.MakeupBrandID == id);
            if (makeupBrand != null && !isUsed)
            {
                db.MakeupBrands.Remove(makeupBrand);
                db.SaveChanges();
                response = "Makeup brand has been deleted!";
            }
            else
            {
                response = "Please check the used brand first!";
            }
            return response;
        }

        public int GenerateMakeupBrandId()
        {
            int lastId = db.MakeupBrands.OrderByDescending(x => x.MakeupBrandID).Select(x => x.MakeupBrandID).FirstOrDefault();
            return lastId + 1;
        }

        public MakeupBrand GetMakeupBrandByName(string name)
        {
            return db.MakeupBrands.Where(x => x.MakeupBrandName == name).FirstOrDefault();
        }
    }
}
