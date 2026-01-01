using System.Security.Cryptography;

namespace TestVirus;

public partial class VirusGeneratorForm : Form
{
    public VirusGeneratorForm()
    {
        InitializeComponent();
    }

    private void btnGenerateVirus_Click(object sender, EventArgs e)
    {
        using (var dialog = new SaveFileDialog())
        {
            dialog.Filter = "Executable Files (*.exe)|*.exe|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Test Virüsü Kaydet";
            dialog.FileName = "TestVirus.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GenerateTestVirus(dialog.FileName);
            }
        }
    }

    private void GenerateTestVirus(string filePath)
    {
        try
        {
            // Test virüsü içeriği
            string virusContent = $@"BU BİR TEST VİRÜSÜDÜR
================================
Oluşturulma Tarihi: {DateTime.Now}
Benzersiz ID: {Guid.NewGuid()}
================================

Bu dosya zararsızdır ve sadece antivirüs test amaçlıdır.
Gerçek bir virüs değildir.

Test Signature: TESTVIRUS-{DateTime.Now.Ticks}
";

            // Dosyayı oluştur
            File.WriteAllText(filePath, virusContent);

            // Hash değerlerini hesapla
            string md5Hash = CalculateMD5(filePath);
            string sha256Hash = CalculateSHA256(filePath);

            // Sonuçları göster
            txtResult.Clear();
            txtResult.AppendText($"Test virüsü başarıyla oluşturuldu!\r\n\r\n");
            txtResult.AppendText($"Dosya Yolu: {filePath}\r\n");
            txtResult.AppendText($"Dosya Boyutu: {new FileInfo(filePath).Length} bytes\r\n\r\n");
            txtResult.AppendText($"MD5 Hash:\r\n{md5Hash}\r\n\r\n");
            txtResult.AppendText($"SHA256 Hash:\r\n{sha256Hash}\r\n\r\n");
            txtResult.AppendText("Bu hash değerlerini antivirüs veritabanına ekleyebilirsiniz.\r\n");

            // Hash değerlerini clipboard'a kopyala
            string hashInfo = $"MD5: {md5Hash}\r\nSHA256: {sha256Hash}";
            Clipboard.SetText(hashInfo);

            MessageBox.Show($"Test virüsü oluşturuldu!\r\n\r\nHash değerleri panoya kopyalandı.\r\n\r\nDosya: {Path.GetFileName(filePath)}", 
                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string CalculateMD5(string filePath)
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

    private string CalculateSHA256(string filePath)
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

    private void btnAddToDatabase_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Bu özellik için:\r\n\r\n" +
                       "1. Test virüsü oluşturun\r\n" +
                       "2. MD5 hash değerini kopyalayın\r\n" +
                       "3. Antivirüs uygulamasını açın\r\n" +
                       "4. Hash değerini veritabanına manuel olarak ekleyin\r\n\r\n" +
                       "Veya virus_signatures.json dosyasını düzenleyin.",
                       "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnClearResult_Click(object sender, EventArgs e)
    {
        txtResult.Clear();
    }
}

