using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class AdminGirisFormu : Form
    {
        public AdminGirisFormu()
        {
            InitializeComponent();
        }

        private void AdminGirisFormu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // Veritabanı bağlantısı
            string connStr = "Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Kullanıcı adı ve şifreyi kontrol et
                    string query = "SELECT * FROM Adminler WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@Sifre", sifre);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Admin giriş başarılı
                            MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Admin paneline yönlendir
                            this.Hide();
                            AdminPaneliFormu adminPaneli = new AdminPaneliFormu();
                            adminPaneli.Show();
                        }
                        else
                        {
                            // Hatalı kullanıcı adı veya şifre
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    
}
