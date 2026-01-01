using System.Security.Cryptography;

// Test virüsünün hash değerini hesapla
string testVirusPath = @"C:\Users\LENOVO\Desktop\Sayısal Tasarım\TestVirus.txt";

if (File.Exists(testVirusPath))
{
    using (var md5 = MD5.Create())
    {
        using (var stream = File.OpenRead(testVirusPath))
        {
            var hash = md5.ComputeHash(stream);
            string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            Console.WriteLine($"Dosya bulundu: {testVirusPath}");
            Console.WriteLine($"MD5 Hash: {md5Hash}");
            
            // Veritabanı dosyasını oluştur
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AntivirusApp"
            );
            
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
            
            string dbPath = Path.Combine(appDataPath, "virus_signatures.json");
            
            string jsonContent = $@"[
  {{
    ""Signature"": ""{md5Hash}"",
    ""ThreatName"": ""TestVirus.Desktop"",
    ""Description"": ""Masaüstünde oluşturulan test virüsü"",
    ""SeverityLevel"": 8,
    ""SignatureType"": ""MD5"",
    ""DateAdded"": ""{DateTime.Now:yyyy-MM-ddTHH:mm:ss}""
  }}
]";
            
            File.WriteAllText(dbPath, jsonContent);
            Console.WriteLine($"\nVeritabanı oluşturuldu: {dbPath}");
            Console.WriteLine("AntivirusApp'i yeniden başlatın!");
        }
    }
}
else
{
    Console.WriteLine($"Dosya bulunamadı: {testVirusPath}");
}
