using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class VehiclePics
    {
        [Key]
        public int VehiclePicId { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        [Column(TypeName ="nvarchar(1000)")]
        public string VehiclePic { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
