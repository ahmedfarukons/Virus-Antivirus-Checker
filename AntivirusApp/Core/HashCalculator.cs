using System.Security.Cryptography;
using System.Text;

namespace AntivirusApp.Core
{
    /// <summary>
    /// Dosya hash değerlerini hesaplamak için yardımcı sınıf
    /// </summary>
    public static class HashCalculator
    {
        /// <summary>
        /// Dosyanın MD5 hash değerini hesaplar
        /// </summary>
        /// <param name="filePath">Hash değeri hesaplanacak dosyanın yolu</param>
        /// <returns>Hexadecimal formatında MD5 hash değeri</returns>
        public static string GetMD5Hash(string filePath)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"MD5 hash hesaplanamadı: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Dosyanın SHA256 hash değerini hesaplar (daha güvenli)
        /// </summary>
        /// <param name="filePath">Hash değeri hesaplanacak dosyanın yolu</param>
        /// <returns>Hexadecimal formatında SHA256 hash değeri</returns>
        public static string GetSHA256Hash(string filePath)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var hash = sha256.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"SHA256 hash hesaplanamadı: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Metin içeriğinin MD5 hash değerini hesaplar
        /// </summary>
        /// <param name="content">Hash değeri hesaplanacak metin</param>
        /// <returns>Hexadecimal formatında MD5 hash değeri</returns>
        public static string GetMD5HashFromString(string content)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    var inputBytes = Encoding.UTF8.GetBytes(content);
                    var hash = md5.ComputeHash(inputBytes);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"String MD5 hash hesaplanamadı: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Dosyanın hem MD5 hem de SHA256 hash değerlerini hesaplar
        /// </summary>
        /// <param name="filePath">Hash değerleri hesaplanacak dosyanın yolu</param>
        /// <returns>MD5 ve SHA256 hash değerlerini içeren tuple</returns>
        public static (string md5, string sha256) GetBothHashes(string filePath)
        {
            return (GetMD5Hash(filePath), GetSHA256Hash(filePath));
        }
    }
}
