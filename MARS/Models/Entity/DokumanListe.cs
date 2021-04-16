using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class DokumanListe
    {
        [Key]
        public int DokumanListeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TekdokAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TekdokNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TekdokTip { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string TekdokDosya { get; set; }

        public int ProjeId { get; set; }
        public virtual Projeler Projeler { get; set; }

        public ICollection<OnaySayfasi> OnaySayfasis { get; set; }
        public ICollection<DegisiklikIzleme> DegisiklikIzlemes { get; set; }
        public ICollection<Kapak> Kapaks { get; set; }
        public ICollection<Referans> Referans { get; set; }
        public ICollection<YazilimVersiyon> YazilimVersiyons { get; set; }
        public ICollection<EmniyetTalimatlari> EmniyetTalimatlaris { get; set; }
        public ICollection<Urunler> Urunlers { get; set; }
        public ICollection<PBSKart> PBSKarts { get; set; }
    }
}