using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace itim_Takip_Otomasyonu
{
    public partial class AdminPaneliFormu : Form
    {
        public AdminPaneliFormu()
        {
            InitializeComponent();
            GunleriDoldur();
            SaatleriDoldur();
            DersleriDoldur();
            OgrencileriDoldur();
            OgrencileriListBoxaDoldur();
            SinavDersleriniDoldur();
        }

        private async void SinavDersleriniDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT DersAdi FROM Dersler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            cmbSinavDers.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                cmbSinavDers.Items.Add(reader["DersAdi"].ToString());
                            }
                            if (cmbSinavDers.Items.Count > 0)
                                cmbSinavDers.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınav dersleri yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async void OgrencileriDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT OgrenciID, CONCAT(Adi, ' ', Soyadi) as TamAd FROM Ogrenciler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cmbOgrenci.DataSource = dt;
                            cmbOgrenci.DisplayMember = "TamAd";
                            cmbOgrenci.ValueMember = "OgrenciID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async void OgrencileriListBoxaDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT OgrenciID, CONCAT(Adi, ' ', Soyadi) as TamAd FROM Ogrenciler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            lstOgrenciler.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                lstOgrenciler.Items.Add(new { OgrenciID = reader["OgrenciID"].ToString(), TamAd = reader["TamAd"].ToString() });
                            }
                            lstOgrenciler.DisplayMember = "TamAd";
                            lstOgrenciler.ValueMember = "OgrenciID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private void cmbSinavDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinavDers.SelectedItem != null)
            {
                DersinOgretmenleriniDoldur(cmbSinavDers.SelectedItem.ToString());
            }
        }

        private void DersinOgretmenleriniDoldur(string dersAdi)
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT OgretmenID, CONCAT(Adi, ' ', Soyadi) as TamAd 
                                   FROM Ogretmenler 
                                   WHERE Brans = @dersAdi";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@dersAdi", dersAdi);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbSinavOgretmen.Items.Clear();
                            while (reader.Read())
                            {
                                cmbSinavOgretmen.Items.Add(new 
                                { 
                                    OgretmenID = reader["OgretmenID"].ToString(),
                                    TamAd = reader["TamAd"].ToString()
                                });
                            }
                            cmbSinavOgretmen.DisplayMember = "TamAd";
                            cmbSinavOgretmen.ValueMember = "OgretmenID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğretmenler yüklenemedi: {ex.Message}");
            }
        }

        private void btnSinavEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSinavDers.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir ders seçin!");
                    return;
                }

                if (cmbSinavOgretmen.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir öğretmen seçin!");
                    return;
                }

                var secilenOgretmen = (dynamic)cmbSinavOgretmen.SelectedItem;

                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Sinavlar (DersAdi, SinavTarihi, SinavSaati, OgretmenID) 
                                   VALUES (@ders, @tarih, @saat, @ogretmenID)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ders", cmbSinavDers.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tarih", dtpSinavTarih.Value.Date);
                        cmd.Parameters.AddWithValue("@saat", dtpSinavSaat.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@ogretmenID", secilenOgretmen.OgretmenID);
                        cmd.ExecuteNonQuery();
                    }
                }
                ListeleSinavlar();
                MessageBox.Show("Sınav başarıyla eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void ListeleSinavlar()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                          s.SinavID as 'Sınav ID',
                                          s.DersAdi as 'Ders',
                                          DATE_FORMAT(s.SinavTarihi, '%d.%m.%Y') as 'Tarih',
                                          TIME_FORMAT(s.SinavSaati, '%H:%i') as 'Saat',
                                          CONCAT(o.Adi, ' ', o.Soyadi) as 'Öğretmen'
                                   FROM Sinavlar s
                                   LEFT JOIN Ogretmenler o ON s.OgretmenID = o.OgretmenID
                                   ORDER BY s.SinavTarihi, s.SinavSaati";
                    using (var da = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListe.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınavlar listelenirken hata oluştu: {ex.Message}");
            }
        }

        private void btnSinavSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir sınav seçin!");
                    return;
                }

                var selectedRow = dgvListe.SelectedRows[0];
                if (selectedRow.Cells["Sınav ID"].Value == null)
                {
                    MessageBox.Show("Seçili sınavın ID'si bulunamadı!");
                    return;
                }

                string sinavID = selectedRow.Cells["Sınav ID"].Value.ToString();
                
                DialogResult result = MessageBox.Show(
                    $"Seçili sınavı silmek istediğinizden emin misiniz?\nDers: {selectedRow.Cells["Ders"].Value}\nTarih: {selectedRow.Cells["Tarih"].Value}\nSaat: {selectedRow.Cells["Saat"].Value}",
                    "Sınav Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Sinavlar WHERE SinavID = @sinavID";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@sinavID", sinavID);
                            int affectedRows = cmd.ExecuteNonQuery();
                            
                            if (affectedRows > 0)
                            {
                                ListeleSinavlar();
                                MessageBox.Show("Sınav başarıyla silindi!");
                            }
                            else
                            {
                                MessageBox.Show("Sınav silinirken bir hata oluştu. Hiçbir kayıt silinmedi.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınav silinirken hata oluştu:\n{ex.Message}");
            }
        }
    }
}