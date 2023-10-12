using BusinessLogic.CommonService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using static Azure.Core.HttpHeader;
using static ViewModels.LookupViewModels;

namespace BusinessLogic
{
    public class Validations
    {
        public Validations() { }
    }
    public class CustomerValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyCustomerName"));
            RuleFor(x => x.CustomerTypeId).NotEmpty().GreaterThan(0).WithMessage(common.GetasPerLanguage(lang).GetString("SelectCustomerType"));
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(common.GetasPerLanguage(lang).GetString("InvalidEmailId"));
            RuleFor(x => x.MobileNo).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyMobileNo"));
            RuleFor(x => x.Gender).NotEmpty().Must(gender => gender == "Male" || gender == "Female").WithMessage("Gender must be either 'Male' or 'Female'."); ;
        }
    }
    public class WorkshopValidator : AbstractValidator<WorkshopViewModel>
    {
        public WorkshopValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.WorkshopName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyWorkshopName"));
            RuleFor(x => x.EmailId).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyEmailId")).EmailAddress().WithMessage(common.GetasPerLanguage(lang).GetString("InvalidEmailId"));
            RuleFor(x => x.MobileNo).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty().GreaterThan(0).WithMessage("Please select Owner");
            RuleFor(x => x.WorkshopAddress).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .MaximumLength(20).WithMessage("Password cannot exceed 20 characters.");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().Equal(user => user.Password).WithMessage("Password and confirm password do not match.");
        }
    }
    public class UpdateWorkshopValidator : AbstractValidator<WorkshopUpdateViewModel>
    {
        public UpdateWorkshopValidator()
        {
            RuleFor(x => x.WorkshopName).NotEmpty();
            RuleFor(x => x.EmailId).NotEmpty().EmailAddress().WithMessage("Invalid Email Id");
            RuleFor(x => x.MobileNo).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
            RuleFor(x => x.WorkshopAddress).NotEmpty();
        }
    }
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EmailId).NotEmpty().EmailAddress().WithMessage("Invalid Email Id");
            RuleFor(x => x.MobileNo).NotEmpty();
                //.Matches(@"^05[0-9]{7}$").WithMessage("Invalid mobile number. The mobile number must start with '05' followed by 9 digits.")
                //.Length(10).WithMessage("Mobile number length must be 10 characters.");
            RuleFor(x => x.RoleId).GreaterThan(0).WithMessage("Please select Role");
            RuleFor(x => x.WorkshopId).GreaterThan(0).WithMessage("Please select Workshop");
            RuleFor(x => x.Password).NotEmpty().Matches(x => x.ConfirmPassword).WithMessage("Password and Confirm Password should be match");
        }
    }
    public class UpdateUserValidator : AbstractValidator<UserUpdateViewModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EmailId).NotEmpty().EmailAddress().WithMessage("Invalid Email Id");
            RuleFor(x => x.MobileNo).NotEmpty();
            RuleFor(x => x.RoleId).GreaterThan(0).WithMessage("Please select Role");
            RuleFor(x => x.WorkshopId).GreaterThan(0).WithMessage("Please select Workshop");
        }
    }
    public class ColorValidator : AbstractValidator<ColorViewModel>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).NotEmpty();
        }
    }
    public class JobStatusValidator : AbstractValidator<JobStatusViewModel>
    {
        public JobStatusValidator()
        {
            RuleFor(x => x.JobStatusName).NotEmpty();
        }
    }
    public class RoleValidator : AbstractValidator<RoleViewModel>
    {
        public RoleValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyRoleName"));
            RuleFor(x => x.WorkshopId).GreaterThan(0).WithMessage(common.GetasPerLanguage(lang).GetString("SelectWorkshop"));
        }
    }
    public class StageValidator : AbstractValidator<StageViewModel>
    {
        public StageValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.StageName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyRoleName"));
            RuleFor(x => x.WorkshopId).GreaterThan(0).WithMessage(common.GetasPerLanguage(lang).GetString("SelectWorkshop"));
        }
    }
    public class VehicleMakeValidator : AbstractValidator<VehicleMakeViewModel>
    {
        public VehicleMakeValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.VehicleMakeName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyVehicleName"));
        }
    }
    public class VehicleModelValidator : AbstractValidator<VehicleModelViewModel>
    {
        public VehicleModelValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.VehicleModelName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyVehicleModel"));
            RuleFor(x => x.VehicleMakeId).GreaterThan(0).WithMessage(common.GetasPerLanguage(lang).GetString("SelectVehicleMake")); 
        }
    }
    public class CustomerTypeValidator : AbstractValidator<CustomerTypeViewModel>
    {
        public CustomerTypeValidator(string lang, ICommonService common)
        {
            RuleFor(x => x.CustomerTypeName).NotEmpty().WithMessage(common.GetasPerLanguage(lang).GetString("EmptyCustomerTypeName"));
        }
    }
}
