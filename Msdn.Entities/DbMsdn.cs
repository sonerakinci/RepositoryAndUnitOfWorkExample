using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.Entities
{
    public class DbMsdn:DbContext
    {
        public DbMsdn():base("DbMsdn")
        {

        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
