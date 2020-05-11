using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Kvest.DTO
{
    public class KvestRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersValueId { get; set; }
        public int AgeCategoryId { get; set; }
        public int PriceForOneUser { get; set; }
    }
}
