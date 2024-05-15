using System;
using System.Collections.Generic;

class Kitap
{      // Burada bir kitap sınıfı tanımlayıp her bir kitabı tanımlayan bilgiler içerir.
    public string Adi { get; set; }
    public string Yazari { get; set; }
    public string Yayinevi { get; set; }
    public int YayinYili { get; set; }
    public string ISBN { get; set; }
    public string KonuKategorisi { get; set; }
    public decimal Deger { get; set; }
}

class Kullanici
{     
    // Burada bir kullanıcı sınıfı tanımlayıp her bir kullanıcının temel bilgilerini içeriri.
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public int OgrenciNo { get; set; }
    public string Telefon { get; set; }
    public string Eposta { get; set; }
    public DateTime OduncTarihi { get; set; }
}

class Program
{
    static List<Kitap> kitaplar = new List<Kitap>();
    static List<Kullanici> kullanicilar = new List<Kullanici>();
    static Dictionary<Kitap, Kullanici> oduncKitaplar = new Dictionary<Kitap, Kullanici>();
    


    static void Main(string[] args)
    {
        SabitKitaplariEkle(); // Bu metod program başladığı zaman eklediğim sabit kitapların listesini oluşturur.
        SabitKullanicilariEkle(); // Aynı şekilde bu metodda program başladığı zaman eklediğim sabit kullancıların listesini oluşturu.

        


        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");  // Bu Kısımda menü gösterimi bulunmaktadır kişi bu menüden herhangi birini seçerek o işleme gidebilir.
            Console.WriteLine("1) Kitap Bilgileri");
            Console.WriteLine("2) Kullanıcı Yönetimi");
            Console.WriteLine("3) Ödünç Alma ve İade İşlemleri");
            Console.WriteLine("4) Cezaların Belirlenmesi");
            Console.WriteLine("5) Raporlama");
            Console.WriteLine("6) İstatistik");
            Console.WriteLine("0) Çıkış");

            int secim;
            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                continue;
            }

            switch (secim)
            {
                case 1:
                    KitapBilgileri();
                    break;
                case 2:
                    KullaniciYonetimi();
                    break;
                case 3:
                    OduncAlmaIadeIslemleri();
                    break;
                case 4:
                    CezalariBelirle();
                    break;
                case 5:
                    Raporlama();
                    break;
                case 6:
                    Istatislik();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void KitapBilgileri()  
    {  // Bu kod bloğu kullanıcıya 2 farklı seçenek sunar bu seçekler kitap ekleme ve kitapları gösterme gibi seçimler sunar. 
        Console.WriteLine("1) Kitap Ekle");
        Console.WriteLine("2) Kitapları Görüntüle");
        int secim = int.Parse(Console.ReadLine());
        // Seçim yapıldıktan sonra kod bloğu çalışıp kitap eklenir veya olan kitapları gösterir.
        switch (secim)
        {
            case 1:
                KitapEkle();
                break;
            case 2:
                KitapGoruntule();
                break;
            default:
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                break;
        }
    }

    static void KitapEkle()
    {  // Bu kısımda uygulamayı kullanan kişi kitap ekleme olanağı sunar. 
        Kitap kitap = new Kitap();
        Console.Write("Kitap Adı: ");
        kitap.Adi = Console.ReadLine();
        Console.Write("Yazarı: ");
        kitap.Yazari = Console.ReadLine();
        Console.Write("Yayınevi: ");
        kitap.Yayinevi = Console.ReadLine();
        Console.Write("Yayın Yılı: ");
        kitap.YayinYili = int.Parse(Console.ReadLine());
        Console.Write("ISBN: ");
        kitap.ISBN = Console.ReadLine();
        Console.Write("Konu Kategorisi: ");
        kitap.KonuKategorisi = Console.ReadLine();

        kitaplar.Add(kitap);
        Console.WriteLine("Kitap başarıyla eklendi.");
    }

    static void KitapGoruntule()
    { // Bu kod bloğu kullanıcının mevcut kitaplarının bilgilerini görüntüleyebilmesini sağlar ve bu bilgileri kullanıcıya sunar.
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine($"Adı: {kitap.Adi}, Yazarı: {kitap.Yazari}, Yayınevi: {kitap.Yayinevi}, Yayın Yılı: {kitap.YayinYili}, ISBN: {kitap.ISBN}, Konu Kategorisi: {kitap.KonuKategorisi}");
        }
    }

