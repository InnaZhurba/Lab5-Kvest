using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class Sertificate
    {
        public int Id { get; set; }
        public int SertificateNumber { get; set; }
        public Boolean Shown { get; set; }

        public virtual Order Order { get; set; }
    }
}
