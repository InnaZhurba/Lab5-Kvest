using BLL_Kvest.DTO;
using System.Collections.Generic;

namespace BLL_Kvest.Interfaces
{
    public interface IKvestRoomService
    {
        void MakeKvest(KvestRoomDTO kvestDTO);
        //void EditKvest(KvestRoomDTO kvestDTO);
        IEnumerable<KvestRoomDTO> GetKvests();
        IEnumerable<AgeCategoryDTO> GetAgeCategories();
        IEnumerable<UsersValueDTO> GetUsersValues();
        KvestRoomDTO GetKvest(int? id);
        AgeCategoryDTO GetAgeCategory(int? id);
        UsersValueDTO GetUsersValue(int? id);
        void Dispose();
    }
}
