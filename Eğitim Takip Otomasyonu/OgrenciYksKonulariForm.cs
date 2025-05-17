using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Eğitim_Takip_Otomasyonu
{
    public partial class OgrenciYksKonulariForm : Form
    {
        private string ogrenciID;
        private CheckBox chkTYT;
        private CheckBox chkAYT;
        private ListBox lstTamamlananKonular;

        public OgrenciYksKonulariForm(string ogrenciID)
        {
            InitializeComponent();
            this.ogrenciID = ogrenciID;

            // CheckBox'ları oluştur
            chkTYT = new CheckBox();
            chkTYT.Text = "TYT Konuları";
            chkTYT.Location = new System.Drawing.Point(20, 40);
            chkTYT.AutoSize = true;
            chkTYT.Checked = true;
            chkTYT.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);

            chkAYT = new CheckBox();
            chkAYT.Text = "AYT Konuları";
            chkAYT.Location = new System.Drawing.Point(20, 60);
            chkAYT.AutoSize = true;
            chkAYT.Checked = false;
            chkAYT.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);

            // Tamamlanan Konular ListBox'ını oluştur
            lstTamamlananKonular = new ListBox();
            lstTamamlananKonular.Location = new System.Drawing.Point(lstKonular.Location.X + lstKonular.Width + 20, lstKonular.Location.Y);
            lstTamamlananKonular.Size = new System.Drawing.Size(200, lstKonular.Height);
            lstTamamlananKonular.Name = "lstTamamlananKonular";

            // Form'a kontrolleri ekle
            this.Controls.Add(chkTYT);
            this.Controls.Add(chkAYT);
            this.Controls.Add(lstTamamlananKonular);

            // ListBox'ın konumunu aşağı kaydır
            lstDersler.Location = new System.Drawing.Point(lstDersler.Location.X, lstDersler.Location.Y + 30);
            lstDersler.Height = lstDersler.Height - 30;

            // Tamamlanan Konular için başlık label'ı ekle
            Label lblTamamlanan = new Label();
            lblTamamlanan.Text = "Tamamlanan Konular";
            lblTamamlanan.Location = new System.Drawing.Point(lstTamamlananKonular.Location.X, lstTamamlananKonular.Location.Y - 20);
            lblTamamlanan.AutoSize = true;
            this.Controls.Add(lblTamamlanan);
        }

        private void OgrenciYksKonulariForm_Load(object sender, EventArgs e)
        {
            DersleriYukle();
        }

        private void TamamlananKonulariYukle(string dersID)
        {

            try
            {
                string connectionString = "server=localhost;database=EgitimTakipOtomasyonu;user=root;password=root;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT k.KonuID, k.KonuAdi 
                                   FROM Konular k 
                                   INNER JOIN OgrenciKonular ok ON k.KonuID = ok.KonuID 
                                   WHERE k.DersID = @dersID 
                                   AND ok.OgrenciID = @ogrenciID 
                                   AND ok.BittiMi = 1 
                                   AND (";

                    if (chkTYT.Checked && !chkAYT.Checked)
                        query += "k.TYT_mi = 1 AND k.AYT_mi = 0";
                    else if (!chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 0 AND k.AYT_mi = 1";
                    else if (chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 1 OR k.AYT_mi = 1";
                    else
                        query += "1 = 0";

                    query += ") ORDER BY k.KonuAdi";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dersID", dersID);
                        cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        lstTamamlananKonular.Items.Clear();

                        while (reader.Read())
                        {
                            Konu konu = new Konu(reader["KonuID"].ToString(), reader["KonuAdi"].ToString(), true);
                            lstTamamlananKonular.Items.Add(konu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tamamlanan konular yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void DersleriYukle()
        {
            try
            {
                string connectionString = "server=localhost;database=EgitimTakipOtomasyonu;user=root;password=root;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT d.DersID, d.DersAdi, d.UstDersID " +
                                 "FROM Dersler d " +
                                 "LEFT JOIN Konular k ON d.DersID = k.DersID " +
                                 "WHERE d.YKS_Dersi = 1 AND (";

                    if (chkTYT.Checked && !chkAYT.Checked)
                        query += "k.TYT_mi = 1 AND k.AYT_mi = 0";
                    else if (!chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 0 AND k.AYT_mi = 1";
                    else if (chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 1 OR k.AYT_mi = 1";
                    else
                        query += "1 = 0"; // Hiçbiri seçili değilse hiç ders gösterme

                    query += ") ORDER BY d.UstDersID IS NULL DESC, d.DersID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        lstDersler.Items.Clear();

                        var dersler = new System.Collections.Generic.Dictionary<int, Ders>();
                        while (reader.Read())
                        {
                            int? ustDersID = reader["UstDersID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UstDersID"]);
                            dersler.Add(Convert.ToInt32(reader["DersID"]), new Ders(reader["DersID"].ToString(), reader["DersAdi"].ToString(), ustDersID));
                        }
                        reader.Close();

                        foreach (var ders in dersler.Values)
                        {
                            if (ders.UstDersID == null)
                            {
                                lstDersler.Items.Add(ders);
                            }
                            else if (dersler.ContainsKey(ders.UstDersID.Value))
                            {
                                lstDersler.Items.Add(new Ders(ders.DersID, $"  - {ders.DersAdi}", ders.UstDersID));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void lstDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDersler.SelectedItem is Ders secilenDers)
            {
                KonulariYukle(secilenDers.DersID);
                TamamlananKonulariYukle(secilenDers.DersID);
            }
        }

        private void KonulariYukle(string dersID)
        {
            try
            {
                string connectionString = "server=localhost;database=EgitimTakipOtomasyonu;user=root;password=root;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT k.KonuID, k.KonuAdi, IFNULL(ot.BittiMi, 0) AS BittiMi " +
                                 "FROM Konular k " +
                                 "LEFT JOIN OgrenciKonular ot ON k.KonuID = ot.KonuID AND ot.OgrenciID = @ogrenciID " +
                                 "WHERE k.DersID = @dersID AND (";

                    if (chkTYT.Checked && !chkAYT.Checked)
                        query += "k.TYT_mi = 1 AND k.AYT_mi = 0";
                    else if (!chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 0 AND k.AYT_mi = 1";
                    else if (chkTYT.Checked && chkAYT.Checked)
                        query += "k.TYT_mi = 1 OR k.AYT_mi = 1";
                    else
                        query += "1 = 0"; // Hiçbiri seçili değilse hiç konu gösterme

                    query += ")";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        cmd.Parameters.AddWithValue("@dersID", dersID);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        lstKonular.Items.Clear();

                        while (reader.Read())
                        {
                            bool tamamlandiMi = Convert.ToBoolean(reader["BittiMi"]);
                            Konu konu = new Konu(reader["KonuID"].ToString(), reader["KonuAdi"].ToString(), tamamlandiMi);
                            lstKonular.Items.Add(konu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konular yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void lstKonular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKonular.SelectedItem is Konu secilenKonu)
            {
                chkTamamlandi.Checked = secilenKonu.BittiMi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstKonular.SelectedItem is Konu secilenKonu)
            {
                try
                {
                    string connectionString = "server=localhost;database=EgitimTakipOtomasyonu;user=root;password=root;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO OgrenciKonular (OgrenciID, KonuID, BittiMi) " +
                                       "VALUES (@ogrenciID, @konuID, @bittiMi) " +
                                       "ON DUPLICATE KEY UPDATE BittiMi = @bittiMi";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                            cmd.Parameters.AddWithValue("@konuID", secilenKonu.KonuID);
                            cmd.Parameters.AddWithValue("@bittiMi", chkTamamlandi.Checked ? 1 : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    int selectedIndex = lstKonular.SelectedIndex;
                    KonulariYukle(((Ders)lstDersler.SelectedItem).DersID);
                    TamamlananKonulariYukle(((Ders)lstDersler.SelectedItem).DersID);
                    lstKonular.SelectedIndex = selectedIndex;

                    MessageBox.Show("Konu durumu güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }
    
    

        class Ders
        {
            public string DersID { get; }
            public string DersAdi { get; }
            public int? UstDersID { get; } // Nullable int olarak bırakıyoruz

            public Ders(string dersID, string dersAdi, int? ustDersID)
            {
                DersID = dersID;
                DersAdi = dersAdi;
                UstDersID = ustDersID;
            }

            public override string ToString()
            {
                return DersAdi;
            }
        }

        class Konu
        {
            public string KonuID { get; }
            public string KonuAdi { get; }
            public bool BittiMi { get; }

            public Konu(string konuID, string konuAdi, bool bittiMi)
            {
                KonuID = konuID;
                KonuAdi = konuAdi;
                BittiMi = bittiMi;
            }

            public override string ToString()
            {
                return KonuAdi;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DersleriYukle();
        }

        private void chkTamamlandi_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}