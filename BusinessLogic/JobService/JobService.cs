using BusinessLogic.CommonService;
using BusinessLogic.UnitOfWork;
using DataAccess.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic.JobService
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public JobService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }
        public async Task<ResponseObj<string>> CreateJob(JobViewModel jobViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                Job job = new Job();
                job.UserId = jobViewModel.UserId;
                job.WorkshopId = jobViewModel.WorkshopId;
                job.VehicleParts = string.Empty;
                job.JobStatusId = 1;
                job.StartedOn = jobViewModel.JobCreated;
                var CustDetails = await _unitOfWork.CustomerRepository.GetWithoutTracking().
                    Where(x => x.Email == jobViewModel.Email && x.MobileNo == jobViewModel.MobileNo && x.IsActive).FirstOrDefaultAsync();
                if (CustDetails != null)
                {
                    job.CustomerId = CustDetails.CustomerId;
                }
                else
                {
                    job.Customer = new Customer();
                    job.Customer.CustomerName = jobViewModel.CustomerName;
                    job.Customer.Address = jobViewModel.Address == null ? string.Empty : jobViewModel.Address;
                    job.Customer.MobileNo = jobViewModel.MobileNo;
                    job.Customer.Email = jobViewModel.Email;
                    job.Customer.Gender = jobViewModel.Gender;
                    job.Customer.IsActive = true;
                    job.Customer.CustomerTypeId = jobViewModel.CustomerType == 0 ? null : jobViewModel.CustomerType;
                    job.Customer.CreatedOn = _commonService.GetCurrentSaudiTime();
                    job.Customer.CreatedBy = Convert.ToInt32(jobViewModel.UserId);
                }
                job.Vehicle = new Vehicle();
                job.Vehicle.VehicleMakeId = jobViewModel.VehicleMakeId;
                job.Vehicle.VehicleModelId = jobViewModel.VehicleModelId;
                job.Vehicle.Year = jobViewModel.Year;
                job.Vehicle.ColorName = jobViewModel.ColorName;
                job.Vehicle.ChassisNumber = jobViewModel.ChassisNumber;
                job.Vehicle.PlateNumber = jobViewModel.PlateNumber;
                job.Vehicle.Odometer = jobViewModel.Odometer;
                job.Vehicle.IsInsured = jobViewModel.IsInsured;
                job.Vehicle.IsCorporate = jobViewModel.IsCorporate;
                job.Vehicle.SpareTyre = jobViewModel.SpareTyre;
                job.Vehicle.NumberPlates = jobViewModel.NumberPlates;
                job.Vehicle.CdPlay = jobViewModel.CdPlay;
                job.Vehicle.ToolKit = jobViewModel.ToolKit;
                job.Vehicle.AirCondition = jobViewModel.AirCondition;
                job.Vehicle.CarKey = jobViewModel.CarKey;
                job.Vehicle.CheckEngineLight = jobViewModel.CheckEngineLight;
                job.Vehicle.Batteries = jobViewModel.Batteries;
                job.Vehicle.WheelCaps = jobViewModel.WheelCaps;
                job.Vehicle.AirbagsLight = jobViewModel.AirbagsLight;
                job.Vehicle.ABSLight = jobViewModel.ABSLight;
                job.Vehicle.FloorMats = jobViewModel.FloorMats;
                job.Vehicle.CreatedOn = _commonService.GetCurrentSaudiTime();
                job.Vehicle.CreatedBy = Convert.ToInt32(jobViewModel.UserId);
                job.Vehicle.IsActive = true;
                var StageId = await _unitOfWork.StageRepository.GetWithoutTracking().Where(x => x.WorkshopId == jobViewModel.WorkshopId && x.IsActive).OrderBy(x => x.StageNo).Select(x => x.StageId).FirstOrDefaultAsync();
                if (StageId > 0)
                {
                    job.StageId = StageId;
                }
                string FolderPath = _commonService.CreateFolder("VehiclePics", jobViewModel.PlateNumber, string.Empty);
                string _VehicleVideo = _commonService.SaveImage(jobViewModel.VehicleVideo, FolderPath, "VehicleVideo", true);
                if (!string.IsNullOrEmpty(_VehicleVideo))
                {
                    job.VehicleVideo = _VehicleVideo;
                }
                foreach (var item in jobViewModel.VehiclePictures)
                {

                    string _VehicleImage = _commonService.SaveImage(item.VehiclePic, FolderPath, item.PicName, true);

                    job.Vehicle.VehiclePics.Add(new VehiclePics()
                    {
                        VehiclePic = _VehicleImage,
                        CreatedOn = _commonService.GetCurrentSaudiTime(),
                        CreatedBy = Convert.ToInt32(jobViewModel.UserId),
                        IsActive = true
                    });
                }
                job.IsActive = true;
                job.CreatedOn = _commonService.GetCurrentSaudiTime();
                job.CreatedBy = Convert.ToInt32(jobViewModel.UserId);
                await _unitOfWork.JobRepository.CreateJob(job);
                await _unitOfWork.Complete();
                responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("JobCreated");
                responseObj.isSuccess = true;
            }
            catch (Exception ex)
            {
                try
                {
                    ErrorLog errorLog = new ErrorLog();
                    errorLog.ErrorId = 0;
                    errorLog.ErrorMessage = "Message:" + ex.Message + "  InnerException: " + ex.InnerException + "  ex.StackTrace:  " + ex.StackTrace;
                    errorLog.CreatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.ErrorLogRepository.Add(errorLog);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex1)
                {

                    throw;
                }

            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateJobStatus(ActivityLogViewModel activityLogViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var JobDetails = await _unitOfWork.JobRepository.GetWithoutTracking()
                    .Where(x => x.JobId == activityLogViewModel.JobId).FirstOrDefaultAsync();
                if (JobDetails != null)
                {
                    if (JobDetails.StageId != activityLogViewModel.StageId)
                    {
                        JobDetails.JobStatusId = 2;
                        JobDetails.StageId = activityLogViewModel.StageId;
                        JobDetails.UpdatedOn = _commonService.GetCurrentSaudiTime();
                        ActivityLog activityLog = new ActivityLog();
                        activityLog.StageId = activityLogViewModel.StageId;
                        activityLog.JobId = activityLogViewModel.JobId;
                        activityLog.UserId = activityLogViewModel.UserId;
                        activityLog.LoggedOn = _commonService.GetCurrentSaudiTime();
                        await _unitOfWork.JobRepository.Update(JobDetails);
                        await _unitOfWork.ActivityLogRepository.Add(activityLog);
                        await _unitOfWork.Complete();

                        responseObj.Message = "Job status changed";
                    }
                    responseObj.isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<GetJobViewModel>>> GetJobList(int WorkshopId, string lang)
        {
            ResponseObj<List<GetJobViewModel>> responseObj = new ResponseObj<List<GetJobViewModel>>();
            try
            {
                var JobList = await _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.WorkshopId == WorkshopId).Select(x => new GetJobViewModel
                {
                    JobId = x.JobId,
                    JobDescription = x.JobDescription,
                    VehicleMake = lang == "ar" ? x.Vehicle.VehicleMake.VehicleMakeNameAr : x.Vehicle.VehicleMake.VehicleMakeName,
                    VehicleModel = lang == "ar" ? x.Vehicle.VehicleModel.VehicleModelNameAr : x.Vehicle.VehicleModel.VehicleModelName,
                    Year = x.Vehicle.Year,
                    ColorName = x.Vehicle.ColorName,
                    CustomerName = x.Customer.CustomerName,
                    //CustomerType = lang == "ar" ? x.Customer.CustomerType.CustomerTypeNameAr : x.Customer.CustomerType.CustomerTypeName
                }).ToListAsync();
                if (JobList.Count > 0)
                {
                    responseObj.Data = JobList;
                    responseObj.isSuccess = true;
                }

            }
            catch (Exception ex)
            {

                responseObj.Message = "Message:" + ex.Message + "  InnerException: " + ex.InnerException + "  ex.StackTrace:  " + ex.StackTrace;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<GetJobViewModel>>> GetJobList1(int WorkshopId, string lang)
        {
            ResponseObj<List<GetJobViewModel>> responseObj = new ResponseObj<List<GetJobViewModel>>();
            try
            {
                var JobList = await _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.WorkshopId == WorkshopId).Select(x => new GetJobViewModel
                {
                    JobId = x.JobId,
                    JobDescription = x.JobDescription,
                    VehicleMake = lang == "ar" ? x.Vehicle.VehicleMake.VehicleMakeNameAr : x.Vehicle.VehicleMake.VehicleMakeName,
                    VehicleModel = lang == "ar" ? x.Vehicle.VehicleModel.VehicleModelNameAr : x.Vehicle.VehicleModel.VehicleModelName,
                    Year = x.Vehicle.Year,
                    ColorName = x.Vehicle.ColorName,
                    CustomerName = x.Customer.CustomerName,
                    CustomerType = lang == "ar" ? x.Customer.CustomerType.CustomerTypeNameAr : x.Customer.CustomerType.CustomerTypeName
                }).ToListAsync();


                if (JobList.Count > 0)
                {
                    responseObj.Data = JobList;
                    responseObj.isSuccess = true;
                }

            }
            catch (Exception ex)
            {

                responseObj.Message = "Message:" + ex.Message + "  InnerException: " + ex.InnerException + "  ex.StackTrace:  " + ex.StackTrace;
            }
            return responseObj;
        }

        public async Task<ResponseObj<List<GetKanbanJobViewModel>>> GetKanbanJobList(int WorkshopId)
        {
            ResponseObj<List<GetKanbanJobViewModel>> responseObj = new ResponseObj<List<GetKanbanJobViewModel>>();
            try
            {
                var JobList = await _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.WorkshopId == WorkshopId)
                    .Select(x => new
                    {
                        x.JobId,
                        x.UpdatedOn,
                        x.Vehicle.VehicleMake.VehicleMakeName,
                        x.Vehicle.VehicleModel.VehicleModelName,
                        x.Vehicle.ColorName,
                        x.StageId,
                        x.JobDescription
                    })
                    .ToListAsync();
                if (JobList.Any())
                {
                    List<GetKanbanJobViewModel> getKanbanJobViewModels = new List<GetKanbanJobViewModel>();
                    foreach (var Job in JobList)
                    {
                        GetKanbanJobViewModel getKanbanJobViewModel = new GetKanbanJobViewModel();

                        TimeSpan timeDifference = _commonService.GetCurrentSaudiTime() - Convert.ToDateTime(Job.UpdatedOn);
                        int timeDifferenceInMinutes = (int)timeDifference.TotalMinutes;
                        getKanbanJobViewModel.id = Job.JobId;

                        getKanbanJobViewModel.name = Job.VehicleMakeName + " " + Job.VehicleModelName;
                        getKanbanJobViewModel.column = Job.StageId.ToString();
                        if (!string.IsNullOrEmpty(Job.JobDescription))
                        {
                            StringBuilder commaSeparated = new StringBuilder();


                            commaSeparated.Append("<b>Color :</b> " + Job.ColorName)
                                          .Append(",")
                                          .Append("<br/>")
                                          .Append("<b>Age :</b> " + timeDifferenceInMinutes)
                                          .Append("mins")

                                          .AppendLine();

                            getKanbanJobViewModel.text = commaSeparated.ToString();
                        }

                        getKanbanJobViewModels.Add(getKanbanJobViewModel);
                    }
                    if (JobList.Count > 0)
                    {
                        responseObj.Data = getKanbanJobViewModels;
                        responseObj.isSuccess = true;
                    }
                }




            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> UpdateJobDesc(int JobId, string JobDescription, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var UpdateDesc = await _unitOfWork.JobRepository.GetWithTracking().Where(x => x.JobId == JobId).FirstOrDefaultAsync();
                if (UpdateDesc != null)
                {
                    UpdateDesc.JobDescription = JobDescription;
                    UpdateDesc.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.JobRepository.Update(UpdateDesc);
                    await _unitOfWork.Complete();
                    responseObj.isSuccess = true;
                    responseObj.Message
                        = _commonService.GetasPerLanguage(lang).GetString("DescAdded");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<JobDetailsViewModel>> GetJobById(int JobId, string lang)
        {
            ResponseObj<JobDetailsViewModel> responseObj = new ResponseObj<JobDetailsViewModel>();
            try
            {
                var ActivityDetails = await _unitOfWork.ActivityLogRepository.GetWithoutTracking().Where(x => x.JobId == JobId).Select(x => new ActivityViewModel
                {
                    StageName = lang == "ar" ? x.Stage.NameAr : x.Stage.Name,
                    StartTime = x.LoggedOn,
                    UserName = x.User.Name,
                    IsJobStarted = x.IsJobStarted
                }).ToListAsync();
                var JobDetails = await _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.JobId == JobId).Select(x => new JobDetailsViewModel
                {
                    JobId = x.JobId,
                    StageId = Convert.ToInt32(x.StageId),
                    CustomerName = x.Customer.CustomerName,
                    WorkshopName = x.Workshop.WorkshopName,
                    JobDescription = x.JobDescription,
                    UserName = x.User.Name,
                    VehicleMake = lang == "ar" ? x.Vehicle.VehicleMake.VehicleMakeNameAr : x.Vehicle.VehicleMake.VehicleMakeName,
                    Year = x.Vehicle.Year,
                    VehicleModel = lang == "ar" ? x.Vehicle.VehicleModel.VehicleModelNameAr : x.Vehicle.VehicleModel.VehicleModelName,
                    ColorName = x.Vehicle.ColorName,
                    ChassisNumber = x.Vehicle.ChassisNumber,
                    PlateNumber = x.Vehicle.PlateNumber,
                    Odometer = x.Vehicle.Odometer,
                    IsCorporate = Convert.ToBoolean(x.Vehicle.IsCorporate),
                    IsInsured = Convert.ToBoolean(x.Vehicle.IsInsured),
                    VehicleParts = x.VehicleParts,
                    vehiclePictures = x.Vehicle.VehiclePics.Select(x => new VehiclePicsViewModel { VehiclePic = x.VehiclePic }).ToList(),
                    activityViewModels = ActivityDetails,
                    SpareTyre = x.Vehicle.SpareTyre,
                    NumberPlates = x.Vehicle.NumberPlates,
                    CdPlay = x.Vehicle.CdPlay,
                    ToolKit = x.Vehicle.ToolKit,
                    AirCondition = x.Vehicle.AirCondition,
                    CarKey = x.Vehicle.CarKey,
                    CheckEngineLight = x.Vehicle.CheckEngineLight,
                    Batteries = x.Vehicle.Batteries,
                    WheelCaps = x.Vehicle.WheelCaps,
                    AirbagsLight = x.Vehicle.AirbagsLight,
                    ABSLight = x.Vehicle.ABSLight,
                    FloorMats = x.Vehicle.FloorMats,
                    JobCreated = x.CreatedOn,
                    TotalParts = x.TotalParts,
                    MobileNo = x.Customer.MobileNo,
                    WorkshopAddress = x.Workshop.WorkshopAddress
                }).FirstOrDefaultAsync();


                if (JobDetails != null)
                {
                    responseObj.Data = JobDetails;
                    responseObj.isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> StartJob(int JobId, int StageId, int UserId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var JobDetails = await _unitOfWork.JobRepository.GetWithoutTracking()
                    .Where(x => x.JobId == JobId).FirstOrDefaultAsync();
                if (JobDetails != null)
                {
                    JobDetails.JobStatusId = 2;
                    JobDetails.StageId = StageId;
                    JobDetails.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    ActivityLog activityLog = new ActivityLog();
                    activityLog.StageId = StageId;
                    activityLog.JobId = JobId;
                    activityLog.UserId = UserId;
                    activityLog.IsJobStarted = true;
                    activityLog.LoggedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.JobRepository.Update(JobDetails);
                    await _unitOfWork.ActivityLogRepository.Add(activityLog);
                    await _unitOfWork.Complete();
                    responseObj.isSuccess = true;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("Jobstarted");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> AddParts(int JobId, string PartsName, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var JobDetails = await _unitOfWork.JobRepository.GetWithoutTracking()
                   .Where(x => x.JobId == JobId).FirstOrDefaultAsync();
                if (JobDetails != null)
                {
                    JobDetails.VehicleParts = PartsName;
                    await _unitOfWork.JobRepository.Update(JobDetails);
                    await _unitOfWork.Complete();
                    responseObj.isSuccess = true;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("PartsAdded");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> FinalStage(FinalizeJob finalizeJob, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var JobDetails = await _unitOfWork.JobRepository.GetWithoutTracking()
                   .Where(x => x.JobId == finalizeJob.JobId).FirstOrDefaultAsync();
                if (JobDetails != null)
                {
                    JobDetails.TotalParts = finalizeJob.TotalParts;
                    JobDetails.LaborCharge = finalizeJob.LaborCharge;
                    JobDetails.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.JobRepository.Update(JobDetails);
                    await _unitOfWork.Complete();
                    responseObj.isSuccess = true;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("PartsAdded");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<InvoiceReceipt>> GetInvoiceDetails(int JobId, string lang)
        {
            ResponseObj<InvoiceReceipt> responseObj = new ResponseObj<InvoiceReceipt>();
            try
            {

                var InvDetails = await _unitOfWork.JobRepository.GetWithoutTracking().Where(x => x.JobId == JobId)
                    .Select(x => new InvoiceReceipt
                    {
                        JobId = JobId,
                        TotalParts = x.TotalParts,
                        LaborCharge = x.LaborCharge,
                        PlateNo = x.Vehicle.PlateNumber,
                        VehicleMake = lang == "ar" ? x.Vehicle.VehicleMake.VehicleMakeNameAr : x.Vehicle.VehicleMake.VehicleMakeName,
                        VehicleModel = lang == "ar" ? x.Vehicle.VehicleModel.VehicleModelNameAr : x.Vehicle.VehicleModel.VehicleModelName,
                        Color = x.Vehicle.ColorName,
                        TotalCharge = x.LaborCharge * 15 * 0.01 + x.LaborCharge,
                        InvDate = Convert.ToDateTime(x.UpdatedOn)
                    })
                    .FirstOrDefaultAsync();
                if (InvDetails != null)
                {
                    responseObj.Data = InvDetails;
                    responseObj.isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<StageView>>> GetNewSampleStage(int WorkshopId)
        {
            ResponseObj<List<StageView>> responseObj = new ResponseObj<List<StageView>>();
            try
            {
                var StageWithJob = await _unitOfWork.StageRepository.GetWithoutTracking().Where(x => x.WorkshopId == WorkshopId)
                    .Select(x => new StageView
                    {
                        Id = x.StageId,
                        Name = x.Name,
                        Jobs = x.Tasks.Select(y => new JobView
                        {
                            Id = y.JobId,
                            Name = y.Vehicle.VehicleMake.VehicleMakeName+ " " + y.Vehicle.VehicleModel.VehicleModelName,
                            StageId = Convert.ToInt32(y.StageId)
                        }).ToList(),
                    })
                    .ToListAsync();
                if (StageWithJob.Any())
                {
                    responseObj.Data = StageWithJob;
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
