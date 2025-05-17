using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgretmenNotIslemleriFormu : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");
        private string ogretmenID;
        private string ogretmenBrans;
        public OgretmenNotIslemleriFormu(string ogretmenID)
        {
            InitializeComponent();
            this.ogretmenID = ogretmenID;
            OgretmenBilgileriniGetir();
            OgrencileriYukle();
        }

        private void OgretmenNotIslemleriFormu_Load(object sender, EventArgs e)
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
                ogretmenBrans = cmd.ExecuteScalar()?.ToString();
                if (string.IsNullOrEmpty(ogretmenBrans))
                {
                    MessageBox.Show("Öğretmen branşı bulunamadı!");
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

                cmbOgrenciSec.SelectedIndexChanged -= cmbOgrenciSec_SelectedIndexChanged;
                cmbOgrenciSec.DataSource = dt;
                cmbOgrenciSec.DisplayMember = "Adi";
                cmbOgrenciSec.ValueMember = "OgrenciID";
                cmbOgrenciSec.SelectedIndex = -1;
                cmbOgrenciSec.SelectedIndexChanged += cmbOgrenciSec_SelectedIndexChanged;
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
            if (cmbOgrenciSec.SelectedValue == null || string.IsNullOrEmpty(txtNot1.Text))
            {
                MessageBox.Show("Lütfen öğrenci seçin ve en az 1. notu girin!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                MySqlCommand checkCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Notlar WHERE OgrenciID = @ogrenciID AND Ders = @ders", conn);
                checkCmd.Parameters.AddWithValue("@ogrenciID", cmbOgrenciSec.SelectedValue);
                checkCmd.Parameters.AddWithValue("@ders", ogretmenBrans);
                int kayitSayisi = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (kayitSayisi == 0)
                {
                    MySqlCommand insertCmd = new MySqlCommand(
                        "INSERT INTO Notlar (OgrenciID, Ders, Not1, Not2, Performans1, Performans2) " +
                        "VALUES (@ogrenciID, @ders, @not1, @not2, @performans1, @performans2)", conn);
                    insertCmd.Parameters.AddWithValue("@ogrenciID", cmbOgrenciSec.SelectedValue);
                    insertCmd.Parameters.AddWithValue("@ders", ogretmenBrans);
                    insertCmd.Parameters.AddWithValue("@not1", string.IsNullOrEmpty(txtNot1.Text) ? (object)DBNull.Value : txtNot1.Text);
                    insertCmd.Parameters.AddWithValue("@not2", string.IsNullOrEmpty(txtNot2.Text) ? (object)DBNull.Value : txtNot2.Text);
                    insertCmd.Parameters.AddWithValue("@performans1", string.IsNullOrEmpty(txtPerformans1.Text) ? (object)DBNull.Value : txtPerformans1.Text);
                    insertCmd.Parameters.AddWithValue("@performans2", string.IsNullOrEmpty(txtPerformans2.Text) ? (object)DBNull.Value : txtPerformans2.Text);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Notlar başarıyla kaydedildi!");
                }
                else
                {
                    MessageBox.Show("Bu öğrencinin bu ders için zaten notları var. Güncellemek için 'Güncelle' butonunu kullanın.");
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

        private void btnGuncelle_Click(object sender, EventArgs e)
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
                    "UPDATE Notlar SET Not1 = @not1, Not2 = @not2, Performans1 = @performans1, Performans2 = @performans2 " +
                    "WHERE OgrenciID = @ogrenciID AND Ders = @ders", conn);
                cmd.Parameters.AddWithValue("@ogrenciID", cmbOgrenciSec.SelectedValue);
                cmd.Parameters.AddWithValue("@ders", ogretmenBrans);
                cmd.Parameters.AddWithValue("@not1", string.IsNullOrEmpty(txtNot1.Text) ? (object)DBNull.Value : txtNot1.Text);
                cmd.Parameters.AddWithValue("@not2", string.IsNullOrEmpty(txtNot2.Text) ? (object)DBNull.Value : txtNot2.Text);
                cmd.Parameters.AddWithValue("@performans1", string.IsNullOrEmpty(txtPerformans1.Text) ? (object)DBNull.Value : txtPerformans1.Text);
                cmd.Parameters.AddWithValue("@performans2", string.IsNullOrEmpty(txtPerformans2.Text) ? (object)DBNull.Value : txtPerformans2.Text);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Notlar başarıyla güncellendi!");
                }
                else
                {
                    MessageBox.Show("Güncellenecek not bulunamadı. Önce notları kaydedin!");
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

        private void cmbOgrenciSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgrenciSec.SelectedValue != null && cmbOgrenciSec.SelectedIndex != -1)
            {
                try
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT Not1, Not2, Performans1, Performans2 FROM Notlar " +
                        "WHERE OgrenciID = @ogrenciID AND Ders = @ders", conn);
                    cmd.Parameters.AddWithValue("@ogrenciID", cmbOgrenciSec.SelectedValue);
                    cmd.Parameters.AddWithValue("@ders", ogretmenBrans);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNot1.Text = reader["Not1"] != DBNull.Value ? reader["Not1"].ToString() : "";
                        txtNot2.Text = reader["Not2"] != DBNull.Value ? reader["Not2"].ToString() : "";
                        txtPerformans1.Text = reader["Performans1"] != DBNull.Value ? reader["Performans1"].ToString() : "";
                        txtPerformans2.Text = reader["Performans2"] != DBNull.Value ? reader["Performans2"].ToString() : "";
                        // Hata ayıklama için: Notların yüklendiğini doğrula
                        MessageBox.Show($"Notlar yüklendi: Not1 = {txtNot1.Text}", "Bilgi");
                    }
                    else
                    {
                        txtNot1.Text = "";
                        txtNot2.Text = "";
                        txtPerformans1.Text = "";
                        txtPerformans2.Text = "";
                        // Hata ayıklama için: Kayıt bulunmadığını bildir
                        MessageBox.Show("Bu öğrencinin bu ders için notu bulunamadı.", "Bilgi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Notlar yüklenemedi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
