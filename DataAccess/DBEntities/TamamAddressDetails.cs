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
    public class TamamAddressDetails
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string? Location { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public string? City { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public string? Street { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public string? AreaCode { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
