using AntivirusApp.Core;
using AntivirusApp.Models;

namespace AntivirusApp;

public partial class MainForm : Form
{
    private ScanEngine _scanEngine;
    private QuarantineManager _quarantineManager;
    private RealtimeMonitor _realtimeMonitor;
    private VirusDatabase _virusDatabase;
    private List<ScanResult> _currentScanResults;
    private bool _isScanning;

    public MainForm()
    {
        InitializeComponent();
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _scanEngine = new ScanEngine();
        _quarantineManager = QuarantineManager.Instance;
        _realtimeMonitor = new RealtimeMonitor();
        _virusDatabase = VirusDatabase.Instance;
        _currentScanResults = new List<ScanResult>();
        _isScanning = false;

        // Event subscriptions
        _scanEngine.ProgressChanged += ScanEngine_ProgressChanged;
        _scanEngine.ThreatDetected += ScanEngine_ThreatDetected;
        _scanEngine.ScanCompleted += ScanEngine_ScanCompleted;

        _realtimeMonitor.ThreatDetectedInRealtime += RealtimeMonitor_ThreatDetected;
        _realtimeMonitor.FileScannedInRealtime += RealtimeMonitor_FileScanned;
        _realtimeMonitor.MonitoringError += RealtimeMonitor_Error;

        // UI başlangıç durumu
        UpdateUI();
        LoadQuarantineList();
        UpdateStatusBar();
    }

