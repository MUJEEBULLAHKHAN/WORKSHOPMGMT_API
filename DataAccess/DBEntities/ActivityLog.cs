using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class ActivityLog
    {
        [Key]
        public int ActivityLogId { get; set; }
        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? StageId { get; set; }
        [ForeignKey("StageId")]
        public Stage Stage { get; set; }
        public bool IsJobStarted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoggedOn { get; set; }  //when job comes to the stage
    }
}
