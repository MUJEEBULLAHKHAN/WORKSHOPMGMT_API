using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.VehicleMakeRepository
{
    public class VehicleMakeRepository:GenericRepository<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(ApplicationContext Options):base(Options) { }
    }
}
