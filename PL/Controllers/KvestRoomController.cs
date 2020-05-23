using AutoMapper;
using BLL_Kvest.DTO;
using BLL_Kvest.Interfaces;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PL.Controllers
{
    public class KvestRoomController : ApiController
    {
        IKvestRoomService kvestroom;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoomDTO, KvestRoom>()).CreateMapper();
        private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoom, KvestRoomDTO>()).CreateMapper();
        public KvestRoomController(IKvestRoomService serv)
        {
            kvestroom = serv;
        }
        // GET: api/KvestRoom
        [HttpGet]
        public IEnumerable<KvestRoom> Get()
        {           
            return mapper.Map<IEnumerable<KvestRoomDTO>, List<KvestRoom>>(kvestroom.GetKvests());
        }

        // GET: api/KvestRoom/5
        [HttpGet]
        public KvestRoom Get(int id)
        {
            return mapper.Map<KvestRoomDTO, KvestRoom>(kvestroom.GetKvest(id));
        }

        // POST: api/KvestRoom
        [HttpPost]
        public void Post([FromBody]KvestRoom value)
        {
            if (value != null)
            {
                kvestroom.MakeKvest(mapperDTO.Map<KvestRoom, KvestRoomDTO>(value));
            }
        }

        // PUT: api/KvestRoom/5
        public void Put([FromBody]KvestRoom value)
        {
           
        }

        // DELETE: api/KvestRoom/5
        public void Delete(int id)
        {
        }
    }
}
