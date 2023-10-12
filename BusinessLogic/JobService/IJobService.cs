using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.JobService
{
    public interface IJobService
    {
        Task<ResponseObj<string>> CreateJob(JobViewModel jobViewModel,string lang);
        Task<ResponseObj<string>> UpdateJobStatus(ActivityLogViewModel activityLogViewModel);
        Task<ResponseObj<List<GetJobViewModel>>> GetJobList(int WorkshopId,string lang);
        Task<ResponseObj<string>> UpdateJobDesc(int JobId, string JobDescription, string lang);
        Task<ResponseObj<JobDetailsViewModel>> GetJobById(int JobId,string lang);
        Task<ResponseObj<List<GetKanbanJobViewModel>>> GetKanbanJobList(int WorkshopId);
        Task<ResponseObj<string>> StartJob(int JobId, int StageId, int UserId, string lang);
        Task<ResponseObj<string>> AddParts(int JobId, string PartsName, string lang);
        Task<ResponseObj<string>> FinalStage(FinalizeJob finalizeJob,string lang);
        Task<ResponseObj<InvoiceReceipt>> GetInvoiceDetails(int JobId, string lang);
        Task<ResponseObj<List<StageView>>> GetNewSampleStage(int WorkshopId);
    }
}
