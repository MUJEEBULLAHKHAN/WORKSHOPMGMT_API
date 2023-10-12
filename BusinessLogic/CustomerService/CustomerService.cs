using BusinessLogic.CommonService;
using BusinessLogic.UnitOfWork;
using DataAccess.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public CustomerService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }
        public async Task<ResponseObj<string>> AddCustomer(CustomerViewModel customerViewModel,string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                CustomerValidator validationRules = new CustomerValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(customerViewModel);
                if (ValidatorResult.IsValid)
                {
                    var UpdateCustomer = await _unitOfWork.CustomerRepository.GetWithTracking().
                        Where(x => x.CustomerId == customerViewModel.CustomerId && x.IsActive).FirstOrDefaultAsync();
                    if (UpdateCustomer != null)
                    {
                        if (UpdateCustomer.MobileNo == customerViewModel.MobileNo)
                        {
                            responseObj.Message = "Mobile No is already exist";
                            responseObj.isSuccess = false;
                        }
                        else if (UpdateCustomer.Email == customerViewModel.Email)
                        {
                            responseObj.Message = "Email Id is already exist";
                            responseObj.isSuccess = false;
                        }
                    }
                    else
                    {
                        Customer customer = new Customer();
                        customer.CustomerName = customerViewModel.CustomerName;
                        customer.MobileNo = customerViewModel.MobileNo;
                        customer.Email = customerViewModel.Email;
                        customer.Address = customerViewModel.Address;
                        customer.Gender = customerViewModel.Gender;
                        customer.CustomerTypeId = customerViewModel.CustomerTypeId;
                        customer.CreatedOn = _commonService.GetCurrentSaudiTime();
                        customer.IsActive = true;
                        customer.CreatedBy = customerViewModel.AddOrModifiedBy;
                        await _unitOfWork.CustomerRepository.Add(customer);
                        await _unitOfWork.Complete();
                        responseObj.Message = "Customer Added";
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
        public async Task<ResponseObj<string>> UpdateCustomer(CustomerViewModel customerViewModel, string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                CustomerValidator validationRules = new CustomerValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(customerViewModel);
                if (ValidatorResult.IsValid)
                {
                    var UpdateCustomer = await _unitOfWork.CustomerRepository.GetWithTracking().Where(x => x.CustomerId == customerViewModel.CustomerId && x.IsActive).FirstOrDefaultAsync();
                    if (UpdateCustomer != null)
                    {
                        if (UpdateCustomer.MobileNo != customerViewModel.MobileNo)
                        {
                            if (UpdateCustomer.Email != customerViewModel.Email)
                            {
                                UpdateCustomer.CustomerName = customerViewModel.CustomerName;
                                UpdateCustomer.MobileNo = customerViewModel.MobileNo;
                                UpdateCustomer.Email = customerViewModel.Email;
                                UpdateCustomer.Address = customerViewModel.Address;
                                UpdateCustomer.Gender = customerViewModel.Gender;
                                UpdateCustomer.CustomerTypeId = customerViewModel.CustomerTypeId;
                                UpdateCustomer.UpdatedOn = _commonService.GetCurrentSaudiTime();
                                UpdateCustomer.UpdatedBy = customerViewModel.AddOrModifiedBy;
                                await _unitOfWork.CustomerRepository.Add(UpdateCustomer);
                                await _unitOfWork.Complete();
                                responseObj.Message = "Customer Updated";
                                responseObj.isSuccess = true;
                            }
                            else
                            {
                                responseObj.Message = "Email Id is already exist";
                                responseObj.isSuccess = false;
                            }
                        }
                        else
                        {
                            responseObj.Message = "Mobile No is already exist";
                            responseObj.isSuccess = false;
                        }

                    }
                    else
                    {
                        responseObj.Message = "No Customer Found";
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
        public async Task<ResponseObj<List<CustomerViewModel>>> GetAllCustomer()
        {
            ResponseObj<List<CustomerViewModel>> responseObj = new ResponseObj<List<CustomerViewModel>>();
            try
            {
                var Customers = await _unitOfWork.CustomerRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.CustomerId)
                    .Select(x => new CustomerViewModel
                    {
                        CustomerId = x.CustomerId,
                        CustomerName = x.CustomerName,
                        Email = x.Email,
                        MobileNo = x.MobileNo,
                        Gender = x.Gender,
                        Address = x.Address,
                        CustomerTypeId = x.CustomerTypeId,
                        CustomerTypeName=x.CustomerType.CustomerTypeName
                    }).ToListAsync();
                if (Customers.Count() > 0)
                {
                    responseObj.Data = Customers;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Customers";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<CustomerViewModel>> GetCustomerById(int CustomerId)
        {
            ResponseObj<CustomerViewModel> responseObj = new ResponseObj<CustomerViewModel>();
            try
            {
                var Customer = await _unitOfWork.CustomerRepository.GetWithoutTracking()
                    .Where(x => x.CustomerId == CustomerId && x.IsActive).Select(x => new CustomerViewModel
                    {
                        CustomerId = x.CustomerId,
                        CustomerName = x.CustomerName,
                        Email = x.Email,
                        MobileNo = x.MobileNo,
                        Gender = x.Gender,
                        Address = x.Address,
                        CustomerTypeId = x.CustomerTypeId,
                        CustomerTypeName = x.CustomerType.CustomerTypeName
                    }).FirstOrDefaultAsync();
                if (Customer != null)
                {
                    responseObj.Data = Customer;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Customer Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteCustomer(int CustomerId, int AddOrModifiedBy)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveCustomer = await _unitOfWork.CustomerRepository.GetWithTracking().Where(x => x.CustomerId == CustomerId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveCustomer != null)
                {
                    RemoveCustomer.IsActive = false;
                    RemoveCustomer.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    RemoveCustomer.UpdatedBy = AddOrModifiedBy;
                    await _unitOfWork.CustomerRepository.Update(RemoveCustomer);
                    await _unitOfWork.Complete();
                    responseObj.Message = "Customer Deleted Successfully";
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No User Found";
                    responseObj.isSuccess = false;
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
