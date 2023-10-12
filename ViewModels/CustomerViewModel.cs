using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CustomerViewModel
    {
        public int? CustomerId { get; set; }
        public int? CustomerTypeId { get; set; }
        public string MobileNo { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? CustomerTypeName { get; set; }
        public string Gender { get; set; }
        public int AddOrModifiedBy { get; set; }
    }
}
