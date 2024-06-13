using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
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

        public void UpdateMakeup(Makeup makeup)
        {
            db.Entry(makeup).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMakeup(int id)
        {
            var makeup = db.Makeups.Find(id);
            if (makeup != null)
            {
                db.Makeups.Remove(makeup);
                db.SaveChanges();
            }
        }

        public int GenerateMakeupId()
        {
            int lastId = db.Makeups.OrderByDescending(x => x.MakeupID).Select(x => x.MakeupID).FirstOrDefault();
            return lastId + 1;
        }
    }
}
