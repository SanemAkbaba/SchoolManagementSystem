using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkulYonetimSistemi
{
    class Okul
    {
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        public double SinifOrtalamasi(SUBE sube)
        {
            List<Ogrenci> SinifOrtalamasi = Ogrenciler.Where(t => t.Sube == sube).ToList();
            double sinifOrtalama = (SinifOrtalamasi.Count == 0) ? 0 : SinifOrtalamasi.Average(t => t.NotOrtalamasi);
            return Math.Round(sinifOrtalama, 2);
        }
        public void OgrenciEkle(int ogrenciNo, string ogAd, string ogSoyad, DateTime ogrenciDogumTarih, CINSIYET ogrenciCinsiyet, SUBE ogrenciSube)
        {
            Ogrenciler.Add(new Ogrenci(ogrenciNo, ogAd, ogSoyad, ogrenciDogumTarih, ogrenciCinsiyet, ogrenciSube));
        }
        public void OgrenciEkle(Ogrenci o)
        {
            Ogrenciler.Add(o);
        }

        public void OgrenciSil(Ogrenci o)
        {
            Ogrenciler.Remove(o);
        }
        

    }
}
