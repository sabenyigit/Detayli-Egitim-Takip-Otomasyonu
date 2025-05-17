using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciAnaEkran : Form
    {
        private string ogrenciID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");
        private CheckBox chkTYTGoster;
        private CheckBox chkAYTGoster;

        public OgrenciAnaEkran(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;

            // TYT ve AYT Checkbox'larını oluştur
            chkTYTGoster = new CheckBox();
            chkTYTGoster.Text = "TYT İlerlemesini Göster";
            chkTYTGoster.Location = new System.Drawing.Point(20,  - 30);
            chkTYTGoster.AutoSize = true;
            chkTYTGoster.Checked = true;
            chkTYTGoster.CheckedChanged += new EventHandler(FilterCheckBox_CheckedChanged);

            chkAYTGoster = new CheckBox();
            chkAYTGoster.Text = "AYT İlerlemesini Göster";
            chkAYTGoster.Location = new System.Drawing.Point(+ 20, - 30);
            chkAYTGoster.AutoSize = true;
            chkAYTGoster.Checked = true;
            chkAYTGoster.CheckedChanged += new EventHandler(FilterCheckBox_CheckedChanged);

            // Form'a kontrolleri ekle
            this.Controls.Add(chkTYTGoster);
            this.Controls.Add(chkAYTGoster);
        }

        private List<string> motivasyonCumleleri = new List<string>
        {
            "Kazanma isteği ve başarıya ulaşma arzusu birleşirse kişisel mükemmelliğin kapısını açar. (Konfüçyüs)",
            "Hiçbir şeyden vazgeçme, çünkü sadece kaybedenler vazgeçer. (Abraham Lincoln)",
            "Başarıya çıkan asansör bozuk. Bekleyerek zaman kaybetmeyin, adım adım merdivenleri çıkmaya başlayın. (Joe Girard)",
            "Fırsatlar durup dururken karşınıza çıkmaz, onları siz yaratırsınız. (Chris Grosser)",
            "Şansa çok inanırım ve ne kadar çok çalıştıysam ona o kadar çok sahip oldum. (Thomas Jefferson)",
            "Bir şeye başlayıp başarısız olmaktan daha kötü tek şey hiçbir şeye başlamamaktır. (Seth Godin)",
            "Sadece sınırlarını aşmanın riskini alanlar ne kadar ileri gidebildiklerini görürler. (T.S. Elliot)",
            "Hayat her ne kadar zor görünse de, yapabileceğimiz ve başarabileceğimiz bir şey mutlaka vardır. (Stephen Hawking)",
            "Bir şeyi başarmak ne kadar zorsa, zaferin tadı o kadar güzeldir. (Pele)",
            "Hiç kimse başarı merdivenine elleri cebinde tırmanmamıştır. (J. Keth Moorhead)",
            "Ne zaman başarılı bir iş görseniz, birisi bir zamanlar mutlaka cesur bir karar almıştır. (Peter Ducker)",
            "Sessizce sıkı çalışın, bırakın başarı sesiniz olsun. (Frank Ocean)",
            "Eğer her şey kontrol altında gibi görünüyorsa, yeterince hızlı gitmiyorsunuzdur. (Mario Andretti)",
            "Sadece başarılı bir insan olmaya değil, değerli bir insan olmaya çalışın. (Albert Einstein)",
            "Başarı son değildir, başarısızlık ise ölümcül değildir: Önemli olan ilerlemeye cesaret etmektir. (Winston S. Churchill)",
            "Hayatımı sadece ben değiştirebilirim. Kimse benim için bunu yapmaz. (Carol Burnett)",
            "Hiç kimse geriye gidip yeni bir başlangıç yapamaz ama bugün yeni bir son yapıp yeniden başlayabilir. (Frank M. Robinson)"
        };

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            YukleBasariDurumuAsync().ConfigureAwait(false);
        }

        private async void OgrenciAnaEkran_Load(object sender, EventArgs e)
        {
            try
            {
                lblMerhaba.Text = "Hoşgeldin Öğrenci"; // Varsayılan
                await YukleKullaniciAdiAsync();

                // Rastgele motivasyon cümlesi
                Random rastgele = new Random();
                int index = rastgele.Next(motivasyonCumleleri.Count);
                lblMotivasyon.Text = motivasyonCumleleri[index];

                // Başarı durumunu yükle
                lblBasariDurumu.Text = "İlerleme durumu yükleniyor...";
                await YukleBasariDurumuAsync();

                // Duyuruları yükle
                await ListeleDuyurularAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ana ekran yüklenirken hata oluştu: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async Task YukleKullaniciAdiAsync()
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand cmd = new MySqlCommand("SELECT Adi, Soyadi FROM Ogrenciler WHERE OgrenciID = @id", conn);
                cmd.Parameters.AddWithValue("@id", ogrenciID);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string adi = reader["Adi"]?.ToString() ?? "Öğrenci";
                        string soyadi = reader["Soyadi"]?.ToString() ?? "";
                        lblMerhaba.Text = $"Hoşgeldin {adi} {soyadi}".Trim();
                    }
                    else
                    {
                        lblMerhaba.Text = "Hoşgeldin Öğrenci";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı adı yüklenirken hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                lblMerhaba.Text = "Hoşgeldin Öğrenci (Hocalarına haber vermeyi unutma! Sistemsel Sıkıntı Var!)";
            }
            finally
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
            }
        }

        private async Task YukleBasariDurumuAsync()
        {
            try
            {
                if (conn.State == ConnectionState.Open) await conn.CloseAsync();
                await conn.OpenAsync();

                string sorgu = @"
                    SELECT 
                        d.DersID, 
                        d.DersAdi,
                        (SELECT COUNT(*) FROM Konular k WHERE k.DersID = d.DersID AND k.TYT_mi = 1) AS ToplamTYTKonu,
                        (SELECT COUNT(*) FROM Konular k WHERE k.DersID = d.DersID AND k.AYT_mi = 1) AS ToplamAYTKonu,
                        (SELECT COUNT(*) 
                         FROM OgrenciKonular ok 
                         INNER JOIN Konular k ON ok.KonuID = k.KonuID 
                         WHERE k.DersID = d.DersID AND ok.OgrenciID = @ogrenciID AND ok.BittiMi = 1 AND k.TYT_mi = 1) AS TamamlananTYTKonu,
                        (SELECT COUNT(*) 
                         FROM OgrenciKonular ok 
                         INNER JOIN Konular k ON ok.KonuID = k.KonuID 
                         WHERE k.DersID = d.DersID AND ok.OgrenciID = @ogrenciID AND ok.BittiMi = 1 AND k.AYT_mi = 1) AS TamamlananAYTKonu
                    FROM Dersler d 
                    WHERE d.YKS_Dersi = 1 AND d.UstDersID IS NULL";

                MySqlCommand cmd = new MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                cmd.CommandTimeout = 60;

                StringBuilder basariMetni = new StringBuilder();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string dersAdi = reader["DersAdi"].ToString();
                        int toplamTYTKonu = Convert.ToInt32(reader["ToplamTYTKonu"]);
                        int tamamlananTYTKonu = Convert.ToInt32(reader["TamamlananTYTKonu"]);
                        int toplamAYTKonu = Convert.ToInt32(reader["ToplamAYTKonu"]);
                        int tamamlananAYTKonu = Convert.ToInt32(reader["TamamlananAYTKonu"]);

                        double tytyuzde = toplamTYTKonu > 0 ? (tamamlananTYTKonu * 100.0 / toplamTYTKonu) : 0;
                        double aytyuzde = toplamAYTKonu > 0 ? (tamamlananAYTKonu * 100.0 / toplamAYTKonu) : 0;

                        if (chkTYTGoster.Checked && toplamTYTKonu > 0)
                            basariMetni.AppendLine($"TYT {dersAdi}'de ilerleme durumunuz %{tytyuzde:0}");
                        if (chkAYTGoster.Checked && toplamAYTKonu > 0)
                            basariMetni.AppendLine($"AYT {dersAdi}'de ilerleme durumunuz %{aytyuzde:0}");
                    }
                }

                lblBasariDurumu.Text = basariMetni.Length > 0 ? basariMetni.ToString().TrimEnd() : "Henüz ilerleme durumu mevcut değil.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İlerleme durumu yüklenirken hata oluştu: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                lblBasariDurumu.Text = "İlerleme durumu yüklenemedi.";
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT Baslik, Icerik, YayimTarihi FROM Duyurular WHERE HedefRol = 'Ogrenci'", conn);
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

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciGiris ogrenciGirisForm = new OgrenciGiris(ogrenciID);
            ogrenciGirisForm.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten Anasayfa'dasınız. Lütfen başka bir seçeneğe tıklayın!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void yKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private async void btnDuyurularYenile_Click(object sender, EventArgs e)
        {
            await ListeleDuyurularAsync();
            MessageBox.Show("Duyurular yenilendi!");
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

        private void lblBasariDurumu_Click(object sender, EventArgs e)
        {
        }

        private void bugünküYapılacaklarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugunkuYapilacaklarForm frm = new BugunkuYapilacaklarForm(Convert.ToInt32(ogrenciID));
            frm.ShowDialog();
        }
    }
}