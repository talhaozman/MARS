using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class PBSKart
    {
        [Key]
        public int PBSKartId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string GemiBirlikSistemi { get; set; }
        public string AltSistem { get; set; }
        public string Sistem { get; set; }
        public string Cihaz { get; set; }
        public string BikKodu { get; set; }
        public string Rutbe { get; set; }
        public string AxS { get; set; }
        public string ToplamAxS { get; set; }
        public string BakimSuresi { get; set; }
        public string BakimİslemTarifi { get; set; }
        public string EmniyetTedbirleri { get; set; }
        public string AtikBertaraf { get; set; }
        public string TestOlcuAletleri { get; set; }
        public string SarfMalzemeleri { get; set; }
        public string YedekParcalar { get; set; }
        public string BikTanNo { get; set; }
        public string Mevkii { get; set; }
        public string BikNu { get; set; }
        public string TakimAvadanlik { get; set; }
        public string YedekKullanim { get; set; }
        public string BakimYonetim { get; set; }

        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}