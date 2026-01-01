# Virus & Antivirus Checker

A signature-based virus detection system built with C# and Windows Forms. This educational project demonstrates how antivirus software detects threats using file hash signatures.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=flat-square&logo=windows)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## 📋 Overview

This project consists of two applications:

1. **AntivirusApp** - Full-featured antivirus scanner with quarantine and real-time protection
2. **TestVirus** - Harmless test file generator for testing the antivirus

### How It Works

The antivirus uses **signature-based detection**:
- Each file has a unique "fingerprint" (MD5/SHA256 hash)
- The hash is compared against a database of known threats
- If a match is found, the file is flagged as malicious
- Users can quarantine or delete detected threats

## ✨ Features

### AntivirusApp
- ✅ **Hash-Based Scanning** - MD5 and SHA256 file signature detection
- ✅ **Directory Scanning** - Recursive folder scanning with progress tracking
- ✅ **Quarantine System** - Isolate threats with `.vir` extension
- ✅ **Real-Time Protection** - Monitor file system for new threats
- ✅ **JSON Database** - Easily manageable threat signature database
- ✅ **Async Operations** - Non-blocking UI during scans

### TestVirus
- ✅ Generate harmless test files
- ✅ Automatic hash calculation (MD5 & SHA256)
- ✅ Copy hashes to clipboard
- ✅ Unique signatures for each file

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Windows OS
- Visual Studio 2022 (optional)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/ahmedfarukons/Virus-Antivirus-Checker.git
cd Virus-Antivirus-Checker
```

2. Build the solution:
```bash
dotnet build
```

3. Run the applications:
```bash
# Run AntivirusApp
dotnet run --project AntivirusApp/AntivirusApp.csproj

# Run TestVirus
dotnet run --project TestVirus/TestVirus.csproj
```

## 📖 Usage

### Creating a Test Virus

1. Launch **TestVirus**
2. Click "Test Virüsü Oluştur" (Create Test Virus)
3. Save the file
4. Hash values are automatically calculated and copied to clipboard

### Scanning for Threats

1. Launch **AntivirusApp**
2. Go to the **Tarama** (Scan) tab
3. Select a folder to scan
4. Click "Taramayı Başlat" (Start Scan)
5. View detected threats in the results table

### Managing Quarantine

1. Go to the **Karantina** (Quarantine) tab
2. View quarantined files
3. Restore or permanently delete files

### Real-Time Protection

1. Go to the **Gerçek Zamanlı Koruma** (Real-Time Protection) tab
2. Enable real-time monitoring
3. New files are automatically scanned

## 🏗️ Project Structure

```
Virus-Antivirus-Checker/
├── AntivirusApp/
│   ├── Core/
│   │   ├── HashCalculator.cs      # Hash computation
│   │   ├── VirusDatabase.cs       # Signature database
│   │   ├── ScanEngine.cs          # Scanning engine
│   │   ├── QuarantineManager.cs   # Quarantine management
│   │   └── RealtimeMonitor.cs     # Real-time monitoring
│   ├── Models/
│   │   ├── ThreatInfo.cs          # Threat data model
│   │   └── ScanResult.cs          # Scan result model
│   └── MainForm.cs                # Main UI
├── TestVirus/
│   └── VirusGeneratorForm.cs      # Test virus generator
└── README.md
```

## 🔧 Configuration

### Adding Virus Signatures

Edit `%APPDATA%\AntivirusApp\virus_signatures.json`:

```json
[
  {
    "Signature": "your_md5_hash_here",
    "ThreatName": "Threat.Name",
    "Description": "Threat description",
    "SeverityLevel": 8,
    "SignatureType": "MD5",
    "DateAdded": "2026-01-01T21:00:00"
  }
]
```

## ⚠️ Important Notes

- **Educational Purpose**: This is an educational project and should not be used as a real antivirus solution
- **Test Files Only**: Generated "viruses" are completely harmless
- **Windows Defender**: May flag the application during development. Add project folder to exclusions if needed

## 🎓 Learning Objectives

This project demonstrates:
- Hash algorithms (MD5, SHA256)
- File system operations
- Asynchronous programming (async/await)
- Event-driven architecture
- Windows Forms UI development
- Singleton pattern
- JSON serialization
- FileSystemWatcher usage

## 📸 Screenshots

### AntivirusApp - Scanning
![Scanning Interface](https://via.placeholder.com/800x500?text=Scanning+Interface)

### TestVirus - Generator
![Test Virus Generator](https://via.placeholder.com/800x500?text=Test+Virus+Generator)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👨‍💻 Author

**Ahmed Faruk**
- GitHub: [@ahmedfarukons](https://github.com/ahmedfarukons)

**⚠️ Disclaimer**: This software is for educational purposes only. It is not intended to replace professional antivirus solutions.

---

## 📋 Proje Yapısı

### 1. **AntivirusApp** - Ana Antivirüs Uygulaması
Tam özellikli antivirüs uygulaması aşağıdaki özelliklere sahiptir:

#### ✨ Özellikler:
- ✅ **Hash Tabanlı Tarama**: MD5 ve SHA256 hash değerleriyle dosya tarama
- ✅ **Klasör Tarama**: Recursive (alt klasörler dahil) tarama desteği
- ✅ **Karantina Sistemi**: Tehlikeli dosyaları `.vir` uzantısıyla karantinaya alma
- ✅ **Gerçek Zamanlı Koruma**: FileSystemWatcher ile yeni dosyaları otomatik tarama
- ✅ **İlerleme Takibi**: Asenkron tarama ile UI donmaması
- ✅ **Veritabanı Yönetimi**: JSON tabanlı virüs imza veritabanı

#### 🎯 Kullanım:
1. Uygulamayı çalıştırın
2. **Tarama** sekmesinden taranacak klasörü seçin
3. "Taramayı Başlat" butonuna tıklayın
4. Tespit edilen tehditleri karantinaya alın veya silin
5. **Gerçek Zamanlı Koruma** sekmesinden otomatik korumayı etkinleştirin

---

### 2. **TestVirus** - Test Virüsü Oluşturucu
Antivirüsü test etmek için zararsız dosyalar oluşturur.

#### ✨ Özellikler:
- ✅ Zararsız test dosyası oluşturma
- ✅ Otomatik MD5 ve SHA256 hash hesaplama
- ✅ Hash değerlerini panoya kopyalama
- ✅ Benzersiz imza oluşturma

#### 🎯 Kullanım:
1. TestVirus uygulamasını çalıştırın
2. "Test Virüsü Oluştur" butonuna tıklayın
3. Dosyayı kaydedin
4. Hash değerleri otomatik olarak hesaplanır ve panoya kopyalanır
5. Bu hash değerini antivirüs veritabanına ekleyin

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler:
- .NET 8.0 SDK veya üzeri
- Windows işletim sistemi
- Visual Studio 2022 (opsiyonel)

### Derleme:
```bash
# Tüm projeleri derle
dotnet build

