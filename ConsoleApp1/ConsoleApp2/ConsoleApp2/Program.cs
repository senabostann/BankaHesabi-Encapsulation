using System;
public class BankaHesabi
{
    // 🔒 KAPSÜLLEME: Alanlar private (dışarıdan erişilemez)
    private string sahipAdi;
    private double bakiye;
    // 🏗 Constructor
    public BankaHesabi(string sahipAdi, double bakiye)
    {
        SetSahipAdi(sahipAdi); // kontrol içerir
        this.bakiye = bakiye;
    }
    // 📥 Getter (okuma)
    public string GetSahipAdi()
    {
        return sahipAdi;
    }
    public double GetBakiye()
    {
        return bakiye;
    }
    // 📤 Setter (kontrollü erişim)
    public void SetSahipAdi(string sahipAdi)
    {
        // ❗ Kapsülleme: veri doğrulama
        if (string.IsNullOrWhiteSpace(sahipAdi))
        {
            Console.WriteLine("Hata: İsim boş olamaz!");
        }
        else
        {
            this.sahipAdi = sahipAdi;
        }
    }
    // 💰 Para yatırma (kontrollü işlem)
    public void ParaYatir(double miktar)
    {
        if (miktar > 0)
        {
            bakiye += miktar;
            Console.WriteLine("Para yatırıldı. Yeni bakiye: " + bakiye);
        }
        else
        {
            Console.WriteLine("Hata: Miktar pozitif olmalı!");
        }
    }
    // 💸 Para çekme (kontrollü işlem)
    public void ParaCek(double miktar)
    {
        if (miktar <= 0)
        {
            Console.WriteLine("Hata: Miktar pozitif olmalı!");
        }
        else if (miktar > bakiye)
        {
            Console.WriteLine("Hata: Yetersiz bakiye!");
        }
        else
        {
            bakiye -= miktar;
            Console.WriteLine("Para çekildi. Yeni bakiye: " + bakiye);
        }
    }
}
class Program
{
    static void Main()
    {
        // 🧪 TEST
        BankaHesabi hesap = new BankaHesabi("Ahmet", 1000);

        // ✔ Geçerli işlemler
        hesap.ParaYatir(500);
        hesap.ParaCek(200);

        // ❌ Geçersiz işlemler
        hesap.ParaYatir(-10);
        hesap.ParaCek(5000);

        // ❌ Geçersiz isim
        hesap.SetSahipAdi("");

        // ✔ Geçerli isim
        hesap.SetSahipAdi("Mehmet");

        Console.WriteLine("Son bakiye: " + hesap.GetBakiye());
    }
}



