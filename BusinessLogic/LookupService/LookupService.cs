using BusinessLogic.CommonService;
using BusinessLogic.UnitOfWork;
using DataAccess.DBEntities;
using FluentValidation;
using FluentValidation.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using static Azure.Core.HttpHeader;
using static ViewModels.LookupViewModels;

namespace BusinessLogic.LookupService
{
    public class LookupService : ILookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public LookupService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }
        public async Task<ResponseObj<string>> AddColor(ColorViewModel colorViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                ColorValidator validationRules = new ColorValidator();
                var ValidatorResult = validationRules.Validate(colorViewModel);
                if (ValidatorResult.IsValid)
                {
                    Color color = new Color();
                    color.ColorName = colorViewModel.ColorName;
                    color.IsActive = true;
                    await _unitOfWork.ColorRepository.Add(color);
                    await _unitOfWork.Complete();
                    responseObj.Message = "Color Added";
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateColor(ColorViewModel colorViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                ColorValidator validationRules = new ColorValidator();
                var ValidatorResult = validationRules.Validate(colorViewModel);
                if (ValidatorResult.IsValid)
                {
                    var colorDetails = await _unitOfWork.ColorRepository.GetWithTracking().Where(x => x.ColorId == colorViewModel.ColorId && x.IsActive).FirstOrDefaultAsync();
                    if (colorDetails != null)
                    {
                        colorDetails.ColorName = colorViewModel.ColorName;
                        await _unitOfWork.ColorRepository.Update(colorDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = "Color Updated";
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = "No Color Found";
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<ColorViewModel>>> GetAllColor()
        {
            ResponseObj<List<ColorViewModel>> responseObj = new ResponseObj<List<ColorViewModel>>();
            try
            {
                var Colors = await _unitOfWork.ColorRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.ColorId)
                    .Select(x => new ColorViewModel
                    {
                        ColorId = x.ColorId,
                        ColorName = x.ColorName
                    }).ToListAsync();
                if (Colors.Count() > 0)
                {
                    responseObj.Data = Colors;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Colors";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<ColorViewModel>> GetColorById(int ColorId)
        {
            ResponseObj<ColorViewModel> responseObj = new ResponseObj<ColorViewModel>();
            try
            {
                var ColorDetails = await _unitOfWork.ColorRepository.GetWithoutTracking()
                    .Where(x => x.ColorId == ColorId && x.IsActive).Select(x => new ColorViewModel
                    {
                        ColorId = x.ColorId,
                        ColorName = x.ColorName
                    }).FirstOrDefaultAsync();
                if (ColorDetails != null)
                {
                    responseObj.Data = ColorDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Color Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteColor(int ColorId)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveColor = await _unitOfWork.ColorRepository.GetWithTracking().Where(x => x.ColorId == ColorId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveColor != null)
                {
                    RemoveColor.IsActive = false;
                    await _unitOfWork.ColorRepository.Update(RemoveColor);
                    await _unitOfWork.Complete();
                    responseObj.Message = "Color Deleted Successfully";
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No Color Found";
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddJobStatus(JobStatusViewModel jobStatusViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                JobStatusValidator validationRules = new JobStatusValidator();
                var ValidatorResult = validationRules.Validate(jobStatusViewModel);
                if (ValidatorResult.IsValid)
                {
                    JobStatus jobStatus = new JobStatus();
                    jobStatus.JobStatusName = jobStatusViewModel.JobStatusName;
                    jobStatus.IsActive = true;
                    await _unitOfWork.JobStatusRepository.Add(jobStatus);
                    await _unitOfWork.Complete();
                    responseObj.Message = "JobStatus Added";
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateJobStatus(JobStatusViewModel jobStatusViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                JobStatusValidator validationRules = new JobStatusValidator();
                var ValidatorResult = validationRules.Validate(jobStatusViewModel);
                if (ValidatorResult.IsValid)
                {
                    var jobStatusDetails = await _unitOfWork.JobStatusRepository.GetWithTracking().Where(x => x.JobStatusId == jobStatusViewModel.JobStatusId && x.IsActive).FirstOrDefaultAsync();
                    if (jobStatusDetails != null)
                    {
                        jobStatusDetails.JobStatusName = jobStatusViewModel.JobStatusName;
                        await _unitOfWork.JobStatusRepository.Update(jobStatusDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = "JobStatus Updated";
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = "No JobStatus Found";
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<JobStatusViewModel>>> GetAllJobStatus(string lang)
        {
            ResponseObj<List<JobStatusViewModel>> responseObj = new ResponseObj<List<JobStatusViewModel>>();
            try
            {
                var JobStatuss = await _unitOfWork.JobStatusRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.JobStatusId)
                    .Select(x => new JobStatusViewModel
                    {
                        JobStatusId = x.JobStatusId,
                        JobStatusName = lang == "ar" ? x.JobStatusNameAr : x.JobStatusName
                    }).ToListAsync();
                if (JobStatuss.Count() > 0)
                {
                    responseObj.Data = JobStatuss;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of JobStatuss";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<JobStatusViewModel>> GetJobStatusById(int JobStatusId, string lang)
        {
            ResponseObj<JobStatusViewModel> responseObj = new ResponseObj<JobStatusViewModel>();
            try
            {
                var jobStatusDetails = await _unitOfWork.JobStatusRepository.GetWithoutTracking()
                    .Where(x => x.JobStatusId == JobStatusId && x.IsActive).Select(x => new JobStatusViewModel
                    {
                        JobStatusId = x.JobStatusId,
                        JobStatusName = lang == "ar" ? x.JobStatusNameAr : x.JobStatusName
                    }).FirstOrDefaultAsync();
                if (jobStatusDetails != null)
                {
                    responseObj.Data = jobStatusDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "JobStatus Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteJobStatus(int JobStatusId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveJobStatus = await _unitOfWork.JobStatusRepository.GetWithTracking().Where(x => x.JobStatusId == JobStatusId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveJobStatus != null)
                {
                    RemoveJobStatus.IsActive = false;
                    await _unitOfWork.JobStatusRepository.Update(RemoveJobStatus);
                    await _unitOfWork.Complete();
                    responseObj.Message = "JobStatus Deleted Successfully";
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No JobStatus Found";
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddRole(RoleViewModel roleViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                RoleValidator validationRules = new RoleValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(roleViewModel);
                if (ValidatorResult.IsValid)
                {
                    Role role = new Role();
                    role.RoleName = roleViewModel.RoleName;
                    role.RoleNameAr = roleViewModel.RoleNameAr;
                    role.WorkshopId = roleViewModel.WorkshopId;
                    role.IsActive = true;
                    await _unitOfWork.RoleRepository.Add(role);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("RoleAdded");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateRole(RoleViewModel roleViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                RoleValidator validationRules = new RoleValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(roleViewModel);
                if (ValidatorResult.IsValid)
                {
                    var roleDetails = await _unitOfWork.RoleRepository.GetWithTracking().Where(x => x.RoleId == roleViewModel.RoleId && x.IsActive).FirstOrDefaultAsync();
                    if (roleDetails != null)
                    {
                        roleDetails.RoleName = roleViewModel.RoleName;
                        roleDetails.RoleNameAr = roleViewModel.RoleNameAr;
                        roleDetails.WorkshopId = roleViewModel.WorkshopId;
                        await _unitOfWork.RoleRepository.Update(roleDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("RoleUpdated");
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoRoleFound");
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<RoleViewModel>>> GetAllRole()
        {
            ResponseObj<List<RoleViewModel>> responseObj = new ResponseObj<List<RoleViewModel>>();
            try
            {
                var Roles = await _unitOfWork.RoleRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.RoleId)
                    .Select(x => new RoleViewModel
                    {
                        RoleId = x.RoleId,
                        RoleName =  x.RoleName,
                        RoleNameAr= x.RoleNameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).ToListAsync();
                if (Roles.Count() > 0)
                {
                    responseObj.Data = Roles;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Roles";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<RoleViewModel>>> GetAllRoleByWorkshopId(int WorkshopId)
        {
            ResponseObj<List<RoleViewModel>> responseObj = new ResponseObj<List<RoleViewModel>>();
            try
            {
                var Roles = await _unitOfWork.RoleRepository.GetWithoutTracking()
                    .Where(x => x.IsActive && x.WorkshopId == WorkshopId).OrderByDescending(x => x.RoleId)
                    .Select(x => new RoleViewModel
                    {
                        RoleId = x.RoleId,
                        RoleName =  x.RoleName,
                        RoleNameAr =  x.RoleNameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).ToListAsync();
                if (Roles.Count() > 0)
                {
                    responseObj.Data = Roles;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Roles";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<RoleViewModel>> GetRoleById(int RoleId)
        {
            ResponseObj<RoleViewModel> responseObj = new ResponseObj<RoleViewModel>();
            try
            {
                var RoleDetails = await _unitOfWork.RoleRepository.GetWithoutTracking()
                    .Where(x => x.RoleId == RoleId && x.IsActive).Select(x => new RoleViewModel
                    {
                        RoleId = x.RoleId,
                        RoleName =  x.RoleName,
                        RoleNameAr = x.RoleNameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).FirstOrDefaultAsync();
                if (RoleDetails != null)
                {
                    responseObj.Data = RoleDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Role Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteRole(int RoleId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveRole = await _unitOfWork.RoleRepository.GetWithTracking().Where(x => x.RoleId == RoleId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveRole != null)
                {
                    RemoveRole.IsActive = false;
                    await _unitOfWork.RoleRepository.Update(RemoveRole);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("RoleDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoRoleFound");
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddStage(StageViewModel stageViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                StageValidator validationRules = new StageValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(stageViewModel);
                if (ValidatorResult.IsValid)
                {
                    Stage stage = new Stage();
                    stage.StageNo = stageViewModel.StageNo;
                    stage.Name = stageViewModel.StageName;
                    stage.NameAr = stageViewModel.StageNameAr;
                    stage.WorkshopId = stageViewModel.WorkshopId;
                    stage.IsActive = true;
                    stage.CreatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.StageRepository.Add(stage);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("StageAdded");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateStage(StageViewModel stageViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                StageValidator validationRules = new StageValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(stageViewModel);
                if (ValidatorResult.IsValid)
                {
                    var stageDetails = await _unitOfWork.StageRepository.GetWithTracking().Where(x => x.StageId == stageViewModel.StageId && x.IsActive).FirstOrDefaultAsync();
                    if (stageDetails != null)
                    {


                        stageDetails.Name = stageViewModel.StageName;
                        stageDetails.NameAr = stageViewModel.StageNameAr;
                        stageDetails.StageNo = stageViewModel.StageNo;
                        stageDetails.WorkshopId = stageViewModel.WorkshopId;
                        await _unitOfWork.StageRepository.Update(stageDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("StageUpdated");
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoStageFound");
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<StageViewModel>>> GetAllStage()
        {
            ResponseObj<List<StageViewModel>> responseObj = new ResponseObj<List<StageViewModel>>();
            try
            {
                var Stages = await _unitOfWork.StageRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.StageId)
                    .Select(x => new StageViewModel
                    {
                        StageId = x.StageId,
                        StageName =  x.Name,
                        StageNameAr=x.NameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).ToListAsync();
                if (Stages.Count() > 0)
                {
                    responseObj.Data = Stages;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Stages";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<StageViewModel>>> GetAllStageByWorkshopId(int WorkshopId)
        {
            ResponseObj<List<StageViewModel>> responseObj = new ResponseObj<List<StageViewModel>>();
            try
            {
                var Stages = await _unitOfWork.StageRepository.GetWithoutTracking()
                    .Where(x => x.IsActive && x.WorkshopId == WorkshopId).OrderBy(x => x.StageNo)
                    .Select(x => new StageViewModel
                    {
                        StageId = x.StageId,
                        StageNo = x.StageNo,
                        StageName = x.Name,
                        StageNameAr = x.NameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).ToListAsync();
                if (Stages.Count() > 0)
                {
                    responseObj.Data = Stages;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Stages";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<KanbanStageViewModel>>> GetAllStageForKanbanByWorkshopId(int WorkshopId)
        {
            ResponseObj<List<KanbanStageViewModel>> responseObj = new ResponseObj<List<KanbanStageViewModel>>();
            try
            {

                var Stages = await _unitOfWork.StageRepository.GetWithoutTracking()
                    .Where(x => x.IsActive && x.WorkshopId == WorkshopId).OrderBy(x => x.StageNo).ToListAsync();
                List<KanbanStageViewModel> kanbanStages = new List<KanbanStageViewModel>();
                foreach (var stage in Stages)
                {
                    KanbanStageViewModel kanbanStageViewModel = new KanbanStageViewModel();
                    var JobCount = _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.IsActive && x.WorkshopId == WorkshopId && x.StageId == stage.StageId).Count();
                    kanbanStageViewModel.id = stage.StageId.ToString();
                    kanbanStageViewModel.name = stage.Name + " (" + JobCount + ")";
                    kanbanStages.Add(kanbanStageViewModel);
                }
                if (Stages.Count() > 0)
                {
                    responseObj.Data = kanbanStages;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Stages";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<StageViewModel>> GetStageById(int StageId)
        {
            ResponseObj<StageViewModel> responseObj = new ResponseObj<StageViewModel>();
            try
            {
                var StageDetails = await _unitOfWork.StageRepository.GetWithoutTracking()
                    .Where(x => x.StageId == StageId && x.IsActive).Select(x => new StageViewModel
                    {
                        StageId = x.StageId,
                        StageName = x.Name,
                        StageNameAr = x.NameAr,
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.Workshop.WorkshopName
                    }).FirstOrDefaultAsync();
                if (StageDetails != null)
                {
                    responseObj.Data = StageDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Stage Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteStage(int StageId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveStage = await _unitOfWork.StageRepository.GetWithTracking().Where(x => x.StageId == StageId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveStage != null)
                {
                    RemoveStage.IsActive = false;
                    await _unitOfWork.StageRepository.Update(RemoveStage);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("StageDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoStageFound");
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddVehicleMake(VehicleMakeViewModel vehicleMakeViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                VehicleMakeValidator validationRules = new VehicleMakeValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(vehicleMakeViewModel);
                if (ValidatorResult.IsValid)
                {
                    VehicleMake vehicleMake = new VehicleMake();
                    vehicleMake.VehicleMakeName = vehicleMakeViewModel.VehicleMakeName;
                    vehicleMake.VehicleMakeNameAr = vehicleMakeViewModel.VehicleMakeNameAr;
                    vehicleMake.IsActive = true;
                    await _unitOfWork.VehicleMakeRepository.Add(vehicleMake);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleMakeAdded");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                VehicleMakeValidator validationRules = new VehicleMakeValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(vehicleMakeViewModel);
                if (ValidatorResult.IsValid)
                {
                    var vehicleMakeDetails = await _unitOfWork.VehicleMakeRepository.GetWithTracking().Where(x => x.VehicleMakeId == vehicleMakeViewModel.VehicleMakeId && x.IsActive).FirstOrDefaultAsync();
                    if (vehicleMakeDetails != null)
                    {

                        vehicleMakeDetails.VehicleMakeName = vehicleMakeViewModel.VehicleMakeName;
                        vehicleMakeDetails.VehicleMakeNameAr = vehicleMakeViewModel.VehicleMakeNameAr;
                        await _unitOfWork.VehicleMakeRepository.Update(vehicleMakeDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleMakeUpdated");
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoVehicleMakeFound");
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<VehicleMakeViewModel>>> GetAllVehicleMake()
        {
            ResponseObj<List<VehicleMakeViewModel>> responseObj = new ResponseObj<List<VehicleMakeViewModel>>();
            try
            {
                var VehicleMakes = await _unitOfWork.VehicleMakeRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.VehicleMakeId)
                    .Select(x => new VehicleMakeViewModel
                    {
                        VehicleMakeId = x.VehicleMakeId,
                        VehicleMakeName =  x.VehicleMakeName,
                        VehicleMakeNameAr =  x.VehicleMakeNameAr
                    }).ToListAsync();
                if (VehicleMakes.Count() > 0)
                {
                    responseObj.Data = VehicleMakes;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of VehicleMakes";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<VehicleMakeViewModel>> GetVehicleMakeById(int VehicleMakeId)
        {
            ResponseObj<VehicleMakeViewModel> responseObj = new ResponseObj<VehicleMakeViewModel>();
            try
            {
                var VehicleMakeDetails = await _unitOfWork.VehicleMakeRepository.GetWithoutTracking()
                    .Where(x => x.VehicleMakeId == VehicleMakeId && x.IsActive).Select(x => new VehicleMakeViewModel
                    {
                        VehicleMakeId = x.VehicleMakeId,
                        VehicleMakeName =  x.VehicleMakeName,
                        VehicleMakeNameAr = x.VehicleMakeNameAr
                    }).FirstOrDefaultAsync();
                if (VehicleMakeDetails != null)
                {
                    responseObj.Data = VehicleMakeDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "VehicleMake Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteVehicleMake(int VehicleMakeId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveVehicleMake = await _unitOfWork.VehicleMakeRepository.GetWithTracking().Where(x => x.VehicleMakeId == VehicleMakeId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveVehicleMake != null)
                {
                    RemoveVehicleMake.IsActive = false;
                    await _unitOfWork.VehicleMakeRepository.Update(RemoveVehicleMake);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleMakeDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No VehicleMake Found";
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddVehicleModel(VehicleModelViewModel vehicleModelViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                VehicleModelValidator validationRules = new VehicleModelValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(vehicleModelViewModel);
                if (ValidatorResult.IsValid)
                {
                    VehicleModel vehicleModel = new VehicleModel();
                    vehicleModel.VehicleModelName = vehicleModelViewModel.VehicleModelName;
                    vehicleModel.VehicleModelNameAr = vehicleModelViewModel.VehicleModelNameAr;
                    vehicleModel.VehicleMakeId = vehicleModelViewModel.VehicleMakeId;
                    vehicleModel.IsActive = true;
                    await _unitOfWork.VehicleModelRepository.Add(vehicleModel);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleModelAdded");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                VehicleModelValidator validationRules = new VehicleModelValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(vehicleModelViewModel);
                if (ValidatorResult.IsValid)
                {
                    var vehicleModelDetails = await _unitOfWork.VehicleModelRepository.GetWithTracking().Where(x => x.VehicleModelId == vehicleModelViewModel.VehicleModelId && x.IsActive).FirstOrDefaultAsync();
                    if (vehicleModelDetails != null)
                    {


                        vehicleModelDetails.VehicleModelName = vehicleModelViewModel.VehicleModelName;
                        vehicleModelDetails.VehicleModelNameAr = vehicleModelViewModel.VehicleModelNameAr;
                        vehicleModelDetails.VehicleMakeId = vehicleModelViewModel.VehicleMakeId;
                        await _unitOfWork.VehicleModelRepository.Update(vehicleModelDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleModelUpdated");
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoVehicleModelFound");
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModel()
        {
            ResponseObj<List<VehicleModelViewModel>> responseObj = new ResponseObj<List<VehicleModelViewModel>>();
            try
            {
                var VehicleModels = await _unitOfWork.VehicleModelRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.VehicleModelId)
                    .Select(x => new VehicleModelViewModel
                    {
                        VehicleModelId = x.VehicleModelId,
                        VehicleMakeId = Convert.ToInt32(x.VehicleMakeId),
                        VehicleModelName =x.VehicleModelName,
                        VehicleModelNameAr =x.VehicleModelNameAr,
                        VehicleMakeNameAr =  x.VehicleMake.VehicleMakeNameAr,
                        VehicleMakeName =  x.VehicleMake.VehicleMakeName
                    }).ToListAsync();
                if (VehicleModels.Count() > 0)
                {
                    responseObj.Data = VehicleModels;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of VehicleModels";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<VehicleModelViewModel>>> GetAllVehicleModelByMakeId(int VehicleMakeId)
        {
            ResponseObj<List<VehicleModelViewModel>> responseObj = new ResponseObj<List<VehicleModelViewModel>>();
            try
            {
                var VehicleModels = await _unitOfWork.VehicleModelRepository.GetWithoutTracking()
                    .Where(x => x.IsActive && x.VehicleMakeId == VehicleMakeId).OrderByDescending(x => x.VehicleModelId)
                    .Select(x => new VehicleModelViewModel
                    {
                        VehicleModelId = x.VehicleModelId,
                        VehicleMakeId = Convert.ToInt32(x.VehicleMakeId),
                        VehicleModelName = x.VehicleModelName,
                        VehicleModelNameAr = x.VehicleModelNameAr,
                        VehicleMakeNameAr = x.VehicleMake.VehicleMakeNameAr,
                        VehicleMakeName = x.VehicleMake.VehicleMakeName
                    }).ToListAsync();
                if (VehicleModels.Count() > 0)
                {
                    responseObj.Data = VehicleModels;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of VehicleModels";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<VehicleModelViewModel>> GetVehicleModelById(int VehicleModelId)
        {
            ResponseObj<VehicleModelViewModel> responseObj = new ResponseObj<VehicleModelViewModel>();
            try
            {
                var VehicleModelDetails = await _unitOfWork.VehicleModelRepository.GetWithoutTracking()
                    .Where(x => x.VehicleModelId == VehicleModelId && x.IsActive).Select(x => new VehicleModelViewModel
                    {
                        VehicleModelId = x.VehicleModelId,
                        VehicleMakeId = Convert.ToInt32(x.VehicleMakeId),
                        VehicleModelName = x.VehicleModelName,
                        VehicleModelNameAr = x.VehicleModelNameAr,
                        VehicleMakeNameAr = x.VehicleMake.VehicleMakeNameAr,
                        VehicleMakeName = x.VehicleMake.VehicleMakeName
                    }).FirstOrDefaultAsync();
                if (VehicleModelDetails != null)
                {
                    responseObj.Data = VehicleModelDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "VehicleModel Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteVehicleModel(int VehicleModelId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveVehicleModel = await _unitOfWork.VehicleModelRepository.GetWithTracking().Where(x => x.VehicleModelId == VehicleModelId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveVehicleModel != null)
                {
                    RemoveVehicleModel.IsActive = false;
                    await _unitOfWork.VehicleModelRepository.Update(RemoveVehicleModel);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("VehicleModelDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoVehicleModelFound");
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddCustomerType(CustomerTypeViewModel customerTypeViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                CustomerTypeValidator validationRules = new CustomerTypeValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(customerTypeViewModel);
                if (ValidatorResult.IsValid)
                {
                    CustomerType customerType = new CustomerType();
                    customerType.CustomerTypeName = customerTypeViewModel.CustomerTypeName;
                    customerType.CustomerTypeNameAr = customerTypeViewModel.CustomerTypeNameAr;
                    customerType.IsActive = true;
                    customerType.CreatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.CustomerTypeRepository.Add(customerType);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("CustomerTypeAdded");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateCustomerType(CustomerTypeViewModel customerTypeViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                CustomerTypeValidator validationRules = new CustomerTypeValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(customerTypeViewModel);
                if (ValidatorResult.IsValid)
                {
                    var customerTypeDetails = await _unitOfWork.CustomerTypeRepository.GetWithTracking().Where(x => x.CustomerTypeId == customerTypeViewModel.CustomerTypeId && x.IsActive).FirstOrDefaultAsync();
                    if (customerTypeDetails != null)
                    {
                        customerTypeDetails.CustomerTypeName = customerTypeViewModel.CustomerTypeName;
                        await _unitOfWork.CustomerTypeRepository.Update(customerTypeDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("CustomerTypeUpdated");
                        responseObj.isSuccess = true;

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoCustomerTypeFound");
                        responseObj.isSuccess = false;
                    }
                }
                else
                {
                    responseObj.Message = ValidatorResult.Errors.FirstOrDefault().ErrorMessage;
                    responseObj.isSuccess = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<CustomerTypeViewModel>>> GetAllCustomerType(string lang)
        {
            ResponseObj<List<CustomerTypeViewModel>> responseObj = new ResponseObj<List<CustomerTypeViewModel>>();
            try
            {
                var CustomerTypes = await _unitOfWork.CustomerTypeRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.CustomerTypeId)
                    .Select(x => new CustomerTypeViewModel
                    {
                        CustomerTypeId = x.CustomerTypeId,
                        CustomerTypeName = lang == "ar" ? x.CustomerTypeNameAr : x.CustomerTypeName
                    }).ToListAsync();
                if (CustomerTypes.Count() > 0)
                {
                    responseObj.Data = CustomerTypes;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of CustomerTypes";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<CustomerTypeViewModel>> GetCustomerTypeById(int CustomerTypeId,string lang)
        {
            ResponseObj<CustomerTypeViewModel> responseObj = new ResponseObj<CustomerTypeViewModel>();
            try
            {
                var CustomerTypeDetails = await _unitOfWork.CustomerTypeRepository.GetWithoutTracking()
                    .Where(x => x.CustomerTypeId == CustomerTypeId && x.IsActive).Select(x => new CustomerTypeViewModel
                    {
                        CustomerTypeId = x.CustomerTypeId,
                        CustomerTypeName = lang == "ar" ? x.CustomerTypeNameAr : x.CustomerTypeName
                    }).FirstOrDefaultAsync();
                if (CustomerTypeDetails != null)
                {
                    responseObj.Data = CustomerTypeDetails;
                    responseObj.isSuccess = true;
                    responseObj.Message = "CustomerType Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteCustomerType(int CustomerTypeId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveCustomerType = await _unitOfWork.CustomerTypeRepository.GetWithTracking().Where(x => x.CustomerTypeId == CustomerTypeId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveCustomerType != null)
                {
                    RemoveCustomerType.IsActive = false;
                    await _unitOfWork.CustomerTypeRepository.Update(RemoveCustomerType);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("CustomerTypeDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No CustomerType Found";
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<TasksResponse>> GetColumns(int WorkshopId)
        {
            ResponseObj<TasksResponse> responseObj = new ResponseObj<TasksResponse>();
            try
            {
                var columns = new Dictionary<string, ColumnData>();
                var tasksData = await _unitOfWork.JobRepository.GetWithoutTracking()
                    .Select(x => new { StageId = x.StageId.ToString(), x.JobId })
                    .ToListAsync();
                //var daysOfWeek = await _dbContext.DaysOfWeek.Select(day => day.Name).ToListAsync();
                var stages = await _unitOfWork.StageRepository.GetWithoutTracking()
                    .Select(x => new { StageId = Convert.ToString(x.StageId), x.Name, x.WorkshopId, x.IsActive })
                    .Where(x => x.WorkshopId == WorkshopId && x.IsActive).ToListAsync();

                foreach (var stage in stages)
                {
                    var tasksForStage = tasksData
           .Where(task => task.StageId == stage.StageId)
           .Select(task => task.JobId.ToString())
           .ToList();

                    columns[stage.StageId] = new ColumnData
                    {
                        Id = stage.StageId,
                        Title = "To do", // Adjust as needed
                        TaskIds = tasksForStage
                    };

                }
                var taskResponse = new TasksResponse
                {
                    ColumnOrder = stages.Select(x => new ColOrder { Id = x.StageId, Name = x.Name }).ToList(),
                    Columns = columns
                };
                if (columns.Any())
                {
                    responseObj.Data = taskResponse;
                    responseObj.isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
    }
}
