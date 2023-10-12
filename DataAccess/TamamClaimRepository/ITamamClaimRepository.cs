using BusinessLogic.GenericRepository;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataAccess.TamamClaimRepository
{
    public interface ITamamClaimRepository : IGenericRepository<TamamClaimDetails>
    {
        Task RegisterClaim(TamamClaimDetails claim);
    }
}