# Sadece AntivirusApp
dotnet build AntivirusApp/AntivirusApp.csproj

# Sadece TestVirus
dotnet build TestVirus/TestVirus.csproj
```

### Çalıştırma:
```bash
# AntivirusApp'i çalıştır
dotnet run --project AntivirusApp/AntivirusApp.csproj

# TestVirus'ü çalıştır
dotnet run --project TestVirus/TestVirus.csproj
```

---

## 📚 Teknik Detaylar

### İmza Tabanlı Tespit Nasıl Çalışır?

1. **Hash Hesaplama**: Her dosyanın benzersiz bir "parmak izi" (MD5/SHA256 hash) hesaplanır
2. **Veritabanı Karşılaştırma**: Hesaplanan hash, bilinen zararlı hash'lerle karşılaştırılır
3. **Tespit**: Eşleşme varsa dosya tehdit olarak işaretlenir
4. **Aksiyon**: Kullanıcı dosyayı karantinaya alabilir veya silebilir

### Proje Mimarisi:

```
AntivirusApp/
├── Core/
│   ├── HashCalculator.cs      # Hash hesaplama
│   ├── VirusDatabase.cs       # Veritabanı yönetimi
│   ├── ScanEngine.cs          # Tarama motoru
│   ├── QuarantineManager.cs   # Karantina yönetimi
│   └── RealtimeMonitor.cs     # Gerçek zamanlı izleme
├── Models/
│   ├── ThreatInfo.cs          # Tehdit bilgisi modeli
│   └── ScanResult.cs          # Tarama sonucu modeli
└── MainForm.cs                # Ana UI

TestVirus/
└── VirusGeneratorForm.cs      # Test virüsü oluşturucu UI
```

---

## ⚠️ Önemli Notlar

### Windows Defender Uyarısı:
Geliştirme sırasında Windows Defender, uygulamalarınızı engelleyebilir. Çözüm:

1. Windows Security → Virus & threat protection → Manage settings
2. "Add or remove exclusions" → Add an exclusion
3. Proje klasörünü ekleyin: `C:\Users\LENOVO\Documents\Visual Studio 2022\My Codes\Virus And Antivirus`

### Test Virüsü Veritabanına Ekleme:

**Yöntem 1 - JSON Dosyası:**
1. `%APPDATA%\AntivirusApp\virus_signatures.json` dosyasını açın
2. Yeni bir tehdit ekleyin:
```json
{
  "Signature": "BURAYA_MD5_HASH",
  "ThreatName": "TestVirus.MyVirus",
  "Description": "Test amaçlı virüs",
  "SeverityLevel": 5,
  "SignatureType": "MD5",
  "DateAdded": "2026-01-01T20:00:00"
}
```

**Yöntem 2 - Kod ile:**
```csharp
var db = VirusDatabase.Instance;
db.AddThreat(new ThreatInfo(
    "HASH_DEGERI",
    "TestVirus.MyVirus",
    "Test virüsü",
    5,
    "MD5"
));
db.SaveDatabase();
```

---

## 🎓 Eğitim Amaçlı Kullanım

Bu proje, aşağıdaki konuları öğrenmek için idealdir:

- ✅ Hash algoritmaları (MD5, SHA256)
- ✅ Dosya sistemi işlemleri
- ✅ Asenkron programlama (async/await)
- ✅ Event-driven architecture
- ✅ Windows Forms UI geliştirme
- ✅ Singleton pattern
- ✅ JSON serializasyon
- ✅ FileSystemWatcher kullanımı

---

## 📊 Örnek Kullanım Senaryosu

### 1. Test Virüsü Oluşturma:
```
TestVirus.exe → "Test Virüsü Oluştur" → TestVirus.txt kaydedildi
Hash: a1b2c3d4e5f6...
```

### 2. Hash'i Veritabanına Ekleme:
```
virus_signatures.json dosyasına hash ekle
```

### 3. Tarama:
```
AntivirusApp.exe → Klasör seç → Taramayı Başlat
Sonuç: TestVirus.txt tespit edildi!
```

### 4. Karantina:
```
Tespit edilen dosya → "Karantinaya Al"
Dosya: %APPDATA%\AntivirusApp\Quarantine\{GUID}.vir
```
---

## 📝 Lisans

Bu proje eğitim amaçlıdır. Ticari kullanım için uygun değildir.

**Önemli**: Bu bir eğitim projesidir. Gerçek dünya kullanımı için profesyonel antivirüs çözümleri kullanılmalıdır.
