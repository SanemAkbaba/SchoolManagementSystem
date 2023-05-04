using System;
using System.Collections.Generic;
using System.Text;

namespace OkulYonetimSistemi
{
    class Araclar
    {
        
        static public int SayiAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();
                int sayi;

                if (!int.TryParse(giris, out sayi) || sayi <= 0 || giris.StartsWith(" "))
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin");
                    continue;
                }
                return sayi;
            }
        }
        static public string HarflerAl(string mesaj)
        {
            string veri = "";
            while (true)
            {
                bool kontrol = true;
                Console.Write(mesaj);
                veri = IlkHarfBuyut(Console.ReadLine());
                string[] veriler = veri.Split(" ");
                foreach (string item in veriler)
                {
                    if (!HarflerMi(item) || veri.StartsWith(" ") || veri.Contains("  ") || veri.Length == 0)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                        kontrol = false;
                        break;
                    }
                }
                if (kontrol == true)
                {
                    if (veri.Split(" ").Length > 1)//Öğrencinin iki ismi veya soyismi varsa her birinin ilk harfini büyütmek gerekir.
                    {
                        for (int i = 0; i < veriler.Length; i++)
                        {
                            veriler[i] = IlkHarfBuyut(veriler[i]);
                        }
                        veri = string.Join(" ", veriler);
                    }
                    break;
                }
            }
            return veri;
        }
        public static bool HarflerMi(string veri)
        {
            veri = veri.ToUpper();

            foreach (char item in veri)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }

            return true;
        }

        static public string IlkHarfBuyut(string veri)
        {
            if (veri.Length != 0)
            {
                veri = veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
            }
            return veri;
        }


        static public DERS DersBul(string veri)
        {
            DERS drs = DERS.Empty;
            if (veri.ToUpper() == "1")
            {
                drs = DERS.Fen;
            }
            else if (veri.ToUpper() == "2")
            {
                drs = DERS.Matematik;
            }
            else if (veri.ToUpper() == "3")
            {
                drs = DERS.Sosyal;
            }
            else if (veri.ToUpper() == "4")
            {
                drs = DERS.Turkce;
            }

            return drs;
        }



        static public SUBE SubeAl(string mesaj)
        {
            SUBE ogrenciSube;
            while (true)
            {
                Console.Write(mesaj);
                string sb = Console.ReadLine().ToUpper();
                ogrenciSube = SubeBul(sb);
                if (ogrenciSube != SUBE.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
            return ogrenciSube;
        }
        static public SUBE SubeGuncelle(string mesaj, SUBE ogrSube)
        {
            SUBE ogrenciSube;
            while (true)
            {
                Console.Write(mesaj);
                string sb = Console.ReadLine().ToUpper();
                ogrenciSube = SubeBul(sb);
                if (sb.Length < 1)
                {
                    return ogrSube;
                }
                if (ogrenciSube != SUBE.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
            return ogrenciSube;
        }

        static public CINSIYET CinsiyetAl(string mesaj)
        {
            CINSIYET ogrenciCinsiyet;
            while (true)
            {
                Console.Write(mesaj);
                string cns = Console.ReadLine().ToUpper();
                ogrenciCinsiyet = CinsiyetBul(cns);
                if (ogrenciCinsiyet != CINSIYET.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
            return ogrenciCinsiyet;
        }
        static public CINSIYET CinsiyetGuncelle(string mesaj, CINSIYET ogrCinsiyet)
        {
            CINSIYET ogrenciCinsiyet;
            while (true)
            {
                Console.Write(mesaj);
                string cns = Console.ReadLine().ToUpper();
                ogrenciCinsiyet = CinsiyetBul(cns);
                if (cns.Length < 1)
                {
                    return ogrCinsiyet;
                }

                if (ogrenciCinsiyet != CINSIYET.Empty)
                {
                    break;
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
            return ogrenciCinsiyet;
        }
        static public string IsimGuncelle(string mesaj, string ad)
        {
            string veri = "";
            while (true)
            {
                bool kontrol = true;
                Console.Write(mesaj);
                veri = IlkHarfBuyut(Console.ReadLine());
                if (veri.Length < 1)
                {
                    return ad;
                }
                string[] veriler = veri.Split(" ");
                foreach (string item in veriler)
                {
                    if (!HarflerMi(item) || veri.StartsWith(" ") || veri.Contains("  "))
                    {
                        Console.WriteLine("Hatalı giriş yaptınız, tekrar deneyin.");
                        kontrol = false;
                        break;
                    }
                }
                if (kontrol == true)
                {
                    if (veri.Split(" ").Length > 1)//Öğrencinin iki ismi veya soyismi varsa her birinin ilk harfini büyütmek gerekir.
                    {
                        for (int i = 0; i < veriler.Length; i++)
                        {
                            veriler[i] = IlkHarfBuyut(veriler[i]);
                        }
                        veri = string.Join(" ", veriler);
                    }
                    break;
                }
            }
            return veri;

        }

        static public DateTime TarihAl(string text)//Bu metot GG.AA.YYYY şeklinde tarih alınmasını sağlıyor.
        {
            int x;
            string tarih;
            DateTime trh;
            while (true)
            {
                Console.Write(text);
                tarih = Console.ReadLine();
                string[] veriler = tarih.Split(".");

                if (tarih.Split(".").Length == 3 
                    && veriler[0].Length == 2 && int.TryParse(veriler[0], out x)
                    && veriler[1].Length == 2 && int.TryParse(veriler[1], out x)
                    && veriler[2].Length == 4 && int.TryParse(veriler[2], out x)
                    && DateTime.TryParse(tarih, out trh))
                {
                    return trh;
                }

                Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyin");
            }

        }
        static public DateTime TarihGuncelle(string text, DateTime ogrTarih)
        {

            int x;
            string tarih;
            DateTime trh;

            while (true)
            {
                Console.Write(text);
                tarih = Console.ReadLine();
                if (tarih.Length < 1)
                {
                    return ogrTarih;
                }

                string[] veriler = tarih.Split(".");
                if (tarih.Split(".").Length == 3
                    && veriler[0].Length == 2 && int.TryParse(veriler[0], out x)
                    && veriler[1].Length == 2 && int.TryParse(veriler[1], out x)
                    && veriler[2].Length == 4 && int.TryParse(veriler[2], out x)
                    && DateTime.TryParse(tarih, out trh))
                {
                    return trh;
                }

                Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyin");

            }

        }



        static public CINSIYET CinsiyetBul(string veri)
        {
            CINSIYET cns = CINSIYET.Empty;
            if (veri.ToUpper() == "K")
            {
                cns = CINSIYET.Kız;
            }
            else if (veri.ToUpper() == "E")
            {
                cns = CINSIYET.Erkek;
            }

            return cns;
        }


        static public SUBE SubeBul(string veri)
        {
            SUBE sube = SUBE.Empty;
            if (veri.ToUpper() == "A")
            {
                sube = SUBE.A;
            }
            else if (veri.ToUpper() == "B")
            {
                sube = SUBE.B;
            }
            else if (veri.ToUpper() == "C")
            {
                sube = SUBE.C;
            }

            return sube;
        }
    }
}
