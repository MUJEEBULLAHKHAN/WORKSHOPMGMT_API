using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string CustomerTypeName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerTypeNameAr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
