using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MobileNo { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public double HourlyRate { get; set; }
        public bool IsProductive { get; set; }
        public int? WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set;}

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
