# 📚 Eğitim Takip Otomasyonu (Education Tracking Automation)

Bu proje, öğrenci ve eğitim süreçlerinin takibini kolaylaştırmak için C# ve Windows Forms kullanılarak geliştirilmiş kapsamlı bir masaüstü uygulamasıdır.

## 🚀 Özellikler

### 📊 YKS (Üniversite Sınavı) Modülü

- TYT puan hesaplama
- Net hesaplama
- Geçmiş sonuçları kaydetme ve görüntüleme
- Deneme sınavı sonuçları takibi
- YKS konuları takibi
- Çıkmış sorular arşivi

### 📝 Öğrenci Akademik Takip

- Ders notları görüntüleme
- Devamsızlık takibi
- Ders programı görüntüleme
- Özel notlar tutma

### 💬 İletişim Özellikleri

- Mesajlaşma sistemi
- Öğrenci-öğretmen iletişimi

## 🛠️ Kullanılan Teknolojiler

- 💻 Programlama Dili: C#
- 🖥️ Görsel Arayüz: Windows Forms
- 🛢️ Veritabanı: MySQL
- 🧰 Geliştirme Ortamı: Visual Studio
- ⚙️ .NET Framework 4.8

## 📋 Sistem Gereksinimleri

- Windows 7 veya üzeri işletim sistemi
- .NET Framework 4.8
- MySQL Server
- Minimum 4GB RAM
- 100MB boş disk alanı

## 📥 Kurulum

1. Projeyi indirin veya klonlayın
2. Visual Studio ile projeyi açın
3. MySQL Server'da veritabanını oluşturun (aşağıdaki veritabanı şeması bölümünü kullanın)
4. `App.config` dosyasında veritabanı bağlantı ayarlarını güncelleyin
5. Projeyi derleyin ve çalıştırın

## 📊 Veritabanı Şeması

### Veritabanı Oluşturma
```sql
CREATE DATABASE EgitimTakipOtomasyonu;
USE EgitimTakipOtomasyonu;
```

### Tablolar

#### 👥 Kullanıcı Tabloları
```sql
CREATE TABLE veliler (
    veli_id INT AUTO_INCREMENT PRIMARY KEY,
    ad VARCHAR(50),
    soyad VARCHAR(50),
    telefon VARCHAR(20)
);

CREATE TABLE Ogrenciler (
    OgrenciID INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(100) NOT NULL UNIQUE,
    Sifre VARCHAR(100) NOT NULL,
    Adi VARCHAR(50),
    Soyadi VARCHAR(50),
    Sinifi VARCHAR(50),
    Email VARCHAR(100),
    Tarih DATE,
    veli_id INT,
    FOREIGN KEY (veli_id) REFERENCES veliler(veli_id)
);

CREATE TABLE Ogretmenler (
    OgretmenID INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(100) NOT NULL UNIQUE,
    Sifre VARCHAR(100) NOT NULL,
    Adi VARCHAR(50),
    Soyadi VARCHAR(50),
    Brans VARCHAR(50),
    Email VARCHAR(100),
    Tarih DATE
);

CREATE TABLE Adminler (
    AdminID INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
    Sifre VARCHAR(255) NOT NULL
);
```

#### 📚 Eğitim Tabloları
```sql
CREATE TABLE Dersler (
    DersID INT AUTO_INCREMENT PRIMARY KEY,
    DersAdi VARCHAR(50),
    UstDersID INT NULL,
    YKS_Dersi BOOLEAN DEFAULT 1,
    FOREIGN KEY (UstDersID) REFERENCES Dersler(DersID)
);

CREATE TABLE Konular (
    KonuID INT AUTO_INCREMENT PRIMARY KEY,
    DersID INT,
    KonuAdi VARCHAR(100),
    TYT_mi BOOLEAN DEFAULT 1,
    AYT_mi BOOLEAN DEFAULT 0,
    FOREIGN KEY (DersID) REFERENCES Dersler(DersID)
);

CREATE TABLE OgrenciKonular (
    OgrenciID INT,
    KonuID INT,
    BittiMi BOOLEAN DEFAULT 0,
    PRIMARY KEY (OgrenciID, KonuID),
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID),
    FOREIGN KEY (KonuID) REFERENCES Konular(KonuID)
);
```

#### 📝 Takip Tabloları
```sql
CREATE TABLE Denemeler (
    DenemeID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT,
    Tarih DATE,
    MatDogru INT,
    MatYanlis INT,
    MatNet FLOAT,
    FenDogru INT,
    FenYanlis INT,
    FenNet FLOAT,
    TurkceDogru INT,
    TurkceYanlis INT,
    TurkceNet FLOAT,
    SosyalDogru INT,
    SosyalYanlis INT,
    SosyalNet FLOAT,
    ToplamPuan INT,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID)
);

CREATE TABLE Notlar (
    NotID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT,
    Ders VARCHAR(50),
    Not1 DECIMAL(5,2) NULL,
    Not2 DECIMAL(5,2) NULL,
    Performans1 DECIMAL(5,2) NULL,
    Performans2 DECIMAL(5,2) NULL,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID)
);

CREATE TABLE Devamsizliklar (
    DevamsizlikID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT,
    Ders VARCHAR(50),
    Tarih DATE,
    DersSaati INT,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID)
);
```

#### 📅 Program ve İletişim Tabloları
```sql
CREATE TABLE DersProgrami (
    ProgramID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT NOT NULL,
    DersID INT NOT NULL,
    Gun VARCHAR(10) NOT NULL CHECK (Gun IN ('Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi', 'Pazar')),
    Saat TIME NOT NULL,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID) ON DELETE CASCADE,
    FOREIGN KEY (DersID) REFERENCES Dersler(DersID) ON DELETE CASCADE
);

CREATE TABLE Mesajlar (
    MesajID INT AUTO_INCREMENT PRIMARY KEY,
    GonderenID INT,
    AliciID INT,
    MesajIcerik TEXT,
    GonderimTarihi DATETIME DEFAULT CURRENT_TIMESTAMP,
    OkunduMu BOOLEAN DEFAULT 0,
    FOREIGN KEY (GonderenID) REFERENCES Ogrenciler(OgrenciID),
    FOREIGN KEY (AliciID) REFERENCES Ogretmenler(OgretmenID)
);

CREATE TABLE Duyurular (
    DuyuruID INT AUTO_INCREMENT PRIMARY KEY,
    Baslik VARCHAR(100),
    Icerik TEXT,
    YayimTarihi DATETIME DEFAULT CURRENT_TIMESTAMP,
    HedefRol VARCHAR(50)
);
```

## 👥 Kullanıcı Rolleri

### 👨‍🎓 Öğrenci

- YKS puan hesaplama
- Ders notlarını görüntüleme
- Devamsızlık bilgilerini kontrol etme
- Ders programını görüntüleme
- Özel notlar alma
- Mesajlaşma

### 👨‍🏫 Öğretmen

- Not girişi
- Devamsızlık kaydı
- Öğrenci performans takibi
- Mesajlaşma

## 📝 Lisans

Bu proje "Yiğit Türkkan" tarafından yapılmış olup, her hakkı saklıdır.

## 📞 İletişim

Proje ile ilgili sorularınız için:
- E-posta: yigit.trkkan2003@gmail.com
- GitHub: Yiğit Türkkan
