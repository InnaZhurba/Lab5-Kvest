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
    public class TimeCategoryRepository : IRepository<TimeCategory>
    {
        private BDContext db;

        public TimeCategoryRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<TimeCategory> GetAll()
        {
            return db.TimeCategories;
        }

        public IEnumerable<TimeCategory> GetName(string name)
        {
            return db.TimeCategories;
        }
        public TimeCategory Get(int id)
        {
            return db.TimeCategories.Find(id);
        }

        public void Create(TimeCategory list)
        {
            db.TimeCategories.Add(list);
        }

        public void Update(TimeCategory list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<TimeCategory> Find(Func<TimeCategory, Boolean> predicate)
        {
            return db.TimeCategories.Include(o => o.Id).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TimeCategory list = db.TimeCategories.Find(id);
            if (list != null)
                db.TimeCategories.Remove(list);
        }
    }
}
