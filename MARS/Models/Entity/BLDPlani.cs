using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class BLDPlani
    {
        [Key]
        public int BLDPlaniId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DokumanNo { get; set; }
        public string BLDDosya { get; set; }

        public int ProjeId { get; set; }
        public virtual Projeler Projeler { get; set; }

 
    }
}