using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.WorkshopRepository
{
    public class WorkshopRepository : GenericRepository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(ApplicationContext options) : base(options)
        {
        }
    }
}
