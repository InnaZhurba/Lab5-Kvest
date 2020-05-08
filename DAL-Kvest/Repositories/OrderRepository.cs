using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Kvest.Interfaces;
using DAL_Kvest.Entities;
using DAL_Kvest.EF;
using System.Data.Entity;


namespace DAL_Kvest.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private BDContext db;

        public OrderRepository(BDContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public IEnumerable<Order> GetName(string name)
        {
            return db.Orders;
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order list)
        {
            db.Orders.Add(list);
        }

        public void Update(Order list)
        {
            db.Entry(list).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Id).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order list = db.Orders.Find(id);
            if (list != null)
                db.Orders.Remove(list);
        }
    }
}
