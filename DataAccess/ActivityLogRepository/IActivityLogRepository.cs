﻿using BusinessLogic.GenericRepository;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ActivityLogRepository
{
    public interface IActivityLogRepository:IGenericRepository<ActivityLog>
    {
    }
}
