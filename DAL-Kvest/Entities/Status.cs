using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class Status
    {
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int KvestRoomId { get; set; }
        public int OrderId { get; set; }

        public virtual ICollection<TimeCategory> TimeCategories { get; set; }
        public virtual ICollection<KvestRoom> KvestRooms { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
