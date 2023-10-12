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

namespace BusinessLogic.TamamService
{
    public class TamamService : ITamamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public TamamService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }

        public async Task<ResponseObj<TamamUserViewModel>> TamamUserLogin(string MobileNo)
        {
            ResponseObj<TamamUserViewModel> responseObj = new ResponseObj<TamamUserViewModel>();
            try
            {
                var User = await _unitOfWork.tamamUserRepository.GetWithoutTracking()
                    .Where(x => x.MobileNo == MobileNo).Select(x => new TamamUserViewModel
                    {
                        UserId = x.UserId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        VerificationPin = x.VerificationPin
                    }).FirstOrDefaultAsync();
                if (User != null)
                {
                    responseObj.Data = User;
                    responseObj.isSuccess = true;
                    responseObj.Message = "User Details";
                }
                else
                {
                    responseObj.Data = null;
                    responseObj.isSuccess = false;
                    responseObj.Message = "Mobile No Not Exists";
                }

            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        
        public async Task<ResponseObj<TamamUserViewModel>> AddTamamUser(TamamUserViewModel tamamUserViewModel)
        {
            ResponseObj<TamamUserViewModel> responseObj = new ResponseObj<TamamUserViewModel>();
            try
            {
              
                    if (tamamUserViewModel.UserId == 0)
                    {
                        var userdetails = await _unitOfWork.tamamUserRepository.GetWithTracking().Where(x => x.MobileNo == tamamUserViewModel.MobileNo).FirstOrDefaultAsync();
                        if (userdetails != null)
                        {
                            responseObj.Message = "Mobile No is already exist";
                            responseObj.isSuccess = false;
                        }
                        else
                        {
                            TamamUserDetails user = new TamamUserDetails();
                            user.MobileNo = tamamUserViewModel.MobileNo;
                            user.FirstName = tamamUserViewModel.FirstName;
                            user.LastName = tamamUserViewModel.LastName;
                            user.EmailId = tamamUserViewModel.EmailId;
                            user.VerificationPin = "0000";
                            user.CreatedBy = 1;
                            user.CreatedOn = _commonService.GetCurrentSaudiTime();
                            user.IsActive = true;
                            await _unitOfWork.tamamUserRepository.Add(user);
                            await _unitOfWork.Complete();
                            responseObj.Message = "User Added";
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

        public async Task<ResponseObj<TamamUserViewModel>> AddTamamUserAddress(TamamAddressViewModel tamamAddressViewModel)
        {
            ResponseObj<TamamUserViewModel> responseObj = new ResponseObj<TamamUserViewModel>();
            try
            {

                if (tamamAddressViewModel.UserId != 0)
                {
                    var userdetails = await _unitOfWork.tamamUserRepository.GetWithTracking().Where(x => x.UserId == tamamAddressViewModel.UserId).FirstOrDefaultAsync();
                    if (userdetails != null)
                    {
                        TamamAddressDetails address = new TamamAddressDetails();
                        address.Location = tamamAddressViewModel.Location;
                        address.City = tamamAddressViewModel.City;
                        address.AreaCode = tamamAddressViewModel.AreaCode;
                        address.Street = tamamAddressViewModel.Street;
                        address.UserId = tamamAddressViewModel.UserId;
                        address.CreatedBy = 1;
                        address.CreatedOn = _commonService.GetCurrentSaudiTime();
                        address.IsActive = true;
                        await _unitOfWork.tamamAddressRepository.Add(address);
                        await _unitOfWork.Complete();
                        responseObj.Message = "Address Added";
                        responseObj.isSuccess = true;
                    }
                    else
                    {
                        responseObj.Message = "User Not found";
                        responseObj.isSuccess = false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<List<TamamUserViewModel>>> GetAllTamamUsers()
        {
            ResponseObj<List<TamamUserViewModel>> responseObj = new ResponseObj<List<TamamUserViewModel>>();
            try
            {
                var Users = await _unitOfWork.tamamUserRepository.GetWithoutTracking()
                    .OrderByDescending(x => x.UserId)
                    .Select(x => new TamamUserViewModel
                    {
                        UserId = x.UserId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        VerificationPin = x.VerificationPin
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

        public async Task<ResponseObj<TamamUserViewModel>> AddTamamUserVehicle(TamamVehicleViewModel tamamVehicleViewModel)
        {
            ResponseObj<TamamUserViewModel> responseObj = new ResponseObj<TamamUserViewModel>();
            try
            {

                if (tamamVehicleViewModel.UserId != 0)
                {
                    var userdetails = await _unitOfWork.tamamUserRepository.GetWithTracking().Where(x => x.UserId == tamamVehicleViewModel.UserId).FirstOrDefaultAsync();
                    if (userdetails != null)
                    {
                        TamamVehicleDetails vehicle = new TamamVehicleDetails();
                        vehicle.UserId   = tamamVehicleViewModel.UserId;
                        vehicle.VehicleMake = tamamVehicleViewModel.VehicleMake;
                        vehicle.VehicleModel = tamamVehicleViewModel.VehicleModel;
                        vehicle.ChassisNumber = tamamVehicleViewModel.ChassisNumber;
                        vehicle.IsCorporate = tamamVehicleViewModel.IsCorporate;
                        vehicle.Color = tamamVehicleViewModel.Color;
                        vehicle.Year = tamamVehicleViewModel.Year;
                        vehicle.PlateNumber = tamamVehicleViewModel.PlateNumber;
                        vehicle.Odometer = tamamVehicleViewModel.Odometer;
                        vehicle.IsInsured = tamamVehicleViewModel.IsInsured;
                        vehicle.CreatedBy = 1;
                        vehicle.CreatedOn = _commonService.GetCurrentSaudiTime();
                        vehicle.IsActive = true;
                        await _unitOfWork.tamamVehicleRepository.Add(vehicle);
                        await _unitOfWork.Complete();
                        responseObj.Message = "Vehicle Added";
                        responseObj.isSuccess = true;
                    }
                    else
                    {
                        responseObj.Message = "User Not found";
                        responseObj.isSuccess = false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }




        public async Task<ResponseObj<string>> AddTamamClaim(TamamClaimViewModel tamamClaimViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                TamamClaimDetails claim = new TamamClaimDetails();
                claim.UserId = tamamClaimViewModel.UserId;
                claim.ClaimId = tamamClaimViewModel.ClaimId;
                claim.status = "Pending";
                claim.Description = string.Empty;

                claim.Vehicle = new TamamVehicleDetails();
                claim.Vehicle.VehicleMake = tamamClaimViewModel.VehicleMake;
                claim.Vehicle.VehicleModel = tamamClaimViewModel.VehicleModel;
                claim.Vehicle.Year = tamamClaimViewModel.Year;
                claim.Vehicle.Color = tamamClaimViewModel.Color;
                claim.Vehicle.ChassisNumber = tamamClaimViewModel.ChassisNumber;
                claim.Vehicle.PlateNumber = tamamClaimViewModel.PlateNumber;
                claim.Vehicle.IsInsured = tamamClaimViewModel.IsInsured;
                claim.Vehicle.IsCorporate = tamamClaimViewModel.IsCorporate;
                claim.Vehicle.CreatedBy = Convert.ToInt32(tamamClaimViewModel.UserId);
                claim.Vehicle.IsActive = true;
                claim.Vehicle.CreatedOn = _commonService.GetCurrentSaudiTime();

                claim.address = new TamamAddressDetails();
                claim.address.Location = tamamClaimViewModel.Location;
                claim.address.Street = tamamClaimViewModel.Street;
                claim.address.City = tamamClaimViewModel.City;
                claim.address.CreatedOn = _commonService.GetCurrentSaudiTime();
                claim.address.CreatedBy = Convert.ToInt32(tamamClaimViewModel.UserId);
                claim.address.AreaCode = tamamClaimViewModel.AreaCode;


                claim.CreatedOn = _commonService.GetCurrentSaudiTime();
                claim.CreatedBy = Convert.ToInt32(tamamClaimViewModel.UserId);
                await _unitOfWork.tamamClaimRepository.RegisterClaim(claim);
                await _unitOfWork.Complete();
                responseObj.Message = "claims Details Created";
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
        public async Task<ResponseObj<List<TamamClaimViewModel>>> GetAllTamamClaimsbyUserId(int TamamUserId)
        {
            ResponseObj<List<TamamClaimViewModel>> responseObj = new ResponseObj<List<TamamClaimViewModel>>();
            try
            {
                var Claimlist = await _unitOfWork.tamamClaimRepository.GetWithoutTracking().Where(x => x.UserId == TamamUserId).Select(x => new TamamClaimViewModel
                {
                    UserId = Convert.ToInt32( x.UserId),
                    ClaimId = x.ClaimId,    
                    Color = x.Vehicle.Color,
                    ChassisNumber=x.Vehicle.ChassisNumber,
                    IsCorporate=x.Vehicle.IsCorporate,
                    IsInsured  =x.Vehicle.IsInsured,    
                    City    =x.address.City,
                    PlateNumber = x.Vehicle.PlateNumber ,
                    VehicleMake = x.Vehicle.VehicleMake,
                    VehicleModel = x.Vehicle.VehicleModel,
                    Year = x.Vehicle.Year,
                }).ToListAsync();
                if (Claimlist.Count > 0)
                {
                    responseObj.Data = Claimlist;
                    responseObj.isSuccess = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }

       
     
        
        
        
        public async Task<ResponseObj<TamamClaimViewModel>> GetTamamClaimbyClaimId(int ClaimId)
        {
            ResponseObj<TamamClaimViewModel> responseObj = new ResponseObj<TamamClaimViewModel>();
            try
            {
                var User = await _unitOfWork.tamamClaimRepository.GetWithoutTracking()
                    .Where(x => x.ClaimId == ClaimId).Select(x => new TamamClaimViewModel
                    {
                        UserId = Convert.ToInt32(x.UserId),
                        ClaimId = x.ClaimId,
                        Color = x.Vehicle.Color,
                        ChassisNumber = x.Vehicle.ChassisNumber,
                        IsCorporate = x.Vehicle.IsCorporate,
                        IsInsured = x.Vehicle.IsInsured,
                        City = x.address.City,
                        PlateNumber = x.Vehicle.PlateNumber,
                        VehicleMake = x.Vehicle.VehicleMake,
                        VehicleModel = x.Vehicle.VehicleModel,
                        Year = x.Vehicle.Year,
                    }).FirstOrDefaultAsync();
                if (User != null)
                {
                    responseObj.Data = User;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Claim Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }

        public async Task<ResponseObj<TamamAddressViewModel>> GetTamamUserAddressbyUserId(int TamamUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObj<TamamUserViewModel>> GetTamamUserbyUserId(int TamamUserId)
        {
            ResponseObj<TamamUserViewModel> responseObj = new ResponseObj<TamamUserViewModel>();
            try
            {
                var User = await _unitOfWork.tamamUserRepository.GetWithoutTracking()
                    .Where(x => x.UserId == TamamUserId ).Select(x => new TamamUserViewModel
                    {
                        UserId = x.UserId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        VerificationPin = x.VerificationPin
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

        public async Task<ResponseObj<TamamVehicleViewModel>> GetTamamUserVehiclebyUserId(int TamamUserId)
        {
            throw new NotImplementedException();
        }

        






        public async Task<ResponseObj<string>> UpdateTamamUserAddressDetails(TamamAddressViewModel tamamAddressViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObj<string>> UpdateTamamUserDetails(TamamUserViewModel tamamUserViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObj<string>> UpdateTamamUserVehicleDetails(TamamVehicleViewModel tamamVehicleViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
