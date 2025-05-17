using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgretmenGirisFormu : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");
        public OgretmenGirisFormu()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifreyi doldurun!");
                    return;
                }

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT OgretmenID FROM Ogretmenler WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre", conn);
                cmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string ogretmenID = result.ToString();
                    MessageBox.Show("Giriş başarılı!");
                    OgretmenAnaEkran anaEkran = new OgretmenAnaEkran(ogretmenID);
                    anaEkran.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
