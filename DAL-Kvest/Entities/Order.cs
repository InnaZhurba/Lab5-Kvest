using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SertificateId { get; set; }
        public int NumberOfUsers { get; set; }

        public virtual ICollection<Sertificate> Sertificate { get; set; }
        public virtual Status Status { get; set; }
    }
}
