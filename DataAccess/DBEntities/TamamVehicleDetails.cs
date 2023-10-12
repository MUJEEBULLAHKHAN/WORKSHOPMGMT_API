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
    public class TamamVehicleDetails
    {
       
        [Key]
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? VehicleMake { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? VehicleModel { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string? Year { get; set; }

        public string? Color { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? ChassisNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? PlateNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Odometer { get; set; }

        public bool? IsInsured { get; set; }

        public bool? IsCorporate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
       
    }
}
