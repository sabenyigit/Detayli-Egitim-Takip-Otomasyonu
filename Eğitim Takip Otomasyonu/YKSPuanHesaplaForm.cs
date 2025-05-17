using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class YKSPuanHesaplaForm : Form
    {
        private string ogrenciID;
        public YKSPuanHesaplaForm()
        {
            InitializeComponent();
        }

        private void btnPuanHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                int dogruTurkce = int.Parse(txtTurkceDogru.Text);
                int yanlisTurkce = int.Parse(txtTurkceYanlis.Text);
                int dogruMat = int.Parse(txtMatDogru.Text);
                int yanlisMat = int.Parse(txtMatYanlis.Text);
                int dogruFen = int.Parse(txtFenDogru.Text);
                int yanlisFen = int.Parse(txtFenYanlis.Text);
                int dogruSosyal = int.Parse(txtSosyalDogru.Text);
                int yanlisSosyal = int.Parse(txtSosyalYanlis.Text);

                double netTurkce = dogruTurkce - (yanlisTurkce / 4.0);
                double netMat = dogruMat - (yanlisMat / 4.0);
                double netFen = dogruFen - (yanlisFen / 4.0);
                double netSosyal = dogruSosyal - (yanlisSosyal / 4.0);

                double tytPuan = 100 + (netTurkce * 3.3) + (netMat * 3.5) + (netFen * 3.1) + (netSosyal * 3.0);

                lblTurkceNet.Text = netTurkce.ToString("0.00");
                lblMatNet.Text = netMat.ToString("0.00");
                lblFenNet.Text = netFen.ToString("0.00");
                lblSosyalNet.Text = netSosyal.ToString("0.00");
                lblGenelPuan.Text = tytPuan.ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve doğru formatta girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSonucuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string ogrenciAd = "Öğrenci Adı";
                string ogrenciSoyad = "Öğrenci Soyadı";
                string tarih = DateTime.Now.ToShortDateString();

                double netTurkce = double.Parse(lblTurkceNet.Text);
                double netMat = double.Parse(lblMatNet.Text);
                double netFen = double.Parse(lblFenNet.Text);
                double netSosyal = double.Parse(lblSosyalNet.Text);
                double tytPuan = double.Parse(lblGenelPuan.Text);

                string kayit = $"{ogrenciAd};{ogrenciSoyad};{tarih};{netTurkce};{netMat};{netFen};{netSosyal};{tytPuan}\n";
                File.AppendAllText("yks_sonuc.csv", kayit);
                MessageBox.Show("Sonuç başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu. Lütfen tekrar deneyin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("yks_sonuc.csv"))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Ad");
                dt.Columns.Add("Soyad");
                dt.Columns.Add("Tarih");
                dt.Columns.Add("Türkçe Net");
                dt.Columns.Add("Matematik Net");
                dt.Columns.Add("Fen Net");
                dt.Columns.Add("Sosyal Net");
                dt.Columns.Add("TYT Puanı");

                string[] satirlar = File.ReadAllLines("yks_sonuc.csv");
                foreach (string satir in satirlar)
                {
                    string[] veriler = satir.Split(';');
                    dt.Rows.Add(veriler);
                }

                dgvGecmisSonuclar.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Henüz kaydedilmiş sınav sonucu yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
