using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciMesajlasmaForm : Form
    {
        private string ogrenciID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");

        public OgrenciMesajlasmaForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;
        }

        private void OgrenciMesajlasmaForm_Load(object sender, EventArgs e)
        {
            OgretmenleriYukle();
        }

        private void OgretmenleriYukle()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT OgretmenID, Adi, Soyadi, Email FROM Ogretmenler", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                cmbOgretmenler.Items.Clear();

                while (reader.Read())
                {
                    string ogretmenID = reader["OgretmenID"].ToString();
                    string adSoyad = $"{reader["Adi"]} {reader["Soyadi"]}";
                    string email = reader["Email"]?.ToString();
                    cmbOgretmenler.Items.Add(new Ogretmen(ogretmenID, adSoyad, email));
                }
                reader.Close();

                if (cmbOgretmenler.Items.Count > 0)
                    cmbOgretmenler.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğretmenler yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        private void cmbOgretmenler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgretmenler.SelectedItem is Ogretmen secilenOgretmen)
            {
                txtEposta.Text = secilenOgretmen.Email ?? "E-posta tanımlı değil";
            }
        }

        private void btnMesajlariListele_Click(object sender, EventArgs e)
        {
            if (cmbOgretmenler.SelectedItem is Ogretmen secilenOgretmen)
            {
                MesajlariYukle(secilenOgretmen.OgretmenID);
            }
            else
            {
                MessageBox.Show("Lütfen bir öğretmen seçin!");
            }
        }

        private void MesajlariYukle(string ogretmenID)
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT m.MesajIcerik, m.GonderimTarihi, o.Adi, o.Soyadi, o.Email " +
                    "FROM Mesajlar m " +
                    "INNER JOIN Ogretmenler o ON m.GonderenID = o.OgretmenID " +
                    "WHERE m.GonderenID = @ogretmenID AND m.AliciID = @ogrenciID " +
                    "ORDER BY m.GonderimTarihi", conn);
                cmd.Parameters.AddWithValue("@ogretmenID", ogretmenID);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                MySqlDataReader reader = cmd.ExecuteReader();
                lstMesajlar.Items.Clear();

                if (!reader.HasRows)
                {
                    lstMesajlar.Items.Add("Bu öğretmenden mesaj yok.");
                }
                else
                {
                    while (reader.Read())
                    {
                        string mesajKisa = reader["MesajIcerik"].ToString().Length > 20
                            ? reader["MesajIcerik"].ToString().Substring(0, 20) + "..."
                            : reader["MesajIcerik"].ToString();
                        string tarih = Convert.ToDateTime(reader["GonderimTarihi"]).ToString("dd.MM.yyyy HH:mm");
                        string adi = reader["Adi"].ToString();
                        string soyadi = reader["Soyadi"].ToString();
                        string email = reader["Email"]?.ToString();
                        lstMesajlar.Items.Add(new Mesaj(mesajKisa, reader["MesajIcerik"].ToString(), tarih, adi, soyadi, email));
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlar yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstMesajlar_DoubleClick(object sender, EventArgs e)
        {
            if (lstMesajlar.SelectedItem is Mesaj secilenMesaj)
            {
                MessageBox.Show($"Gönderen: {secilenMesaj.Adi} {secilenMesaj.Soyadi}\n" +
                                $"E-posta: {secilenMesaj.Email}\n" +
                                $"Mesaj İçeriği:\n\n{secilenMesaj.TamMesaj}\n\n" +
                                $"Gönderim Tarihi: {secilenMesaj.Tarih}");
            }
        }

        private void lstMesajlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bu metod şu an boş, gerekirse ek işlevsellik eklenebilir
        }

        // Ogretmen sınıfı
        class Ogretmen
        {
            public string OgretmenID { get; }
            public string AdSoyad { get; }
            public string Email { get; }

            public Ogretmen(string ogretmenID, string adSoyad, string email)
            {
                OgretmenID = ogretmenID;
                AdSoyad = adSoyad;
                Email = email;
            }

            public override string ToString()
            {
                return AdSoyad;
            }
        }

        // Mesaj sınıfı
        // Mesaj sınıfı (Gönderen bilgileri eklendi)
        class Mesaj
        {
            public string KisaMesaj { get; }
            public string TamMesaj { get; }
            public string Tarih { get; }
            public string Adi { get; }
            public string Soyadi { get; }
            public string Email { get; }

            public Mesaj(string kisaMesaj, string tamMesaj, string tarih, string adi, string soyadi, string email)
            {
                KisaMesaj = kisaMesaj;
                TamMesaj = tamMesaj;
                Tarih = tarih;
                Adi = adi;
                Soyadi = soyadi;
                Email = email;
            }

            public override string ToString()
            {
                return $"{Tarih} - {KisaMesaj}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMesaj.Text))
            {
                MessageBox.Show("Lütfen bir mesaj yazın!");
                return;
            }

            if (cmbOgretmenler.SelectedItem is Ogretmen secilenOgretmen)
            {
                try
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO Mesajlar (GonderenID, AliciID, MesajIcerik) " +
                        "VALUES (@gonderenID, @aliciID, @mesajIcerik)", conn);
                    cmd.Parameters.AddWithValue("@gonderenID", ogrenciID);
                    cmd.Parameters.AddWithValue("@aliciID", secilenOgretmen.OgretmenID);
                    cmd.Parameters.AddWithValue("@mesajIcerik", txtMesaj.Text);
                    cmd.ExecuteNonQuery();

                    txtMesaj.Clear();
                    MessageBox.Show("Mesaj seçtiğiniz hocaya gönderildi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mesaj gönderilirken hata oluştu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void anasayfaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OgrenciAnaEkran anaEkran = new OgrenciAnaEkran(ogrenciID);
            anaEkran.Show();
            this.Hide();
        }

        private void dersNotlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciNotlarForm dersNotlariForm = new OgrenciNotlarForm(ogrenciID);
            dersNotlariForm.Show();
            this.Hide();
        }

        private void devamsızlıklarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDevamsizlikForm devamsizliklarForm = new OgrenciDevamsizlikForm(ogrenciID);
            devamsizliklarForm.Show();
            this.Hide();
        }

        private void dersProgramımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersProgramiForm dersProgramiForm = new OgrenciDersProgramiForm(ogrenciID);
            dersProgramiForm.Show();
            this.Hide();
        }

        private void konularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciYksKonulariForm yksKonularForm = new OgrenciYksKonulariForm(ogrenciID);
            yksKonularForm.Show();
            this.Hide();
        }

        private void çıkmışSorularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciCikmisSorularForm cikmisSorularForm = new OgrenciCikmisSorularForm();
            cikmisSorularForm.Show();
            this.Hide();
        }

        private void denemelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDenemeSonuclariForm yksDenemelerForm = new OgrenciDenemeSonuclariForm(ogrenciID);
            yksDenemelerForm.Show();
            this.Hide();
        }

        private void puanHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YKSPuanHesaplaForm puanHesaplaForm = new YKSPuanHesaplaForm();
            puanHesaplaForm.Show();
            this.Hide();
        }

        private void özelNotlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciOzelNotlarForm ozelNotlarForm = new OgrenciOzelNotlarForm();
            ozelNotlarForm.Show();
            this.Hide();
        }

        private void mesajlaşmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciMesajlasmaForm mesajlasmaForm = new OgrenciMesajlasmaForm(ogrenciID);
            mesajlasmaForm.Show();
            this.Hide();
        }
    }
}