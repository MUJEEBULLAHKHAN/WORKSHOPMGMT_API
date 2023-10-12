using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ErrorLogRepository
{
    public class ErrorLogRepository:GenericRepository<ErrorLog>,IErrorLogRepository
    {
        public ErrorLogRepository(ApplicationContext Options):base(Options) { }
    }
}
