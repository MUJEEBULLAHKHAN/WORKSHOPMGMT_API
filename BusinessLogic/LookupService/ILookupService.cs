using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ViewModels.LookupViewModels;
using ViewModels;

namespace BusinessLogic.LookupService
{
    public interface ILookupService
    {
        Task<ResponseObj<string>> AddColor(ColorViewModel colorViewModel);
        Task<ResponseObj<string>> UpdateColor(ColorViewModel colorViewModel);
        Task<ResponseObj<List<ColorViewModel>>> GetAllColor();
        Task<ResponseObj<ColorViewModel>> GetColorById(int ColorId);
        Task<ResponseObj<string>> DeleteColor(int ColorId);
        Task<ResponseObj<string>> AddJobStatus(JobStatusViewModel jobStatusViewModel);
        Task<ResponseObj<string>> UpdateJobStatus(JobStatusViewModel jobStatusViewModel);
        Task<ResponseObj<List<JobStatusViewModel>>> GetAllJobStatus(string lang);
        Task<ResponseObj<JobStatusViewModel>> GetJobStatusById(int JobStatusId, string lang);
        Task<ResponseObj<string>> DeleteJobStatus(int JobStatusId, string lang);
        Task<ResponseObj<string>> AddRole(RoleViewModel roleViewModel, string lang);
        Task<ResponseObj<string>> UpdateRole(RoleViewModel roleViewModel, string lang);
        Task<ResponseObj<List<RoleViewModel>>> GetAllRole();
        Task<ResponseObj<List<RoleViewModel>>> GetAllRoleByWorkshopId(int WorkshopId);
        Task<ResponseObj<RoleViewModel>> GetRoleById(int RoleId);
        Task<ResponseObj<string>> DeleteRole(int RoleId, string lang);
        Task<ResponseObj<string>> AddStage(StageViewModel stageViewModel, string lang);
        Task<ResponseObj<string>> UpdateStage(StageViewModel stageViewModel, string lang);
        Task<ResponseObj<List<StageViewModel>>> GetAllStage();
        Task<ResponseObj<List<StageViewModel>>> GetAllStageByWorkshopId(int WorkshopId);
        Task<ResponseObj<StageViewModel>> GetStageById(int StageId);
        Task<ResponseObj<string>> DeleteStage(int StageId, string lang);
        Task<ResponseObj<string>> AddVehicleMake(VehicleMakeViewModel vehicleMakeViewModel, string lang);
        Task<ResponseObj<string>> UpdateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel, string lang);
        Task<ResponseObj<List<VehicleMakeViewModel>>> GetAllVehicleMake();
        Task<ResponseObj<VehicleMakeViewModel>> GetVehicleMakeById(int VehicleMakeId);
        Task<ResponseObj<string>> DeleteVehicleMake(int VehicleMakeId, string lang);
        Task<ResponseObj<string>> AddVehicleModel(VehicleModelViewModel vehicleModelViewModel, string lang);
        Task<ResponseObj<string>> UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel, string lang);
        Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModel();
        Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModelByMakeId(int VehicleMakeId);
        Task<ResponseObj<VehicleModelViewModel>> GetVehicleModelById(int VehicleModelId);
        Task<ResponseObj<string>> DeleteVehicleModel(int VehicleModelId, string lang);
        Task<ResponseObj<string>> AddCustomerType(CustomerTypeViewModel customerTypeViewModel, string lang);
        Task<ResponseObj<string>> UpdateCustomerType(CustomerTypeViewModel customerTypeViewModel, string lang);
        Task<ResponseObj<List<CustomerTypeViewModel>>> GetAllCustomerType(string lang);
        Task<ResponseObj<CustomerTypeViewModel>> GetCustomerTypeById(int CustomerTypeId, string lang);
        Task<ResponseObj<string>> DeleteCustomerType(int CustomerTypeId, string lang);
        Task<ResponseObj<List<KanbanStageViewModel>>> GetAllStageForKanbanByWorkshopId(int WorkshopId);
        Task<ResponseObj<TasksResponse>> GetColumns(int WorkshopId);

    }
}
