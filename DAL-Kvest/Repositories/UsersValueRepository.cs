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
    public class UsersValueRepository : IRepository<UsersValue>
    {
        private BDContext db;

        public UsersValueRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<UsersValue> GetAll()
        {
            return db.UsersValues;
        }

        public IEnumerable<UsersValue> GetName(string name)
        {
            return db.UsersValues;
        }
        public UsersValue Get(int id)
        {
            return db.UsersValues.Find(id);
        }

        public void Create(UsersValue list)
        {
            db.UsersValues.Add(list);
        }

        public void Update(UsersValue list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<UsersValue> Find(Func<UsersValue, Boolean> predicate)
        {
            return db.UsersValues.Include(o => o.ID).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UsersValue list = db.UsersValues.Find(id);
            if (list != null)
                db.UsersValues.Remove(list);
        }
    }
}
