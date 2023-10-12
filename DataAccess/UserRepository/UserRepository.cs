using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserRepository
{
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext Options): base(Options)
        { 
        }
    }
}
