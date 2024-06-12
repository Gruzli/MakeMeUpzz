using MakeMeUpzz.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        private Database1Entities2 db = new Database1Entities2();

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
            makeup.MakeupID = GenerateMakeupId();
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

        private int GenerateMakeupId()
        {
            int lastId = db.Makeups.OrderByDescending(x => x.MakeupID).Select(x => x.MakeupID).FirstOrDefault();
            return lastId + 1;
        }
    }
}
