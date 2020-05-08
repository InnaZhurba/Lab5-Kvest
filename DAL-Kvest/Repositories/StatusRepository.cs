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
    public class StatusRepository : IRepository<Status>
    {
        private BDContext db;

        public StatusRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Statuses;
        }

        public IEnumerable<Status> GetName(string name)
        {
            return db.Statuses;
        }
        public Status Get(int id)
        {
            return db.Statuses.Find(id);
        }

        public void Create(Status list)
        {
            db.Statuses.Add(list);
        }

        public void Update(Status list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<Status> Find(Func<Status, Boolean> predicate)
        {
            return db.Statuses.Include(o => o.Id).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Status list = db.Statuses.Find(id);
            if (list != null)
                db.Statuses.Remove(list);
        }
    }
}
