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

namespace BusinessLogic.WorkshopService
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        public WorkshopService(IUnitOfWork unitOfWork, ICommonService commonService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
        }
        public async Task<ResponseObj<string>> AddWorkshop(WorkshopViewModel workshopViewModel,string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                WorkshopValidator validationRules = new WorkshopValidator(lang, _commonService);
                var ValidatorResult = validationRules.Validate(workshopViewModel);
                if (ValidatorResult.IsValid)
                {
                    var workshopDetails = await _unitOfWork.WorkshopRepository.GetWithTracking().Where(x => x.WorkshopId == workshopViewModel.WorkshopId && x.IsActive).FirstOrDefaultAsync();
                    if (workshopDetails != null)
                    {
                        if (workshopDetails.MobileNo == workshopViewModel.MobileNo)
                        {
                            responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistMobileNo");
                            responseObj.isSuccess = false;
                        }
                        else if (workshopDetails.EmailId == workshopViewModel.EmailId)
                        {
                            responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("ExistEmailId");
                            responseObj.isSuccess = false;
                        }
                    }
                    else
                    {
                        Workshop workshop = new Workshop();
                        workshop.WorkshopName = workshopViewModel.WorkshopName;
                        workshop.OwnerId = workshopViewModel.OwnerId;
                        workshop.EmailId = workshopViewModel.EmailId;
                        workshop.MobileNo = workshopViewModel.MobileNo;
                        workshop.WorkshopAddress = workshopViewModel.WorkshopAddress;
                        workshop.Password = workshopViewModel.Password;
                        workshop.Vat = workshopViewModel.Vat;
                        workshop.LaborRate = workshopViewModel.LaborRate;
                        string FolderPath = _commonService.CreateFolder("Workshop", workshopViewModel.WorkshopName, string.Empty);
                        string _WorkshopCR = _commonService.SaveImage(workshopViewModel.CR, FolderPath, "CRDoc", true);
                        if (!string.IsNullOrEmpty(_WorkshopCR))
                        {
                            workshop.CR = _WorkshopCR;
                        }
                        string _Logo = _commonService.SaveImage(workshopViewModel.Logo, FolderPath, "Logo", true);
                        if (!string.IsNullOrEmpty(_Logo))
                        {
                            workshop.Logo = _Logo;
                        }
                        workshop.Password = workshopViewModel.Password;
                        workshop.CreatedOn = _commonService.GetCurrentSaudiTime();
                        workshop.IsActive = true;
                        await _unitOfWork.WorkshopRepository.Add(workshop);
                        await _unitOfWork.Complete();
                        string userName = workshopViewModel.EmailId;
                        string temporaryPassword = workshopViewModel.Password;
                        if (lang == "en")
                        {
                            string body = @"
                    <html>
                    <body>
                        <p>Dear,</p>
                        <p>We are thrilled to welcome you to Workshop manager! Thank you for choosing our services, and we're excited to have you on board.</p>
                        <p>To get started, we've created your account, and your login credentials are provided below:</p>
                        <p><strong>Username/Email:</strong> {{userName}}</p>
                        <p><strong>Password:</strong> {{temporaryPassword}}</p>
                        <p>Please take a moment to log in using the provided credentials. We highly recommend changing your password after your initial login for security purposes. Here's a quick guide on how to do that:</p>
                        <ol>
                            <li>Visit our website (www.smaftco.com).</li>
                            <li>Click on the ""Login"" or ""Sign In"" button.</li>
                            <li>Enter your provided username/email and temporary password.</li>
                            <li>You will be prompted to create a new, secure password. Please ensure it meets our password requirements for added security.</li>
                        </ol>
                        <p>If you encounter any difficulties logging in or have any questions, our support team is ready to assist you. You can reach us at <a href='mailto:info@smaftco.com'>info@smaftco.com</a>.</p>
                        <p>Once you've logged in, you'll have access to all the features and resources available to workshop manager users.</p>
                        <p>We are committed to providing you with a seamless and valuable experience, and we look forward to serving your needs.</p>
                        <p>Best regards,<br/>SMAFTCO SOFTWARE DEVELOPMENT & IT SOLUTIONS<br/><a href='http://www.smaftco.com'>www.smaftco.com</a><br/><a href='mailto:info@smaftco.com'>info@smaftco.com</a></p>
                    </body>
                    </html>";
                            body = body.Replace("{{userName}}", userName).Replace("{{temporaryPassword}}", temporaryPassword);
                            _commonService.SendEmail(body, workshopViewModel.EmailId, "Welcome to Workshop Manager");
                        }
                        else
                        {
                            string body = @"
                    <html dir=""""rtl"""">
    <body>
        <p>عزيزي/عزيزتي,</p>
        <p>نحن متحمسون للغاية لرحب بكم في """"مدير ورش العمل""""! شكرًا لاختياركم خدماتنا، ونحن متحمسون لوجودكم معنا.</p>
        <p>للبدء، قمنا بإنشاء حسابكم، ومعلومات تسجيل الدخول الخاصة بكم متاحة أدناه:</p>
        <p><strong>اسم المستخدم/البريد الإلكتروني:</strong> {{userName}}</p>
        <p><strong>كلمة المرور:</strong> {{temporaryPassword}}</p>
        <p>نرجو منكم أن تقضوا لحظة لتسجيل الدخول باستخدام المعلومات المقدمة. نوصي بشدة بتغيير كلمة المرور بعد تسجيل الدخول الأول لأسباب أمانية. إليكم دليل سريع حول كيفية القيام بذلك:</p>
        <ol>
            <li>زيارة موقعنا على الويب.</li>
            <li>النقر على زر """"تسجيل الدخول"""" أو """"تسجيل الدخول"""".</li>
            <li>إدخال اسم المستخدم/البريد الإلكتروني الخاص بكم وكلمة المرور المؤقتة المقدمة.</li>
            <li>ستتم مطالبتكم بإنشاء كلمة مرور جديدة وآمنة. يرجى التأكد من أنها تلبي متطلبات كلمة المرور الخاصة بنا لزيادة الأمان.</li>
        </ol>
        <p>إذا واجهتم أية صعوبات أثناء تسجيل الدخول أو كان لديكم أي استفسارات، فإن فريق الدعم الخاص بنا مستعد لمساعدتكم. يمكنكم الاتصال بنا على البريد الإلكتروني <a href=""""mailto:info@smaftco.com"""">info@smaftco.com</a>.</p>
        <p>بمجرد تسجيل الدخول، ستكون لديكم وصول إلى جميع الميزات والموارد المتاحة لمستخدمي مدير ورش العمل.</p>
        <p>نحن ملتزمون بتوفير تجربة سلسة وقيمة بالنسبة لكم، ونتطلع إلى خدمة احتياجاتكم.</p>
        <p>مع أطيب التحيات،</p>
        <p>سمافتكو</p>
        <p>تطوير البرمجيات وحلول تكنولوجيا المعلومات</p>
        <a href=""""http://www.smaftco.com"""">www.smaftco.com</a>
        <a href=""""mailto:info@smaftco.com"""">info@smaftco.com</a>
    </body>
    </html>"";";
                            body = body.Replace("{{userName}}", userName).Replace("{{temporaryPassword}}", temporaryPassword);
                            _commonService.SendEmail(body, workshopViewModel.EmailId, "مرحبا بكم في مدير ورشة العمل");
                        }
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("WorkshopAdded");
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
        public async Task<ResponseObj<string>> UpdateWorkshop(WorkshopUpdateViewModel workshopUpdateViewModel,string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                UpdateWorkshopValidator validationRules = new UpdateWorkshopValidator();
                var ValidatorResult = validationRules.Validate(workshopUpdateViewModel);
                if (ValidatorResult.IsValid)
                {
                    var workshopDetails = await _unitOfWork.WorkshopRepository.GetWithTracking().Where(x => x.WorkshopId == workshopUpdateViewModel.WorkshopId && x.IsActive).FirstOrDefaultAsync();
                    if (workshopDetails != null)
                    {

                        workshopDetails.WorkshopName = workshopUpdateViewModel.WorkshopName;
                        workshopDetails.MobileNo = workshopUpdateViewModel.MobileNo;
                        workshopDetails.EmailId = workshopUpdateViewModel.EmailId;
                        workshopDetails.OwnerId = workshopUpdateViewModel.OwnerId;
                        workshopDetails.WorkshopAddress = workshopUpdateViewModel.WorkshopAddress;
                        workshopDetails.UpdatedOn = _commonService.GetCurrentSaudiTime();
                        await _unitOfWork.WorkshopRepository.Add(workshopDetails);
                        await _unitOfWork.Complete();
                        responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("WorkshopUpdated");
                        responseObj.isSuccess = true;



                    }
                    else
                    {
                        responseObj.Message = "No Workshop Found";
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
        public async Task<ResponseObj<List<WorkshopUpdateViewModel>>> GetAllWorkshop()
        {
            ResponseObj<List<WorkshopUpdateViewModel>> responseObj = new ResponseObj<List<WorkshopUpdateViewModel>>();
            try
            {
                var Workshops = await _unitOfWork.WorkshopRepository.GetWithoutTracking()
                    .Where(x => x.IsActive).OrderByDescending(x => x.WorkshopId)
                    .Select(x => new WorkshopUpdateViewModel
                    {
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.WorkshopName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        OwnerId = x.OwnerId,
                        WorkshopAddress = x.WorkshopAddress
                    }).ToListAsync();
                if (Workshops.Count() > 0)
                {
                    responseObj.Data = Workshops;
                    responseObj.isSuccess = true;
                    responseObj.Message = "List of Workshops";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<WorkshopUpdateViewModel>> GetWorkshopById(int WorkshopId)
        {
            ResponseObj<WorkshopUpdateViewModel> responseObj = new ResponseObj<WorkshopUpdateViewModel>();
            try
            {
                var Workshop = await _unitOfWork.WorkshopRepository.GetWithoutTracking()
                    .Where(x => x.WorkshopId == WorkshopId && x.IsActive).Select(x => new WorkshopUpdateViewModel
                    {
                        WorkshopId = x.WorkshopId,
                        WorkshopName = x.WorkshopName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        OwnerId = x.OwnerId,
                        WorkshopAddress = x.WorkshopAddress
                    }).FirstOrDefaultAsync();
                if (Workshop != null)
                {
                    responseObj.Data = Workshop;
                    responseObj.isSuccess = true;
                    responseObj.Message = "Workshop Details";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> DeleteWorkshop(int WorkshopId,string lang)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                var RemoveWorkshop = await _unitOfWork.WorkshopRepository.GetWithTracking().Where(x => x.WorkshopId == WorkshopId && x.IsActive).FirstOrDefaultAsync();
                if (RemoveWorkshop != null)
                {
                    RemoveWorkshop.IsActive = false;
                    RemoveWorkshop.UpdatedOn = _commonService.GetCurrentSaudiTime();
                    await _unitOfWork.WorkshopRepository.Update(RemoveWorkshop);
                    await _unitOfWork.Complete();
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("WorkshopDeleted");
                    responseObj.isSuccess = true;
                }
                else
                {
                    responseObj.Message = "No Workshop Found";
                    responseObj.isSuccess = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<GetWorkshopViewModel>> WorkshopLogin(string EmailId, string Password,string lang)
        {
            ResponseObj<GetWorkshopViewModel> responseObj = new ResponseObj<GetWorkshopViewModel>();
            try
            {
                var VerifyUser = await _unitOfWork.WorkshopRepository.GetWithoutTracking()
                    .Where(x => x.EmailId == EmailId && x.Password == Password && x.IsActive)
                    .Select(x => new GetWorkshopViewModel
                    {

                        WorkshopId = Convert.ToInt32(x.WorkshopId),
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        Name = x.WorkshopName,
                        UserType = "Workshop"
                    }).FirstOrDefaultAsync();
                if (VerifyUser != null)
                {

                    responseObj.Data = VerifyUser;
                    responseObj.isSuccess = true;

                }
                else
                {
                    responseObj.isSuccess = false;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("IncorrectEmailPwd");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }

        public async Task<ResponseObj<OwnerViewModel>> OwnerLogin(string EmailId, string Password,string lang)
        {
            ResponseObj<OwnerViewModel> responseObj = new ResponseObj<OwnerViewModel>();
            try
            {
                var VerifyUser = await _unitOfWork.OwnerRepository.GetWithoutTracking()
                    .Where(x => x.EmailId == EmailId && x.Password == Password && x.IsActive)
                    .Select(x => new OwnerViewModel
                    {
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        Name = x.OwnerName,
                        UserType = "Owner"
                    }).FirstOrDefaultAsync();
                if (VerifyUser != null)
                {

                    responseObj.Data = VerifyUser;
                    responseObj.isSuccess = true;

                }
                else
                {
                    responseObj.isSuccess = false;
                    responseObj.Message = _commonService.GetasPerLanguage(lang).GetString("IncorrectEmailPwd");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<string>> CreateOwner(OwnerViewModel ownerViewModel)
        {
            ResponseObj<string> responseObj = new ResponseObj<string>();
            try
            {
                Owner owner = new Owner();
                owner.EmailId=ownerViewModel.EmailId;
                owner.Password=ownerViewModel.Password;
                owner.MobileNo=ownerViewModel.MobileNo;
                owner.IsActive = true;
                owner.CreatedOn = _commonService.GetCurrentSaudiTime();
                owner.CreatedBy = 1;
                await _unitOfWork.OwnerRepository.Add(owner);
                await _unitOfWork.Complete();
                responseObj.Message = "Owner created";
                responseObj.isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
        public async Task<ResponseObj<UserCountViewModel>> UserCount()
        {
            ResponseObj<UserCountViewModel> responseObj = new ResponseObj<UserCountViewModel>();
            try
            {
                UserCountViewModel userCountViewModel= new UserCountViewModel();
                userCountViewModel.TotalWorkshops=await _unitOfWork.WorkshopRepository.GetWithoutTracking().Where(x=>x.IsActive).CountAsync();
                userCountViewModel.TotalWorkshopUsers=await _unitOfWork.UserRepository.GetWithoutTracking().Where(x => x.IsActive).CountAsync();
                userCountViewModel.TotalUsers = userCountViewModel.TotalWorkshops + userCountViewModel.TotalWorkshopUsers;
                responseObj.isSuccess=true;
                responseObj.Data = userCountViewModel;
            }
            catch (Exception)
            {

                throw;
            }
            return responseObj;
        }
    }
}
