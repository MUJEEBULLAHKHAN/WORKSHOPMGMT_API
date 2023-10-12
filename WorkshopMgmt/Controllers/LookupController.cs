using BusinessLogic.LookupService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ViewModels.LookupViewModels;
using ViewModels;

namespace WorkshopMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }
        [HttpPost("AddColor")]
        public async Task<ResponseObj<string>> AddColor(ColorViewModel colorViewModel)
            => await _lookupService.AddColor(colorViewModel);
        [HttpPost("UpdateColor")]
        public async Task<ResponseObj<string>> UpdateColor(ColorViewModel colorViewModel)
            => await _lookupService.UpdateColor(colorViewModel);
        [HttpGet("GetAllColor")]
        public async Task<ResponseObj<List<ColorViewModel>>> GetAllColor()
            => await _lookupService.GetAllColor();
        [HttpGet("GetColorById")]
        public async Task<ResponseObj<ColorViewModel>> GetColorById(int ColorId)
            => await _lookupService.GetColorById(ColorId);
        [HttpGet("DeleteColor")]
        public async Task<ResponseObj<string>> DeleteColor(int ColorId)
            => await _lookupService.DeleteColor(ColorId);
        [HttpPost("AddJobStatus")]
        public async Task<ResponseObj<string>> AddJobStatus(JobStatusViewModel jobStatusViewModel)
            => await _lookupService.AddJobStatus(jobStatusViewModel);
        [HttpPost("UpdateJobStatus")]
        public async Task<ResponseObj<string>> UpdateJobStatus(JobStatusViewModel jobStatusViewModel)
            => await _lookupService.UpdateJobStatus(jobStatusViewModel);
        [HttpGet("GetAllJobStatus")]
        public async Task<ResponseObj<List<JobStatusViewModel>>> GetAllJobStatus()
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.GetAllJobStatus(lang);
        }
        [HttpGet("GetJobStatusById")]
        public async Task<ResponseObj<JobStatusViewModel>> GetJobStatusById(int JobStatusId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.GetJobStatusById(JobStatusId, lang);
        }
        [HttpGet("DeleteJobStatus")]
        public async Task<ResponseObj<string>> DeleteJobStatus(int JobStatusId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteJobStatus(JobStatusId, lang);
        }
        [HttpPost("AddRole")]
        public async Task<ResponseObj<string>> AddRole(RoleViewModel roleViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.AddRole(roleViewModel, lang);
        }
        [HttpPost("UpdateRole")]
        public async Task<ResponseObj<string>> UpdateRole(RoleViewModel roleViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.UpdateRole(roleViewModel, lang);
        }
        [HttpGet("GetAllRole")]
        public async Task<ResponseObj<List<RoleViewModel>>> GetAllRole()
       => await _lookupService.GetAllRole();
        
        [HttpGet("GetAllRoleByWorkshopId")]
        public async Task<ResponseObj<List<RoleViewModel>>> GetAllRoleByWorkshopId(int WorkshopId)
        => await _lookupService.GetAllRoleByWorkshopId(WorkshopId);
        
        [HttpGet("GetRoleById")]
        public async Task<ResponseObj<RoleViewModel>> GetRoleById(int RoleId)        
            => await _lookupService.GetRoleById(RoleId);
        
        [HttpGet("DeleteRole")]
        public async Task<ResponseObj<string>> DeleteRole(int RoleId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteRole(RoleId, lang);
        }
        [HttpPost("AddStage")]
        public async Task<ResponseObj<string>> AddStage(StageViewModel stageViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.AddStage(stageViewModel, lang);
        }
        [HttpPost("UpdateStage")]
        public async Task<ResponseObj<string>> UpdateStage(StageViewModel stageViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.UpdateStage(stageViewModel, lang);
        }
        [HttpGet("GetAllStage")]
        public async Task<ResponseObj<List<StageViewModel>>> GetAllStage()
        => await _lookupService.GetAllStage();
        
        [HttpGet("GetAllStageWithJob")]
        public async Task<ResponseObj<TasksResponse>> GetAllStageWithJob(int WorkshopId)

            => await _lookupService.GetColumns(WorkshopId);

        [HttpGet("GetAllStageByWorkshopId")]
        public async Task<ResponseObj<List<StageViewModel>>> GetAllStageByWorkshopId(int WorkshopId)
        => await _lookupService.GetAllStageByWorkshopId(WorkshopId);
        
        [HttpGet("GetAllStageForKanbanByWorkshopId")]
        public async Task<ResponseObj<List<KanbanStageViewModel>>> GetAllStageForKanbanByWorkshopId(int WorkshopId)
            => await _lookupService.GetAllStageForKanbanByWorkshopId(WorkshopId);
        [HttpGet("GetStageById")]
        public async Task<ResponseObj<StageViewModel>> GetStageById(int StageId)
            => await _lookupService.GetStageById(StageId);
        [HttpGet("DeleteStage")]
        public async Task<ResponseObj<string>> DeleteStage(int StageId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteStage(StageId, lang);
        }
        [HttpPost("AddVehicleMake")]
        public async Task<ResponseObj<string>> AddVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.AddVehicleMake(vehicleMakeViewModel, lang);
        }
        [HttpPost("UpdateVehicleMake")]
        public async Task<ResponseObj<string>> UpdateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.UpdateVehicleMake(vehicleMakeViewModel, lang);
        }
        [HttpGet("GetAllVehicleMake")]
        public async Task<ResponseObj<List<VehicleMakeViewModel>>> GetAllVehicleMake()
        =>await _lookupService.GetAllVehicleMake();
        
        [HttpGet("GetVehicleMakeById")]
        public async Task<ResponseObj<VehicleMakeViewModel>> GetVehicleMakeById(int VehicleMakeId)
        => await _lookupService.GetVehicleMakeById(VehicleMakeId);
        
        [HttpGet("DeleteVehicleMake")]
        public async Task<ResponseObj<string>> DeleteVehicleMake(int VehicleMakeId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteVehicleMake(VehicleMakeId, lang);
        }
        [HttpPost("AddVehicleModel")]
        public async Task<ResponseObj<string>> AddVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.AddVehicleModel(vehicleModelViewModel, lang);
        }
        [HttpPost("UpdateVehicleModel")]
        public async Task<ResponseObj<string>> UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.UpdateVehicleModel(vehicleModelViewModel, lang);
        }
        [HttpGet("GetAllVehicleModel")]
        public async Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModel()
        => await _lookupService.GetAllVehicleModel();
        
        [HttpGet("GetAllVehicleModelByMakeId")]
        public async Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModelByMakeId(int VehicleMakeId)
        =>await _lookupService.GetAllVehicleModelByMakeId(VehicleMakeId);
        
        [HttpGet("GetVehicleModelById")]
        public async Task<ResponseObj<VehicleModelViewModel>> GetVehicleModelById(int VehicleModelId)
        =>await _lookupService.GetVehicleModelById(VehicleModelId);
        
        [HttpGet("DeleteVehicleModel")]
        public async Task<ResponseObj<string>> DeleteVehicleModel(int VehicleModelId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteVehicleModel(VehicleModelId, lang);
        }
        [HttpPost("AddCustomerType")]
        public async Task<ResponseObj<string>> AddCustomerType(CustomerTypeViewModel customerTypeViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.AddCustomerType(customerTypeViewModel, lang);
        }
        [HttpPost("UpdateCustomerType")]
        public async Task<ResponseObj<string>> UpdateCustomerType(CustomerTypeViewModel customerTypeViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.UpdateCustomerType(customerTypeViewModel, lang);
        }
        [HttpGet("GetAllCustomerType")]
        public async Task<ResponseObj<List<CustomerTypeViewModel>>> GetAllCustomerType()
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.GetAllCustomerType(lang);
        }
        [HttpGet("GetCustomerTypeById")]
        public async Task<ResponseObj<CustomerTypeViewModel>> GetCustomerTypeById(int CustomerTypeId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.GetCustomerTypeById(CustomerTypeId,lang);
        }
        [HttpGet("DeleteCustomerType")]
        public async Task<ResponseObj<string>> DeleteCustomerType(int CustomerTypeId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _lookupService.DeleteCustomerType(CustomerTypeId,lang);
        }

    }
}
