using System.Text.Json;
using AntivirusApp.Models;

namespace AntivirusApp.Core
{
    /// <summary>
    /// Virüs imza veritabanını yöneten sınıf
    /// </summary>
    public class VirusDatabase
    {
        private Dictionary<string, ThreatInfo> _signatures;
        private readonly string _databasePath;
        private static VirusDatabase? _instance;
        private static readonly object _lock = new object();

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static VirusDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new VirusDatabase();
                    }
                }
                return _instance;
            }
        }

        private VirusDatabase()
        {
            _signatures = new Dictionary<string, ThreatInfo>();
            
            // Veritabanı dosyasının yolu
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AntivirusApp"
            );
            
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
            
            _databasePath = Path.Combine(appDataPath, "virus_signatures.json");
            
            LoadDatabase();
        }

        /// <summary>
        /// Veritabanını dosyadan yükler
        /// </summary>
        public void LoadDatabase()
        {
            try
            {
                if (File.Exists(_databasePath))
                {
                    string json = File.ReadAllText(_databasePath);
                    var threats = JsonSerializer.Deserialize<List<ThreatInfo>>(json);
                    
                    if (threats != null)
                    {
                        _signatures.Clear();
                        foreach (var threat in threats)
                        {
                            _signatures[threat.Signature.ToLowerInvariant()] = threat;
                        }
                    }
                }
                else
                {
                    // İlk çalıştırmada varsayılan tehditler ekle
                    AddDefaultThreats();
                    SaveDatabase();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabanı yüklenemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Veritabanını dosyaya kaydeder
        /// </summary>
        public void SaveDatabase()
        {
            try
            {
                var threats = _signatures.Values.ToList();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(threats, options);
                File.WriteAllText(_databasePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabanı kaydedilemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Varsayılan test tehditlerini ekler
        /// </summary>
        private void AddDefaultThreats()
        {
            // Test virüsü için örnek imzalar
            AddThreat(new ThreatInfo(
                "d41d8cd98f00b204e9800998ecf8427e",
                "TestVirus.Empty",
                "Boş dosya test virüsü",
                3,
                "MD5"
            ));

            // EICAR test dosyası (standart antivirüs test dosyası)
            AddThreat(new ThreatInfo(
                "44d88612fea8a8f36de82e1278abb02f",
                "EICAR-Test-File",
                "Standart antivirüs test dosyası",
                1,
                "MD5"
            ));
        }

        /// <summary>
        /// Yeni bir tehdit imzası ekler
        /// </summary>
        public void AddThreat(ThreatInfo threat)
        {
            _signatures[threat.Signature.ToLowerInvariant()] = threat;
        }

        /// <summary>
        /// Tehdit imzasını siler
        /// </summary>
        public bool RemoveThreat(string signature)
        {
            return _signatures.Remove(signature.ToLowerInvariant());
        }

        /// <summary>
        /// Hash değerine göre tehdit arar
        /// </summary>
        public ThreatInfo? FindThreat(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return null;

            _signatures.TryGetValue(hash.ToLowerInvariant(), out var threat);
            return threat;
        }

        /// <summary>
        /// Dosyanın tehdit olup olmadığını kontrol eder
        /// </summary>
        public bool IsThreat(string hash)
        {
            return FindThreat(hash) != null;
        }

        /// <summary>
        /// Tüm tehditleri döndürür
        /// </summary>
        public List<ThreatInfo> GetAllThreats()
        {
            return _signatures.Values.ToList();
        }

        /// <summary>
        /// Veritabanındaki toplam tehdit sayısı
        /// </summary>
        public int ThreatCount => _signatures.Count;

        /// <summary>
        /// Veritabanını temizler
        /// </summary>
        public void ClearDatabase()
        {
            _signatures.Clear();
        }

        /// <summary>
        /// Veritabanı dosyasının yolunu döndürür
        /// </summary>
        public string DatabasePath => _databasePath;
    }
}
