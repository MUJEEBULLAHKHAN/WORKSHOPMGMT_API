using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.JobStatusRepository
{
    public class JobStatusRepository:GenericRepository<JobStatus>, IJobStatusRepository
    {
        public JobStatusRepository(ApplicationContext Options) : base(Options) { }
    }
}
