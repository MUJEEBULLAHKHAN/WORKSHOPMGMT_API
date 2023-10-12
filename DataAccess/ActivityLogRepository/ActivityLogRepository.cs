using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ActivityLogRepository
{
    public class ActivityLogRepository:GenericRepository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(ApplicationContext Options) : base(Options)
        {
        }
    }
}
