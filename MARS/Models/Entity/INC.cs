using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class INC
    {
        [Key]
        public int INCId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string INCNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string INCAd { get; set; }

      
    }
}