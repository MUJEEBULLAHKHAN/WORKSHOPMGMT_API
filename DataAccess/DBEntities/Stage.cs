using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Stage
    {
        [Key]
        public int StageId { get; set; }
        public int StageNo { get; set; }
        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string NameAr { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
        public ICollection<Job> Tasks { get; set;}
    }
}
