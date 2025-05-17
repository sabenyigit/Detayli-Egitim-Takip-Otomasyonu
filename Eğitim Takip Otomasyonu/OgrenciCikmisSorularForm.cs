using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciCikmisSorularForm : Form
    {
        private string ogrenciID;
        public OgrenciCikmisSorularForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbYillar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir yıl seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string secilenYil = cmbYillar.SelectedItem.ToString();
            string cikmisSorularYolu = @"C:\Users\MSİ\Desktop\Eğitim Takip Otomasyonu\CikmisSorular";

            string projePdfYolu = Path.Combine(cikmisSorularYolu, secilenYil + ".pdf");
            string masaustuPdfYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), secilenYil + ".pdf");

            try
            {
                if (File.Exists(projePdfYolu))
                {
                    File.Copy(projePdfYolu, masaustuPdfYolu, true);
                    MessageBox.Show($"Dosya başarıyla indirildi: {masaustuPdfYolu}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz yıl için PDF dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya indirilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OgrenciCikmisSorularForm_Load(object sender, EventArgs e)
        {
            cmbYillar.Items.Add("TYT 2018");
            cmbYillar.Items.Add("TYT 2019");
            cmbYillar.Items.Add("TYT 2020");
            cmbYillar.Items.Add("TYT 2021");
            cmbYillar.Items.Add("TYT 2022");
            cmbYillar.Items.Add("TYT 2023");
            cmbYillar.Items.Add("TYT 2024");
            cmbYillar.Items.Add("AYT 2018");
            cmbYillar.Items.Add("AYT 2019");
            cmbYillar.Items.Add("AYT 2020");
            cmbYillar.Items.Add("AYT 2021");
            cmbYillar.Items.Add("AYT 2022");
            cmbYillar.Items.Add("AYT 2023");
            cmbYillar.Items.Add("AYT 2024");
            cmbYillar.SelectedIndex = 0;
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
