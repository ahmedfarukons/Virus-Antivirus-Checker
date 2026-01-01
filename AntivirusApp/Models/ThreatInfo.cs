namespace AntivirusApp.Models
{
    /// <summary>
    /// Tehdit bilgilerini tutan model sınıfı
    /// </summary>
    public class ThreatInfo
    {
        /// <summary>
        /// Tehdidin benzersiz hash imzası (MD5 veya SHA256)
        /// </summary>
        public string Signature { get; set; } = string.Empty;

        /// <summary>
        /// Tehdidin adı (örn: "TestVirus.A", "Trojan.Generic")
        /// </summary>
        public string ThreatName { get; set; } = string.Empty;

        /// <summary>
        /// Tehdit açıklaması
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Tehdit seviyesi (1-10 arası)
        /// </summary>
        public int SeverityLevel { get; set; } = 5;

        /// <summary>
        /// İmza türü (MD5 veya SHA256)
        /// </summary>
        public string SignatureType { get; set; } = "MD5";

        /// <summary>
        /// İmzanın veritabanına eklenme tarihi
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public ThreatInfo() { }

        public ThreatInfo(string signature, string threatName, string description = "", int severity = 5, string signatureType = "MD5")
        {
            Signature = signature;
            ThreatName = threatName;
            Description = description;
            SeverityLevel = severity;
            SignatureType = signatureType;
            DateAdded = DateTime.Now;
        }
    }
}
