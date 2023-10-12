using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class WorkshopViewModel
    {
        public int WorkshopId { get; set; }
        public string WorkshopName { get; set; }
        public int OwnerId { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string WorkshopAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public double Vat { get; set; }
        public double LaborRate { get; set; }
        public string CR { get; set; }
        public string? Logo { get; set; }
    }
    public class WorkshopUpdateViewModel
    {
        public int WorkshopId { get; set; }
        public string WorkshopName { get; set; }
        public int OwnerId { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string WorkshopAddress { get; set; }
        public double Vat { get; set; }
        public double LaborRate { get; set; }
        public string CR { get; set; }
    }
    public class GetWorkshopViewModel
    {
        public int WorkshopId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public double Vat { get; set; }
        public double LaborRate { get; set; }
        public string CR { get; set; }
        public string UserType { get; set; }
    }
    public class OwnerViewModel
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string UserType { get; set; }
    }
    public class UserCountViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalWorkshops { get; set; }
        public int TotalWorkshopUsers { get; set; }
        
    }
}
