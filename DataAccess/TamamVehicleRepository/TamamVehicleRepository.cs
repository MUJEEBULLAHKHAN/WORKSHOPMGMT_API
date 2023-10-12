using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TamamVehicleRepository
{
    public class TamamVehicleRepository : GenericRepository<TamamVehicleDetails>, ITamamVehicleRepository
    {
        public TamamVehicleRepository(ApplicationContext Options):base(Options) { }
    }
}
