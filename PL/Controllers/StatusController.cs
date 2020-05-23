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
    public class StatusController : ApiController
    {
        IStatusService service;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, Status>()).CreateMapper();
        private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusDTO>()).CreateMapper();
        public StatusController(IStatusService serv)
        {
            service = serv;
        }
        // GET: api/Status
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return mapper.Map<IEnumerable<StatusDTO>, List<Status>>(service.GetStatuses());
        }

        // GET: api/Status/5
        [HttpGet]
        public Status Get(int id)
        {
            return mapper.Map<StatusDTO, Status>(service.GetStatus(id));
        }

        // POST: api/Status
        [HttpPost]
        public void Post([FromBody]Status value)
        {
            if(value!=null)
            {
                service.MakeStatus(mapperDTO.Map<Status, StatusDTO>(value));
            }
        }

        // PUT: api/Status/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Status/5
        public void Delete(int id)
        {
        }
    }
}
