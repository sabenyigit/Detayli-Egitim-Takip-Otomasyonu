using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgretmenMesajlasmaForm : Form
    {
        private string ogretmenID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");
        public OgretmenMesajlasmaForm(string ogretmenID)
        {
            InitializeComponent();
            this.ogretmenID = ogretmenID;
        }

        private void OgretmenMesajlasmaForm_Load(object sender, EventArgs e)
        {
            OgrencileriYukle();
        }

        private void OgrencileriYukle()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT OgrenciID, Adi, Soyadi, Email FROM Ogrenciler", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                cmbOgrenciler.Items.Clear();

                while (reader.Read())
                {
                    string ogrenciID = reader["OgrenciID"].ToString();
                    string adSoyad = $"{reader["Adi"]} {reader["Soyadi"]}";
                    string email = reader["Email"]?.ToString();
                    cmbOgrenciler.Items.Add(new Ogrenci(ogrenciID, adSoyad, email));
                }
                reader.Close();

                if (cmbOgrenciler.Items.Count > 0)
                    cmbOgrenciler.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenciler yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cmbOgrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgrenciler.SelectedItem is Ogrenci secilenOgrenci)
            {
                txtEposta.Text = secilenOgrenci.Email ?? "E-posta tanımlı değil";
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMesaj.Text))
            {
                MessageBox.Show("Lütfen bir mesaj yazın!");
                return;
            }

            if (cmbOgrenciler.SelectedItem is Ogrenci secilenOgrenci)
            {
                try
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO Mesajlar (GonderenID, AliciID, MesajIcerik) " +
                        "VALUES (@gonderenID, @aliciID, @mesajIcerik)", conn);
                    cmd.Parameters.AddWithValue("@gonderenID", ogretmenID);
                    cmd.Parameters.AddWithValue("@aliciID", secilenOgrenci.OgrenciID);
                    cmd.Parameters.AddWithValue("@mesajIcerik", txtMesaj.Text);
                    cmd.ExecuteNonQuery();

                    txtMesaj.Clear();
                    MessageBox.Show("Mesaj gönderildi!");
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


        private void MesajlariYukle(string ogrenciID)
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT m.MesajIcerik, m.GonderimTarihi, o.Adi, o.Soyadi, o.Email " +
                    "FROM Mesajlar m " +
                    "INNER JOIN Ogrenciler o ON m.GonderenID = o.OgrenciID " +
                    "WHERE m.GonderenID = @ogrenciID AND m.AliciID = @ogretmenID " +
                    "ORDER BY m.GonderimTarihi", conn);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                cmd.Parameters.AddWithValue("@ogretmenID", ogretmenID);
                MySqlDataReader reader = cmd.ExecuteReader();
                lstMesajlar.Items.Clear();

                if (!reader.HasRows)
                {
                    lstMesajlar.Items.Add("Bu öğrenciden mesaj yok.");
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

        class Ogrenci
        {
            public string OgrenciID { get; }
            public string AdSoyad { get; }
            public string Email { get; }

            public Ogrenci(string ogrenciID, string adSoyad, string email)
            {
                OgrenciID = ogrenciID;
                AdSoyad = adSoyad;
                Email = email;
            }

            public override string ToString()
            {
                return AdSoyad;
            }
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOgrenciler.SelectedItem is Ogrenci secilenOgrenci)
            {
                MesajlariYukle(secilenOgrenci.OgrenciID);
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci seçin!");
            }
        }
    }
    
}
