using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Entities
{
    public class KvestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersValueId { get; set; }
        public int AgeCategoryId { get; set; }
        public int PriceForOneUser { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
        public virtual AgeCategory AgeCategory { get; set; }
        public virtual UsersValue UsersValue { get; set; }
    }
}
