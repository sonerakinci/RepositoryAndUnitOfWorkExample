using Msdn.DataAccess.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.DataAccess.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISubscriberRepository Subscribers { get; }
        IAddressRepository Address { get; }
        int SaveChanges();
    }
}
