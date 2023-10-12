using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class VehicleMake
    {
        public int VehicleMakeId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string VehicleMakeName { get; set; }
        public string VehicleMakeNameAr { get; set; }
        public bool IsActive { get; set; }
    }
}
