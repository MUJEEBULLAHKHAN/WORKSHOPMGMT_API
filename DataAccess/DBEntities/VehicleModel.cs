using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class VehicleModel
    {
        [Key]
        public int VehicleModelId { get; set; }

        public int? VehicleMakeId { get; set; }
        [ForeignKey("VehicleMakeId")]
        public VehicleMake VehicleMake { get; set;}

        [Column(TypeName = "varchar(50)")]
        public string VehicleModelName { get; set; }
        public string VehicleModelNameAr { get; set; }
        public bool IsActive { get; set; }
    }
}
