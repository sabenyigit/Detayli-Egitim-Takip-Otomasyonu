using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciDevamsizlikForm : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");
        private string ogrenciID;
        public OgrenciDevamsizlikForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await YukleDevamsizliklarAsync();
            MessageBox.Show("Devamsızlıklar yenilendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void OgrenciDevamsizlikForm_Load(object sender, EventArgs e)
        {
            dtpTarih.MaxDate = DateTime.Today; // İleri tarih seçilemesin
            dtpTarih.Value = DateTime.Today; // Varsayılan olarak bugünü seç
            await YukleDevamsizliklarAsync();
        }

        private async Task YukleDevamsizliklarAsync()
        {
            lstDevamsizliklar.Items.Clear(); // Liste her zaman temizlensin
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                        SELECT Ders, Tarih, DersSaati
                        FROM Devamsizliklar
                        WHERE OgrenciID = @ogrenciID AND DATE(Tarih) = @tarih";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        cmd.Parameters.AddWithValue("@tarih", dtpTarih.Value.Date);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            bool hasRecords = false;
                            while (await reader.ReadAsync())
                            {
                                hasRecords = true;
                                string ders = reader["Ders"].ToString();
                                DateTime tarih = Convert.ToDateTime(reader["Tarih"]);
                                int dersSaati = Convert.ToInt32(reader["DersSaati"]);
                                lstDevamsizliklar.Items.Add(new DevamsizlikItem
                                {
                                    Ders = ders,
                                    Tarih = tarih,
                                    DersSaati = dersSaati
                                });
                            }
                            if (!hasRecords)
                            {
                                lstDevamsizliklar.Items.Add("Seçilen tarihte devamsızlık yok.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Devamsızlıklar yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                lstDevamsizliklar.Items.Clear();
                lstDevamsizliklar.Items.Add("Hata oluştu, lütfen tekrar deneyin.");
            }
        }

        // Devamsızlık bilgilerini tutmak için yardımcı sınıf
        private class DevamsizlikItem
        {
            public string Ders { get; set; }
            public DateTime Tarih { get; set; }
            public int DersSaati { get; set; }

            public override string ToString()
            {
                return $"{Ders} - {DersSaati} ders saati";
            }
        }

        private async void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            await YukleDevamsizliklarAsync();
        }

        private void lstDevamsizliklar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstDevamsizliklar_DoubleClick(object sender, EventArgs e)
        {
            if (lstDevamsizliklar.SelectedItem != null && lstDevamsizliklar.SelectedItem is DevamsizlikItem item)
            {
                string detay = $"Ders Adı: {item.Ders}\n" +
                               $"Tarih: {item.Tarih:dd.MM.yyyy}\n" +
                               $"Devamsızlık: {item.DersSaati} ders saati";
                MessageBox.Show(detay, "Devamsızlık Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
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
            MessageBox.Show("Zaten Devamsızlıklarım sayfasındasınız. Lütfen başka bir seçeneğe tıklayın!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void konularaGöreVideolarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void puanHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YKSPuanHesaplaForm puanHesaplaForm = new YKSPuanHesaplaForm();
            puanHesaplaForm.Show();
            this.Hide();
        }
    }
    
}
