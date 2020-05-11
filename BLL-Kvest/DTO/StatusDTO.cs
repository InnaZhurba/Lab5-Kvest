using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Kvest.DTO
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int KvestRoomId { get; set; }
        public int OrderId { get; set; }
    }
}
