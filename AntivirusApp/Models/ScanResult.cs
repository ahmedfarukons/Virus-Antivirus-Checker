namespace AntivirusApp.Models
{
    /// <summary>
    /// Tarama sonucu bilgilerini tutan model sınıfı
    /// </summary>
    public class ScanResult
    {
        /// <summary>
        /// Taranan dosyanın tam yolu
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// Dosya adı
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Dosyanın MD5 hash değeri
        /// </summary>
        public string MD5Hash { get; set; } = string.Empty;

        /// <summary>
        /// Dosyanın SHA256 hash değeri
        /// </summary>
        public string SHA256Hash { get; set; } = string.Empty;

        /// <summary>
        /// Tehdit bulundu mu?
        /// </summary>
        public bool IsThreatDetected { get; set; } = false;

        /// <summary>
        /// Tespit edilen tehdit bilgisi (varsa)
        /// </summary>
        public ThreatInfo? DetectedThreat { get; set; }

        /// <summary>
        /// Tarama tarihi ve saati
        /// </summary>
        public DateTime ScanDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Dosya boyutu (byte)
        /// </summary>
        public long FileSize { get; set; } = 0;

        /// <summary>
        /// Dosya durumu (Normal, Quarantined, Deleted)
        /// </summary>
        public string Status { get; set; } = "Normal";

        public ScanResult() { }

        public ScanResult(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileName(filePath);
            
            if (File.Exists(filePath))
            {
                var fileInfo = new FileInfo(filePath);
                FileSize = fileInfo.Length;
            }
        }

        /// <summary>
        /// Tehdit seviyesine göre renk kodu döndürür (UI için)
        /// </summary>
        public Color GetSeverityColor()
        {
            if (!IsThreatDetected || DetectedThreat == null)
                return Color.Green;

            return DetectedThreat.SeverityLevel switch
            {
                >= 8 => Color.DarkRed,
                >= 5 => Color.Orange,
                _ => Color.Yellow
            };
        }
    }
}
