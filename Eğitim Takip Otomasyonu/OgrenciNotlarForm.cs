using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciNotlarForm : Form
    {
        private string ogrenciID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");
        public OgrenciNotlarForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID; // Constructor’dan gelen ogrenciID’yi sınıf değişkenine ata
        }

        private async void OgrenciNotlarForm_Load(object sender, EventArgs e)
        {
            await YukleDerslerAsync();
        }

        private async Task YukleDerslerAsync()
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT DISTINCT Ders FROM Notlar WHERE OgrenciID = @ogrenciID", conn);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    cmbDersler.Items.Clear();
                    while (await reader.ReadAsync())
                    {
                        cmbDersler.Items.Add(reader["Ders"].ToString());
                    }
                }
                if (cmbDersler.Items.Count > 0)
                {
                    cmbDersler.SelectedIndex = 0; // İlk dersi seç
                    await YukleNotlarAsync(cmbDersler.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Hiçbir ders için not bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleTextBoxlar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dersler yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                TemizleTextBoxlar();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
            }
        }

        private void TemizleTextBoxlar()
        {
            txtNot1.Text = "-";
            txtNot2.Text = "-";
            txtPerformans1.Text = "-";
            txtPerformans2.Text = "-";
        }

        private async Task YukleNotlarAsync(string ders)
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT Not1, Not2, Performans1, Performans2 FROM Notlar WHERE OgrenciID = @ogrenciID AND Ders = @ders", conn);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                cmd.Parameters.AddWithValue("@ders", ders);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        txtNot1.Text = reader["Not1"] != DBNull.Value ? reader["Not1"].ToString() : "-";
                        txtNot2.Text = reader["Not2"] != DBNull.Value ? reader["Not2"].ToString() : "-";
                        txtPerformans1.Text = reader["Performans1"] != DBNull.Value ? reader["Performans1"].ToString() : "-";
                        txtPerformans2.Text = reader["Performans2"] != DBNull.Value ? reader["Performans2"].ToString() : "-";
                    }
                    else
                    {
                        MessageBox.Show($"Seçilen ders ({ders}) için not bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TemizleTextBoxlar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Notlar yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                TemizleTextBoxlar();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await YukleDerslerAsync();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciAnaEkran anaEkran = new OgrenciAnaEkran(ogrenciID);
            anaEkran.Show();
            this.Hide();
        }

        private void dersNotlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten Notlarım sayfasındasınız. Lütfen başka bir seçeneğe tıklayın!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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