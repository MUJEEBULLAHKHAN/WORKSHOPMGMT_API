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
    public class Workshop
    {
        [Key]
        public int WorkshopId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string WorkshopName { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string EmailId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MobileNo { get; set; }
        public double Vat { get; set; }
        public double LaborRate { get; set; }
        [Column(TypeName = "nvarchar(600)")]
        public string CR { get; set; }
        [Column(TypeName = "nvarchar(600)")]
        public string? Logo { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string WorkshopAddress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
