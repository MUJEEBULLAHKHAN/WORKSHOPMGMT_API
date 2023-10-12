using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VehicleViewModel
    {
        public int? VehicleMakeId { get; set; }
        public int? VehicleModelId { get; set; }
        public string Year { get; set; }
        public int? ColorId { get; set; }
        public string ChassisNumber { get; set; }
        public string PlateNumber { get; set; }
        public string Odometer { get; set; }
        public bool IsInsured { get; set; }
        public bool IsCorporate { get; set; }
    }
    public class VehiclePicsViewModel
    {
        public int VehiclePicsId { get; set; }
        public int VehicleId { get; set; }
        public string VehiclePic { get; set; }
        public string PicName { get; set; }
    }
}
