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
    public class OrderController : ApiController
    {
        IStatusService service;
        private IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
        private IMapper mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
        public OrderController(IStatusService serv)
        {
            service = serv;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return mapper.Map<IEnumerable<OrderDTO>, List<Order>>(service.GetOrders());
        }

        // GET: api/Order/5
        [HttpGet]
        public Order Get(int id)
        {
            return mapper.Map<OrderDTO, Order>(service.GetOrder(id));
        }

        // POST: api/Order
        [HttpPost]
        public void Post([FromBody]Order value)
        {
            if(value!=null)
            {
                service.MakeOrder(mapperDTO.Map<Order, OrderDTO>(value));
            }
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
