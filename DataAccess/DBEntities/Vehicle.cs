using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Vehicle
    {
        public Vehicle()
        {
            VehiclePics = new HashSet<VehiclePics>();
        }
        [Key]
        public int VehicleId { get; set; }

        public int? VehicleMakeId { get; set; }
        [ForeignKey("VehicleMakeId")]
        public VehicleMake VehicleMake { get; set; }

        public int? VehicleModelId { get; set; }
        [ForeignKey("VehicleModelId")]
        public VehicleModel VehicleModel { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string Year { get; set; }

        public string? ColorName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? ChassisNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PlateNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Odometer { get; set; }

        public bool? IsInsured { get; set; }

        public bool? IsCorporate { get; set; }
        public bool SpareTyre { get; set; }
        public bool NumberPlates { get; set; }
        public bool CdPlay { get; set; }
        public bool ToolKit { get; set; }
        public bool AirCondition  { get; set; }
        public bool CarKey { get; set; }
        public bool CheckEngineLight { get; set; }
        public bool Batteries { get; set; }
        public bool WheelCaps { get; set; }
        public bool AirbagsLight { get; set; }
        public bool ABSLight { get; set; }
        public bool FloorMats { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
        public ICollection<VehiclePics> VehiclePics { get; set; }
    }
}
