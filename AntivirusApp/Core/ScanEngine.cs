using AntivirusApp.Models;

namespace AntivirusApp.Core
{
    /// <summary>
    /// Dosya ve klasör tarama motorunu yöneten sınıf
    /// </summary>
    public class ScanEngine
    {
        private bool _isCancelled = false;
        private readonly VirusDatabase _database;

        // Events
        public event EventHandler<ScanProgressEventArgs>? ProgressChanged;
        public event EventHandler<ScanResult>? ThreatDetected;
        public event EventHandler<ScanCompletedEventArgs>? ScanCompleted;

        public ScanEngine()
        {
            _database = VirusDatabase.Instance;
        }

        /// <summary>
        /// Taramayı iptal eder
        /// </summary>
        public void CancelScan()
        {
            _isCancelled = true;
        }

        /// <summary>
        /// Tek bir dosyayı tarar
        /// </summary>
        public async Task<ScanResult> ScanFileAsync(string filePath)
        {
            var result = new ScanResult(filePath);

            try
            {
                if (!File.Exists(filePath))
                {
                    result.Status = "File Not Found";
                    return result;
                }

                // Hash hesapla
                await Task.Run(() =>
                {
                    result.MD5Hash = HashCalculator.GetMD5Hash(filePath);
                    result.SHA256Hash = HashCalculator.GetSHA256Hash(filePath);
                });

                // Veritabanında kontrol et
                var threat = _database.FindThreat(result.MD5Hash);
                if (threat == null)
                {
                    threat = _database.FindThreat(result.SHA256Hash);
                }

                if (threat != null)
                {
                    result.IsThreatDetected = true;
                    result.DetectedThreat = threat;
                    ThreatDetected?.Invoke(this, result);
                }
            }
            catch (Exception ex)
            {
                result.Status = $"Error: {ex.Message}";
            }

            return result;
        }

        /// <summary>
        /// Bir klasörü ve alt klasörlerini tarar
        /// </summary>
        public async Task<List<ScanResult>> ScanDirectoryAsync(string directoryPath, bool recursive = true)
        {
            _isCancelled = false;
            var results = new List<ScanResult>();
            var startTime = DateTime.Now;

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    throw new DirectoryNotFoundException($"Klasör bulunamadı: {directoryPath}");
                }

                // Tüm dosyaları al
                var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                var files = Directory.GetFiles(directoryPath, "*.*", searchOption);

                int totalFiles = files.Length;
                int scannedFiles = 0;
                int threatsFound = 0;

                foreach (var file in files)
                {
                    if (_isCancelled)
                    {
                        break;
                    }

                    try
                    {
                        var result = await ScanFileAsync(file);
                        results.Add(result);

                        if (result.IsThreatDetected)
                        {
                            threatsFound++;
                        }

                        scannedFiles++;

                        // İlerleme bildir
                        ProgressChanged?.Invoke(this, new ScanProgressEventArgs
                        {
                            TotalFiles = totalFiles,
                            ScannedFiles = scannedFiles,
                            ThreatsFound = threatsFound,
                            CurrentFile = file,
                            PercentComplete = (int)((scannedFiles / (double)totalFiles) * 100)
                        });
                    }
                    catch (Exception ex)
                    {
                        // Dosya erişim hatalarını atla
                        results.Add(new ScanResult(file) { Status = $"Error: {ex.Message}" });
                        scannedFiles++;
                    }
                }

                // Tarama tamamlandı
                var duration = DateTime.Now - startTime;
                ScanCompleted?.Invoke(this, new ScanCompletedEventArgs
                {
                    TotalFiles = totalFiles,
                    ScannedFiles = scannedFiles,
                    ThreatsFound = threatsFound,
                    Duration = duration,
                    WasCancelled = _isCancelled
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Tarama hatası: {ex.Message}", ex);
            }

            return results;
        }

        /// <summary>
        /// Birden fazla dosyayı tarar
        /// </summary>
        public async Task<List<ScanResult>> ScanFilesAsync(string[] filePaths)
        {
            _isCancelled = false;
            var results = new List<ScanResult>();
            var startTime = DateTime.Now;

            int totalFiles = filePaths.Length;
            int scannedFiles = 0;
            int threatsFound = 0;

            foreach (var file in filePaths)
            {
                if (_isCancelled)
                    break;

                var result = await ScanFileAsync(file);
                results.Add(result);

                if (result.IsThreatDetected)
                    threatsFound++;

                scannedFiles++;

                ProgressChanged?.Invoke(this, new ScanProgressEventArgs
                {
                    TotalFiles = totalFiles,
                    ScannedFiles = scannedFiles,
                    ThreatsFound = threatsFound,
                    CurrentFile = file,
                    PercentComplete = (int)((scannedFiles / (double)totalFiles) * 100)
                });
            }

            var duration = DateTime.Now - startTime;
            ScanCompleted?.Invoke(this, new ScanCompletedEventArgs
            {
                TotalFiles = totalFiles,
                ScannedFiles = scannedFiles,
                ThreatsFound = threatsFound,
                Duration = duration,
                WasCancelled = _isCancelled
            });

            return results;
        }
    }

    /// <summary>
    /// Tarama ilerleme bilgilerini taşıyan event args
    /// </summary>
    public class ScanProgressEventArgs : EventArgs
    {
        public int TotalFiles { get; set; }
        public int ScannedFiles { get; set; }
        public int ThreatsFound { get; set; }
        public string CurrentFile { get; set; } = string.Empty;
        public int PercentComplete { get; set; }
    }

    /// <summary>
    /// Tarama tamamlanma bilgilerini taşıyan event args
    /// </summary>
    public class ScanCompletedEventArgs : EventArgs
    {
        public int TotalFiles { get; set; }
        public int ScannedFiles { get; set; }
        public int ThreatsFound { get; set; }
        public TimeSpan Duration { get; set; }
        public bool WasCancelled { get; set; }
    }
}
