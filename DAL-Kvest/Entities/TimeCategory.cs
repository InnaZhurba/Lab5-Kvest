using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Entities
{
    public class TimeCategory
    {
        public int Id { get; set; }
        public DateTime data { get; set; }
        //public string Day { get; set; }
        //public int Start { get; set; }
        //public int Finish { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}
