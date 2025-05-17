using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciOzelNotlarForm : Form
    {
        string eskiNot = null;
        private string ogrenciID;
        public OgrenciOzelNotlarForm()
        {
            InitializeComponent();
        }

        string notlarDosyaYolu = "özel_notlar.csv";

        private void OgrenciOzelNotlarForm_Load(object sender, EventArgs e)
        {
            LoadNotlar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yeniNot = txtNot.Text;

            if (string.IsNullOrEmpty(yeniNot))
            {
                MessageBox.Show("Lütfen notunuzu girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(eskiNot))
            {
                // Eski notu dosyadan sil ve yeni notu ekle
                string[] satirlar = File.ReadAllLines(notlarDosyaYolu);
                using (StreamWriter sw = new StreamWriter(notlarDosyaYolu))
                {
                    foreach (string satir in satirlar)
                    {
                        if (!satir.Contains(eskiNot))
                            sw.WriteLine(satir);
                    }

                    // Yeni notu yaz
                    string yeniKayit = $"{DateTime.Now.ToShortDateString()};{yeniNot}";
                    sw.WriteLine(yeniKayit);
                }

                MessageBox.Show("Not başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                eskiNot = null; // Güncelleme tamamlandı
            }
            else
            {
                // Yeni not ekle
                SaveNot(yeniNot);
                MessageBox.Show("Not başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtNot.Clear();
            LoadNotlar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstNotlar.SelectedItem != null)
            {
                string secilenNot = lstNotlar.SelectedItem.ToString();
                txtNot.Text = secilenNot;
                eskiNot = secilenNot; // Güncellenecek notu kaydet
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir not seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveNot(string not)
        {
            // Notu CSV dosyasına kaydedelim
            string kayit = $"{DateTime.Now.ToShortDateString()};{not}\n";
            File.AppendAllText(notlarDosyaYolu, kayit);
        }

        private void LoadNotlar()
        {
            // Listbox'ı temizleyelim
            lstNotlar.Items.Clear();

            // Daha önce kaydedilmiş notları dosyadan okuyalım
            if (File.Exists(notlarDosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(notlarDosyaYolu);
                foreach (string satir in satirlar)
                {
                    // Satırdaki notu listeye ekleyelim
                    string[] veriler = satir.Split(';');
                    lstNotlar.Items.Add(veriler[1]);
                }
            }
            else
            {
                MessageBox.Show("Henüz kaydedilmiş not yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstNotlar.SelectedItem != null)
            {
                string secilenNot = lstNotlar.SelectedItem.ToString();

                DialogResult sonuc = MessageBox.Show("Seçilen notu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    if (File.Exists(notlarDosyaYolu))
                    {
                        // Tüm satırları oku
                        var satirlar = File.ReadAllLines(notlarDosyaYolu);
                        using (StreamWriter sw = new StreamWriter(notlarDosyaYolu))
                        {
                            foreach (var satir in satirlar)
                            {
                                if (!satir.Contains(secilenNot)) // Seçilen notu içermeyenleri tekrar yaz
                                {
                                    sw.WriteLine(satir);
                                }
                            }
                        }

                        MessageBox.Show("Not silindi.");
                        LoadNotlar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir not seçin.");
            }
        }

        private void lstNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotlar.SelectedItem != null)
            {
                txtNot.Text = lstNotlar.SelectedItem.ToString();
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
