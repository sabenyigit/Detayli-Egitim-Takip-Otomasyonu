using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciGiris : Form
    {
        private string ogrenciID; // Öğrenci ID'sini saklamak için
        public OgrenciGiris(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID; // Öğrenci ID'sini alıp saklıyoruz
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // Veritabanı bağlantı stringi
            string connString = "Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;";

            // Veritabanı bağlantısı oluşturuluyor
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // SQL sorgusu ile kullanıcı adı ve şifreyi kontrol etme
                    string query = "SELECT * FROM Ogrenciler WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@Sifre", sifre);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Kullanıcı bulundu, giriş başarılı
                            MessageBox.Show("Giriş başarılı!");

                            // Öğrenci ID'sini alalım
                            reader.Read();
                            string ogrenciID = reader["OgrenciID"].ToString();

                            // Öğrenci ana ekranına yönlendirme
                            OgrenciAnaEkran ogrenciAnaEkran = new OgrenciAnaEkran(ogrenciID); // Parametreli yapıcı metot çağrısı
                            ogrenciAnaEkran.Show();
                            this.Hide(); // Giriş sayfasını gizliyoruz
                        }
                        else
                        {
                            // Kullanıcı adı veya şifre yanlış
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya mesaj gösteriyoruz
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OgrenciGiris_Load(object sender, EventArgs e)
        {
            // Yükleme işlemleri burada yapılabilir
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı tamamen kapat
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anaGirisEkrani = new Form1();
            anaGirisEkrani.Show();
            this.Hide(); // Mevcut formu gizle
        }
    }
}
