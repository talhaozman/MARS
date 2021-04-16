using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MARS.Models.Entity
{
    public class Context : DbContext
    {
        public DbSet<AmbSahKod> AmbSahKods { get; set; }
        public DbSet<AtikKodlari> AtikKodlaris { get; set; }
        public DbSet<BLDPlani> BLDPlanis { get; set; }
        public DbSet<DokumanListe> DokumanListes { get; set; }
        public DbSet<ElCikYontemi> ElCikYontemis { get; set; }
        public DbSet<GIGN> GIGNs { get; set; }
        public DbSet<INC> INCs { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<MalzemeKalemi> MalzemeKalemis { get; set; }
        public DbSet<Malzemeler> Malzemelers { get; set; }
        public DbSet<MalzemeTurleri> MalzemeTurleris { get; set; }
        public DbSet<NatoUreticileri> NatoUreticileris { get; set; }
        public DbSet<OlcuBirimleri> OlcuBirimleris { get; set; }
        public DbSet<OnarBilKodu> OnarBilKodus { get; set; }
        public DbSet<OzelMalzemeKodu> OzelMalzemeKodus { get; set; }
        public DbSet<PBSKart> PBSKarts { get; set; }
        public DbSet<Projeler> Projelers { get; set; }
        public DbSet<RafOmruKodu> RafOmruKodus { get; set; }
        public DbSet<Sozlesmeler> Sozlesmelers { get; set; }
        public DbSet<TemelBirim> TemelBirims { get; set; }
        public DbSet<UreticiMalzemeler> UreticiMalzemelers { get; set; }
        public DbSet<GrupSinifKodlari> GrupSinifKodlaris { get; set; }
        public DbSet<VeriBankasi> VeriBankasis { get; set; }
        public DbSet<OnaySayfasi> OnaySayfasis { get; set; }
        public DbSet<DegisiklikIzleme> DegisiklikIzlemes { get; set; }
        public DbSet<Kapak> Kapaks { get; set; }
        public DbSet<Referans> Referans { get; set; }
        public DbSet<YazilimVersiyon> YazilimVersiyons { get; set; }
        public DbSet<EmniyetTalimatlari> EmniyetTalimatlaris { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }

    }
}