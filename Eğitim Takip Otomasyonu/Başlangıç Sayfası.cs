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
    public partial class Form1 : Form
    {
        private string ogrenciID; // Öğrenci ID'sini saklamak için

        public Form1()  // Constructor'ı düzelttim, ogrenciID parametresini kaldırdım
        {
            InitializeComponent();
        }


        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            // Öğrenci girişini doğruladıktan sonra
            string ogrenciID = "123"; // Bu, doğrulama sonucunda alınan öğrenci ID'si olacak.
            OgrenciGiris ogrenciAnaEkranForm = new OgrenciGiris(ogrenciID);
            ogrenciAnaEkranForm.Show();
            this.Hide();
        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            OgretmenGirisFormu ogretmenGirisForm = new OgretmenGirisFormu();
            ogretmenGirisForm.Show();
            this.Hide(); // Giriş sayfasını gizle
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminGirisFormu adminGirisForm = new AdminGirisFormu();
            adminGirisForm.Show();
            this.Hide(); // Giriş sayfasını gizle
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı kapat
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            velibilgi frm = new velibilgi();  // Parametresiz constructor'ı çağırıyoruz
            frm.Show();
            this.Hide(); // Giriş sayfasını gizle
        }
    }
}
