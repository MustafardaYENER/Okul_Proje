namespace Okul
{
    namespace OgrenciNotHesaplama
    {     
        public enum OgretimDuzeyi
        {
            IlkOgretim,
            OrtaOgretim,
            Lise,
            Lisans
        }

        public class Ogrenci
        {
            public string AdSoyad { get; set; }
            public int OkulNumarasi { get; set; }
            public string OkulAdi { get; } = "Açıktan Eğitim";
            public OgretimDuzeyi Duzey { get; set; }

            private static List<Ogrenci> ogrenciListesi = new List<Ogrenci>();

            public Ogrenci(string adSoyad, int okulNumarasi, OgretimDuzeyi duzey)
            {
                AdSoyad = adSoyad;
                OkulNumarasi = okulNumarasi;
                Duzey = duzey;

                ogrenciListesi.Add(this);
            }

            public virtual void NotHesapla()
            {
                Console.WriteLine("Not Bilgisi Eksik !");
            }
        }

        public class LiseOgrencisi : Ogrenci
        {
            public string OkulAdi { get; set; }
            public double Not1 { get; set; }
            public double Not2 { get; set; }

            public LiseOgrencisi(string adSoyad, int okulNumarasi, string okulAdi, double not1, double not2)
                : base(adSoyad, okulNumarasi, OgretimDuzeyi.Lise)
            {
                OkulAdi = okulAdi;
                Not1 = not1;
                Not2 = not2;
            }

            public override void NotHesapla()
            {
                double ortalama = (Not1 + Not2) / 2;
                Console.WriteLine($"Lise Öğrencisi {AdSoyad} Not Ortalaması: {ortalama}");
            }
        }

        public class LisansOgrencisi : Ogrenci
        {
            public string Fakulte { get; set; }
            public double VizeNotu { get; set; }
            public double FinalNotu { get; set; }

            public LisansOgrencisi(string adSoyad, int okulNumarasi, string fakulte, double vizeNotu, double finalNotu)
                : base(adSoyad, okulNumarasi, OgretimDuzeyi.Lisans)
            {
                Fakulte = fakulte;
                VizeNotu = vizeNotu;
                FinalNotu = finalNotu;
            }

            public override void NotHesapla()
            {
                double ortalama = (VizeNotu * 0.4) + (FinalNotu * 0.6);
                char derece;

                if (ortalama >= 85)
                    derece = 'A';
                else if (ortalama >= 70)
                    derece = 'B';
                else if (ortalama >= 60)
                    derece = 'C';
                else if (ortalama >= 50)
                    derece = 'D';
                else if (ortalama >= 45)
                    derece = 'E';
                else
                    derece = 'F';

                Console.WriteLine($"Lisans Öğrencisi {AdSoyad} Not Ortalaması: {ortalama} - Derece: {derece}");
            }
        }

        class Program
        {
            static void OgrenciNotHesapla(Ogrenci ogr)
            {
                ogr.NotHesapla();
            }

            static void Main(string[] args)
            {
                LiseOgrencisi liseOgrenci = new LiseOgrencisi("Ali Veli", 123, "Açı Lisesi", 80, 90);
                OgrenciNotHesapla(liseOgrenci);

                LisansOgrencisi lisansOgrenci = new LisansOgrencisi("Ayşe Fatma", 456, "Mühendislik", 70, 85);
                OgrenciNotHesapla(lisansOgrenci);

                Console.ReadLine();
            }
        }
    }
}
