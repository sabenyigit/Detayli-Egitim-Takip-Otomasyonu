using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class velibilgi : Form
    {
        private string connString = "Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;";
        private string guvenlikKodu = "";
        private string ogrenciID = "";

        public velibilgi()
        {
            InitializeComponent();
            GuvenlikKoduOlustur();

            // Başlangıçta tabloları gizle
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void GuvenlikKoduOlustur()
        {
            Random rnd = new Random();
            string karakterler = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            guvenlikKodu = "";

            for (int i = 0; i < 5; i++)
            {
                guvenlikKodu += karakterler[rnd.Next(karakterler.Length)];
            }

            // Bitmap ile güvenlik kodunu oluştur
            Bitmap bmp = new Bitmap(150, 50);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Font font = new Font("Arial", 24, FontStyle.Bold);
            g.DrawString(guvenlikKodu, font, Brushes.Black, new PointF(10, 10));
            picGuvenlikKodu.Image = bmp;
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (txtGuvenlikKodu.Text.ToUpper() != guvenlikKodu)
            {
                MessageBox.Show("Güvenlik kodu yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuvenlikKoduOlustur();
                txtGuvenlikKodu.Clear();
                return;
            }

            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Öğrenci numarası boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Öğrenci ve veli bilgilerini alıyoruz
                    string query = @"
                        SELECT 
                            o.OgrenciID, 
                            o.Adi as OgrenciAdi, 
                            o.Soyadi as OgrenciSoyadi,
                            'Yiğit Türkkan' as VeliAdSoyad  -- Veli adını statik olarak ekliyoruz
                        FROM Ogrenciler o 
                        WHERE o.KullaniciAdi = @kadi";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ogrenciID = reader["OgrenciID"].ToString();
                                string ogrenciAdi = reader["OgrenciAdi"].ToString();
                                string ogrenciSoyadi = reader["OgrenciSoyadi"].ToString();
                                string veliAdSoyad = reader["VeliAdSoyad"].ToString();

                                // Hoşgeldiniz mesajını güncelle - yan yana yazacak şekilde
                                lblHosgeldiniz.Text = $"Hoşgeldiniz - {ogrenciAdi} {ogrenciSoyadi} Velisi - {veliAdSoyad}";
                                lblHosgeldiniz.AutoSize = true; // Metnin tamamının görünmesi için
                                
                                // Giriş panelini gizle
                                pnlGiris.Height = 60; // Sadece hoşgeldiniz mesajı görünsün
                                
                                // Tabloları göster
                                panel1.Visible = true;
                                panel2.Visible = true;
                                
                                // Verileri yükle
                                LoadOgrenciData();
                                LoadSinavlar();
                            }
                            else
                            {
                                MessageBox.Show("Öğrenci bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                GuvenlikKoduOlustur();
                                txtGuvenlikKodu.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picGuvenlikKodu_Click(object sender, EventArgs e)
        {
            GuvenlikKoduOlustur();
        }

        private void LoadOgrenciData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CONCAT(o.Adi, ' ', o.Soyadi) as 'Öğrenci',
                            n.Ders as 'Ders',
                            n.Not1 as 'Not 1',
                            n.Not2 as 'Not 2',
                            n.Performans1 as 'Performans 1',
                            n.Performans2 as 'Performans 2',
                            (SELECT COUNT(*) FROM Devamsizliklar d 
                             WHERE d.OgrenciID = o.OgrenciID 
                             AND d.Ders = n.Ders) as 'Devamsızlık Sayısı'
                        FROM Ogrenciler o
                        LEFT JOIN Notlar n ON o.OgrenciID = n.OgrenciID
                        WHERE o.OgrenciID = @OgrenciID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OgrenciID", ogrenciID);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvNotlar.DataSource = dt;

                            if (dgvNotlar.Columns.Count > 0)
                            {
                                foreach (DataGridViewColumn col in dgvNotlar.Columns)
                                {
                                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void LoadSinavlar()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            DersAdi as 'Ders',
                            SinavTarihi as 'Sınav Tarihi',
                            (SELECT CONCAT(Adi, ' ', Soyadi) FROM Ogretmenler WHERE OgretmenID = s.OgretmenID) as 'Öğretmen'
                        FROM Sinavlar s
                        ORDER BY SinavTarihi";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvSinavTakvimi.DataSource = dt;

                            if (dgvSinavTakvimi.Columns.Count > 0)
                            {
                                foreach (DataGridViewColumn col in dgvSinavTakvimi.Columns)
                                {
                                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sınav takvimi yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Form1 anaGirisEkrani = new Form1();
            anaGirisEkrani.Show();
            this.Hide(); // Mevcut formu gizle
        }
    }
}
