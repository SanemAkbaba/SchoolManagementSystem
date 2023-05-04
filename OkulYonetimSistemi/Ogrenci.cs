using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkulYonetimSistemi
{
    class Ogrenci
    {
        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public Adres Adres { get; set; }
        public List<string> Kitaplar { get; set; }
        public string Aciklama { get; set; }
        public List<DersNotu> Notlar { get; set; }
        public SUBE Sube { get; set; }
        public CINSIYET Cinsiyet { get; set; }
        public double NotOrtalamasi
        {
            get
            {
                double NotOrtalama = (this.Notlar.Count == 0) ? 0 : this.Notlar.Average(t => t.Not);
                return Math.Round(NotOrtalama, 2);
            }
        }

        public Ogrenci(int no, string ad, string soyad, DateTime dtarihi, CINSIYET cins, SUBE sube)
        {
            Adres = new Adres();
            Notlar = new List<DersNotu>();
            Kitaplar = new List<string>();
            this.No = no;
            this.Ad = ad;
            this.Soyad = soyad;
            this.DogumTarihi = dtarihi;
            this.Cinsiyet = cins;
            this.Sube = sube;
        }

        public void NotEkle(DERS ders, int not)
        {
            try
            {
                DersNotu dn = new DersNotu(ders, not);
                this.Notlar.Add(dn);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AdresEkle(string il, string ilce, string mahalle)
        {
            this.Adres.Sehir = Araclar.IlkHarfBuyut(il);
            this.Adres.Semt = Araclar.IlkHarfBuyut(ilce);
            this.Adres.Mahalle = Araclar.IlkHarfBuyut(mahalle);
        }
    }
    public enum SUBE
    {
        Empty, A, B, C
    }

    public enum CINSIYET
    {
        Empty, Kız, Erkek
    }
}
