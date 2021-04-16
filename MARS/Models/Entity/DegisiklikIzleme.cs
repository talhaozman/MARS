using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class DegisiklikIzleme
    {
        [Key]
        public int DegIzId { get; set; }
        public string sirano { get; set; }
        public DateTime SurumTarihi { get; set; }
        public string SurumNo { get; set; }
        public string DokOnayNo { get; set; }
        public DateTime OnayTarihi { get; set; }
        public string DegAciklama { get; set; }
        public string DegYapSayfa { get; set; }
        public string DegisiklikDosyaYolu { get; set; }
        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}