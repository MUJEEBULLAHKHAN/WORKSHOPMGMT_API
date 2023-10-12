using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RoleRepository
{
    public class RoleRepository:GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext Options):base(Options) { }

    }
}
