using BusinessLogic.JobService;
using BusinessLogic.TamamService;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WorkshopMgmt.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TamamController:ControllerBase
    {


        private readonly ITamamService  _tamamservice;
        public TamamController(ITamamService  tamamService)
        {
            _tamamservice =  tamamService;
        }

     
        [HttpPost("RegisterTamamUser")]
        public async Task<ResponseObj<TamamUserViewModel>> RegisterTamamUser(TamamUserViewModel  tamamUserViewModel)
         => await _tamamservice.AddTamamUser(tamamUserViewModel);

        [HttpGet("TamamUserLogin")]
        public async Task<ResponseObj<TamamUserViewModel>> TamamUserLogin(string mobileno)
            => await _tamamservice.TamamUserLogin(mobileno);

        [HttpPost("AddTamamUserAddress")]
        public async Task<ResponseObj<TamamUserViewModel>> AddTamamUserAddress(TamamAddressViewModel tamamAddressViewModel)
       => await _tamamservice.AddTamamUserAddress(tamamAddressViewModel);

        [HttpPost("AddTamamUserVehicle")]
        public async Task<ResponseObj<TamamUserViewModel>> RegisterTamamUser(TamamVehicleViewModel tamamVehicleViewModel)
       => await _tamamservice.AddTamamUserVehicle(tamamVehicleViewModel);

     
        
        
        
        
        
        
        
        [HttpPost("RegisterClaim")]
        public async Task<ResponseObj<string>> RegisterClaim(TamamClaimViewModel tamamClaimViewModel)
         => await _tamamservice.AddTamamClaim(tamamClaimViewModel);

       
        [HttpGet("GetAllTamamClaimsbyUserId")]
        public async Task<ResponseObj<List<TamamClaimViewModel>>> GetAllTamamClaimsbyUserIdint(int TamamUserId)
         => await _tamamservice.GetAllTamamClaimsbyUserId(TamamUserId);



        [HttpGet("GetTamamClaimbyClaimId")]
        public async Task<ResponseObj<TamamClaimViewModel>> GetTamamClaimbyClaimId(int ClaimId)
          => await _tamamservice.GetTamamClaimbyClaimId(ClaimId);


    }
}
