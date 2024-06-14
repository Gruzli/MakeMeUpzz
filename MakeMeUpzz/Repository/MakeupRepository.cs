using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        private static Database1Entities2 db = DatabaseSingleton.GetInstance();

        public List<Makeup> GetAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public Makeup GetMakeupById(int id)
        {
            return db.Makeups.Find(id);
        }

        public void AddMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public void UpdateMakeup(int id, string name, int price, int weight, MakeupType type, MakeupBrand brand)
        {
            Makeup makeup = db.Makeups.Find(id);
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupType = type;
            makeup.MakeupBrand = brand;

            db.SaveChanges();
        }

        public string DeleteMakeup(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            String response = "";
            bool isUsed = db.Carts.Any(x => x.MakeupID == id) || 
                          db.TransactionDetails.Any(x => x.MakeupID == id);
            if (makeup != null && !isUsed)
            {
                db.Makeups.Remove(makeup);
                db.SaveChanges();
                response = "Makeup has been deleted!";
            }
            else
            {
                response = "Please check the used makeup first!";
            }
            return response;
        }

        public int GenerateMakeupId()
        {
            int lastId = db.Makeups.OrderByDescending(x => x.MakeupID).Select(x => x.MakeupID).FirstOrDefault();
            return lastId + 1;
        }
    }
}
