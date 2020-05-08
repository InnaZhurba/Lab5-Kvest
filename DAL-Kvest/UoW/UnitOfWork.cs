using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Kvest.Entities;
using DAL_Kvest.EF;
using DAL_Kvest.Interfaces;
using DAL_Kvest.Repositories;

namespace DAL_Kvest.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private BDContext db;
        private AdministratorRepository adminRepository;
        private AgeCategoryRepository ageRepository;
        private KvestRoomRepository roomRepository;
        private OrderRepository orderRepository;
        private SertificateRepository sertRepository;
        private StatusRepository statusRepository;
        private TimeCategoryRepository timeRepository;
        private UsersValueRepository valRepository;

        public UnitOfWork()
        {
            db = new BDContext();
        }

        public IRepository<Administrator> Administrators
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdministratorRepository(db);
                return adminRepository;
            }
        }
        public IRepository<AgeCategory> AgeCategories
        {
            get
            {
                if (ageRepository == null)
                    ageRepository = new AgeCategoryRepository(db);
                return ageRepository;
            }
        }
        public IRepository<KvestRoom> KvestRooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new KvestRoomRepository(db);
                return roomRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<Sertificate> Sertificates
        {
            get
            {
                if (sertRepository == null)
                    sertRepository = new SertificateRepository(db);
                return sertRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }
        public IRepository<TimeCategory> TimeCategories
        {
            get
            {
                if (timeRepository == null)
                    timeRepository = new TimeCategoryRepository(db);
                return timeRepository;
            }
        }
        public IRepository<UsersValue> UsersValues
        {
            get
            {
                if (valRepository == null)
                    valRepository = new UsersValueRepository(db);
                return valRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
