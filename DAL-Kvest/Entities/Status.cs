using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int KvestRoomId { get; set; }
        public int OrderId { get; set; }

        public virtual TimeCategory TimeCategory { get; set; }
        public virtual KvestRoom KvestRoom { get; set; }
        public virtual Order Order { get; set; }
    }
}
