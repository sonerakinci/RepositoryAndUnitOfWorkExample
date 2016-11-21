using Msdn.DataAccess.Abstract.Repositories;
using Msdn.DataAccess.Abstract.UnitOfWork;
using Msdn.DataAccess.Base.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.DataAccess.Base
{
    public class Worker:IUnitOfWork
    {
        #region Properties

        public DbContext Context { get; set; }
        public ISubscriberRepository Subscribers { get; private set; }
        public IAddressRepository Address { get; private set; }

        #endregion


        public Worker(DbContext context)
        {
            Context = context;

            Subscribers = new SubscriberRepositoy() { Worker=this};
            Address = new AddressRepository() { Worker = this };
        }


        public DbSet<T> CreateDbSetInstance<T>() where T : class
        {
            return Context.Set<T>();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
