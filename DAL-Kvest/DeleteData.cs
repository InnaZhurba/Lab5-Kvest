using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class DeleteData
    {
        BDContext db = new BDContext();
        public void DeleteSertificate(int sertificateNum)
        {
            using (db)
            {
                Sertificate sert = db.Sertificates
                .Where(o => o.Id == sertificateNum)
                .FirstOrDefault();

                db.Sertificates.Remove(sert);
                db.SaveChanges();
            }
        }
    }
}
