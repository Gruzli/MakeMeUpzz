using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
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
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }

        public void UpdateMakeupType(int typeId, string typeName)
        {
            MakeupType makeupType = db.MakeupTypes.Find(typeId);
            makeupType.MakeupTypeName = typeName;

            db.SaveChanges();
        }

        public string DeleteMakeupType(int id)
        {
            MakeupType makeupType = db.MakeupTypes.Find(id);
            String response = "";
            bool isUsed = db.Makeups.Any(x => x.MakeupTypeID == id);
            if (makeupType != null && !isUsed)
            {
                db.MakeupTypes.Remove(makeupType);
                db.SaveChanges();
                response = "Makeup type has been deleted!";
            }
            else
            {
                response = "Please check the used type first!";
            }
            return response;
        }

        public int GenerateMakeupTypeId()
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
