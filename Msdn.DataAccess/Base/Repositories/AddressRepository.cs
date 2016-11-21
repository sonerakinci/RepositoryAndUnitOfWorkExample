using Msdn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Msdn.DataAccess.Abstract.Repositories;

namespace Msdn.DataAccess.Base.Repositories
{
    public class AddressRepository: Repository<Address>,IAddressRepository
    {
    }
}