    private void btnSelectFolder_Click(object sender, EventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            dialog.Description = "Taranacak klasörü seçin";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtScanPath.Text = dialog.SelectedPath;
            }
        }
    }

    private async void btnStartScan_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtScanPath.Text))
        {
            MessageBox.Show("Lütfen taranacak bir klasör seçin!", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Directory.Exists(txtScanPath.Text))
        {
            MessageBox.Show("Seçilen klasör bulunamadı!", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        await StartScanAsync(txtScanPath.Text);
    }

    private async Task StartScanAsync(string path)
    {
        _isScanning = true;
        _currentScanResults.Clear();
        dgvThreats.Rows.Clear();
        
        UpdateUI();

        try
        {
            lblStatus.Text = "Tarama başlatılıyor...";
            var results = await _scanEngine.ScanDirectoryAsync(path, chkRecursive.Checked);
            _currentScanResults = results;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Tarama hatası: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isScanning = false;
            UpdateUI();
        }
    }

    private void btnStopScan_Click(object sender, EventArgs e)
    {
        if (_isScanning)
        {
            _scanEngine.CancelScan();
            lblStatus.Text = "Tarama durduruluyor...";
        }
    }

    private void ScanEngine_ProgressChanged(object? sender, ScanProgressEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(() => ScanEngine_ProgressChanged(sender, e));
            return;
        }

        progressBar.Maximum = e.TotalFiles;
        progressBar.Value = e.ScannedFiles;
        
        lblProgress.Text = $"{e.ScannedFiles} / {e.TotalFiles} dosya tarandı";
        lblThreatsFound.Text = $"Tehdit bulundu: {e.ThreatsFound}";
        lblStatus.Text = $"Taranıyor: {Path.GetFileName(e.CurrentFile)}";
    }

    private void ScanEngine_ThreatDetected(object? sender, ScanResult result)
    {
        if (InvokeRequired)
        {
            Invoke(() => ScanEngine_ThreatDetected(sender, result));
            return;
        }

        AddThreatToGrid(result);
    }

    private void ScanEngine_ScanCompleted(object? sender, ScanCompletedEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(() => ScanEngine_ScanCompleted(sender, e));
            return;
        }

        string message = e.WasCancelled 
            ? $"Tarama iptal edildi.\n\n{e.ScannedFiles} dosya tarandı.\n{e.ThreatsFound} tehdit bulundu."
            : $"Tarama tamamlandı!\n\n{e.ScannedFiles} dosya tarandı.\n{e.ThreatsFound} tehdit bulundu.\nSüre: {e.Duration.TotalSeconds:F2} saniye";

        lblStatus.Text = e.WasCancelled ? "Tarama iptal edildi" : "Tarama tamamlandı";
        
        MessageBox.Show(message, "Tarama Sonucu", MessageBoxButtons.OK, 
            e.ThreatsFound > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
    }

    private void AddThreatToGrid(ScanResult result)
    {
        int rowIndex = dgvThreats.Rows.Add();
        var row = dgvThreats.Rows[rowIndex];
        
        row.Cells["colFileName"].Value = result.FileName;
        row.Cells["colPath"].Value = result.FilePath;
        row.Cells["colThreat"].Value = result.DetectedThreat?.ThreatName ?? "Unknown";
        row.Cells["colHash"].Value = result.MD5Hash;
        row.Cells["colStatus"].Value = result.Status;
        
        row.DefaultCellStyle.BackColor = result.GetSeverityColor();
        row.Tag = result;
    }

    private void btnQuarantine_Click(object sender, EventArgs e)
    {
        if (dgvThreats.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen karantinaya alınacak dosyayı seçin!", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedRow = dgvThreats.SelectedRows[0];
        var result = selectedRow.Tag as ScanResult;

        if (result == null) return;

        try
        {
            var entry = _quarantineManager.QuarantineFile(result.FilePath, result);
            MessageBox.Show($"Dosya karantinaya alındı:\n{result.FileName}", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            selectedRow.Cells["colStatus"].Value = "Quarantined";
            LoadQuarantineList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Karantina hatası: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvThreats.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen silinecek dosyayı seçin!", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Seçilen dosya kalıcı olarak silinecek. Emin misiniz?", 
            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result != DialogResult.Yes) return;

        var selectedRow = dgvThreats.SelectedRows[0];
        var scanResult = selectedRow.Tag as ScanResult;

        if (scanResult == null) return;

        try
        {
            if (File.Exists(scanResult.FilePath))
            {
                File.Delete(scanResult.FilePath);
                MessageBox.Show("Dosya silindi.", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedRow.Cells["colStatus"].Value = "Deleted";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void chkRealtimeProtection_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRealtimeProtection.Checked)
        {
            // Varsayılan olarak kullanıcının Documents klasörünü izle
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _realtimeMonitor.AddMonitoredPath(documentsPath);
            _realtimeMonitor.StartMonitoring();
            
            lblRealtimeStatus.Text = "Gerçek zamanlı koruma: AÇIK";
            lblRealtimeStatus.ForeColor = Color.Green;
        }
        else
        {
            _realtimeMonitor.StopMonitoring();
            lblRealtimeStatus.Text = "Gerçek zamanlı koruma: KAPALI";
            lblRealtimeStatus.ForeColor = Color.Red;
        }
    }

    private void RealtimeMonitor_ThreatDetected(object? sender, ScanResult result)
    {
        if (InvokeRequired)
        {
            Invoke(() => RealtimeMonitor_ThreatDetected(sender, result));
            return;
        }

        MessageBox.Show($"Gerçek zamanlı koruma bir tehdit tespit etti!\n\n" +
                       $"Dosya: {result.FileName}\n" +
                       $"Tehdit: {result.DetectedThreat?.ThreatName}\n\n" +
                       $"Dosyayı karantinaya almak ister misiniz?", 
                       "Tehdit Tespit Edildi!", 
                       MessageBoxButtons.YesNo, 
                       MessageBoxIcon.Warning);
    }

    private void RealtimeMonitor_FileScanned(object? sender, string filePath)
    {
        if (InvokeRequired)
        {
            Invoke(() => RealtimeMonitor_FileScanned(sender, filePath));
            return;
        }

        lblRealtimeStatus.Text = $"Son tarama: {Path.GetFileName(filePath)}";
    }

    private void RealtimeMonitor_Error(object? sender, string error)
    {
        if (InvokeRequired)
        {
            Invoke(() => RealtimeMonitor_Error(sender, error));
            return;
        }

        lblStatus.Text = $"İzleme hatası: {error}";
    }

    private void LoadQuarantineList()
    {
        dgvQuarantine.Rows.Clear();
        var entries = _quarantineManager.GetAllQuarantineEntries();

        foreach (var entry in entries)
        {
            int rowIndex = dgvQuarantine.Rows.Add();
            var row = dgvQuarantine.Rows[rowIndex];
            
            row.Cells["colQFileName"].Value = entry.OriginalFileName;
            row.Cells["colQThreat"].Value = entry.ThreatName;
            row.Cells["colQDate"].Value = entry.QuarantineDate.ToString("g");
            row.Cells["colQSize"].Value = FormatFileSize(entry.FileSize);
            row.Tag = entry;
        }

        lblQuarantineCount.Text = $"Karantinada {entries.Count} dosya";
    }

    private void btnRestoreFromQuarantine_Click(object sender, EventArgs e)
    {
        if (dgvQuarantine.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen geri yüklenecek dosyayı seçin!", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var entry = dgvQuarantine.SelectedRows[0].Tag as QuarantineEntry;
        if (entry == null) return;

        var result = MessageBox.Show("Bu dosyayı geri yüklemek istediğinizden emin misiniz?", 
            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        try
        {
            _quarantineManager.RestoreFile(entry.QuarantineId);
            MessageBox.Show("Dosya geri yüklendi.", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadQuarantineList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Geri yükleme hatası: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDeleteFromQuarantine_Click(object sender, EventArgs e)
    {
        if (dgvQuarantine.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen silinecek dosyayı seçin!", "Uyarı", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var entry = dgvQuarantine.SelectedRows[0].Tag as QuarantineEntry;
        if (entry == null) return;

        var result = MessageBox.Show("Bu dosya kalıcı olarak silinecek. Emin misiniz?", 
            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result != DialogResult.Yes) return;

        try
        {
            _quarantineManager.DeleteFromQuarantine(entry.QuarantineId);
            MessageBox.Show("Dosya silindi.", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadQuarantineList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateUI()
    {
        btnStartScan.Enabled = !_isScanning;
        btnStopScan.Enabled = _isScanning;
        btnSelectFolder.Enabled = !_isScanning;
        txtScanPath.Enabled = !_isScanning;
        chkRecursive.Enabled = !_isScanning;
    }

    private void UpdateStatusBar()
    {
        lblDatabaseCount.Text = $"Veritabanı: {_virusDatabase.ThreatCount} imza";
        lblQuarantineCount.Text = $"Karantina: {_quarantineManager.QuarantineCount} dosya";
    }

    private string FormatFileSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _realtimeMonitor?.Dispose();
        base.OnFormClosing(e);
    }
}
