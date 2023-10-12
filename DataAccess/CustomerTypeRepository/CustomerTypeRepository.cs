using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomerTypeRepository
{
    public class CustomerTypeRepository:GenericRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ApplicationContext Options):base(Options)
        {
        }
    }
}
