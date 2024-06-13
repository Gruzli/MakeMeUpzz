using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
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
            return db.MakeupBrands.ToList();
        }

        public MakeupBrand GetMakeupBrandById(int id)
        {
            return db.MakeupBrands.Find(id);
        }

        public void AddMakeupBrand(MakeupBrand makeupBrand)
        {
            makeupBrand.MakeupBrandID = GenerateMakeupBrandId();
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
        }

        public void UpdateMakeupBrand(MakeupBrand makeupBrand)
        {
            db.Entry(makeupBrand).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMakeupBrand(int id)
        {
            var makeupBrand = db.MakeupBrands.Find(id);
            if (makeupBrand != null)
            {
                db.MakeupBrands.Remove(makeupBrand);
                db.SaveChanges();
            }
        }

        private int GenerateMakeupBrandId()
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
