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
    public class TamamClaimDetails
    {
        [Key]
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public TamamVehicleDetails Vehicle { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public TamamUserDetails User { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public TamamAddressDetails address { get; set;}

        [Column(TypeName ="varchar(50)")]
        public string? status { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Description { get; set; }
      

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
