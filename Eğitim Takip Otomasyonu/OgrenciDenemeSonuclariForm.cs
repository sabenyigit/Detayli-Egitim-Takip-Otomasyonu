using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciDenemeSonuclariForm : Form
    {
        private string ogrenciID;
        public OgrenciDenemeSonuclariForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;

        
        }

        private void btnSonucuKaydet_Click(object sender, EventArgs e)
        {
            int dogruMat = int.Parse(txtMatDogru.Text);
            int yanlisMat = int.Parse(txtMatYanlis.Text);

            int dogruFen = int.Parse(txtFenDogru.Text);
            int yanlisFen = int.Parse(txtFenYanlis.Text);

            int dogruTurkce = int.Parse(txtTurkceDogru.Text);
            int yanlisTurkce = int.Parse(txtTurkceYanlis.Text);

            int dogruSosyal = int.Parse(txtSosyalDogru.Text);
            int yanlisSosyal = int.Parse(txtSosyalYanlis.Text);

            double netMat = dogruMat - (yanlisMat / 4.0);
            double netFen = dogruFen - (yanlisFen / 4.0);
            double netTurkce = dogruTurkce - (yanlisTurkce / 4.0);
            double netSosyal = dogruSosyal - (yanlisSosyal / 4.0);

            string dosyaAdi = $"deneme_sonuclari_{ogrenciID}.csv";  // Öğrenciye özel dosya adı

            string kayit = $"{DateTime.Now.ToShortDateString()};{dogruMat};{yanlisMat};{netMat};{dogruFen};{yanlisFen};{netFen};{dogruTurkce};{yanlisTurkce};{netTurkce};{dogruSosyal};{yanlisSosyal};{netSosyal}\n";

            File.AppendAllText(dosyaAdi, kayit);
            MessageBox.Show("Deneme sonucu kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Alanları temizle
            txtMatDogru.Clear();
            txtMatYanlis.Clear();
            txtFenDogru.Clear();
            txtFenYanlis.Clear();
            txtTurkceDogru.Clear();
            txtTurkceYanlis.Clear();
            txtSosyalDogru.Clear();
            txtSosyalYanlis.Clear();
        }

        private void btnGecmisDenemeleriGor_Click(object sender, EventArgs e)
        {
            string dosyaAdi = $"deneme_sonuclari_{ogrenciID}.csv";  // Öğrenciye özgü dosya adı

            if (File.Exists(dosyaAdi))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Tarih");
                dt.Columns.Add("Mat Doğru");
                dt.Columns.Add("Mat Yanlış");
                dt.Columns.Add("Mat Net");
                dt.Columns.Add("Fen Doğru");
                dt.Columns.Add("Fen Yanlış");
                dt.Columns.Add("Fen Net");
                dt.Columns.Add("Türkçe Doğru");
                dt.Columns.Add("Türkçe Yanlış");
                dt.Columns.Add("Türkçe Net");
                dt.Columns.Add("Sosyal Doğru");
                dt.Columns.Add("Sosyal Yanlış");
                dt.Columns.Add("Sosyal Net");

                // Dosya içeriğini okuma
                string[] satirlar = File.ReadAllLines(dosyaAdi);
                foreach (string satir in satirlar)
                {
                    string[] veriler = satir.Split(';');

                    int matDogru, matYanlis, fenDogru, fenYanlis, turkceDogru, turkceYanlis, sosyalDogru, sosyalYanlis;
                    double netMat, netFen, netTurkce, netSosyal;

                    if (int.TryParse(veriler[1], out matDogru) &&
                        int.TryParse(veriler[2], out matYanlis) &&
                        double.TryParse(veriler[3], out netMat) &&
                        int.TryParse(veriler[4], out fenDogru) &&
                        int.TryParse(veriler[5], out fenYanlis) &&
                        double.TryParse(veriler[6], out netFen) &&
                        int.TryParse(veriler[7], out turkceDogru) &&
                        int.TryParse(veriler[8], out turkceYanlis) &&
                        double.TryParse(veriler[9], out netTurkce) &&
                        int.TryParse(veriler[10], out sosyalDogru) &&
                        int.TryParse(veriler[11], out sosyalYanlis) &&
                        double.TryParse(veriler[12], out netSosyal))
                    {
                        dt.Rows.Add(veriler[0], matDogru, matYanlis, netMat, fenDogru, fenYanlis, netFen, turkceDogru, turkceYanlis, netTurkce, sosyalDogru, sosyalYanlis, netSosyal);
                    }
                }

                dgvGecmisDenemeler.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Henüz kayıtlı deneme sonucu yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void OgrenciDenemeSonuclariForm_Load(object sender, EventArgs e)
        {
            // Öğrenci ID'sine göre veritabanından deneme sonuçlarını alıyoruz
            string query = "SELECT * FROM Denemeler WHERE OgrenciID = @OgrenciID ORDER BY Tarih DESC"; // Tarih sırasına göre sonuçları alıyoruz

            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;"))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OgrenciID", this.ogrenciID);  // Öğrenci ID'sini parametre olarak ekliyoruz
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Veri okuma ve ekranda görüntüleme işlemi
                        while (reader.Read())
                        {
                            string denemeID = reader["DenemeID"].ToString();
                            DateTime tarih = Convert.ToDateTime(reader["Tarih"]);
                            int matDogru = Convert.ToInt32(reader["MatDogru"]);
                            int matYanlis = Convert.ToInt32(reader["MatYanlis"]);
                            float matNet = Convert.ToSingle(reader["MatNet"]);

                            int fenDogru = Convert.ToInt32(reader["FenDogru"]);
                            int fenYanlis = Convert.ToInt32(reader["FenYanlis"]);
                            float fenNet = Convert.ToSingle(reader["FenNet"]);

                            int turkceDogru = Convert.ToInt32(reader["TurkceDogru"]);
                            int turkceYanlis = Convert.ToInt32(reader["TurkceYanlis"]);
                            float turkceNet = Convert.ToSingle(reader["TurkceNet"]);

                            int sosyalDogru = Convert.ToInt32(reader["SosyalDogru"]);
                            int sosyalYanlis = Convert.ToInt32(reader["SosyalYanlis"]);
                            float sosyalNet = Convert.ToSingle(reader["SosyalNet"]);

                            // Deneme sonuçlarını ekranda gösterebilirsiniz (örneğin, DataGridView'e ekleyebilirsiniz)
                            // Örnek: DataGridView'e ekleme
                        }
                    }
                }
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
