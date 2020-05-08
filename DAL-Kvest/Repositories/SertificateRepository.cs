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
    public class SertificateRepository : IRepository<Sertificate>
    {
        private BDContext db;

        public SertificateRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<Sertificate> GetAll()
        {
            return db.Sertificates;
        }

        public IEnumerable<Sertificate> GetName(string name)
        {
            return db.Sertificates;
        }
        public Sertificate Get(int id)
        {
            return db.Sertificates.Find(id);
        }

        public void Create(Sertificate list)
        {
            db.Sertificates.Add(list);
        }

        public void Update(Sertificate list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<Sertificate> Find(Func<Sertificate, Boolean> predicate)
        {
            return db.Sertificates.Include(o => o.Id).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Sertificate list = db.Sertificates.Find(id);
            if (list != null)
                db.Sertificates.Remove(list);
        }
    }
}
