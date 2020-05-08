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
    public class AdministratorRepository : IRepository<Administrator>
    {
        private BDContext db;

        public AdministratorRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<Administrator> GetAll()
        {
            return db.Administrators;
        }

        public IEnumerable<Administrator> GetName(string name)
        {
            return db.Administrators.Where(p => p.Login == name);
        }
        public Administrator Get(int id)
        {
            return db.Administrators.Find(id);
        }

        public void Create(Administrator list)
        {
            db.Administrators.Add(list);
        }

        public void Update(Administrator list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<Administrator> Find(Func<Administrator, Boolean> predicate)
        {
            return db.Administrators.Include(o => o.Login).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Administrator list = db.Administrators.Find(id);
            if (list != null)
                db.Administrators.Remove(list);
        }
    }
}
