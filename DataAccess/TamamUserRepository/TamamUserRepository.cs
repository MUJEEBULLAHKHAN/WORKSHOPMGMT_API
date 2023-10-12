using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using DataAccess.TamamUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TamamUserRepository
{
    public class TamamUserRepository:GenericRepository<TamamUserDetails>, ITamamUserRepository
    {
        public TamamUserRepository(ApplicationContext Options):base(Options) { }
    }
}
