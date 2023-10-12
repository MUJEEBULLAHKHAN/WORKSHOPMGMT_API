using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.Net.Mail;
using System.Net;

namespace BusinessLogic.CommonService
{
    public class CommonService: ICommonService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CommonService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public DateTime GetCurrentSaudiTime()
        {
            TimeZoneInfo Saudi_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");
            DateTime dateTime_Saudi = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Saudi_Standard_Time);
            return dateTime_Saudi;
        }
        public string CreateFolder(string FolderName, string MobileNo, string Flag)
        {
            string RootPath = _hostingEnvironment.ContentRootPath;
            string ImagePath = null;
            if (FolderName == "VehiclePics")
            {
                ImagePath = "Files/VehiclePics/" + MobileNo;
                Directory.CreateDirectory(RootPath + ImagePath);
            }
            if (FolderName == "Workshop")
            {
                ImagePath = "Files/Workshop/" + MobileNo;
                Directory.CreateDirectory(RootPath + ImagePath);
            }
            return ImagePath;

        }
        public string SaveImage(string image, string imagePath, string ImageName, bool IsDataNull)
        {
            string Extention = null, filePath = null;

            string[] ImageFile;
            try
            {
                string Path = _hostingEnvironment.ContentRootPath;
                if (IsDataNull == true)
                {
                    if (image.Contains(','))
                    {
                        ImageFile = image.Split(',');
                        image = ImageFile[1];
                        if (ImageFile[0].StartsWith("data:image/png"))
                        {
                            Extention = ".png";
                        }
                        else if (ImageFile[0].StartsWith("data:image/jpeg"))
                        {
                            Extention = ".jpeg";
                        }
                        else if (ImageFile[0].StartsWith("data:application/pdf"))
                        {
                            Extention = ".pdf";
                        }
                        else if (ImageFile[0].StartsWith("data:video/mp4"))
                        {
                            Extention = ".mp4";
                        }
                        else
                        {
                            Extention = ".jpg";
                        }
                    }
                    else
                    {
                        Extention = ".png";
                    }

                }
                else
                {
                    Extention = ".png";
                }



                byte[] newBytes = new byte[8000];
                if (image != null)
                {
                    newBytes = Convert.FromBase64String(image);
                }

                filePath = imagePath + "/" + ImageName + Extention;
                MemoryStream ms = new MemoryStream(newBytes, 0, newBytes.Length);
                ms.Write(newBytes, 0, newBytes.Length);
                if (Extention == ".pdf")
                {
                    File.WriteAllBytes(Path + filePath, newBytes);
                    return filePath;
                }
                else if (Extention == ".mp4")
                {
                    File.WriteAllBytes(Path + filePath, newBytes);
                    return filePath;
                }
                else
                {
                    Image img = Image.FromStream(ms, true);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    img.Save(Path + filePath);
                }
                //string httpPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace("api", "|").Split('|')[0];
                return filePath;
            }
            catch (Exception ex)
            {

            }
            return filePath;
        }
        public ResourceManager GetasPerLanguage(string lang)
        {
            ResourceManager _LangEng = new ResourceManager("BusinessLogic.MessageEnglish", Assembly.GetExecutingAssembly());
            ResourceManager _LangAr = new ResourceManager("BusinessLogic.MessageArabic", Assembly.GetExecutingAssembly());
            ResourceManager resourceManger;
            if (lang == "ar")
                resourceManger = _LangAr;
            else
                resourceManger = _LangEng;
            return resourceManger;
        }
        public async Task SendEmail(string Body, string MailTo, string Subject)
        {
            try
            {
                MailAddress to = new MailAddress(MailTo);
                MailAddress from = new MailAddress("sajeddeshmukh@gmail.com");

                MailMessage mail = new MailMessage(from, to);

                mail.Subject = Subject;

                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential(
                    "sajeddeshmukh@gmail.com", "bobbrtpkomqoubxp");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
