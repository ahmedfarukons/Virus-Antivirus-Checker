# Virüs ve Antivirüs Uygulaması - Kullanım Kılavuzu

## 🎯 Hızlı Başlangıç

### Adım 1: Test Virüsü Oluşturma

1. **TestVirus.exe** uygulamasını çalıştırın
2. Ana ekranda "**Test Virüsü Oluştur**" butonuna tıklayın
3. Dosya kaydetme penceresinde:
   - Dosya adı: `TestVirus.txt` (veya istediğiniz isim)
   - Konum: Masaüstü veya test klasörü
   - "Kaydet" butonuna tıklayın

4. **Sonuç Ekranı**:
   ```
   Test virüsü başarıyla oluşturuldu!
   
   Dosya Yolu: C:\Users\...\TestVirus.txt
   Dosya Boyutu: 245 bytes
   
   MD5 Hash:
   a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6
   
   SHA256 Hash:
   1a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p7q8r9s0t1u2v3w4x5y6z7
   ```

5. Hash değerleri **otomatik olarak panoya kopyalanır**

---

### Adım 2: Hash Değerini Veritabanına Ekleme

#### Yöntem A: JSON Dosyası ile (Önerilen)

1. Windows tuşu + R → `%APPDATA%\AntivirusApp` yazın → Enter
2. Eğer klasör yoksa, önce AntivirusApp'i bir kez çalıştırın
3. `virus_signatures.json` dosyasını Not Defteri ile açın
4. Aşağıdaki formatı kullanarak yeni bir giriş ekleyin:

```json
[
  {
    "Signature": "BURAYA_MD5_HASH_YAPISTIRIN",
    "ThreatName": "TestVirus.MyFirstVirus",
    "Description": "İlk test virüsüm",
    "SeverityLevel": 7,
    "SignatureType": "MD5",
    "DateAdded": "2026-01-01T20:00:00"
  }
]
```

**Örnek**:
```json
[
  {
    "Signature": "a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6",
    "ThreatName": "TestVirus.Desktop",
    "Description": "Masaüstünde oluşturduğum test virüsü",
    "SeverityLevel": 8,
    "SignatureType": "MD5",
    "DateAdded": "2026-01-01T20:30:00"
  }
]
```

5. Dosyayı kaydedin

#### Yöntem B: Birden Fazla Tehdit Ekleme

```json
[
  {
    "Signature": "hash1",
    "ThreatName": "TestVirus.First",
    "Description": "Birinci test virüsü",
    "SeverityLevel": 5,
    "SignatureType": "MD5",
    "DateAdded": "2026-01-01T20:00:00"
  },
  {
    "Signature": "hash2",
    "ThreatName": "TestVirus.Second",
    "Description": "İkinci test virüsü",
    "SeverityLevel": 7,
    "SignatureType": "MD5",
    "DateAdded": "2026-01-01T20:05:00"
  }
]
```

---

### Adım 3: Antivirüs ile Tarama

1. **AntivirusApp.exe** uygulamasını çalıştırın

2. **Tarama Sekmesi**:
   - "Gözat..." butonuna tıklayın
   - Test virüsünün bulunduğu klasörü seçin (örn: Masaüstü)
   - "Alt klasörleri de tara" seçeneğini işaretleyin
   - "**Taramayı Başlat**" butonuna tıklayın

3. **Tarama Sırasında**:
   ```
   İlerleme: 45 / 120 dosya tarandı
   Tehdit bulundu: 1
   Taranıyor: TestVirus.txt
   ```

4. **Tespit Edilen Tehditler**:
   | Dosya Adı | Yol | Tehdit | MD5 Hash | Durum |
   |-----------|-----|--------|----------|-------|
   | TestVirus.txt | C:\Users\...\Desktop | TestVirus.MyFirstVirus | a1b2c... | Normal |

---

### Adım 4: Karantina İşlemleri

#### Dosyayı Karantinaya Alma:

1. Tespit edilen dosyayı listeden seçin
2. "**Karantinaya Al**" butonuna tıklayın
3. Onay mesajı: "Dosya karantinaya alındı: TestVirus.txt"

**Ne Olur?**
- Dosya orijinal konumdan kaldırılır
- `%APPDATA%\AntivirusApp\Quarantine\{GUID}.vir` konumuna taşınır
- Dosya uzantısı `.vir` olarak değiştirilir
- Karantina sekmesinde görünür

#### Karantinadan Geri Yükleme:

1. "**Karantina**" sekmesine gidin
2. Geri yüklenecek dosyayı seçin
3. "**Geri Yükle**" butonuna tıklayın
4. Dosya orijinal konumuna geri taşınır

#### Karantinadan Kalıcı Silme:

1. "**Karantina**" sekmesinde dosyayı seçin
2. "**Kalıcı Sil**" butonuna tıklayın
3. Onay verin
4. Dosya tamamen silinir (geri alınamaz!)

---

### Adım 5: Gerçek Zamanlı Koruma

1. "**Gerçek Zamanlı Koruma**" sekmesine gidin
2. "Gerçek zamanlı korumayı etkinleştir" kutusunu işaretleyin
3. Durum: **"Gerçek zamanlı koruma: AÇIK"** (yeşil)

**Ne Yapar?**
- Varsayılan olarak "Belgelerim" klasörünü izler
- Yeni oluşturulan dosyaları otomatik tarar
- Tehdit tespit edilirse anında uyarı verir

**Test Etme**:
1. Gerçek zamanlı korumayı etkinleştirin
2. TestVirus ile yeni bir test dosyası oluşturun
3. Dosyayı "Belgelerim" klasörüne kaydedin
4. Otomatik tespit uyarısı alacaksınız!

