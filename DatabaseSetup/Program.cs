using System.Security.Cryptography;
using System.Text.Json;

string testVirusPath = @"C:\Users\LENOVO\Desktop\Sayısal Tasarım\TestVirus.txt";

if (!File.Exists(testVirusPath))
{
    Console.WriteLine($"HATA: Dosya bulunamadı: {testVirusPath}");
    Console.WriteLine("\nLütfen TestVirus.txt dosyasının konumunu kontrol edin.");
    return;
}

// Hash hesapla
string md5Hash = CalculateMD5(testVirusPath);

Console.WriteLine("=== TEST VİRÜSÜ HASH DEĞERİ ===");
Console.WriteLine($"Dosya: {testVirusPath}");
Console.WriteLine($"MD5 Hash: {md5Hash}");
Console.WriteLine();

// Veritabanı oluştur
string appDataPath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "AntivirusApp"
);

if (!Directory.Exists(appDataPath))
{
    Directory.CreateDirectory(appDataPath);
    Console.WriteLine($"Klasör oluşturuldu: {appDataPath}");
}

string dbPath = Path.Combine(appDataPath, "virus_signatures.json");

var threats = new[]
{
    new
    {
        Signature = md5Hash,
        ThreatName = "TestVirus.Desktop",
        Description = "Masaüstünde oluşturulan test virüsü",
        SeverityLevel = 8,
        SignatureType = "MD5",
        DateAdded = DateTime.Now
    }
};

var options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(threats, options);
File.WriteAllText(dbPath, json);

Console.WriteLine($"✅ Veritabanı oluşturuldu: {dbPath}");
Console.WriteLine();
Console.WriteLine("=== SONRAKİ ADIMLAR ===");
Console.WriteLine("1. AntivirusApp'i KAPATIN");
Console.WriteLine("2. AntivirusApp'i YENİDEN BAŞLATIN");
Console.WriteLine("3. Taramayı tekrar yapın");
Console.WriteLine();
Console.WriteLine("Veritabanı içeriği:");
Console.WriteLine(json);

static string CalculateMD5(string filePath)
{
    using (var md5 = MD5.Create())
    {
        using (var stream = File.OpenRead(filePath))
        {
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
