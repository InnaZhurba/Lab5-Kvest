using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SertificateId { get; set; }
        public int NumberOfUsers { get; set; }

        public virtual Sertificate Sertificate { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}
