using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class JobStatus
    {
        [Key]
        public int JobStatusId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string JobStatusName { get; set; }
        public string JobStatusNameAr { get; set; }
        public bool IsActive { get; set; }
    }
}
