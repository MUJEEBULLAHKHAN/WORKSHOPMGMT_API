using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace BusinessLogic.CommonService
{
    public interface ICommonService
    {
        DateTime GetCurrentSaudiTime();
        string CreateFolder(string FolderName, string MobileNo, string Flag);
        string SaveImage(string image, string imagePath, string ImageName, bool IsDataNull);
        ResourceManager GetasPerLanguage(string lang);
        Task SendEmail(string Body, string MailTo, string Subject);
    }
}
