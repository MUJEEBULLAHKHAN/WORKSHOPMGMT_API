using BusinessLogic.GenericRepository;
using DataAccess.Context;
using DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ColorRepository
{
    public class ColorRepository:GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationContext Options):base(Options)
        {
        }        
    }
}
