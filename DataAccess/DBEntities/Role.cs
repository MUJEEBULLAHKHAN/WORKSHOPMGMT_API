using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string RoleName { get; set; }
        public string RoleNameAr { get; set; }
        public bool IsActive { get; set; }
    }
}
