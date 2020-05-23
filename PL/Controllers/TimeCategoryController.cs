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
    public class TimeCategoryController : ApiController
    {
        IStatusService service;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimeCategoryDTO, TimeCategory>()).CreateMapper();
        //private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<TimeCategory, TimeCategoryDTO>()).CreateMapper();
        public TimeCategoryController(IStatusService serv)
        {
            service = serv;
        }
        // GET: api/TimeCategory
        [HttpGet]
        public IEnumerable<TimeCategory> Get()
        {
            return mapper.Map<IEnumerable<TimeCategoryDTO>, List<TimeCategory>>(service.GetTimeCategories());
        }

        // GET: api/TimeCategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TimeCategory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TimeCategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TimeCategory/5
        public void Delete(int id)
        {
        }
    }
}
