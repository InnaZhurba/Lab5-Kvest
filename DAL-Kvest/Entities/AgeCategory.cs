using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Entities
{
    public class AgeCategory
    {
        public int Id { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public virtual ICollection<KvestRoom> KvestRooms { get; set; }
    }
}
