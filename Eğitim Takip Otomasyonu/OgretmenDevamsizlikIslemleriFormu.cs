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
    public partial class OgretmenDevamsizlikIslemleriFormu : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");
        private string ogretmenID;
        private string ogretmenBrans;
        public OgretmenDevamsizlikIslemleriFormu(string ogretmenID)
        {
            InitializeComponent();
            this.ogretmenID = ogretmenID;
            OgretmenBilgileriniGetir();
            OgrencileriYukle();
        }

        private void OgretmenDevamsizlikIslemleriFormu_Load(object sender, EventArgs e)
        {

        }

        private void OgretmenBilgileriniGetir()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Brans FROM Ogretmenler WHERE OgretmenID = @ogretmenID", conn);
                cmd.Parameters.AddWithValue("@ogretmenID", ogretmenID);
                object result = cmd.ExecuteScalar();
                ogretmenBrans = result?.ToString();
                if (string.IsNullOrEmpty(ogretmenBrans))
                {
                    MessageBox.Show($"Öğretmen branşı bulunamadı! OgretmenID: {ogretmenID}, Sorgu sonucu: {result ?? "null"}");
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

        private void OgrencileriYukle()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT OgrenciID, Adi, Soyadi FROM Ogrenciler", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOgrenciSec.DataSource = dt;
                cmbOgrenciSec.DisplayMember = "Adi";
                cmbOgrenciSec.ValueMember = "OgrenciID";
                cmbOgrenciSec.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenciler yüklenemedi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbOgrenciSec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir öğrenci seçin!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Devamsizliklar (OgrenciID, Ders, Tarih, DersSaati) " +
                    "VALUES (@ogrenciID, @ders, @tarih, @dersSaati)", conn);
                cmd.Parameters.AddWithValue("@ogrenciID", cmbOgrenciSec.SelectedValue);
                cmd.Parameters.AddWithValue("@ders", ogretmenBrans);
                cmd.Parameters.AddWithValue("@tarih", dtpTarih.Value.Date);
                cmd.Parameters.AddWithValue("@dersSaati", nudDersSaati.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"{cmbOgrenciSec.Text} için {ogretmenBrans} dersinde " +
                                $"{dtpTarih.Value.ToShortDateString()} tarihinde {nudDersSaati.Value} ders saati devamsızlık kaydedildi!");
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
