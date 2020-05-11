using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Kvest.DTO;
using BLL_Kvest.Interfaces;
using DAL_Kvest.Entities;
using DAL_Kvest.Interfaces;
using BLL_Kvest.Infostructure;
using AutoMapper;

namespace BLL_Kvest.Services
{
    public class StatusService : IStatusService
    {
        IUnitOfWork Database { get; set; }

        public StatusService(IUnitOfWork data)
        {
            Database = data;
        }
        public void MakeStatus(StatusDTO data)
        {
            TimeCategory dalDataTime = Database.TimeCategories.Get(data.TimeCategoryId);
            Order dalDataOrder = Database.Orders.Get(data.OrderId);
            KvestRoom dalDataKvest = Database.KvestRooms.Get(data.KvestRoomId);

            if (dalDataTime == null || dalDataOrder == null || dalDataKvest ==null)
                throw new ValidationException("Data - status ids` is not found", "");
            Status DATA = new Status
            {
                TimeCategoryId = dalDataTime.Id, 
                OrderId = dalDataOrder.Id, 
                KvestRoomId = dalDataKvest.Id,
            };
            Database.Statuses.Create(DATA);
            Database.Save();
        }
        public void MakeOrder(OrderDTO data)
        {
            Sertificate dalDataSert = Database.Sertificates.Get(data.SertificateId);

            if (dalDataSert == null)
                throw new ValidationException("Data - status ids` is not found", "");
            Order DATA = new Order
            {
                UserName = data.UserName, 
                SertificateId = data.SertificateId, 
                NumberOfUsers = data.NumberOfUsers,
            };
            Database.Orders.Create(DATA);
            Database.Save();
        }
        public IEnumerable<StatusDTO> GetStatuses()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Status>, List<StatusDTO>>(Database.Statuses.GetAll());
        }
        public IEnumerable<TimeCategoryDTO> GetTimeCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimeCategory, TimeCategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TimeCategory>, List<TimeCategoryDTO>>(Database.TimeCategories.GetAll());
        }
        public IEnumerable<OrderDTO> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }
        public StatusDTO GetStatus(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - status id", "");
            var data = Database.Statuses.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new StatusDTO
            {
                Id = data.Id,
                KvestRoomId = data.KvestRoomId,
                OrderId = data.OrderId, 
                TimeCategoryId = data.TimeCategoryId,
            };
        }
        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - status id", "");
            var data = Database.Orders.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new OrderDTO
            {
                Id = data.Id,
                SertificateId = data.SertificateId,
                UserName = data.UserName,
                NumberOfUsers = data.NumberOfUsers,
            };
        }
        public SertificateDTO GetSertificate(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - status id", "");
            var data = Database.Sertificates.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new SertificateDTO
            {
                Id = data.Id,
                SertificateNumber = data.SertificateNumber,
                Shown = data.Shown,
            };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
