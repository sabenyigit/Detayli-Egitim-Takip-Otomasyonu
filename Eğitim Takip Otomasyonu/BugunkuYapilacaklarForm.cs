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
    public partial class BugunkuYapilacaklarForm : Form
    {
        private int ogrenciID;

        public BugunkuYapilacaklarForm(int id)
        {
            InitializeComponent();
            ogrenciID = id;
        }

        private void BugunkuYapilacaklarForm_Load(object sender, EventArgs e)
        {
            string bugun = DateTime.Now.DayOfWeek.ToString(); // Örn: "Monday"

            // Türkçe karşılıklar (isteğe göre)
            Dictionary<string, string> gunler = new Dictionary<string, string>
    {
        {"Monday", "Pazartesi"},
        {"Tuesday", "Salı"},
        {"Wednesday", "Çarşamba"},
        {"Thursday", "Perşembe"},
        {"Friday", "Cuma"},
        {"Saturday", "Cumartesi"},
        {"Sunday", "Pazar"}
    };

            // Günlere özel program
            Dictionary<string, List<string>> gunlukProgram = new Dictionary<string, List<string>>
    {
        {"Monday", new List<string> { "TYT Türkçe", "AYT Matematik" }},
        {"Tuesday", new List<string> { "TYT Matematik", "AYT Fizik" }},
        {"Wednesday", new List<string> { "TYT Geometri", "AYT Kimya" }},
        {"Thursday", new List<string> { "TYT Fizik", "AYT Biyoloji" }},
        {"Friday", new List<string> { "TYT Kimya", "AYT Edebiyat" }},
        {"Saturday", new List<string> { "TYT Biyoloji", "AYT Tarih" }},
        {"Sunday", new List<string> { "Genel Tekrar / Dinlenme" }}
    };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"📅 Bugün: {gunler[bugun]}");

            if (gunlukProgram.ContainsKey(bugun))
            {
                var dersler = gunlukProgram[bugun];
                foreach (var ders in dersler)
                {
                    if (ders.Contains("Dinlenme") || ders.Contains("Tekrar"))
                        sb.AppendLine($"- {ders}");
                    else
                        sb.AppendLine($"- {ders}: 1 Konu + 50 Soru");
                }
            }
            else
            {
                sb.AppendLine("Bugün için program bulunamadı.");
            }

            richTextBox1.Text = sb.ToString();
        }
    }
}
