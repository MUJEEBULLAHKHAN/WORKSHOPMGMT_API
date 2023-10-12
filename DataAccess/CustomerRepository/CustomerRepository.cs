using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomerRepository
{
    public class CustomerRepository:GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext options):base(options)
        {
        }
    }
}
