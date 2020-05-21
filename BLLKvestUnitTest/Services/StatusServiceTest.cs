using AutoMapper;
using BLL_Kvest.DTO;
using BLL_Kvest.Services;
using DAL_Kvest.Entities;
using DAL_Kvest.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLLKvestUnitTest.Services
{
    [TestFixture]
    class StatusServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        List<Status> statuses;
        List<Order> orders;
        List<TimeCategory> times;
        List<Sertificate> serts;
        KvestRoom kvestroom;
        TimeCategory time;
        Sertificate sert;

        [SetUp]
        public void SetUp()
        {
            times = new List<TimeCategory>
            {
                new TimeCategory(){Id=1,},
                new TimeCategory(){Id=2,},
                new TimeCategory(){Id=3,},
                new TimeCategory(){Id=4,},
            };
            statuses = new List<Status>
            {
                new Status(){Id=1, OrderId = 1, KvestRoomId=1, TimeCategoryId=1},
                new Status(){Id=2, OrderId = 2, KvestRoomId=1, TimeCategoryId=4},
                new Status(){Id=3, OrderId = 3, KvestRoomId=2, TimeCategoryId=3},
                new Status(){Id=4, OrderId = 4, KvestRoomId=3, TimeCategoryId=2},
            };
            orders = new List<Order>
            {
                new Order (){Id = 1, SertificateId = 1, UserName="Inna", NumberOfUsers=5,},
                new Order (){Id = 2, SertificateId = 5, UserName="Igor", NumberOfUsers=3,},
                new Order (){Id = 3, SertificateId = 6, UserName="Anna", NumberOfUsers=10,},
            };
            serts = new List<Sertificate>
            {
                new Sertificate(){Id=1, SertificateNumber=3,},
                new Sertificate(){Id=2, SertificateNumber=25,},
                new Sertificate(){Id=3, SertificateNumber=44,},
            };
            kvestroom = new KvestRoom() { Id = 1, AgeCategoryId = 1, UsersValueId = 1, Name = "GP", PriceForOneUser = 200 };
            time = new TimeCategory() { Id = 1,};
            sert = new Sertificate() { Id = 1, SertificateNumber = 33, };
        }
        [Test]
        public void MakeStatus_SuccedReturned()
        {
            StatusDTO status = new StatusDTO() { OrderId = 1, KvestRoomId = 1, TimeCategoryId = 1 };
            mock.Setup(m => m.KvestRooms.Get(status.KvestRoomId)).Returns(kvestroom);
            mock.Setup(m => m.TimeCategories.Get(status.TimeCategoryId)).Returns(time);
            mock.Setup(m => m.Orders.Get(status.OrderId)).Returns(orders.ElementAt(0));
            mock.Setup(m => m.Statuses.GetAll()).Returns(statuses);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, Status>()).CreateMapper();
            StatusService service = new StatusService(mock.Object);

            service.MakeStatus(status);
            Status example = mapper.Map<StatusDTO, Status>(status);

            statuses.Add(example);

            mock.Verify(lw => lw.Statuses.Create(It.IsAny<Status>()),
    Times.Once());
            Assert.AreEqual(statuses.Count(), 5);
        }
        [Test]
        public void MakeOrder_SuccedReturned()
        {
            OrderDTO status = new OrderDTO() { NumberOfUsers=7, SertificateId=1, UserName="Oleg"};
            mock.Setup(m => m.Sertificates.Get(status.SertificateId)).Returns(sert);
            mock.Setup(m => m.Orders.GetAll()).Returns(orders);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            StatusService service = new StatusService(mock.Object);

            service.MakeOrder(status);
            Order example = mapper.Map<OrderDTO, Order>(status);

            orders.Add(example);

            mock.Verify(lw => lw.Orders.Create(It.IsAny<Order>()),
    Times.Once());
            Assert.AreEqual(orders.Count(), 4);
        }
        [Test]
        public void GetSTatuses_ListReturnedNotNull()
        {
            mock.Setup(m => m.Statuses.GetAll()).Returns(statuses);
            StatusService service = new StatusService(mock.Object);

            IEnumerable<StatusDTO> status = service.GetStatuses();

            Assert.AreEqual(status.Count(), statuses.Count());
        }
        [Test]
        public void GetTimeCategories_ListReturnedNotNull()
        {
            mock.Setup(m => m.TimeCategories.GetAll()).Returns(times);
            StatusService service = new StatusService(mock.Object);

            IEnumerable<TimeCategoryDTO> status = service.GetTimeCategories();

            Assert.AreEqual(status.Count(), times.Count());
            Assert.IsNotNull(status);
        }
        [Test]
        public void GetOrders_ListReturned_NotNull()
        {
            mock.Setup(m => m.Orders.GetAll()).Returns(orders);
            StatusService service = new StatusService(mock.Object);

            IEnumerable<OrderDTO> status = service.GetOrders();

            Assert.AreEqual(status.Count(), orders.Count());
            Assert.IsNotNull(status);
        }
        [Test]
        public void GetStatus_ValueReturned_NotNull()
        {
            mock.Setup(m => m.Statuses.GetAll()).Returns(statuses);
            mock.Setup(m => m.Statuses.Get(statuses.ElementAt(0).Id)).Returns(statuses.ElementAt(0));
            StatusService service = new StatusService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusDTO>()).CreateMapper();

            StatusDTO kvest = service.GetStatus(1);
            StatusDTO ex = mapper.Map<Status, StatusDTO>(statuses.ElementAt(0));

            Assert.IsNotNull(kvest);
        }
        [Test]
        public void GetOrder_ValueReturned_NotNull()
        {
            mock.Setup(m => m.Orders.GetAll()).Returns(orders);
            mock.Setup(m => m.Orders.Get(orders.ElementAt(0).Id)).Returns(orders.ElementAt(0));
            StatusService service = new StatusService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();

            OrderDTO kvest = service.GetOrder(1);
            OrderDTO ex = mapper.Map<Order, OrderDTO>(orders.ElementAt(0));

            Assert.IsNotNull(kvest);
        }
        [Test]
        public void GetSertificate_ValueReturned_NotNull()
        {
            mock.Setup(m => m.Sertificates.GetAll()).Returns(serts);
            mock.Setup(m => m.Sertificates.Get(serts.ElementAt(0).Id)).Returns(sert);
            StatusService service = new StatusService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sertificate, SertificateDTO>()).CreateMapper();

            SertificateDTO kvest = service.GetSertificate(1);
            SertificateDTO ex = mapper.Map<Sertificate, SertificateDTO>(sert);

            Assert.IsNotNull(kvest);
        }
    }
}
