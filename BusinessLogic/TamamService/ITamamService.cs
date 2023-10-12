using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.TamamService
{
    public interface ITamamService
    {
        Task<ResponseObj<TamamUserViewModel>> AddTamamUser(TamamUserViewModel tamamUserViewModel);
        Task<ResponseObj<TamamUserViewModel>> AddTamamUserAddress(TamamAddressViewModel tamamAddressViewModel);
        Task<ResponseObj<TamamUserViewModel>> AddTamamUserVehicle(TamamVehicleViewModel tamamVehicleViewModel);

        Task<ResponseObj<string>> UpdateTamamUserDetails(TamamUserViewModel tamamUserViewModel);
        Task<ResponseObj<string>> UpdateTamamUserAddressDetails(TamamAddressViewModel tamamAddressViewModel);
        Task<ResponseObj<string>> UpdateTamamUserVehicleDetails(TamamVehicleViewModel tamamVehicleViewModel);
        Task<ResponseObj<List<TamamUserViewModel>>> GetAllTamamUsers();

        Task<ResponseObj<TamamUserViewModel>> GetTamamUserbyUserId(int TamamUserId);
        Task<ResponseObj<TamamAddressViewModel>> GetTamamUserAddressbyUserId(int TamamUserId);
        Task<ResponseObj<TamamVehicleViewModel>> GetTamamUserVehiclebyUserId(int TamamUserId);

        Task<ResponseObj<TamamUserViewModel>> TamamUserLogin(string MobileNo);

        Task<ResponseObj<string>> AddTamamClaim(TamamClaimViewModel tamamClaimViewModel);
        Task<ResponseObj<List<TamamClaimViewModel>>> GetAllTamamClaimsbyUserId(int TamamUserId);

        Task<ResponseObj<TamamClaimViewModel>> GetTamamClaimbyClaimId(int ClaimId);
    }
}
