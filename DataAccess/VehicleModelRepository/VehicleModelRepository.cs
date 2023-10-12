using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.VehicleModelRepository
{
    public class VehicleModelRepository:GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(ApplicationContext Options):base(Options) { }
    }
}
