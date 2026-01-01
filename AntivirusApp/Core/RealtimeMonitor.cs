using AntivirusApp.Models;

namespace AntivirusApp.Core
{
    /// <summary>
    /// Gerçek zamanlı dosya izleme sınıfı
    /// </summary>
    public class RealtimeMonitor : IDisposable
    {
        private readonly List<FileSystemWatcher> _watchers;
        private readonly ScanEngine _scanEngine;
        private bool _isMonitoring;
        private readonly HashSet<string> _monitoredPaths;

        // Events
        public event EventHandler<ScanResult>? ThreatDetectedInRealtime;
        public event EventHandler<string>? FileScannedInRealtime;
        public event EventHandler<string>? MonitoringError;

        public RealtimeMonitor()
        {
            _watchers = new List<FileSystemWatcher>();
            _scanEngine = new ScanEngine();
            _monitoredPaths = new HashSet<string>();
            _isMonitoring = false;

            // Scan engine'den gelen tehdit tespitlerini dinle
            _scanEngine.ThreatDetected += (sender, result) =>
            {
                ThreatDetectedInRealtime?.Invoke(this, result);
            };
        }

        /// <summary>
        /// İzleme durumu
        /// </summary>
        public bool IsMonitoring => _isMonitoring;

        /// <summary>
        /// İzlenen klasör sayısı
        /// </summary>
        public int MonitoredPathCount => _monitoredPaths.Count;

        /// <summary>
        /// Bir klasörü izlemeye başlar
        /// </summary>
        public void AddMonitoredPath(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException($"Klasör bulunamadı: {path}");

                if (_monitoredPaths.Contains(path))
                    return; // Zaten izleniyor

                var watcher = new FileSystemWatcher(path)
                {
                    NotifyFilter = NotifyFilters.FileName | 
                                   NotifyFilters.LastWrite | 
                                   NotifyFilters.CreationTime,
                    Filter = "*.*",
                    IncludeSubdirectories = true,
                    EnableRaisingEvents = _isMonitoring
                };

                // Event handler'ları ekle
                watcher.Created += OnFileCreated;
                watcher.Changed += OnFileChanged;
                watcher.Error += OnError;

                _watchers.Add(watcher);
                _monitoredPaths.Add(path);
            }
            catch (Exception ex)
            {
                MonitoringError?.Invoke(this, $"Klasör izlemeye eklenemedi: {ex.Message}");
            }
        }

        /// <summary>
        /// Bir klasörü izlemeden çıkarır
        /// </summary>
        public void RemoveMonitoredPath(string path)
        {
            try
            {
                var watcher = _watchers.FirstOrDefault(w => w.Path == path);
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                    _watchers.Remove(watcher);
                    _monitoredPaths.Remove(path);
                }
            }
            catch (Exception ex)
            {
                MonitoringError?.Invoke(this, $"Klasör izlemeden çıkarılamadı: {ex.Message}");
            }
        }

        /// <summary>
        /// Gerçek zamanlı izlemeyi başlatır
        /// </summary>
        public void StartMonitoring()
        {
            if (_isMonitoring)
                return;

            _isMonitoring = true;

            foreach (var watcher in _watchers)
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        /// <summary>
        /// Gerçek zamanlı izlemeyi durdurur
        /// </summary>
        public void StopMonitoring()
        {
            if (!_isMonitoring)
                return;

            _isMonitoring = false;

            foreach (var watcher in _watchers)
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        /// <summary>
        /// Yeni dosya oluşturulduğunda tetiklenir
        /// </summary>
        private async void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            await ScanFileAsync(e.FullPath);
        }

        /// <summary>
        /// Dosya değiştirildiğinde tetiklenir
        /// </summary>
        private async void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // Sadece dosya içeriği değiştiğinde tara
            if (File.Exists(e.FullPath))
            {
                await ScanFileAsync(e.FullPath);
            }
        }

        /// <summary>
        /// Hata oluştuğunda tetiklenir
        /// </summary>
        private void OnError(object sender, ErrorEventArgs e)
        {
            var exception = e.GetException();
            MonitoringError?.Invoke(this, $"İzleme hatası: {exception?.Message}");
        }

        /// <summary>
        /// Dosyayı asenkron olarak tarar
        /// </summary>
        private async Task ScanFileAsync(string filePath)
        {
            try
            {
                // Dosyanın tamamen yazılmasını bekle
                await Task.Delay(500);

                if (!File.Exists(filePath))
                    return;

                // Dosyayı tara
                var result = await _scanEngine.ScanFileAsync(filePath);
                
                FileScannedInRealtime?.Invoke(this, filePath);

                // Tehdit tespit edildiyse event fırlatılacak (ScanEngine'den)
            }
            catch (Exception ex)
            {
                MonitoringError?.Invoke(this, $"Dosya taranamadı ({filePath}): {ex.Message}");
            }
        }

        /// <summary>
        /// İzlenen tüm klasörleri döndürür
        /// </summary>
        public List<string> GetMonitoredPaths()
        {
            return _monitoredPaths.ToList();
        }

        /// <summary>
        /// Tüm izlemeleri temizler
        /// </summary>
        public void ClearMonitoredPaths()
        {
            StopMonitoring();

            foreach (var watcher in _watchers)
            {
                watcher.Dispose();
            }

            _watchers.Clear();
            _monitoredPaths.Clear();
        }

        public void Dispose()
        {
            ClearMonitoredPaths();
        }
    }
}
