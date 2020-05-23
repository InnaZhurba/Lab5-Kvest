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
    public class UsersValueController : ApiController
    {
        IKvestRoomService kvestroom;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersValueDTO, UsersValue>()).CreateMapper();
        private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<UsersValue, UsersValueDTO>()).CreateMapper();
        public UsersValueController(IKvestRoomService serv)
        {
            kvestroom = serv;
        }
        // GET: api/UsersValue
        [HttpGet]
        public IEnumerable<UsersValue> Get()
        {
            return mapper.Map<IEnumerable<UsersValueDTO>, List<UsersValue>>(kvestroom.GetUsersValues());
        }

        // GET: api/UsersValue/5
        [HttpGet]
        public UsersValue Get(int id)
        {
            return mapper.Map<UsersValueDTO, UsersValue>(kvestroom.GetUsersValue(id));
        }

        // POST: api/UsersValue
        public void Post([FromBody]UsersValue value)
        {
        }

        // PUT: api/UsersValue/5
        public void Put(int id, [FromBody]UsersValue value)
        {
        }

        // DELETE: api/UsersValue/5
        public void Delete(int id)
        {
        }
    }
}
