using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgretmenAnaEkran : Form
    {
        private string ogretmenID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");
        public OgretmenAnaEkran(string ogretmenID) // Yapıcı metod güncellendi
        {
            InitializeComponent();
            this.ogretmenID = ogretmenID;
        }

        private async void OgretmenAnaEkran_Load(object sender, EventArgs e)
        {
            try
            {
                await YukleOgretmenBilgileriAsync();
                await ListeleDuyurularAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ana ekran yüklenirken hata oluştu: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async Task YukleOgretmenBilgileriAsync()
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand cmd = new MySqlCommand("SELECT Adi FROM Ogretmenler WHERE OgretmenID = @id", conn);
                cmd.Parameters.AddWithValue("@id", ogretmenID);
                string ogretmenAdi = (await cmd.ExecuteScalarAsync())?.ToString() ?? "Öğretmen";
                lblMerhaba.Text = "Hoşgeldin " + ogretmenAdi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğretmen bilgileri yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                lblMerhaba.Text = "Hoşgeldin Öğretmen";
            }
            finally
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
            }
        }

        private async Task ListeleDuyurularAsync()
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT Baslik, Icerik, YayimTarihi FROM Duyurular WHERE HedefRol = 'Ogretmen'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDuyurular.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Duyurular yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
            }
        }

        private void notİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenNotIslemleriFormu dersNotlariForm = new OgretmenNotIslemleriFormu(ogretmenID); // Parametre eklendi
            dersNotlariForm.Show();
        }

        private void devamsızlıkİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ogretmenID))
            {
                MessageBox.Show("ogretmenID boş!", "Hata");
                return;
            }
            OgretmenDevamsizlikIslemleriFormu devamsizlikIslemleriFormu = new OgretmenDevamsizlikIslemleriFormu(ogretmenID);
            devamsizlikIslemleriFormu.Show();
        }

        private void mesajlaşmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenMesajlasmaForm mesajForm = new OgretmenMesajlasmaForm(ogretmenID); // Parametre eklendi
            mesajForm.Show();
        }

        private void dgvDuyurular_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string baslik = dgvDuyurular.Rows[e.RowIndex].Cells["Baslik"].Value.ToString();
                string icerik = dgvDuyurular.Rows[e.RowIndex].Cells["Icerik"].Value.ToString();
                MessageBox.Show($"Başlık: {baslik}\nİçerik: {icerik}", "Duyuru Detayı");
            }
        }

        private void btnDuyurularYenile_Click(object sender, EventArgs e)
        {

        }
    }
}