    static void KullaniciYonetimi()
    {  // Bu kısımda ise yukarıda ki kitap ekle ve kitap gösterme kısmıyla aynıdır. Yani Kullanıcya 2 seçenek sunar.
        Console.WriteLine("1) Kullanıcı Ekle");// Kullanıcı bu seçeneği seçtiği zaman belirli şartlar altında bir kullanıcı ekleme şansı sunar.
        Console.WriteLine("2) Kullanıcıları Görüntüle"); // Kullancı bu seçeneği seçtiği zaman mevcut kullanıcıları görüntüler ve ekrana bastırır.
        int secim = int.Parse(Console.ReadLine());
        
        switch (secim)
        {
            case 1:
                KullaniciEkle();
                break;
            case 2:
                KullanicilariGoruntule();
                break;
            default:
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                break;
        }
    }

    static void KullaniciEkle()
    { // Yukarıda ki kodda kullanıcı ekleme kısmı seçildiği zaman kullanıcı eklemek için aşağıda ki kısımları teker teker doldurmak zorundadır.
        Kullanici kullanici = new Kullanici();
        Console.Write("Adı: ");
        kullanici.Adi = Console.ReadLine();
        Console.Write("Soyadı: ");
        kullanici.Soyadi = Console.ReadLine();
        Console.Write("Öğrenci No: ");
        kullanici.OgrenciNo = int.Parse(Console.ReadLine());
        Console.Write("Telefon: ");
        kullanici.Telefon = Console.ReadLine();
        Console.Write("E-posta: ");
        kullanici.Eposta = Console.ReadLine();

        kullanicilar.Add(kullanici);
        Console.WriteLine("Kullanıcı başarıyla eklendi.");
    }

    static void KullanicilariGoruntule()
    { // Bu kod bloğu kullanıcının mevcut kullanıcıların bilgilerini görüntüleyebilmesini sağlar ve bu bilgileri kullanıcıya sunar.
        foreach (var kullanici in kullanicilar)
        {
            Console.WriteLine($"Adı: {kullanici.Adi}, Soyadı: {kullanici.Soyadi}, Öğrenci No: {kullanici.OgrenciNo}, Telefon: {kullanici.Telefon}, E-posta: {kullanici.Eposta}");
        }
    }

    static void OduncAlmaIadeIslemleri()
    {

        OduncVer(kullanicilar[0], kitaplar[0]); // Bu 3 tane kod bloğu 3 tane sabit olan kullanıcıya ödünç vermesini sağlayan kod bloğudur.
        OduncVer(kullanicilar[1], kitaplar[1]);
        OduncVer(kullanicilar[2], kitaplar[2]);

 
        // Aşağıda ki işlem Ödünç Alma veya İade seçeneklerini kullanıcıya sunar ve seçim yaptırır.
        Console.WriteLine("1) Ödünç Alma");
        Console.WriteLine("2) İade");
        int secim = int.Parse(Console.ReadLine());
        // Aşağıda seçim yapan kullanıcı Ödünç kitap alır veya İade işlemini gerçekleştirir.
        switch (secim)
        {
            case 1:
                OduncAl();
                break;
            case 2:
                IadeEt();
                break;
            default:
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                break;
        }

        KitapBilgileri();// Bu kod ise yukarıda ki işlemlerden sonra kitap bilgileri kısmında kitap bilgilerini günceller ve kullanıcıya gösterir.

        
    }
    static void CezalariBelirle()
    {
        Console.WriteLine("Cezalar:");

        foreach (var kvp in oduncKitaplar)
        {
            var kitap = kvp.Key;
            var kullanici = kvp.Value;
            var gecenGun = (DateTime.Now - kullanici.OduncTarihi).TotalDays;

            if (gecenGun > 5)
            { // Kitabın en az 5 gün içerisinde getirlmesi gerektiğini belirtir.
                decimal ceza = CezayiHesapla(kitap.Deger, gecenGun - 5); // Gecikmiş gün sayısına göre ceza uygulanır.
                Console.WriteLine($"{kullanici.Adi} {kullanici.Soyadi} için {kitap.Adi} kitabı için {ceza:C} ceza uygulandı.");
            }
        }
    }

    static decimal CezayiHesapla(decimal kitapDegeri, double gecenGun)
    {
        // Bu kısımda ceza hesaplama kısmıdır.
        decimal cezaMiktari = 1m; // Gün başına belirlenen ceza miktarı 1Tl'dir.
        return cezaMiktari * Convert.ToDecimal(gecenGun);
    }

