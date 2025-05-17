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
    public partial class OgrenciDersProgramiForm : Form
    {
        private string ogrenciID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");
        public OgrenciDersProgramiForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;
        }

        private async void OgrenciDersProgramiForm_Load(object sender, EventArgs e)
        {
            // ComboBox’a haftaiçi günleri ekle
            cmbGunler.Items.AddRange(new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" });
            cmbGunler.SelectedIndex = 0; // Varsayılan Pazartesi
            // Sabit teneffüsleri ayarla
            txtTeneffus1.Text = "Teneffüs";
            txtTeneffusUzun.Text = "Uzun Teneffüs";
            txtTeneffus2.Text = "Teneffüs";
            await YukleDersProgramiAsync();
        }

        private async Task YukleDersProgramiAsync()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                        SELECT dp.Gun, dp.Saat, d.DersAdi
                        FROM DersProgrami dp
                        INNER JOIN Dersler d ON dp.DersID = d.DersID
                        WHERE dp.OgrenciID = @ogrenciID AND dp.Gun = @gun
                        ORDER BY dp.Saat";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        cmd.Parameters.AddWithValue("@gun", cmbGunler.SelectedItem?.ToString());
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            // TextBox’ları temizle
                            TemizleDersTextBoxlari();
                            bool hasRecords = false;
                            List<string> bulunanDersler = new List<string>(); // Hata ayıklamak için
                            while (await reader.ReadAsync())
                            {
                                hasRecords = true;
                                string saat = reader["Saat"].ToString().Trim();
                                string dersAdi = reader["DersAdi"].ToString();
                                bulunanDersler.Add($"Saat: {saat}, Ders: {dersAdi}");
                                EsleştirSaatVeDers(saat, dersAdi);
                            }
                            if (!hasRecords)
                            {
                                MessageBox.Show($"Seçilen gün ({cmbGunler.SelectedItem}) için ders programı bulunamadı.",
                                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (bulunanDersler.Count > 0 && !TextBoxDoluMu())
                            {
                                // Veri var ama TextBox’lar boşsa, format sorununu bildir
                                MessageBox.Show($"Veri bulundu ({string.Join("; ", bulunanDersler)}), ancak saat formatı uyuşmuyor. " +
                                    "Lütfen veritabanındaki saat formatını kontrol edin.",
                                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ders programı yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                TemizleDersTextBoxlari();
            }
        }
        private bool TextBoxDoluMu()
        {
            return txtDers1.Text != "-" || txtDers2.Text != "-" || txtDers3.Text != "-" ||
                   txtDers4.Text != "-" || txtDers5.Text != "-" || txtDers6.Text != "-" ||
                   txtDers7.Text != "-" || txtDers8.Text != "-";
        }

        private void TemizleDersTextBoxlari()
        {
            txtDers1.Text = "-";
            txtDers2.Text = "-";
            txtDers3.Text = "-";
            txtDers4.Text = "-";
            txtDers5.Text = "-";
            txtDers6.Text = "-";
            txtDers7.Text = "-";
            txtDers8.Text = "-";
        }

        private void EsleştirSaatVeDers(string saat, string dersAdi)
        {
            // Saat formatını temizle ve standardize et
            saat = saat.Trim();
            if (saat.Length > 5) // Örneğin, "14:10:00" → "14:10"
                saat = saat.Substring(0, 5);
            saat = saat.Replace(".", ":"); // "14.10" → "14:10"

            switch (saat)
            {
                case "09:00":
                    txtDers1.Text = dersAdi;
                    break;
                case "09:40":
                    txtDers2.Text = dersAdi;
                    break;
                case "10:30":
                    txtDers3.Text = dersAdi;
                    break;
                case "11:20":
                    txtDers4.Text = dersAdi;
                    break;
                case "12:40":
                    txtDers5.Text = dersAdi;
                    break;
                case "13:20":
                    txtDers6.Text = dersAdi;
                    break;
                case "14:10":
                    txtDers7.Text = dersAdi;
                    break;
                case "14:50":
                    txtDers8.Text = dersAdi;
                    break;
                default:
                    // Bilinmeyen saat formatı için hata ayıklamaya yardımcı olur
                    System.Diagnostics.Debug.WriteLine($"Bilinmeyen saat formatı: {saat}");
                    break;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await YukleDersProgramiAsync();
            MessageBox.Show("Ders programı yenilendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void cmbGunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGunler.SelectedItem != null)
            {
                await YukleDersProgramiAsync();
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
            OgrenciDevamsizlikForm devamsizliklarForm = new OgrenciDevamsizlikForm(ogrenciID);
            devamsizliklarForm.Show();
            this.Hide();
        }

        private void dersProgramımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten Ders Programı sayfasında'sınız. Lütfen başka bir seçeneğe tıklayın!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
