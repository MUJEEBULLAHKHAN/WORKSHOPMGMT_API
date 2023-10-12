using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        public int? UserId { get; set; }
        public int? WorkshopId { get; set; }
        public string? JobDescription { get; set; }
        public int? ActivityLogId { get; set; }
        public int? VehicleMakeId { get; set; }
        public int? VehicleModelId { get; set; }
        public string Year { get; set; }
        public string? ColorName { get; set; }
        public string? ChassisNumber { get; set; }
        public string PlateNumber { get; set; }
        public string? Odometer { get; set; }
        public bool? IsInsured { get; set; }
        public bool? IsCorporate { get; set; }
        public bool SpareTyre { get; set; }
        public bool NumberPlates { get; set; }
        public bool CdPlay { get; set; }
        public bool ToolKit { get; set; }
        public bool AirCondition { get; set; }
        public bool CarKey { get; set; }
        public bool CheckEngineLight { get; set; }
        public bool Batteries { get; set; }
        public bool WheelCaps { get; set; }
        public bool AirbagsLight { get; set; }
        public bool ABSLight { get; set; }
        public bool FloorMats { get; set; }
        public string MobileNo { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string Gender { get; set; }
        public string VehicleVideo { get; set; }
        public int CustomerType { get; set; }
        public DateTime JobCreated { get; set; }
        public List<VehiclePicsViewModel> VehiclePictures { get; set; }
    }
    public class JobDetailsViewModel
    {
        public int JobId { get; set; }
        public int StageId { get; set; }
        public int TotalParts { get; set; }
        public string UserName { get; set; }
        public string? JobDescription { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string? WorkshopAddress { get; set; }
        public string WorkshopName { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string Year { get; set; }
        public string ColorName { get; set; }
        public string ChassisNumber { get; set; }
        public string PlateNumber { get; set; }
        public string Odometer { get; set; }
        public string VehicleParts { get; set; }
        public bool IsInsured { get; set; }
        public bool IsCorporate { get; set; }
        public DateTime JobCreated { get; set; }
        public bool SpareTyre { get; set; }
        public bool NumberPlates { get; set; }
        public bool CdPlay { get; set; }
        public bool ToolKit { get; set; }
        public bool AirCondition { get; set; }
        public bool CarKey { get; set; }
        public bool CheckEngineLight { get; set; }
        public bool Batteries { get; set; }
        public bool WheelCaps { get; set; }
        public bool AirbagsLight { get; set; }
        public bool ABSLight { get; set; }
        public bool FloorMats { get; set; }
        public List<VehiclePicsViewModel> vehiclePictures { get; set; }
        public List<ActivityViewModel> activityViewModels { get; set; }
    }
    public class ActivityViewModel
    {
        public int JobId { get; set; }
        public int StageId { get; set; }
        public string StageName { get; set; }
        public DateTime StartTime { get; set; }
        public string UserName { get; set; }
        public bool? IsJobStarted { get; set; }
    }
    public class GetJobViewModel
    {
        public int JobId { get; set; }
        public string? JobDescription { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string Year { get; set; }
        public string ColorName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
    }
    public class GetKanbanJobViewModel
    {
        public int id { get; set; }
        public string? text { get; set; }
        public string name { get; set; }
        public string column { get; set; }
        public string VehicleMake { get; set; }
    }
    public class TaskInfo
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("EstTime")]
        public string EstTime { get; set; }

        [JsonProperty("EstPrice")]
        public string EstPrice { get; set; }

        [JsonProperty("$$hashKey")]
        public string HashKey { get; set; }
    }
    public class FinalizeJob
    {
        public int JobId { get; set; }
        public int TotalParts { get; set; }
        public double LaborCharge { get; set; }
    }
    public class InvoiceReceipt
    {
        public int JobId { get; set; }
        public int TotalParts { get; set; }
        public string PlateNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string Color { get; set; }
        public DateTime InvDate { get; set; }
        public double LaborCharge { get; set; }
        public double TotalCharge { get; set; }
    }
    // Models/Stage.cs
    public class StageView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobView> Jobs { get; set; }
    }

    // Models/Job.cs
    public class JobView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StageId { get; set; }
        public StageView Stage { get; set; }
    }

}
