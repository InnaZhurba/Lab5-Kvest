using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Kvest.Entities
{
    public class KvestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersValueId { get; set; }
        public int AgeCategoryId { get; set; }
        public int PriceForOneUser { get; set; }
    }
}
