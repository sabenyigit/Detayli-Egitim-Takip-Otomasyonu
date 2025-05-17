-- Veritabanı oluşturma
CREATE DATABASE EgitimTakipOtomasyonu;
USE EgitimTakipOtomasyonu;

-- 1. Öğrenciler Tablosu
CREATE TABLE Ogrenciler (
    OgrenciID INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(100) NOT NULL UNIQUE,
    Sifre VARCHAR(100) NOT NULL,
    Adi VARCHAR(50),
    Soyadi VARCHAR(50),
    Email VARCHAR(100),
    Tarih DATE
);

-- 2. Öğretmenler Tablosu
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

-- 3. Adminler Tablosu
CREATE TABLE Adminler (
    AdminID INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
    Sifre VARCHAR(255) NOT NULL
);

-- 4. Dersler Tablosu (Eksikti, eklendi)
CREATE TABLE Dersler (
    DersID INT AUTO_INCREMENT PRIMARY KEY,
    DersAdi VARCHAR(50),
    UstDersID INT NULL, -- Üst dersin ID’si, hiyerarşi için (örneğin, Tarih’in üstü Sosyal)
    YKS_Dersi BOOLEAN DEFAULT 1,
    FOREIGN KEY (UstDersID) REFERENCES Dersler(DersID)
);

-- 5. Denemeler Tablosu
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
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID)
);

-- 6. Mesajlar Tablosu
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

-- 7. Notlar Tablosu (Eksikti, eklendi)
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

-- 8. DersProgrami Tablosu (Kodla uyumlu hale getirildi)
CREATE TABLE DersProgrami (
    ProgramID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT NOT NULL,
    DersID INT NOT NULL,
    Gun VARCHAR(10) NOT NULL CHECK (Gun IN ('Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi', 'Pazar')),
    Saat TIME NOT NULL,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID) ON DELETE CASCADE,
    FOREIGN KEY (DersID) REFERENCES Dersler(DersID) ON DELETE CASCADE
);

-- 9. Devamsizliklar Tablosu (Eksikti, eklendi)
CREATE TABLE Devamsizliklar (
    DevamsizlikID INT AUTO_INCREMENT PRIMARY KEY,
    OgrenciID INT,
    Ders VARCHAR(50),
    Tarih DATE,
    DersSaati INT,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID)
);

-- 10. Konular Tablosu (Eksikti, eklendi)
CREATE TABLE Konular (
    KonuID INT AUTO_INCREMENT PRIMARY KEY,
    DersID INT,
    KonuAdi VARCHAR(100),
    TYT_mi BOOLEAN DEFAULT 1, -- TYT konuları için
    FOREIGN KEY (DersID) REFERENCES Dersler(DersID)
);

-- 11. OgrenciKonular Tablosu (Eksikti, eklendi)
CREATE TABLE OgrenciKonular (
    OgrenciID INT,
    KonuID INT,
    BittiMi BOOLEAN DEFAULT 0,
    PRIMARY KEY (OgrenciID, KonuID),
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID),
    FOREIGN KEY (KonuID) REFERENCES Konular(KonuID)
);

-- 12. Sinavlar Tablosu
CREATE TABLE Sinavlar (
    SinavID INT AUTO_INCREMENT PRIMARY KEY,
    DersAdi VARCHAR(100),
    SinavTarihi DATE,
    OgretmenID INT,
    FOREIGN KEY (OgretmenID) REFERENCES Ogretmenler(OgretmenID)
);

-- 13. Duyurular Tablosu
CREATE TABLE Duyurular (
    DuyuruID INT AUTO_INCREMENT PRIMARY KEY,
    Baslik VARCHAR(100),
    Icerik TEXT,
    YayimTarihi DATETIME DEFAULT CURRENT_TIMESTAMP,
    HedefRol VARCHAR(50) -- Bu sütun eksik olabilir
);

-- Örnek Veriler
INSERT INTO Ogrenciler (KullaniciAdi, Sifre, Adi, Soyadi, Email, Tarih)
VALUES
('ogrenci1', '12', 'Ahmet', 'Yılmaz', 'ahmet.yilmaz@example.com', '2025-03-23'),
('ogrenci2', '21', 'Mehmet', 'Kaya', 'mehmet.kaya@example.com', '2025-03-22');

INSERT INTO Ogretmenler (KullaniciAdi, Sifre, Adi, Soyadi, Brans, Email, Tarih)
VALUES
('ogretmen1', '123', 'Ayşe', 'Öztürk', 'Matematik', 'ayse.ozturk@example.com', '2025-03-20'),
('ogretmen2', '321', 'Ali', 'Demir', 'Fen Bilimleri', 'ali.demir@example.com', '2025-03-21');

