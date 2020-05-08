using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Kvest.Interfaces;
using DAL_Kvest.Entities;
using DAL_Kvest.EF;
using System.Data.Entity;

namespace DAL_Kvest.Entities  
{
    public class AgeCategoryRepository : IRepository<AgeCategory>
    {
        private BDContext db;

        public AgeCategoryRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<AgeCategory> GetAll()
        {
            return db.AgeCategories;
        }

        public IEnumerable<AgeCategory> GetName(string name)
        {
            return db.AgeCategories;
        }
        public AgeCategory Get(int id)
        {
            return db.AgeCategories.Find(id);
        }

        public void Create(AgeCategory list)
        {
            db.AgeCategories.Add(list);
        }

        public void Update(AgeCategory list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<AgeCategory> Find(Func<AgeCategory, Boolean> predicate)
        {
            return db.AgeCategories.Include(o => o.Id).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AgeCategory list = db.AgeCategories.Find(id);
            if (list != null)
                db.AgeCategories.Remove(list);
        }
    }
}
