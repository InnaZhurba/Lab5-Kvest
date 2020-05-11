using BLL_Kvest.DTO;
using System.Collections.Generic;

namespace BLL_Kvest.Interfaces
{
    public interface IStatusService
    {
        void MakeStatus(StatusDTO kvestDTO);
        void MakeOrder(OrderDTO orderDTO);
        //void MakeSertificate(SertificateDTO sertDTO);
        IEnumerable<StatusDTO> GetStatuses();
        IEnumerable<TimeCategoryDTO> GetTimeCategories();
        IEnumerable<OrderDTO> GetOrders();
        //IEnumerable<SertificateDTO> GetSertifiactes();
        StatusDTO GetStatus(int? id);
        SertificateDTO GetSertificate(int? id);
        OrderDTO GetOrder(int? id);
        void Dispose();
    }
}
