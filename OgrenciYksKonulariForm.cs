using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public partial class grenciYksKonulariForm : Form
{
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
                        cmd.Parameters.AddWithValue("@bittiMi", !secilenKonu.TamamlandiMi);

                        cmd.ExecuteNonQuery();
                        secilenKonu.TamamlandiMi = !secilenKonu.TamamlandiMi;
                        lstKonular.Refresh();

                        // Seçili dersi al ve tamamlanan konuları güncelle
                        if (lstDersler.SelectedItem is Ders secilenDers)
                        {
                            TamamlananKonulariYukle(secilenDers.DersID);
                        }

                        MessageBox.Show("Konu durumu güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }

    private void TamamlananKonulariYukle(string dersID)
    {
        try
        {
            if (lstTamamlananKonular == null)
            {
                // ListBox'ı oluştur
                lstTamamlananKonular = new ListBox();
                lstTamamlananKonular.Location = new System.Drawing.Point(lstKonular.Right + 20, lstKonular.Top);
                lstTamamlananKonular.Size = new System.Drawing.Size(250, lstKonular.Height);
                lstTamamlananKonular.Font = lstKonular.Font;
                this.Controls.Add(lstTamamlananKonular);
            }

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
} 