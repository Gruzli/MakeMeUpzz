using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MakeMeUpzz.Repositories
{
    public class MakeupTypeRepository
    {
        private static Database1Entities2 db = DatabaseSingleton.GetInstance();

        public List<MakeupType> GetAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }

        public MakeupType GetMakeupTypeById(int id)
        {
            return db.MakeupTypes.Find(id);
        }

        public void AddMakeupType(MakeupType makeupType)
        {
            makeupType.MakeupTypeID = GenerateMakeupTypeId();
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }

        public void UpdateMakeupType(MakeupType makeupType)
        {
            db.Entry(makeupType).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMakeupType(int id)
        {
            var makeupType = db.MakeupTypes.Find(id);
            if (makeupType != null)
            {
                db.MakeupTypes.Remove(makeupType);
                db.SaveChanges();
            }
        }

        private int GenerateMakeupTypeId()
        {
            int lastId = db.MakeupTypes.OrderByDescending(x => x.MakeupTypeID).Select(x => x.MakeupTypeID).FirstOrDefault();
            return lastId + 1;
        }

        public MakeupType GetMakeupTypeByName(string name)
        {
            return db.MakeupTypes.Where(x => x.MakeupTypeName == name).FirstOrDefault();
        }
    }
}
