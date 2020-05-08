using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class KvestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersValueId { get; set; }
        public int AgeCategory { get; set; }
        public int PriceForOneUser { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<AgeCategory> AgeCategories { get; set; }
        public virtual ICollection<UsersValue> UsersValues { get; set; }
    }
}
