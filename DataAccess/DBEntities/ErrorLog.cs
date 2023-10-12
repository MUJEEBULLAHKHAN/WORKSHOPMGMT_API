using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class ErrorLog
    {
        [Key]
        public int ErrorId { get; set; }
        [Column(TypeName ="varchar(max)")]
        public string ErrorMessage { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime CreatedOn { get; set; }
    }
}
