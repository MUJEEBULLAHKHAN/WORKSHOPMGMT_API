using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.UserService
{
    public interface IUserService
    {
        Task<ResponseObj<string>> AddUser(UserViewModel userViewModel,string lang);
        Task<ResponseObj<string>> UpdateUser(UserUpdateViewModel userUpdateViewModel,string lang);
        Task<ResponseObj<List<GetUserViewModel>>> GetAllUser();
        Task<ResponseObj<List<GetUserViewModel>>> GetAllUserByWorkshopId(int WorkshopId);
        Task<ResponseObj<GetUserViewModel>> GetUserById(int UserId);
        Task<ResponseObj<string>> DeleteUser(int UserId,string lang);
        Task<ResponseObj<GetUserViewModel>> UserLogin(string EmailId, string Password,string lang);

    }
}
