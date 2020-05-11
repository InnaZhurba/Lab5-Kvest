using BLL_Kvest.DTO;
using BLL_Kvest.Interfaces;
using DAL_Kvest.Entities;
using DAL_Kvest.Interfaces;
using BLL_Kvest.Infostructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL_Kvest.Services
{
    public class KvestRoomService : IKvestRoomService
    {
        IUnitOfWork Database { get; set; }

        public KvestRoomService(IUnitOfWork data)
        {
            Database = data;
        }

        public void MakeKvest(KvestRoomDTO data)
        {
            AgeCategory dalDataAge = Database.AgeCategories.Get(data.AgeCategoryId);
            UsersValue dalDataVal = Database.UsersValues.Get(data.UsersValueId);

            if (dalDataAge == null || dalDataVal == null)
                throw new ValidationException("Data - info/type is not found", "");
            KvestRoom DATA = new KvestRoom
            {
                Name = data.Name,
                UsersValueId = dalDataVal.ID,
                AgeCategoryId = dalDataAge.Id,
            };
            Database.KvestRooms.Create(DATA);
            Database.Save();
        }
        public IEnumerable<KvestRoomDTO> GetKvests()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoom, KvestRoomDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<KvestRoom>, List<KvestRoomDTO>>(Database.KvestRooms.GetAll());
        }

        public IEnumerable<AgeCategoryDTO> GetAgeCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeCategory, AgeCategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AgeCategory>, List<AgeCategoryDTO>>(Database.AgeCategories.GetAll());
        }

        public IEnumerable<UsersValueDTO> GetUsersValues()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersValue, UsersValueDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UsersValue>, List<UsersValueDTO>>(Database.UsersValues.GetAll());
        }

        public KvestRoomDTO GetKvest(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - kvestroom id", "");
            var data = Database.KvestRooms.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new KvestRoomDTO { Id = data.Id, Name = data.Name ,
                AgeCategoryId = data.AgeCategoryId, UsersValueId = data.UsersValueId,
             PriceForOneUser = data.PriceForOneUser,};
        }

        public AgeCategoryDTO GetAgeCategory(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - kvestroom id", "");
            var data = Database.AgeCategories.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new AgeCategoryDTO
            {
                Id = data.Id, max = data.max, min = data.min,
            };
        }

        public UsersValueDTO GetUsersValue(int? id)
        {
            if (id == null)
                throw new ValidationException("It doesn`t exist - kvestroom id", "");
            var data = Database.UsersValues.Get(id.Value);
            if (data == null)
                throw new ValidationException("KvestRoom is not found", "");
            return new UsersValueDTO
            {
                ID = data.ID, max = data.max, min = data.min,
            };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