    static void OduncVer(Kullanici kullanici, Kitap kitap)
    { // Bu kısımda kullanıcıya bir kitap ödünç verme işlemini gerçekleştirir.
        oduncKitaplar.Add(kitap, kullanici);
    }

    static void OduncAl()
    { // Bu kısımda kullanıcıya ödünç almak istediği kitabı seçtirme işlemi uygulanır.
        Console.WriteLine("Ödünç almak istediğiniz kitabı seçin:");
        Kitap secilenKitap = KitapSec();
        if (secilenKitap == null)
        {
            Console.WriteLine("Geçersiz kitap seçimi.");
            return;
        }
        // Kullanıcı Ödünç almak istediği kitapı öğrenciye vermek için öğrencinin numarasını doğru girmesi gerekir aksi takdirde kullanıcı bulunamadı hatası alır.
        Console.WriteLine("Ödünç almak istediğiniz kullanıcının öğrenci numarasını girin:");
        int ogrenciNo = int.Parse(Console.ReadLine());
        Kullanici kullanici = kullanicilar.Find(k => k.OgrenciNo == ogrenciNo);

        if (kullanici != null)
        {
            oduncKitaplar.Add(secilenKitap, kullanici);
            Console.WriteLine($"{secilenKitap.Adi} kitabı {kullanici.Adi} {kullanici.Soyadi} adlı kullanıcıya ödünç verildi.");
        }
        else
        {
            Console.WriteLine("Kullanıcı bulunamadı.");
        }
    }

        static void IadeEt()
    {  // Bu kısımda kullanıcı iade işlemi gerçekleştirir.
        Console.WriteLine("İade etmek istediğiniz kitabı seçin:");
        Kitap secilenKitap = IadeEdilecekKitapSec();
        if (secilenKitap == null)
        {
            Console.WriteLine("Geçersiz kitap seçimi.");
            return;
        }

        if (oduncKitaplar.ContainsKey(secilenKitap))
        {
            oduncKitaplar.Remove(secilenKitap);
            Console.WriteLine($"{secilenKitap.Adi} kitabı başarıyla iade edildi.");
        }
        else
        {
            Console.WriteLine("Bu kitap ödünç alınmamış.");
        }
    }

    static Kitap KitapSec()
    { // Bu kısımda kullanıcı mevcut kitaplardan birini seçmesini sağlar.
        int index = 1;
        Console.WriteLine("Kitaplar:");
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine($"{index++}) {kitap.Adi}");
        }

        Console.Write("Seçiminiz: ");
        int secim;
        if (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > kitaplar.Count)
        {
            return null;
        }

