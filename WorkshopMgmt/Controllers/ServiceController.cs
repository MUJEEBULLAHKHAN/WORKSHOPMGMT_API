using BusinessLogic.JobService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WorkshopMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IJobService _jobService;
        public ServiceController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpPost("CreateJob")]
        public async Task<ResponseObj<string>> CreateJob(JobViewModel jobViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.CreateJob(jobViewModel, lang);
        }
        [HttpPost("UpdateJobStatus")]
        public async Task<ResponseObj<string>> UpdateJobStatus(ActivityLogViewModel activityLogViewModel)
            => await _jobService.UpdateJobStatus(activityLogViewModel);
        [HttpGet("GetJobList")]
        public async Task<ResponseObj<List<GetJobViewModel>>> GetJobList(int WorkshopId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.GetJobList(WorkshopId,lang);
        }
        [HttpGet("GetKanbanJobList")]
        public async Task<ResponseObj<List<GetKanbanJobViewModel>>> GetKanbanJobList(int WorkshopId)
            => await _jobService.GetKanbanJobList(WorkshopId);
        [HttpGet("UpdateJobDesc")]
        public async Task<ResponseObj<string>> UpdateJobDesc(int JobId, string JobDescription)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.UpdateJobDesc(JobId, JobDescription, lang);
        }
        [HttpGet("GetJobById")]
        public async Task<ResponseObj<JobDetailsViewModel>> GetJobById(int JobId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.GetJobById(JobId,lang);
        }
        [HttpGet("StartJob")]
        public async Task<ResponseObj<string>> StartJob(int JobId, int StageId, int UserId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.StartJob(JobId, StageId, UserId, lang);
        }
        [HttpGet("AddParts")]
        public async Task<ResponseObj<string>> AddParts(int JobId, string PartsName)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.AddParts(JobId, PartsName, lang);
        }
        [HttpPost("FinalStage")]
        public async Task<ResponseObj<string>> FinalStage(FinalizeJob finalizeJob)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.FinalStage(finalizeJob, lang);
        }
        [HttpGet("GetInvoiceDetails")]
        public async Task<ResponseObj<InvoiceReceipt>> GetInvoiceDetails(int JobId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _jobService.GetInvoiceDetails(JobId, lang);
        }
        [HttpGet("GetNewSampleStage")]
        public async Task<ResponseObj<List<StageView>>> GetNewSampleStage(int WorkshopId)
            =>await _jobService.GetNewSampleStage(WorkshopId);
    }
}
