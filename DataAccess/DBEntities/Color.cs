﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBEntities
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string ColorName { get; set; }
        public bool IsActive { get; set; }
    }
}