        return kitaplar[secim - 1];
    }


    static Kitap IadeEdilecekKitapSec()
    {  // Bu kısımda sadece ödünç verilen kitapları kullanıcıya gösterir ve kullanıcı bu kitaplardan birini seçerek iade işlemi gerçekleştirir.
        int index = 1;
        Console.WriteLine("İade edilecek kitaplar:");
        foreach (var kitap in oduncKitaplar)
        {
            Console.WriteLine($"{index++}) {kitap.Key.Adi} - Ödünç Alan: {kitap.Value.Adi} {kitap.Value.Soyadi}");
        }

        Console.Write("Seçiminiz: ");
        int secim;
        if (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > oduncKitaplar.Count)
        {
            return null;
        }

        return oduncKitaplar.Keys.ToList()[secim - 1];
    }

    

    static void Raporlama()
    {   // Bu kısımda kullanıcıya raporlanan bilgileri gösterir. Bunlar ödünç alınan kitaplar ver iade edilen kitaplar olarak 2 ye ayrılır.
        Console.WriteLine("Raporlama:");
        Console.WriteLine("1) Ödünç Alınan Kitaplar");
        Console.WriteLine("2) İade Edilen Kitaplar");
        int secim = int.Parse(Console.ReadLine());

        switch (secim)
        {
            case 1:
                OduncAlinanKitaplarRaporu();
                break;
            case 2:
                IadeEdilenKitaplarRaporu();
                break;
            default:
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                break;
        }
    }
    static void OduncAlinanKitaplarRaporu()
    { // Bu kısımda ödünç alma seçeneği seçildiği takdirde ödünç alınan kitapları kullanıcıya sunar.
        if (oduncKitaplar.Count == 0)
        {
            Console.WriteLine("Ödünç alınan kitap bulunmamaktadır.");
            return;
        }

        Console.WriteLine("Ödünç Alınan Kitaplar:");
        foreach (var oduncKitap in oduncKitaplar)
        {
            Console.WriteLine($"Kitap Adı: {oduncKitap.Key.Adi}, Ödünç Alan: {oduncKitap.Value.Adi} {oduncKitap.Value.Soyadi}");
        }
    }

    static void IadeEdilenKitaplarRaporu()
    {   // Bu kısımda iade alma seçeneği seçildiği takdirde kullanıcıya iade edilen kitapları sunar.
        if (oduncKitaplar.Count == 0)
        {
            Console.WriteLine("İade edilen kitap bulunmamaktadır.");
            return;
        }

        Console.WriteLine("İade Edilen Kitaplar:");
        foreach (var oduncKitap in oduncKitaplar.Where(k => !kitaplar.Contains(k.Key)))
        {
            Console.WriteLine($"Kitap Adı: {oduncKitap.Key.Adi}, Ödünç Alan: {oduncKitap.Value.Adi} {oduncKitap.Value.Soyadi}");
        }
    }

    static void Istatislik()
    {// Bu kısımda kullancıya istatislikleri kullanıcıya sunar.
        Console.WriteLine("İstatistikler:");
        Console.WriteLine($"Kütüphanede Bulunan Toplam Kitap Sayısı: {kitaplar.Count}");
        Console.WriteLine($"Toplam Üye Sayısı: {kullanicilar.Count}");

        int oduncVerilenKitapSayisi = oduncKitaplar.Count;
        int iadeEdilenKitapSayisi = kitaplar.Count - oduncVerilenKitapSayisi;
        Console.WriteLine($"Ödünç Verilen Kitap Sayısı: {oduncVerilenKitapSayisi}");
        Console.WriteLine($"İade Edilen Kitap Sayısı: {iadeEdilenKitapSayisi}");
    }

    static void SabitKitaplariEkle()
    { // Bu kısımda kod içerisine belirli cezai işlem uygulanmasına adına 3 tane sabit kitap eklenmiştir.
        kitaplar.Add(new Kitap
        {
            Adi = "Suç ve Ceza",
            Yazari = "Fyodor Dostoyevski",
            Yayinevi = "XYZ Yayınevi",
            YayinYili = 1866,
            ISBN = "9789752841938",
            KonuKategorisi = "Roman",
            Deger=50m  //Kitabın değerini belirten kod.
        });

        kitaplar.Add(new Kitap
        {
            Adi = "1984",
            Yazari = "George Orwell",
            Yayinevi = "ABC Yayınevi",
            YayinYili = 1949,
            ISBN = "9789750719315",
            KonuKategorisi = "Distopya",
            Deger= 40m //Kitabın değerini belirten kod.
        });

        kitaplar.Add(new Kitap
        {
            Adi = "Dune",
            Yazari = "Frank Herbert",
            Yayinevi = "DEF Yayınevi",
            YayinYili = 1965,
            ISBN = "9789750734578",
            KonuKategorisi = "Bilim Kurgu",
            Deger= 60m //Kitabın değerini belirten kod.
        });
    }

    static void SabitKullanicilariEkle()
    {
        // Bu kısımda cezai işlem uygulanması için 3 tane sabit kullanıcı eklenmiştir.
        kullanicilar.Add(new Kullanici
        {
            Adi = "Ahmet",
            Soyadi = "Yılmaz",
            OgrenciNo = 12345,
            Telefon = "5551234567",
            Eposta = "ahmet@example.com",
            OduncTarihi = DateTime.Now.AddDays(-7) // Kişi kitabı 1 hafta önce ödünç almıştır.
        });

        kullanicilar.Add(new Kullanici
        {
            Adi = "Ayşe",
            Soyadi = "Kaya",
            OgrenciNo = 54321,
            Telefon = "5559876543",
            Eposta = "ayse@example.com",
            OduncTarihi = DateTime.Now.AddDays(-14) // Kişi kitabı 2 hafta önce ödünç almıştır.
        });

        kullanicilar.Add(new Kullanici
        {
            Adi = "Mehmet",
            Soyadi = "Demir",
            OgrenciNo = 13579,
            Telefon = "5554567890",
            Eposta = "mehmet@example.com",
            OduncTarihi = DateTime.Now // Kişi kitabı bugün ödünç almıştır.
        });
    }

}

