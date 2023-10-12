using BusinessLogic.UserService;
using BusinessLogic.WorkshopService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WorkshopMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWorkshopService _workshopService;
        public AccountController(IUserService userService, IWorkshopService workshopService)
        {
            _userService = userService;
            _workshopService = workshopService;
        }
        [HttpPost("AddUser")]
        public async Task<ResponseObj<string>> AddUser(UserViewModel userViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _userService.AddUser(userViewModel,lang);
        }
        [HttpGet("UserLogin")]
        public async Task<ResponseObj<GetUserViewModel>> UserLogin(string EmailId, string Password)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _userService.UserLogin(EmailId, Password,lang);
        }
        [HttpGet("GetAllUserByWorkshopId")]
        public async Task<ResponseObj<List<GetUserViewModel>>> GetAllUserByWorkshopId(int WorkshopId)
            => await _userService.GetAllUserByWorkshopId(WorkshopId);
        [HttpGet("GetAllUsers")]
        public async Task<ResponseObj<List<GetUserViewModel>>> GetAllUsers()
           => await _userService.GetAllUser();
        [HttpPost("AddWorkshop")]
        public async Task<ResponseObj<string>> AddWorkshop(WorkshopViewModel workshopViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _workshopService.AddWorkshop(workshopViewModel,lang);
        }
        [HttpPost("UpdateWorkshop")]
        public async Task<ResponseObj<string>> UpdateWorkshop(WorkshopUpdateViewModel workshopUpdateViewModel)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _workshopService.UpdateWorkshop(workshopUpdateViewModel,lang);
        }
        [HttpGet("GetAllWorkshop")]
        public async Task<ResponseObj<List<WorkshopUpdateViewModel>>> GetAllWorkshop()
            => await _workshopService.GetAllWorkshop();
        [HttpGet("GetWorkshopById")]
        public async Task<ResponseObj<WorkshopUpdateViewModel>> GetWorkshopById(int WorkshopId)
            => await _workshopService.GetWorkshopById(WorkshopId);
        [HttpGet("DeleteWorkshop")]
        public async Task<ResponseObj<string>> DeleteWorkshop(int WorkshopId)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _workshopService.DeleteWorkshop(WorkshopId,lang);
        }
        [HttpGet("WorkshopLogin")]
        public async Task<ResponseObj<GetWorkshopViewModel>> WorkshopLogin(string EmailId, string Password)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _workshopService.WorkshopLogin(EmailId, Password,lang);
        }
        [HttpGet("OwnerLogin")]
        public async Task<ResponseObj<OwnerViewModel>> OwnerLogin(string EmailId, string Password)
        {
            Request.Headers.TryGetValue("Culture", out var lang);
            return await _workshopService.OwnerLogin(EmailId, Password,lang);
        }
        [HttpPost("CreateOwner")]
        public async Task<ResponseObj<string>> CreateOwner(OwnerViewModel ownerViewModel)
       => await _workshopService.CreateOwner(ownerViewModel);
        [HttpGet("UserCount")]
        public async Task<ResponseObj<UserCountViewModel>> UserCount()
            =>await _workshopService.UserCount();


    }
}
