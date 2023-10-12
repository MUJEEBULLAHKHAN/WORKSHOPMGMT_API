using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public int? StageId { get; set; }
        [ForeignKey("StageId")]
        public Stage Stage { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set;}
        public string VehicleParts { get; set; }
        public string? JobDescription { get; set; }
        public int? JobStatusId { get; set; }
        [ForeignKey("JobStatusId")]
        public JobStatus JobStatus { get; set;}
        [Column(TypeName ="nvarchar(1000)")]
        public string VehicleVideo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartedOn { get; set; }
        public int TotalParts { get; set; }
        public double LaborCharge { get; set; }
        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
