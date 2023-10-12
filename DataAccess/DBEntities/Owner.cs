using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string OwnerName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string MobileNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
