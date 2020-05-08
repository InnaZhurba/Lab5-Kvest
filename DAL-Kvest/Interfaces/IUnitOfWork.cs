using DAL_Kvest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Administrator> Administrators { get; }
        IRepository<AgeCategory> AgeCategories { get; }
        IRepository<KvestRoom> KvestRooms { get; }
        IRepository<Order> Orders { get; }
        IRepository<Sertificate> Sertificates { get; }
        IRepository<Status> Statuses { get; }
        void Save();
        void Dispose();
    }
}
