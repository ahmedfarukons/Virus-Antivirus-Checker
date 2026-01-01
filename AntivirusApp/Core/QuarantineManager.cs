using System.Text.Json;
using AntivirusApp.Models;

namespace AntivirusApp.Core
{
    /// <summary>
    /// Karantina yönetimi için sınıf
    /// </summary>
    public class QuarantineManager
    {
        private readonly string _quarantinePath;
        private readonly string _quarantineIndexPath;
        private Dictionary<string, QuarantineEntry> _quarantineIndex;
        private static QuarantineManager? _instance;
        private static readonly object _lock = new object();

        public static QuarantineManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new QuarantineManager();
                    }
                }
                return _instance;
            }
        }

        private QuarantineManager()
        {
            // Karantina klasörü
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AntivirusApp"
            );

            _quarantinePath = Path.Combine(appDataPath, "Quarantine");
            _quarantineIndexPath = Path.Combine(appDataPath, "quarantine_index.json");

            if (!Directory.Exists(_quarantinePath))
                Directory.CreateDirectory(_quarantinePath);

            _quarantineIndex = new Dictionary<string, QuarantineEntry>();
            LoadIndex();
        }

        /// <summary>
        /// Karantina indeksini yükler
        /// </summary>
        private void LoadIndex()
        {
            try
            {
                if (File.Exists(_quarantineIndexPath))
                {
                    string json = File.ReadAllText(_quarantineIndexPath);
                    var entries = JsonSerializer.Deserialize<List<QuarantineEntry>>(json);

                    if (entries != null)
                    {
                        _quarantineIndex.Clear();
                        foreach (var entry in entries)
                        {
                            _quarantineIndex[entry.QuarantineId] = entry;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Karantina indeksi yüklenemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Karantina indeksini kaydeder
        /// </summary>
        private void SaveIndex()
        {
            try
            {
                var entries = _quarantineIndex.Values.ToList();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(_quarantineIndexPath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Karantina indeksi kaydedilemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Dosyayı karantinaya alır
        /// </summary>
        public QuarantineEntry QuarantineFile(string filePath, ScanResult scanResult)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Dosya bulunamadı", filePath);

                // Benzersiz ID oluştur
                string quarantineId = Guid.NewGuid().ToString();
                string quarantineFileName = $"{quarantineId}.vir";
                string quarantineFilePath = Path.Combine(_quarantinePath, quarantineFileName);

                // Dosyayı karantinaya taşı
                File.Move(filePath, quarantineFilePath);

                // Karantina kaydı oluştur
                var entry = new QuarantineEntry
                {
                    QuarantineId = quarantineId,
                    OriginalPath = filePath,
                    OriginalFileName = Path.GetFileName(filePath),
                    QuarantinePath = quarantineFilePath,
                    QuarantineDate = DateTime.Now,
                    ThreatName = scanResult.DetectedThreat?.ThreatName ?? "Unknown",
                    MD5Hash = scanResult.MD5Hash,
                    SHA256Hash = scanResult.SHA256Hash,
                    FileSize = scanResult.FileSize
                };

                _quarantineIndex[quarantineId] = entry;
                SaveIndex();

                return entry;
            }
            catch (Exception ex)
            {
                throw new Exception($"Dosya karantinaya alınamadı: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Dosyayı karantinadan geri yükler
        /// </summary>
        public bool RestoreFile(string quarantineId)
        {
            try
            {
                if (!_quarantineIndex.TryGetValue(quarantineId, out var entry))
                    return false;

                if (!File.Exists(entry.QuarantinePath))
                    return false;

                // Orijinal konuma geri taşı
                string restorePath = entry.OriginalPath;

                // Eğer orijinal konum mevcutsa, yeni bir isim ver
                if (File.Exists(restorePath))
                {
                    string directory = Path.GetDirectoryName(restorePath) ?? "";
                    string fileName = Path.GetFileNameWithoutExtension(restorePath);
                    string extension = Path.GetExtension(restorePath);
                    restorePath = Path.Combine(directory, $"{fileName}_restored{extension}");
                }

                File.Move(entry.QuarantinePath, restorePath);

                // İndeksten kaldır
                _quarantineIndex.Remove(quarantineId);
                SaveIndex();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Dosya geri yüklenemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Karantinadan dosyayı kalıcı olarak siler
        /// </summary>
        public bool DeleteFromQuarantine(string quarantineId)
        {
            try
            {
                if (!_quarantineIndex.TryGetValue(quarantineId, out var entry))
                    return false;

                if (File.Exists(entry.QuarantinePath))
                    File.Delete(entry.QuarantinePath);

                _quarantineIndex.Remove(quarantineId);
                SaveIndex();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Dosya silinemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tüm karantina kayıtlarını döndürür
        /// </summary>
        public List<QuarantineEntry> GetAllQuarantineEntries()
        {
            return _quarantineIndex.Values.OrderByDescending(e => e.QuarantineDate).ToList();
        }

        /// <summary>
        /// Karantina klasörünü temizler
        /// </summary>
        public void ClearQuarantine()
        {
            try
            {
                foreach (var entry in _quarantineIndex.Values)
                {
                    if (File.Exists(entry.QuarantinePath))
                        File.Delete(entry.QuarantinePath);
                }

                _quarantineIndex.Clear();
                SaveIndex();
            }
            catch (Exception ex)
            {
                throw new Exception($"Karantina temizlenemedi: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Karantina klasörünün yolu
        /// </summary>
        public string QuarantinePath => _quarantinePath;

        /// <summary>
        /// Karantinada bulunan dosya sayısı
        /// </summary>
        public int QuarantineCount => _quarantineIndex.Count;
    }

    /// <summary>
    /// Karantina kaydı bilgilerini tutan sınıf
    /// </summary>
    public class QuarantineEntry
    {
        public string QuarantineId { get; set; } = string.Empty;
        public string OriginalPath { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public string QuarantinePath { get; set; } = string.Empty;
        public DateTime QuarantineDate { get; set; }
        public string ThreatName { get; set; } = string.Empty;
        public string MD5Hash { get; set; } = string.Empty;
        public string SHA256Hash { get; set; } = string.Empty;
        public long FileSize { get; set; }
    }
}
