using AutoMapper;
using BLL_Kvest.DTO;
using BLL_Kvest.Interfaces;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace PL.Controllers
{
    public class SertificateController : ApiController
    {
        IStatusService service;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<SertificateDTO, Sertificate>()).CreateMapper();
        public SertificateController(IStatusService serv)
        {
            service = serv;
        }
        // GET: api/Sertificate
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sertificate/5
        [HttpGet]
        public Sertificate Get(int id)
        {
            return mapper.Map<SertificateDTO, Sertificate>(service.GetSertificate(id));
        }

        // POST: api/Sertificate
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sertificate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sertificate/5
        public void Delete(int id)
        {
        }
    }
}
