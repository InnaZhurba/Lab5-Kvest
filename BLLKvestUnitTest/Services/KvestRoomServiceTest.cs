using AutoMapper;
using BLL_Kvest.DTO;
using BLL_Kvest.Infostructure;
using BLL_Kvest.Services;
using DAL_Kvest.Entities;
using DAL_Kvest.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLKvestUnitTest.Services
{
    [TestFixture]
    public class KvestRoomServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        List<KvestRoom> rooms;
        List<UsersValue> users;
        List<AgeCategory> ages;
        UsersValue user;
        AgeCategory age;
        [SetUp]
        public void SetUp()
        {
            rooms = new List<KvestRoom>
            {
                new KvestRoom(){Id = 1, Name ="GamePlay", AgeCategoryId=3, PriceForOneUser=300, UsersValueId=2,},
                new KvestRoom(){Id = 2, Name ="Play", AgeCategoryId=2, PriceForOneUser=500, UsersValueId=3,},
                new KvestRoom(){Id = 3, Name ="Game", AgeCategoryId=1, PriceForOneUser=200, UsersValueId=2,},
                new KvestRoom(){Id = 4, Name ="GP", AgeCategoryId=5, PriceForOneUser=300, UsersValueId=1,}
            };
            ages = new List<AgeCategory>
            {
                new AgeCategory(){Id = 1, max=2, min=1},
                new AgeCategory(){Id = 2, max=3, min=2},
                new AgeCategory(){Id = 3, max=4, min=3}

            };
            users = new List<UsersValue>
            {
                new UsersValue(){ID=1, min=1, max =2},
                new UsersValue(){ID=2, min=2, max =3},
                new UsersValue(){ID=3, min=3, max =4}
            };
            age = new AgeCategory() { Id = 1, max = 5, min = 4 };
            user = new UsersValue() { ID = 2, max = 6, min = 2 };
        }

        [Test]
        public void MakeKvest_IncreaseListCount()
        {
            KvestRoomDTO kvest = new KvestRoomDTO() { Name = "Nut", PriceForOneUser = 200, UsersValueId = 2, AgeCategoryId = 1, };
            mock.Setup(m => m.UsersValues.Get(kvest.UsersValueId)).Returns(user);
            mock.Setup(m => m.AgeCategories.Get(kvest.AgeCategoryId)).Returns(age);
            mock.Setup(m => m.KvestRooms.GetAll()).Returns(rooms);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoomDTO, KvestRoom>()).CreateMapper();
            KvestRoomService service = new KvestRoomService(mock.Object);

            service.MakeKvest(kvest);
            KvestRoom example = mapper.Map<KvestRoomDTO, KvestRoom>(kvest);

            rooms.Add(example);

            mock.Verify(lw => lw.KvestRooms.Create(It.IsAny<KvestRoom>()),
    Times.Once());
            Assert.AreEqual(rooms.Count(), 5);
        }
        [Test]
        public void GetKvests_SuccedReturned()
        {
            mock.Setup(m => m.KvestRooms.GetAll()).Returns(rooms);
            KvestRoomService service = new KvestRoomService(mock.Object);

            IEnumerable<KvestRoomDTO> kvest = service.GetKvests();

            Assert.AreEqual(kvest.Count(), rooms.Count());

        }
        [Test]
        public void GetAgeCategories_SuccedReturned()
        {
            mock.Setup(m => m.AgeCategories.GetAll()).Returns(ages);
            KvestRoomService service = new KvestRoomService(mock.Object);

            IEnumerable<AgeCategoryDTO> example = service.GetAgeCategories();

            Assert.AreEqual(example.Count(), ages.Count());
        }
        [Test]
        public void GetUsersValues_SuccedReturned()
        {
            mock.Setup(m => m.UsersValues.GetAll()).Returns(users);
            KvestRoomService service = new KvestRoomService(mock.Object);

            IEnumerable<UsersValueDTO> example = service.GetUsersValues();

            Assert.AreEqual(example.Count(), users.Count());
        }
        [Test]
        public void GetKvest_ObjectReturn()
        {
            mock.Setup(m => m.KvestRooms.GetAll()).Returns(rooms);
            mock.Setup(m => m.KvestRooms.Get(rooms.ElementAt(0).Id)).Returns(rooms.ElementAt(0));
            KvestRoomService service = new KvestRoomService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoom, KvestRoomDTO>()).CreateMapper();

            KvestRoomDTO kvest = service.GetKvest(1);
            KvestRoomDTO ex = mapper.Map<KvestRoom, KvestRoomDTO>(rooms.ElementAt(0));


            Assert.IsNotNull(kvest);
        }
       
        [Test]
        public void GetAgeCategory_ObjectReturn()
        {
            mock.Setup(m => m.AgeCategories.GetAll()).Returns(ages);
            mock.Setup(m => m.AgeCategories.Get(ages.ElementAt(0).Id)).Returns(ages.ElementAt(0));
            KvestRoomService service = new KvestRoomService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeCategory, AgeCategoryDTO>()).CreateMapper();

            AgeCategoryDTO kvest = service.GetAgeCategory(1);
            //KvestRoomDTO ex = mapper.Map<KvestRoom, KvestRoomDTO>(rooms.ElementAt(0));


            Assert.IsNotNull(kvest);
        }
        [Test]
        public void GetUserValue_ObjectReturn()
        {
            mock.Setup(m => m.UsersValues.GetAll()).Returns(users);
            mock.Setup(m => m.UsersValues.Get(users.ElementAt(0).ID)).Returns(users.ElementAt(0));
            KvestRoomService service = new KvestRoomService(mock.Object);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersValue, UsersValueDTO>()).CreateMapper();

            UsersValueDTO kvest = service.GetUsersValue(1);
            //KvestRoomDTO ex = mapper.Map<KvestRoom, KvestRoomDTO>(rooms.ElementAt(0));


            Assert.IsNotNull(kvest);
        }

        [Test]
        public void GetKvest_ErrorReturn()
        {
            try
            {
                mock.Setup(m => m.KvestRooms.GetAll()).Returns(rooms);
                mock.Setup(m => m.KvestRooms.Get(rooms.ElementAt(0).Id)).Returns(rooms.ElementAt(0));
                KvestRoomService service = new KvestRoomService(mock.Object);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoom, KvestRoomDTO>()).CreateMapper();

                KvestRoomDTO kvest = service.GetKvest(77);
                //KvestRoomDTO ex = mapper.Map<KvestRoom, KvestRoomDTO>(rooms.ElementAt(0));

                Assert.Fail();
            }
            catch (ValidationException) { }
           
        }
    }
}
