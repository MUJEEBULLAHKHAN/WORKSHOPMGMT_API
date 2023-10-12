using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TamamAddressRepository
{
    public class TamamAddressRepository : GenericRepository<TamamAddressDetails>, ITamamAddressRepository
    {
        public TamamAddressRepository(ApplicationContext Options):base(Options) { }
    }
}
