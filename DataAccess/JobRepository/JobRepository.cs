using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataAccess.JobRepository
{
    public class JobRepository:GenericRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationContext Options) : base(Options) { }
        public async Task CreateJob(Job job)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeCreateJob");
                await _context.Job.AddAsync(job);
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("BeforeCreateJob");
                throw ex;
            }
        }
    }
}
