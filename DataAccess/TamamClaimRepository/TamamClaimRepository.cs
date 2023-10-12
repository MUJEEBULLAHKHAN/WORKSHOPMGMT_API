using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TamamClaimRepository
{
    public class TamamClaimRepository : GenericRepository<TamamClaimDetails>, ITamamClaimRepository
    {
        public TamamClaimRepository(ApplicationContext Options):base(Options) { }

        public async Task RegisterClaim(TamamClaimDetails claim)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeCreateJob");
                await _context.TamamClaim.AddAsync(claim);
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("BeforeCreateJob");
                throw ex;
            }
        }
    }
}
