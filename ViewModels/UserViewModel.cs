using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsProductive { get; set; }
        public string MobileNo { get; set; }
        public int RoleId { get; set; }
        public double HourlyRate { get; set; }
        public int WorkshopId { get; set; }
    }
    public class UserUpdateViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public bool IsProductive { get; set; }
        public double HourlyRate { get; set; }
        public int RoleId { get; set; }
        public int WorkshopId { get; set; }
    }
    public class GetUserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int RoleId { get; set; }
        public bool IsProductive { get; set; }
        public string RoleName { get; set; }
        public string WorkshopName { get; set; }
        public string UserType { get; set; }
        public int WorkshopId { get; set; }
        public bool IsActive {  get; set; }
    }
}
