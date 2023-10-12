using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.WorkshopService
{
    public interface IWorkshopService
    {
        Task<ResponseObj<string>> AddWorkshop(WorkshopViewModel workshopViewModel, string lang);
        Task<ResponseObj<string>> UpdateWorkshop(WorkshopUpdateViewModel workshopUpdateViewModel, string lang);
        Task<ResponseObj<List<WorkshopUpdateViewModel>>> GetAllWorkshop();
        Task<ResponseObj<WorkshopUpdateViewModel>> GetWorkshopById(int WorkshopId);
        Task<ResponseObj<string>> DeleteWorkshop(int WorkshopId, string lang);
        Task<ResponseObj<GetWorkshopViewModel>> WorkshopLogin(string EmailId, string Password, string lang);
        Task<ResponseObj<OwnerViewModel>> OwnerLogin(string EmailId, string Password, string lang);
        Task<ResponseObj<string>> CreateOwner(OwnerViewModel ownerViewModel);
        Task<ResponseObj<UserCountViewModel>> UserCount();
    }
}
