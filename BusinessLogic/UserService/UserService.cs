using BusinessLogic.CommonService;
using BusinessLogic.UnitOfWork;
using DataAccess.DBEntities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using static Azure.Core.HttpHeader;

namespace BusinessLogic.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public UserService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }
        public async Task<ResponseObj<string>> AddUser(UserViewModel userViewModel,string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                UserValidator validationRules = new UserValidator();
                var ValidatorResult = validationRules.Validate(userViewModel);
                if (ValidatorResult.IsValid)
                {
                    var workshopDetails = await _unitOfWork.UserRepository.GetWithTracking().Where(x => x.UserId == userViewModel.UserId && x.IsActive).FirstOrDefaultAsync();
                    if (workshopDetails != null)
                    {
                        if (workshopDetails.MobileNo == userViewModel.MobileNo)
                        {
                            responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistMobileNo");
                            responseObj.isSuccess = false;

                        }
                        else if (workshopDetails.EmailId == userViewModel.EmailId)
                        {
                            responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistEmailId");
                            responseObj.isSuccess = false;
                        }
                    }
                    else
                    {
                        User user = new User();
                        user.Name = userViewModel.Name;
                        user.EmailId = userViewModel.EmailId;
                        user.MobileNo = userViewModel.MobileNo;
                        user.Password = userViewModel.ConfirmPassword;
                        user.WorkshopId = userViewModel.WorkshopId;
                        user.RoleId = userViewModel.RoleId;
                        user.IsProductive = userViewModel.IsProductive;
                        user.HourlyRate = userViewModel.HourlyRate;
                        user.CreatedOn = _commonService.GetCurrentSaudiTime();
                        user.IsActive = true;
                        await _unitOfWork.UserRepository.Add(user);
                        await _unitOfWork.Complete();
                        responseObj.Message = "User Added";
                        responseObj.isSuccess = true;
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
        public async Task<ResponseObj<string>> UpdateUser(UserUpdateViewModel userUpdateViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                UpdateUserValidator validationRules = new UpdateUserValidator();
                var ValidatorResult = validationRules.Validate(userUpdateViewModel);
                if (ValidatorResult.IsValid)
                {
                    var userDetails = await _unitOfWork.UserRepository.GetWithTracking().Where(x => x.UserId == userUpdateViewModel.UserId && x.IsActive).FirstOrDefaultAsync();
                    if (userDetails != null)
                    {
                        if (userDetails.MobileNo != userUpdateViewModel.MobileNo)
                        {
                            if (userDetails.EmailId != userUpdateViewModel.EmailId)
                            {
                                userDetails.Name = userUpdateViewModel.Name;
                                userDetails.MobileNo = userUpdateViewModel.MobileNo;
                                userDetails.EmailId = userUpdateViewModel.EmailId;
                                userDetails.WorkshopId = userUpdateViewModel.WorkshopId;
                                userDetails.IsProductive = userUpdateViewModel.IsProductive;
                                userDetails.RoleId = userUpdateViewModel.RoleId;
                                userDetails.HourlyRate = userUpdateViewModel.HourlyRate;
                                userDetails.UpdatedOn = _commonService.GetCurrentSaudiTime();
                                await _unitOfWork.UserRepository.Add(userDetails);
                                await _unitOfWork.Complete();
                                responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("UserUpdated");
                                responseObj.isSuccess = true;
                            }
                            else
                            {
                                responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistEmailId");
                                responseObj.isSuccess = false;
                            }
                        }
                        else
                        {
                            responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistMobileNo");
                            responseObj.isSuccess = false;
                        }

                    }
                    else
                    {
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoUserFound");
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
        public async Task<ResponseObj<List<GetUserViewModel>>> GetAllUser()
        {
            ResponseObj<List<GetUserViewModel>> responseObj = new ResponseObj<List<GetUserViewModel>>();
            try
            {
                var Users = await _unitOfWork.UserRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.UserId)
                    .Select(x => new GetUserViewModel
                    {
                        UserId = x.UserId,
                        WorkshopId = Convert.ToInt32(x.WorkshopId),
                        Name = x.Name,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        RoleId = Convert.ToInt32(x.RoleId),
                        WorkshopName = x.Workshop.WorkshopName,
                        IsProductive = x.IsProductive,
                        RoleName = x.Role.RoleName
                    }).ToListAsync();
                if (Users.Count() > 0)
                {
                    responseObj.Data = Users;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Users";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<GetUserViewModel>>> GetAllUserByWorkshopId(int WorkshopId)
        {
            ResponseObj<List<GetUserViewModel>> responseObj = new ResponseObj<List<GetUserViewModel>>();
            try
            {
                var Users = await _unitOfWork.UserRepository.GetWithoutTracking()
                    .Where(x => x.IsActive && x.WorkshopId == WorkshopId).OrderByDescending(x => x.UserId)
                    .Select(x => new GetUserViewModel
                    {
                        UserId = x.UserId,
                        WorkshopId = Convert.ToInt32(x.WorkshopId),
                        Name = x.Name,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        RoleId = Convert.ToInt32(x.RoleId),
                        WorkshopName = x.Workshop.WorkshopName,
                        IsProductive = x.IsProductive,
                        RoleName = x.Role.RoleName
                    }).ToListAsync();
                if (Users.Count() > 0)
                {
                    responseObj.Data = Users;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Users";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<GetUserViewModel>> GetUserById(int UserId)
        {
            ResponseObj<GetUserViewModel> responseObj = new ResponseObj<GetUserViewModel>();
            try
            {
                var User = await _unitOfWork.UserRepository.GetWithoutTracking()
                    .Where(x => x.UserId == UserId && x.IsActive).Select(x => new GetUserViewModel
                    {
                        UserId = x.UserId,
                        WorkshopId = Convert.ToInt32(x.WorkshopId),
                        Name = x.Name,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        IsProductive = x.IsProductive,
                        RoleId = Convert.ToInt32(x.RoleId),
                        WorkshopName = x.Workshop.WorkshopName,
                        RoleName = x.Role.RoleName
                    }).FirstOrDefaultAsync();
                if (User != null)
                {
                    responseObj.Data = User;
                    responseObj.isSuccess = true;
                    responseObj.Message = "User Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteUser(int UserId, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveUser = await _unitOfWork.UserRepository.GetWithTracking().Where(x => x.UserId == UserId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveUser != null)
                {
                    RemoveUser.IsActive = false;
                    RemoveUser.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.UserRepository.Update(RemoveUser);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("UserDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoUserFound");
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<GetUserViewModel>> UserLogin(string EmailId, string Password,string lang)
        {
            ResponseObj<GetUserViewModel> responseObj=new ResponseObj<GetUserViewModel>();
            try
            {
                var VerifyUser=await _unitOfWork.UserRepository.GetWithoutTracking()
                    .Where(x=>x.EmailId==EmailId && x.Password==Password && x.IsActive)
                    .Select(x=> new GetUserViewModel
                    {
                        UserId = x.UserId,
                        WorkshopId = Convert.ToInt32(x.WorkshopId),
                        Name = x.Name,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        IsProductive = x.IsProductive,
                        RoleId = Convert.ToInt32(x.RoleId),
                        WorkshopName = x.Workshop.WorkshopName,
                        RoleName = x.Role.RoleName,
                        IsActive=x.IsActive,
                        UserType = "User"
                    }).FirstOrDefaultAsync();
                if(VerifyUser != null)
                {
                    if (!VerifyUser.IsActive)
                    {
                        responseObj.isSuccess = false;
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("NoUserFound");
                    }
                    else
                    {
                        responseObj.Data = VerifyUser;
                        responseObj.isSuccess = true;
                    }
                }
                else
                {
                    responseObj.isSuccess = false;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("UserInactive");
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
