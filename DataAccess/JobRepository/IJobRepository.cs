using BusinessLogic.GenericRepository;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.JobRepository
{
    public interface IJobRepository:IGenericRepository<Job>
    {
        Task CreateJob(Job job);
    }
}
