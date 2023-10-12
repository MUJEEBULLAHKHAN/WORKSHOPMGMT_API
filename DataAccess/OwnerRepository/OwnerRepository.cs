using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OwnerRepository
{
    public class OwnerRepository:GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationContext options):base(options)
        {
        }
    }
}
