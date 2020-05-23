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
    public class AgeCategoryController : ApiController
    {
        IKvestRoomService kvestroom;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeCategoryDTO, AgeCategory>()).CreateMapper();
        private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<AgeCategory, AgeCategoryDTO>()).CreateMapper();
        public AgeCategoryController(IKvestRoomService serv)
        {
            kvestroom = serv;
        }
        // GET: api/AgeCategory
        [HttpGet]
        public IEnumerable<AgeCategory> Get()
        {
            return mapper.Map<IEnumerable<AgeCategoryDTO>, List<AgeCategory>>(kvestroom.GetAgeCategories()); 
        }
        // GET: api/AgeCategory/5
        [HttpGet]
        public AgeCategory Get(int id)
        {
            return mapper.Map<AgeCategoryDTO, AgeCategory>(kvestroom.GetAgeCategory(id));
        }

        // POST: api/AgeCategory
        [HttpPost]
        public void Post([FromBody]AgeCategory value)
        {
            //if(value!=null)
            //{
            //    kvestroom.
            //}
        }

        // PUT: api/AgeCategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AgeCategory/5
        public void Delete(int id)
        {
        }
    }
}
