using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TamamUserViewModel
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? VerificationPin { get; set; }

        //public int? AddressId { get; set; }
        //public int? VehicleId { get; set; }

    }
    public class TamamClaimViewModel
    {
        public int ClaimId { get; set; }
        public int UserId { get; set; }
       
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? Year { get; set; }
        public string? Color { get; set; }
        public string? ChassisNumber { get; set; }
        public string? PlateNumber { get; set; }
        public string? Odometer { get; set; }
        public bool? IsInsured { get; set; }
        public bool? IsCorporate { get; set; }

        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? AreaCode { get; set; }
    }
    public class TamamAddressViewModel
    {
        public int? AddressId { get; set; }
        public int UserId { get; set; }
        public string? Location { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? AreaCode { get; set; }


    }
    public class TamamVehicleViewModel
    {
        public int? VehicleId { get; set; }
        public int UserId { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? Year { get; set; }
        public string? Color { get; set; }
        public string? ChassisNumber { get; set; }
        public string? PlateNumber { get; set; }
        public string? Odometer { get; set; }
        public bool? IsInsured { get; set; }
        public bool? IsCorporate { get; set; }
       

    }
}
