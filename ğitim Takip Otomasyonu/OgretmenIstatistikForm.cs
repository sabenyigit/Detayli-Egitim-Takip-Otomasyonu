using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgretmenIstatistikForm : Form
    {
        private string ogretmenID;
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;");

        public OgretmenIstatistikForm(string ogretmenID)
        {
            InitializeComponent();
            this.ogretmenID = ogretmenID;
            this.Text = "Öğrenci İstatistikleri";
            this.Size = new Size(800, 600);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Panel oluşturma
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(10)
            };

            // Sınıf Seçimi ComboBox
            ComboBox cmbSiniflar = new ComboBox
            {
                Dock = DockStyle.Top,
                Margin = new Padding(5)
            };

            // DataGridView - Öğrenci Listesi
            DataGridView dgvOgrenciler = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Name = "dgvOgrenciler"
            };

            // İstatistik Panelleri
            GroupBox basariDurumuPanel = new GroupBox
            {
                Text = "Başarı Durumu",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            GroupBox devamsizlikPanel = new GroupBox
            {
                Text = "Devamsızlık Durumu",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // Kontrolleri forma ekleme
            mainPanel.Controls.Add(cmbSiniflar, 0, 0);
            mainPanel.Controls.Add(dgvOgrenciler, 0, 1);
            mainPanel.Controls.Add(basariDurumuPanel, 1, 0);
            mainPanel.Controls.Add(devamsizlikPanel, 1, 1);

            this.Controls.Add(mainPanel);

            // Event handlers
            this.Load += OgretmenIstatistikForm_Load;
            cmbSiniflar.SelectedIndexChanged += CmbSiniflar_SelectedIndexChanged;
        }

        private async void OgretmenIstatistikForm_Load(object sender, EventArgs e)
        {
            try
            {
                await SiniflariYukleAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınıflar yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private async Task SiniflariYukleAsync()
        {
            ComboBox cmbSiniflar = Controls.Find("cmbSiniflar", true)[0] as ComboBox;
            if (cmbSiniflar == null) return;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT DISTINCT s.SinifID, s.SinifAdi " +
                    "FROM Siniflar s " +
                    "INNER JOIN OgretmenDersler od ON s.SinifID = od.SinifID " +
                    "WHERE od.OgretmenID = @ogretmenID", conn))
                {
                    cmd.Parameters.AddWithValue("@ogretmenID", ogretmenID);
                    
                    if (conn.State != ConnectionState.Open)
                        await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        cmbSiniflar.Items.Clear();
                        while (await reader.ReadAsync())
                        {
                            cmbSiniflar.Items.Add(new ComboBoxItem
                            {
                                Value = reader["SinifID"].ToString(),
                                Text = reader["SinifAdi"].ToString()
                            });
                        }
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    await conn.CloseAsync();
            }
        }

        private async void CmbSiniflar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbSiniflar = sender as ComboBox;
            if (cmbSiniflar?.SelectedItem == null) return;

            string sinifID = (cmbSiniflar.SelectedItem as ComboBoxItem)?.Value;
            if (string.IsNullOrEmpty(sinifID)) return;

            await OgrenciIstatistikleriniYukleAsync(sinifID);
        }

        private async Task OgrenciIstatistikleriniYukleAsync(string sinifID)
        {
            DataGridView dgvOgrenciler = Controls.Find("dgvOgrenciler", true)[0] as DataGridView;
            if (dgvOgrenciler == null) return;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT o.OgrenciID, o.Adi, o.Soyadi, " +
                    "(SELECT AVG(n.Not) FROM Notlar n WHERE n.OgrenciID = o.OgrenciID) as NotOrtalamasi, " +
                    "(SELECT COUNT(*) FROM Devamsizliklar d WHERE d.OgrenciID = o.OgrenciID) as DevamsizlikSayisi " +
                    "FROM Ogrenciler o " +
                    "WHERE o.SinifID = @sinifID", conn))
                {
                    cmd.Parameters.AddWithValue("@sinifID", sinifID);

                    if (conn.State != ConnectionState.Open)
                        await conn.OpenAsync();

                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    dgvOgrenciler.DataSource = dt;
                    dgvOgrenciler.Columns["OgrenciID"].Visible = false;
                    dgvOgrenciler.Columns["Adi"].HeaderText = "Adı";
                    dgvOgrenciler.Columns["Soyadi"].HeaderText = "Soyadı";
                    dgvOgrenciler.Columns["NotOrtalamasi"].HeaderText = "Not Ortalaması";
                    dgvOgrenciler.Columns["DevamsizlikSayisi"].HeaderText = "Devamsızlık Sayısı";
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    await conn.CloseAsync();
            }
        }
    }

    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
} 