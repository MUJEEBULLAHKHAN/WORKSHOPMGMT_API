using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class TamamUserDetails
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? EmailId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string VerificationPin { get; set; }

        //public int? AddressId { get; set; }
        //[ForeignKey("AddressId")]
        //public TamamAddressDetails Address { get; set; }

        //public int? VehicleId { get; set; }
        //[ForeignKey("VehicleId")]
        //public TamamVehicleDetails Vehicle { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