---

## 🎓 Örnek Senaryo: Tam İş Akışı

### Senaryo: Hocanıza Gösterim

**1. Hazırlık (5 dakika)**
```
✅ TestVirus.exe ile 3 farklı test virüsü oluştur
✅ Her birinin hash değerini kaydet
✅ İlk 2 tanesini veritabanına ekle (3. yi ekleme!)
✅ Test dosyalarını farklı klasörlere koy
```

**2. Gösterim (10 dakika)**

```
📌 BÖLÜM 1: Test Virüsü Oluşturma
   → TestVirus.exe'yi aç
   → "Test Virüsü Oluştur" butonuna tıkla
   → Hash değerlerini göster
   → "Bu hash değerleri dosyanın parmak izidir" açıkla

📌 BÖLÜM 2: Veritabanı Yönetimi
   → virus_signatures.json dosyasını göster
   → JSON formatını açıkla
   → Yeni hash ekle

📌 BÖLÜM 3: Tarama
   → AntivirusApp.exe'yi aç
   → Klasör seç ve taramayı başlat
   → İlerleme çubuğunu göster
   → 2 virüs tespit edilecek (3. veritabanında yok!)
   → "Signature-based detection böyle çalışır" açıkla

📌 BÖLÜM 4: Karantina
   → Tespit edilen dosyayı karantinaya al
   → Karantina klasörünü göster (.vir uzantısı)
   → Geri yükleme işlemini göster

📌 BÖLÜM 5: Gerçek Zamanlı Koruma
   → Gerçek zamanlı korumayı etkinleştir
   → Yeni bir test virüsü oluştur
   → Belgelerim klasörüne kaydet
   → Otomatik tespit uyarısını göster
```

**3. Sonuç**
```
✅ İmza tabanlı tespit yöntemini gösterdin
✅ Hash algoritmasının önemini açıkladın
✅ Karantina sistemini gösterdin
✅ Gerçek zamanlı korumayı test ettin
```

---

## 🔧 Sorun Giderme

### Problem 1: "Dosya bulunamadı" Hatası
**Çözüm**: 
- Dosya yolunu kontrol edin
- Dosyanın silinmediğinden emin olun
- Yönetici olarak çalıştırmayı deneyin

### Problem 2: Virüs Tespit Edilmiyor
**Çözüm**:
- Hash değerinin doğru kopyalandığından emin olun
- virus_signatures.json dosyasının JSON formatının doğru olduğunu kontrol edin
- AntivirusApp'i yeniden başlatın

### Problem 3: Windows Defender Uygulamayı Engelliyor
**Çözüm**:
1. Windows Security → Virus & threat protection
2. Manage settings → Add or remove exclusions
3. Proje klasörünü ekleyin

### Problem 4: Gerçek Zamanlı Koruma Çalışmıyor
**Çözüm**:
- Checkbox'ın işaretli olduğundan emin olun
- Durum mesajının "AÇIK" (yeşil) olduğunu kontrol edin
- Test dosyasını "Belgelerim" klasörüne kaydedin

---

## 📊 Performans İpuçları

### Hızlı Tarama İçin:
- ✅ Sadece gerekli klasörleri tarayın
- ✅ "Alt klasörleri de tara" seçeneğini büyük klasörlerde kapatın
- ✅ Sistem dosyalarını taramayın

### Veritabanı Optimizasyonu:
- ✅ Gereksiz imzaları silin
- ✅ SHA256 yerine MD5 kullanın (daha hızlı)
- ✅ Veritabanını düzenli güncelleyin

---

## 🎯 İleri Seviye Kullanım

### Özel İmza Ekleme:

```csharp
// Kod ile imza ekleme
var db = VirusDatabase.Instance;
db.AddThreat(new ThreatInfo(
    "custom_hash_here",
    "CustomThreat.Ransomware",
    "Özel tehdit tanımı",
    10, // Maksimum tehdit seviyesi
    "SHA256"
));
db.SaveDatabase();
```

### Toplu Tarama:

```csharp
// Birden fazla dosyayı tara
string[] files = { "file1.txt", "file2.exe", "file3.dll" };
var results = await scanEngine.ScanFilesAsync(files);
```

---

## 📝 Notlar

- ⚠️ Bu bir **eğitim projesidir**, gerçek virüslere karşı koruma sağlamaz
- ⚠️ Test virüsleri **zararsızdır**, gerçek virüs değildir
- ⚠️ Karantinadan silinen dosyalar **geri alınamaz**
- ⚠️ Gerçek zamanlı koruma sistem performansını etkileyebilir

---

## ✅ Başarı Kontrol Listesi

Projenizi test etmek için:

- [ ] Test virüsü oluşturabiliyorum
- [ ] Hash değerlerini hesaplayabiliyorum
- [ ] Veritabanına imza ekleyebiliyorum
- [ ] Klasör taraması yapabiliyorum
- [ ] Virüs tespit edebiliyorum
- [ ] Karantinaya alabiliyorum
- [ ] Karantinadan geri yükleyebiliyorum
- [ ] Gerçek zamanlı korumayı etkinleştirebiliyorum
- [ ] Yeni dosyalar otomatik taranıyor

---

## 🎉 Tebrikler!

Artık kendi antivirüs yazılımınızı kullanabiliyorsunuz! 

**Hocanıza gösterirken başarılar dileriz!** 🚀

---

**Son Güncelleme**: 01 Ocak 2026
**Versiyon**: 1.0.0