INSERT INTO Adminler (KullaniciAdi, Sifre)
VALUES ('admin', '1234');

INSERT INTO Dersler (DersAdi, UstDersID, YKS_Dersi) VALUES
('Türkçe', NULL, 1),
('Tarih', NULL, 1),                   
('Coğrafya', NULL, 1),
('Din Kültürü ve Ahlak Bilgisi', NULL, 1),
('Felsefe', NULL, 1),
('Matematik', NULL, 1),
('Geometri', NULL, 1),
('Fizik', NULL, 1),
('Kimya', NULL, 1),
('Biyoloji',NULL, 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(1, '1. Ünite: Sözcükte Anlam', 1),
(1, '2. Ünite: Cümlede Anlam', 1),
(1, '3. Ünite: Paragraf', 1),
(1, '4. Ünite: Ses Bilgisi', 1),
(1, '5. Ünite: Yazım Kuralları', 1),
(1, '6. Ünite: Noktalama İşaretleri', 1),
(1, '7. Ünite: Sözcükte Yapı', 1),
(1, '8. Ünite: Sözcük Türleri', 1),
(1, '9. Ünite: Fiiller', 1),
(1, '10. Ünite: Cümlenin Ögeleri', 1),
(1, '11. Ünite: Cümle Türleri', 1),
(1, '12. Ünite: Anlatım Bozukluğu', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(2, '1. Ünite: Tarih ve Zaman', 1),
(2, '2. Ünite: İlk ve Orta Çağlarda Türk Dünyası', 1),
(2, '3. Ünite: İslam Medeniyetinin Doğuşu ve İlk İslam Devletleri', 1),
(2, '4. Ünite: Türklerin İslamiyet’i Kabulü ve İlk Türk İslam Devletleri', 1),
(2, '5. Ünite: Beylikten Devlete Osmanlı', 1),
(2, '6. Ünite: Dünya Gücü Osmanlı', 1),
(2, '7. Ünite: Değişim Çağında Avrupa ve Osmanlı', 1),
(2, '8. Ünite: Uluslararası İlişkilerde Denge Stratejisi (1774-1914)', 1),
(2, '9. Ünite: XX. Yüzyıl Başlarında Osmanlı Devleti ve Dünya', 1),
(2, '10. Ünite: Milli Mücadele', 1),
(2, '11. Ünite: Atatürkçülük ve Türk İnkılabı', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(3, '1. Ünite: Doğa ve İnsan', 1),
(3, '2. Ünite: Dünya’nın Şekli ve Hareketleri', 1),
(3, '3. Ünite: Coğrafi Konum', 1),
(3, '4. Ünite: Harita Bilgisi', 1),
(3, '5. Ünite: İklim Bilgisi', 1),
(3, '6. Ünite: İç ve Dış Kuvvetler', 1),
(3, '7. Ünite: Nüfus ve Yerleşme', 1),
(3, '8. Ünite: Türkiye’nin Yer Şekilleri', 1),
(3, '9. Ünite: Ekonomik Faaliyetler', 1),
(3, '10. Ünite: Bölgeler', 1),
(3, '11. Ünite: Uluslararası Ulaşım Hatları', 1),
(3, '12. Ünite: Doğal Afetler', 1);


INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(4, '1. Ünite: Bilgi ve İnanç', 1),
(4, '2. Ünite: Din ve İslam', 1),
(4, '3. Ünite: İslam ve İbadet', 1),
(4, '4. Ünite: Gençlik ve Değerler', 1),
(4, '5. Ünite: Allah İnsan İlişkisi', 1),
(4, '6. Ünite: Hz. Muhammed (S.A.V)', 1),
(4, '7. Ünite: Vahiy ve Akıl', 1),
(4, '8. Ünite: İslam Düşüncesinde İtikadi, Siyasi ve Fıkhi Yorumlar', 1),
(4, '9. Ünite: Din, Kültür ve Medeniyet', 1);


INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(5, '1. Ünite: Felsefe’nin Konusu', 1),
(5, '2. Ünite: Bilgi Felsefesi', 1),
(5, '3. Ünite: Bilim Felsefesi', 1),
(5, '4. Ünite: Varlık Felsefesi', 1),
(5, '5. Ünite: Ahlak Felsefesi', 1),
(5, '6. Ünite: Siyaset Felsefesi', 1),
(5, '7. Ünite: Din Felsefesi', 1),
(5, '8. Ünite: Sanat Felsefesi', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(6, '1. Ünite: Temel Kavramlar', 1),
(6, '2. Ünite: Sayı Basamakları', 1),
(6, '3. Ünite: Bölünebilme Kuralları', 1),
(6, '4. Ünite: EBOB – EKOK', 1),
(6, '5. Ünite: Rasyonel Sayılar', 1),
(6, '6. Ünite: Basit Eşitsizlikler', 1),
(6, '7. Ünite: Mutlak Değer', 1),
(6, '8. Ünite: Üslü Sayılar', 1),
(6, '9. Ünite: Köklü Sayılar', 1),
(6, '10. Ünite: Çarpanlara Ayırma', 1),
(6, '11. Ünite: Oran Orantı', 1),
(6, '12. Ünite: Denklem Çözme', 1),
(6, '13. Ünite: Problemler', 1),
(6, '14. ünite: Kümeler', 1),
(6, '15. ünite: Mantık', 1),
(6, '16. ünite: Fonskiyonlar', 1),
(6, '17. ünite: Polinomlar', 1),
(6, '18. ünite: Permütasyon-Kombinasyon', 1),
(6, '19. ünite: Olasılık', 1),
(6, '20. ünite: Veri – İstatistik', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(7, '1. Ünite: Açılar ve Üçgenler', 1),
(7, '2. Ünite: Çokgenler', 1),
(7, '3. Ünite: Yamuk', 1),
(7, '4. Ünite: Eşkenar Dörtgen', 1),
(7, '5. Ünite: Deltoid', 1),
(7, '6. Ünite: Kare', 1),
(7, '7. Ünite: Dikdörtgen', 1),
(7, '8. Ünite: Çember ve Daire', 1),
(7, '9. Ünite: Analitik Geometri', 1),
(7, '10. Ünite: Katı Cisimler', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(8, '1. Ünite: Fizik Bilimine Giriş', 1),
(8, '2. Ünite: Madde Ve Özellikleri', 1),
(8, '3. Ünite: Kuvvet ve Hareket', 1),
(8, '4. Ünite: İş, Güç ve  Enerji', 1),
(8, '5. Ünite: Isı, Sıcaklık ve Genleşme', 1),
(8, '6. Ünite: Elektrostatik', 1),
(8, '7. Ünite: Elektrik ve Manyetizma', 1),
(8, '8. Ünite: Basınç', 1),
(8, '9. Ünite: Kaldırma Kuvveti', 1),
(8, '10. Ünite: Dalgalar', 1),
(8, '11. Ünite: Optik', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(9, '1. Ünite: Kimya Bilimi', 1),
(9, '2. Ünite: Atomun Yapısı', 1),
(9, '3. Ünite: Periyodik Tablo', 1),
(9, '4. Ünite: Maddenin Halleri', 1),
(9, '5. Ünite: Kimyasal Türler Arası Etkileşimler', 1),
(9, '6. Ünite: Kimyasal Hesaplamalar', 1),
(9, '7. Ünite: Kimyanın Temel Kanunları', 1),
(9, '8. Ünite: Asit, Baz ve Tuz', 1),
(9, '9. Ünite: Karışımlar', 1),
(9, '10. Ünite: Kimya Her Yerde', 1);

INSERT INTO Konular (DersID	, KonuAdi, TYT_mi) VALUES
(10, '1. Ünite: Canlıların Ortak Özellikleri', 1),
(10, '2. Ünite: Canlıların Temel Bileşenleri', 1),
(10, '3. Ünite: Hücre ve Organelleri', 1),
(10, '4. Ünite: Madde Geçişleri', 1),
(10, '5. Ünite: Canlıların Sınıflandırılması', 1),
(10, '6. Ünite: Hücre Bölünmeleri ve Üreme', 1),
(10, '7. Ünite: Kalıtım', 1),
(10, '8. Ünite: Ekosistem Ekoloji', 1),
(10, '9. Ünite: Bitkiler Biyolojisi', 1);

INSERT INTO Denemeler (OgrenciID, Tarih, MatDogru, MatYanlis, MatNet, FenDogru, FenYanlis, FenNet, TurkceDogru, TurkceYanlis, TurkceNet, SosyalDogru, SosyalYanlis, SosyalNet)
VALUES
(1, '2025-03-22', 25, 5, 20, 15, 10, 12.5, 30, 2, 28, 18, 4, 16),
(2, '2025-03-23', 20, 10, 15, 18, 7, 14, 28, 5, 24, 22, 2, 18);

ALTER TABLE Duyurular
ADD COLUMN HedefRol ENUM('Ogrenci', 'Ogretmen') NOT NULL DEFAULT 'Ogrenci';