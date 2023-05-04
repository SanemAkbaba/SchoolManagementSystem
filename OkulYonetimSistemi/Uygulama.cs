using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkulYonetimSistemi
{
    class Uygulama
    {
        Okul Okulumuz = new Okul();
        public void Calistir()
        {
            SahteVeri();
            Menu();
            AnaEkran();
        }
        public void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Sistemi  -----");
            Console.WriteLine("1-Öğrenci Ekle");
            Console.WriteLine("2-Not Gir");
            Console.WriteLine("3-Öğrencinin ortalamasını gör");
            Console.WriteLine("4-Öğrencinin adresini gir");
            Console.WriteLine("5-Bütün Öğrencileri Listele");
            Console.WriteLine("6-Şubeye Göre Öğrencileri Listele");
            Console.WriteLine("7-Öğrencinin notlarını görüntüle");
            Console.WriteLine("8-Sınıfın Not Ortalamasını Gör");
            Console.WriteLine("9-Cinsiyetine göre öğrenci listele");
            Console.WriteLine("10-Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("11-Tüm öğrencileri semtlerine göre sıralayarak listele");
            Console.WriteLine("12-Okuldaki En başarılı 5 öğrenciyi listele");
            Console.WriteLine("13-Okuldaki En başarısız 3 öğrenciyi listele");
            Console.WriteLine("14-Sınıftaki En başarılı 5 öğrenciyi listele");
            Console.WriteLine("15-Sınıftaki En başarısız 3 öğrenciyi listele");
            Console.WriteLine("16-Öğrenci için açıklama gir");
            Console.WriteLine("17-Öğrencinin açıklamasını gör");
            Console.WriteLine("18-Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("19-Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("20-Öğrencinin okuduğu son kitabı görüntüle");
            Console.WriteLine("21-Öğrenci sil");
            Console.WriteLine("22-Öğrenci güncelle");
            Console.WriteLine();
            Console.WriteLine("Çıkış yapmak için “çıkış” yazıp “enter”a basın.");

        }
        public void AnaEkran()
        {
            while (true)
            {

                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                        OgrenciEkle();
                        break;
                    case "2":
                        NotEkle();
                        break;
                    case "3":
                        OgrenciOrtalamaGor();
                        break;
                    case "4":
                        AdresGir();
                        break;
                    case "5":
                        ButunOgrenciler();
                        break;
                    case "6":
                        SubeyeGore();
                        break;
                    case "7":
                        OgrenciNotGoruntule();
                        break;
                    case "8":
                        SinifinOrtalamaGor();
                        break;
                    case "9":
                        CinsiyeteGore();
                        break;
                    case "10":
                        DogumTarihineGore();
                        break;
                    case "11":
                        SemteGore();
                        break;
                    case "12":
                        OkuldaEnBasarili5();
                        break;
                    case "13":
                        OkuldaEnBasarisiz3();
                        break;
                    case "14":
                        SiniftakiEnBasarili5();
                        break;
                    case "15":
                        SiniftaEnBasarisiz3();
                        break;
                    case "16":
                        AciklamaGir();
                        break;
                    case "17":
                        AciklamaGor();
                        break;
                    case "18":
                        KitapGir();
                        break;
                    case "19":
                        OgrencininOkuduguKitaplar();
                        break;
                    case "20":
                        OgrencininOkuduguSonKitap();
                        break;
                    case "21":
                        OgrenciSil();
                        break;
                    case "22":
                        OgrenciGuncelle();
                        break;
                    case "çıkış":
                    case "cikis":
                        Environment.Exit(0);
                        break;
                    case "liste":
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        break;

                }
                MenuDon();
            }
        }
        public string SecimAl()
        {
            Console.WriteLine();
            Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
            string giris = Console.ReadLine().ToLower();
            Console.WriteLine();
            return giris;
        }

        public void OgrenciEkle()
        {
            Console.WriteLine("1-Öğrenci Ekle ---------------------------------------------");

            int ogrenciNo = Araclar.SayiAl("Öğrencinin numarası: ");

            int maxNo = Okulumuz.Ogrenciler.Max(a => a.No) + 1;

            string ogAd = Araclar.HarflerAl("Öğrencinin adı: ");

            string ogSoyad = Araclar.HarflerAl("Öğrencinin soyadı: ");

            DateTime ogrenciDogumTarih = Araclar.TarihAl("Öğrencinin doğum tarihi(GG.AA.YYYY): ");
            CINSIYET ogrenciCinsiyet;
            string ogCns;
            while (true)
            {
                Console.Write("Öğrencinin cinsiyeti(K/E): ");
                ogCns = Console.ReadLine().ToUpper();

                ogrenciCinsiyet = Araclar.CinsiyetBul(ogCns);
                if (ogrenciCinsiyet != CINSIYET.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }

            SUBE ogrenciSube;
            string ogSb;
            while (true)
            {
                Console.Write("Öğrencinin şubesi(A/B/C): ");
                ogSb = Console.ReadLine().ToUpper();

                ogrenciSube = Araclar.SubeBul(ogSb);
                if (ogrenciSube != SUBE.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
            foreach (Ogrenci item in Okulumuz.Ogrenciler)
            {
                if (item.No == ogrenciNo)
                {
                    Console.WriteLine(maxNo + " numaralı öğrenci sisteme başarılı bir şekilde eklenmiştir.");
                    Console.WriteLine("Sistemde " + ogrenciNo + " numaralı öğrenci olduğu için verdiğiniz öğrenci no " + maxNo + " olarak değiştirildi.");
                    ogrenciNo = maxNo;
                    break;
                }
            }
            if (ogrenciNo == 0)
            {
                ogrenciNo = maxNo;
                Console.WriteLine(maxNo + " numaralı öğrenci sisteme başarılı bir şekilde eklenmiştir.");
                Console.WriteLine("0 numara olamayacağı için verdiğiniz öğrenci no " + maxNo + " olarak değiştirildi.");
            }
            else if (maxNo != ogrenciNo)
            {
                Console.WriteLine(ogrenciNo + " numaralı öğrenci sisteme başarılı bir şekilde eklenmiştir.");
            }

            Okulumuz.OgrenciEkle(ogrenciNo, ogAd, ogSoyad, ogrenciDogumTarih, ogrenciCinsiyet, ogrenciSube);

        }
        public void SahteVeri()
        {
            Ogrenci o1 = new Ogrenci(56, "Naz", "Şimşek", DateTime.Parse("01.01.2000"), CINSIYET.Kız, SUBE.A);
            Ogrenci o2 = new Ogrenci(77, "Yağmur", "Aktürk", DateTime.Parse("01.04.1998"), CINSIYET.Kız, SUBE.B);
            Ogrenci o3 = new Ogrenci(88, "Çiçek", "Yüzbaş", DateTime.Parse("08.08.1991"), CINSIYET.Kız, SUBE.B);
            Ogrenci o4 = new Ogrenci(99, "Engin", "Günaydın", DateTime.Parse("12.12.1993"), CINSIYET.Erkek, SUBE.B);

            Okulumuz.OgrenciEkle(o1);
            Okulumuz.OgrenciEkle(o2);
            Okulumuz.OgrenciEkle(o3);
            Okulumuz.OgrenciEkle(o4);

            o1.NotEkle(DERS.Fen, 85);
            o1.NotEkle(DERS.Matematik, 70);
            o1.NotEkle(DERS.Sosyal, 65);
            o1.NotEkle(DERS.Turkce, 55);

            o2.NotEkle(DERS.Fen, 20);
            o2.NotEkle(DERS.Matematik, 40);
            o2.NotEkle(DERS.Sosyal, 54);
            o2.NotEkle(DERS.Turkce, 32);

            o3.NotEkle(DERS.Fen, 90);
            o3.NotEkle(DERS.Matematik, 95);
            o3.NotEkle(DERS.Sosyal, 53);
            o3.NotEkle(DERS.Turkce, 88);

            o4.NotEkle(DERS.Fen, 77);
            o4.NotEkle(DERS.Matematik, 69);
            o4.NotEkle(DERS.Sosyal, 45);
            o4.NotEkle(DERS.Turkce, 33);

            o1.AdresEkle("Ankara", "Çankaya", "Ata");
            o2.AdresEkle("İzmir", "Konak", "Alsancak");
            o3.AdresEkle("İstanbul", "Kartal", "Atalar");

            o1.Kitaplar.Add("Kalemimin Sapını Gülle Donattım");
            o1.Kitaplar.Add("Bir Çift Yürek");
            o2.Kitaplar.Add("Kırmızı Saçlı Kadın");
            o2.Kitaplar.Add("Kürk Mantolu Madonna");
            o2.Kitaplar.Add("Genç Werther'in Acıları");
            o3.Kitaplar.Add("1984");
            o3.Kitaplar.Add("Hayvan Çiftliği");
            o4.Kitaplar.Add("Sapiens");

        }
        public void Listele(List<Ogrenci> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek öğrenci bulunamadı.");
                return;
            }
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.".PadRight(20));
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.NotOrtalamasi.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(20));
            }
        }
        public void KitapListele(Ogrenci ogrencimiz, string secim)
        {
            if (ogrencimiz == null)
            {
                Console.WriteLine("Böyle bir ögrenci bulunamadı");
                return;
            }
            if (ogrencimiz.Kitaplar.Count == 0)
            {
                Console.WriteLine("Listelenecek kitap bulunamadı.");
                return;
            }
            if (secim == "tüm")
            {
                OgrenciGetir(ogrencimiz);
                Console.WriteLine("Okuduğu Kitaplar".PadRight(20));
                Console.WriteLine("-----------------");
                foreach (string item in ogrencimiz.Kitaplar)
                {

                    Console.WriteLine(item);
                }

            }
            else if (secim == "son")
            {
                OgrenciGetir(ogrencimiz);
                Console.WriteLine("Okuduğu Son Kitap".PadRight(20));
                Console.WriteLine("------------------");
                Console.WriteLine(ogrencimiz.Kitaplar[ogrencimiz.Kitaplar.Count - 1]);
            }


        }
        public void ButunOgrenciler()
        {
            Console.WriteLine("5- Bütün Öğrencileri Listele -------------------------------");
            Listele(Okulumuz.Ogrenciler);
        }
        public void SubeyeGore()
        {
            Console.WriteLine("6-Şubeye Göre Öğrencileri Listele -------------------------------");
            SUBE ogrenciSube = Araclar.SubeAl("Listelemek istediğiniz şubeyi girin(A/B/C): ");

            List<Ogrenci> SubeListe = Okulumuz.Ogrenciler.Where(t => t.Sube == ogrenciSube).ToList();
            Listele(SubeListe);
        }
        public void CinsiyeteGore()
        {
            Console.WriteLine("9-Cinsiyete Göre Öğrencileri Listele -------------------------------");
            CINSIYET ogrenciCinsiyet = Araclar.CinsiyetAl("Listelemek istediğiniz cinsiyeti girin(K / E): ");
            List<Ogrenci> CinsiyetListe = Okulumuz.Ogrenciler.Where(t => t.Cinsiyet == ogrenciCinsiyet).ToList();
            Listele(CinsiyetListe);
        }
        public void DogumTarihineGore()
        {
            Console.WriteLine("10-Doğum Tarihine Göre Öğrencileri Listele -------------------------------");
            DateTime ogrenciDogumTarihi = Araclar.TarihAl("Hangi tarihten sonraki öğrencileri listelemek istersiniz(GG.AA.YYYY): ");
            List<Ogrenci> DogumTarihListe = Okulumuz.Ogrenciler.Where(t => t.DogumTarihi > ogrenciDogumTarihi).ToList();
            if (Okulumuz.Ogrenciler.Count != 0 && DogumTarihListe.Count == 0)
            {
                Console.WriteLine("Girilen tarihten sonra doğan öğrenci yok.");
                return;
            }
            Listele(DogumTarihListe);
        }
        public void SemteGore()
        {
            Console.WriteLine("11-Semte Göre Öğrencileri Listele -------------------------------");

            List<Ogrenci> SemtListe = Okulumuz.Ogrenciler.Where(a => a.Adres != null).OrderBy(t => t.Adres.Semt).ThenBy(n => n.Adres.Sehir).ToList();
            SemtListe.AddRange(Okulumuz.Ogrenciler.Where(a => a.Adres == null).ToList());
            if (SemtListe.Count == 0 || Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listelenecek öğrenci bulunamadı.");
                return;
            }
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Şehir".PadRight(15) + "Semt".PadRight(15));
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Ogrenci item in SemtListe)
            {
                if (item.Adres.Sehir != null && item.Adres.Semt != null)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) +
                     item.Adres.Sehir.ToString().PadRight(15) + item.Adres.Semt.ToString().PadRight(15));
                }

            }

        }
        public void OkuldaEnBasarili5()
        {
            Console.WriteLine("12-Okuldaki en başarılı 5 öğrenciyi listele --------------------------");
            List<Ogrenci> BesBasariliListe = Okulumuz.Ogrenciler.OrderByDescending(t => t.NotOrtalamasi).Take(5).ToList();
            Listele(BesBasariliListe);
        }
        public void OkuldaEnBasarisiz3()
        {
            Console.WriteLine("13-Okuldaki en başarısız 3 öğrenciyi listele --------------------------");
            List<Ogrenci> UcBasarisizListe = Okulumuz.Ogrenciler.OrderBy(t => t.NotOrtalamasi).Take(3).ToList();
            Listele(UcBasarisizListe);
        }
        public void SiniftakiEnBasarili5()
        {
            Console.WriteLine("14-Sınıftaki en başarılı 5 öğrenciyi listele --------------------------");
            SUBE sb = Araclar.SubeAl("Listelenecek şube seçin(A/B/C): ");
            List<Ogrenci> SinifBasariliListe = Okulumuz.Ogrenciler.Where(t => t.Sube == sb).OrderByDescending(t => t.NotOrtalamasi).Take(5).ToList();
            Listele(SinifBasariliListe);
        }
        public void SiniftaEnBasarisiz3()
        {
            Console.WriteLine("15-Sınıftaki en başarısız 3 öğrenciyi listele --------------------------");
            SUBE sb = Araclar.SubeAl("Listelenecek şube seçin(A/B/C): ");
            List<Ogrenci> SinifBasarisizListe = Okulumuz.Ogrenciler.Where(t => t.Sube == sb).OrderBy(t => t.NotOrtalamasi).Take(3).ToList();
            Listele(SinifBasarisizListe);
        }
        public void OgrencininOkuduguKitaplar()
        {
            Console.WriteLine("19-Öğrencinin okuduğu kitapları listele --------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci og = OgrenciBul();
            KitapListele(og, "tüm");
        }
        public void OgrencininOkuduguSonKitap()
        {
            Console.WriteLine("20-Öğrencinin okuduğu son kitabı listele --------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci og = OgrenciBul();
            KitapListele(og, "son");
        }
        public void NotEkle()
        {
            //Sistemde öğrenci yoksa öğrenci no sorgulamaya geçmeden metot sonlanıyor.
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            DERS drs = DERS.Empty;
            Ogrenci o = OgrenciGetir(OgrenciKontrol());

            bool tipCheck = true;

            Console.WriteLine("---- Eklenelebilecek Dersler ----");
            Console.WriteLine("-Fen için 1       ");
            Console.WriteLine("-Matematik için 2 ");
            Console.WriteLine("-Sosyal için 3     ");
            Console.WriteLine("-Türkçe için 4     ");
            do
            {
                Console.Write("Ders: ");
                string secimTip = Console.ReadLine();
                switch (secimTip)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        drs = Araclar.DersBul(secimTip);
                        tipCheck = true;
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin.");
                        tipCheck = false;
                        break;
                }

            } while (!tipCheck);
            int notAdedi = Araclar.SayiAl("Eklemek istediğiniz not adedi: ");

            for (int i = 1; i <= notAdedi; i++)
            {

                int not = Araclar.SayiAl(i + ". notu girin: ");

                try
                {
                    o.NotEkle(drs, not);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }

            }
            Console.WriteLine("Bilgiler sisteme girilmiştir.");

        }
        public void OgrenciSil()
        {
            Console.WriteLine("Öğrenci sil --------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciGetir(OgrenciKontrol());
            Console.WriteLine("Öğrenciyi silmek istediğinize emin misiniz (E/H).");
            string karar = Console.ReadLine().ToUpper();
            if (karar == "E")
            {
                Okulumuz.OgrenciSil(ogr);
                Console.WriteLine("Öğrenci başarılı şekilde silindi.");
                return;
            }
            Console.WriteLine("Silme işlemi gerçekleştirilemedi.");

        }
        public void AdresGir()
        {
            Console.WriteLine("4 - Öğrencinin adresini gir--------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciGetir(OgrenciKontrol());

            string il = Araclar.HarflerAl("İl: ");
            string ilce = Araclar.HarflerAl("İlçe: ");
            string mahalle = Araclar.HarflerAl("Mahalle: ");
            ogr.AdresEkle(il, ilce, mahalle);

            Console.WriteLine("Bilgiler sisteme girilmiştir.");
        }
        public void AciklamaGir()
        {
            Console.WriteLine("16 - Öğrenci için açıklama gir--------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciGetir(OgrenciKontrol());
            Console.Write("Açıklama: ");
            string aciklama = Console.ReadLine();
            ogr.Aciklama += Araclar.IlkHarfBuyut(aciklama) + "\n";

            Console.WriteLine("Bilgiler sisteme girilmiştir.");

        }
        public void AciklamaGor()
        {
            Console.WriteLine("17 - Öğrencinin açıklamasını gör--------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr;
            ogr = OgrenciGetir(OgrenciKontrol());

            if (ogr.Aciklama == null)
            {
                Console.WriteLine("Bu öğrenciye ait açıklama bulunmamaktadır.");
                return;
            }

            Console.WriteLine("Açıklama: ");
            Console.WriteLine(ogr.Aciklama);

        }
        public void KitapGir()
        {
            Console.WriteLine("18 - Öğrencinin okuduğu kitabı gir--------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciGetir(OgrenciKontrol());

            Console.Write("Eklenecek Kitap Adı: ");
            string kitap = Araclar.IlkHarfBuyut(Console.ReadLine());
            ogr.Kitaplar.Add(kitap);

            Console.WriteLine("Bilgiler sisteme girilmiştir.");
        }
        public void OgrenciNotGoruntule()
        {
            Console.WriteLine("7-Öğrencinin notlarını görüntüle ------------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr;
            ogr = OgrenciGetir(OgrenciKontrol());
            if (ogr.Notlar.Count == 0)
            {
                Console.WriteLine("Bu öğrenciye not girişi yapılmamış.");
                return;
            }
            Console.WriteLine("Dersin Adı".PadRight(15) + "Notu".PadRight(5));
            Console.WriteLine("--------------------");
            List<DersNotu> dersListe = ogr.Notlar.OrderBy(t => t.DersAdi).ToList();
            foreach (DersNotu item in dersListe)
            {
                Console.WriteLine(item.DersAdi.ToString().PadRight(15) + item.Not.ToString().PadRight(5));
            }

        }
        public void OgrenciOrtalamaGor()
        {
            Console.WriteLine("3-Öğrencinin not ortalamasını gör --------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciGetir(OgrenciKontrol());
            Console.WriteLine("Öğrencinin not ortalaması: " + ogr.NotOrtalamasi);
        }
        public void SinifinOrtalamaGor()
        {
            Console.WriteLine("8-Sınıfın not ortalamasını gör --------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            SUBE sb = Araclar.SubeAl("Bir şube seçin(A/B/C): ");
            Console.WriteLine();

            Console.WriteLine("Sınıfın not ortalaması: " + Okulumuz.SinifOrtalamasi(sb));

        }
        public void OgrenciGuncelle()
        {
            Console.WriteLine("22 - Öğrenciyi güncelle --------------------------------");
            if (Okulumuz.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemde öğrenci yok.");
                return;
            }
            Ogrenci ogr = OgrenciKontrol();

            string ad = Araclar.IsimGuncelle("Öğrencinin adı: ", ogr.Ad);
            ogr.Ad = ad;

            string soyad = Araclar.IsimGuncelle("Öğrencinin soyadı: ", ogr.Soyad);
            ogr.Soyad = soyad;


            DateTime tarih = Araclar.TarihGuncelle("Öğrencinin doğum tarihi(GG.AA.YYYY): ", ogr.DogumTarihi);
            ogr.DogumTarihi = tarih;

            CINSIYET ogrenciCinsiyet = Araclar.CinsiyetGuncelle("Öğrencinin cinsiyeti(K/E): ", ogr.Cinsiyet);
            ogr.Cinsiyet = ogrenciCinsiyet;

            SUBE ogrenciSube = Araclar.SubeGuncelle("Öğrencinin şubesi(A/B/C): ", ogr.Sube);
            ogr.Sube = ogrenciSube;

            Console.WriteLine();
            Console.WriteLine("Öğrenci güncellendi.");

        }
        public Ogrenci OgrenciBul()
        {
            int no = Araclar.SayiAl("Öğrenci no giriniz: ");
            return Okulumuz.Ogrenciler.Where(t => t.No == no).FirstOrDefault();
        }

        public Ogrenci OgrenciKontrol()
        {
            Ogrenci ogr;
            do
            {
                ogr = OgrenciBul();
                if (ogr == null)
                {
                    Console.WriteLine("Bu numarada bir öğrenci yok. Tekrar deneyin.");
                    continue;
                }
                return ogr;
            }
            while (true);
        }
        public Ogrenci OgrenciGetir(Ogrenci ogr)
        {
            Console.WriteLine();
            Console.WriteLine("Öğrencinin Adı Soyadı: " + ogr.Ad + " " + ogr.Soyad);
            Console.WriteLine("Öğrencinin Şubesi: " + ogr.Sube);

            return ogr;
        }
        public void MenuDon()
        {
            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için “liste”, çıkış yapmak için “çıkış” yazın.");
            return;
        }
    }
}
