using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Kvest.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int KvestRoomId { get; set; }
        public int OrderId { get; set; }
    }
}
