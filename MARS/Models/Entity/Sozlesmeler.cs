using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Sozlesmeler
    {
        [Key]
        public int SozlesmeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Idari { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Yuklenici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string AltYuklenici { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Tedarikciler { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DosyaYolu { get; set; }

        public int ProjeId { get; set; }
        public virtual Projeler Projeler { get; set; }
    }
}