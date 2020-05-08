using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Kvest.Interfaces;
using DAL_Kvest.Entities;
using DAL_Kvest.EF;
using System.Data.Entity;

namespace DAL_Kvest.Repositories
{
    public class KvestRoomRepository : IRepository<KvestRoom>
    {
        private BDContext db;

        public KvestRoomRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<KvestRoom> GetAll()
        {
            return db.KvestRooms;
        }

        public IEnumerable<KvestRoom> GetName(string name)
        {
            return db.KvestRooms.Where(p => p.Name == name);
        }
        public KvestRoom Get(int id)
        {
            return db.KvestRooms.Find(id);
        }

        public void Create(KvestRoom list)
        {
            db.KvestRooms.Add(list);
        }

        public void Update(KvestRoom list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<KvestRoom> Find(Func<KvestRoom, Boolean> predicate)
        {
            return db.KvestRooms.Include(o => o.Name).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            KvestRoom list = db.KvestRooms.Find(id);
            if (list != null)
                db.KvestRooms.Remove(list);
        }
    }
}
