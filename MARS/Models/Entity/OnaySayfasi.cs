using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class OnaySayfasi
    {
        [Key]
        public int OnaySafaId { get; set; }
        public string GizlilikDerece { get; set; }
        public string FirmaDokumani { get; set; }
        [DataType(DataType.Date)]
        public DateTime IlkYayimTarih { get; set; }
        [DataType(DataType.Date)]
        public DateTime YayimTarihi { get; set; }
        public string SayfaSayisi { get; set; }
        public string Olcek { get; set; }
        public string SozlesmeMaddesi { get; set; }
        public string PioKoordinesi { get; set; }
        public string HazGorev { get; set; }
        public string HazKimlik { get; set; }
        [DataType(DataType.Date)]
        public DateTime HazTarih { get; set; }
        public string KoorGorev { get; set; }
        public string KoorKimlik { get; set; }
        [DataType(DataType.Date)]
        public DateTime KoorTarih { get; set; }
        public string AltYukOnayGorev { get; set; }
        public string AltYukOnayKimlik { get; set; }
        [DataType(DataType.Date)]
        public DateTime AltYukOnayTarih { get; set; }
        public string YukOnayGorev { get; set; }
        public string YukOnayKimlik { get; set; }
        [DataType(DataType.Date)]
        public DateTime YukOnayTarih { get; set; }
        public string OnayDosyaYolu { get; set; }
        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}