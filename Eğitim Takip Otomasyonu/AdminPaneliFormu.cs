    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    using System.Linq;


namespace Eğitim_Takip_Otomasyonu
    {
        public partial class AdminPaneliFormu : Form
        {
            private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=EgitimTakipOtomasyonu;Uid=root;Pwd=root;ConnectionTimeout=30;Pooling=true;");

            public AdminPaneliFormu()
            {
                InitializeComponent();
                GunleriDoldur();
                SaatleriDoldur();
                DersleriDoldur();
                OgrencileriDoldur();
                OgrencileriListBoxaDoldur();
                SinavDersleriniDoldur();
        }

        private async void SinavDersleriniDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT DersAdi FROM Dersler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            cmbSinavDers.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                cmbSinavDers.Items.Add(reader["DersAdi"].ToString());
                            }
                            if (cmbSinavDers.Items.Count > 0)
                                cmbSinavDers.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınav dersleri yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async void OgrencileriListBoxaDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT OgrenciID, CONCAT(Adi, ' ', Soyadi) as TamAd FROM Ogrenciler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            lstOgrenciler.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                lstOgrenciler.Items.Add(new { OgrenciID = reader["OgrenciID"].ToString(), TamAd = reader["TamAd"].ToString() });
                            }
                            lstOgrenciler.DisplayMember = "TamAd";
                            lstOgrenciler.ValueMember = "OgrenciID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async Task ListeleVelilerAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var da = new MySqlDataAdapter("SELECT * FROM veliler", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private void GunleriDoldur()
            {
                string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
                cmbGun.Items.AddRange(gunler);
                cmbGun.SelectedIndex = 0;
            }

            private void SaatleriDoldur()
            {
                var saatAraliklari = new[]
                {
                    new { Gosterim = "09.00-09.40", Saat = "09:00" },
                    new { Gosterim = "09.40-10.20", Saat = "09:40" },
                    new { Gosterim = "10.30-11.20", Saat = "10:30" },
                    new { Gosterim = "11.20-12.00", Saat = "11:20" },
                    new { Gosterim = "12.40-13.20", Saat = "12:40" },
                    new { Gosterim = "13.20-14.00", Saat = "13:20" },
                    new { Gosterim = "14.10-14.50", Saat = "14:10" },
                    new { Gosterim = "14.50-15.30", Saat = "14:50" }
                };
                cmbSaat.DisplayMember = "Gosterim";
                cmbSaat.ValueMember = "Saat";
                cmbSaat.DataSource = saatAraliklari;
                cmbSaat.SelectedIndex = 0;
            }

            private async void DersleriDoldur()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = "SELECT DersID, DersAdi FROM Dersler";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var da = new MySqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                cmbDers.DataSource = dt;
                                cmbDers.DisplayMember = "DersAdi";
                                cmbDers.ValueMember = "DersID";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dersler yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }


        private async void OgrencileriDoldur()
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT OgrenciID, CONCAT(Adi, ' ', Soyadi) as TamAd FROM Ogrenciler";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cmbOgrenci.DataSource = dt;
                            cmbOgrenci.DisplayMember = "TamAd";
                            cmbOgrenci.ValueMember = "OgrenciID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenciler yüklenemedi: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private async void AdminPaneliFormu_Load(object sender, EventArgs e)
            {
                await ListeleOgretmenlerAsync();
                cmbDuyuruHedef.Items.AddRange(new string[] { "Öğrenci", "Öğretmen" });
                cmbDuyuruHedef.SelectedIndex = 0;
            }

            private async Task ListeleOgretmenlerAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var da = new MySqlDataAdapter("SELECT * FROM Ogretmenler", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async Task ListeleOgrencilerAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var da = new MySqlDataAdapter("SELECT * FROM Ogrenciler", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async Task ListeleDersProgramiAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            SELECT dp.ProgramID, o.Adi AS OgrenciAdi, d.DersAdi, dp.Gun, dp.Saat
                            FROM DersProgrami dp
                            JOIN Ogrenciler o ON dp.OgrenciID = o.OgrenciID
                            JOIN Dersler d ON dp.DersID = d.DersID";
                        using (var da = new MySqlDataAdapter(query, connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async Task ListeleSinavlarAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var da = new MySqlDataAdapter("SELECT * FROM Sinavlar", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async Task ListeleDuyurularAsync()
            {
                try
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var da = new MySqlDataAdapter("SELECT * FROM Duyurular", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvListe.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgrenciEkle_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtOgrenciKullaniciAdi.Text) || string.IsNullOrEmpty(txtOgrenciSifre.Text) ||
                        string.IsNullOrEmpty(txtOgrenciAd.Text) || string.IsNullOrEmpty(txtOgrenciSoyad.Text))
                    {
                        MessageBox.Show("Lütfen tüm zorunlu alanları doldurun!");
                        return;
                    }

                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO Ogrenciler (KullaniciAdi, Sifre, Adi, Soyadi, Email, Tarih)
                            VALUES (@kullaniciAdi, @sifre, @ad, @soyad, @email, @tarih)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@kullaniciAdi", txtOgrenciKullaniciAdi.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtOgrenciSifre.Text);
                            cmd.Parameters.AddWithValue("@ad", txtOgrenciAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtOgrenciSoyad.Text);
                            cmd.Parameters.AddWithValue("@email", txtOgrenciEmail.Text);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgrencilerAsync();
                    MessageBox.Show("Öğrenci başarıyla eklendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgrenciSil_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir öğrenci seçin!");
                    return;
                }

                try
                {
                    string id = dgvListe.SelectedRows[0].Cells["OgrenciID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var cmd = new MySqlCommand("DELETE FROM Ogrenciler WHERE OgrenciID=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgrencilerAsync();
                    MessageBox.Show("Öğrenci başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgrenciGuncelle_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellemek için bir öğrenci seçin!");
                    return;
                }

                try
                {
                    string id = dgvListe.SelectedRows[0].Cells["OgrenciID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            UPDATE Ogrenciler
                            SET KullaniciAdi=@kullaniciAdi, Sifre=@sifre, Adi=@ad, Soyadi=@soyad, Email=@email, Tarih=@tarih
                            WHERE OgrenciID=@id";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@kullaniciAdi", txtOgrenciKullaniciAdi.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtOgrenciSifre.Text);
                            cmd.Parameters.AddWithValue("@ad", txtOgrenciAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtOgrenciSoyad.Text);
                            cmd.Parameters.AddWithValue("@email", txtOgrenciEmail.Text);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@id", id);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgrencilerAsync();
                    MessageBox.Show("Öğrenci başarıyla güncellendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgretmenEkle_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtOgretmenKullaniciAdi.Text) || string.IsNullOrEmpty(txtOgretmenSifre.Text) ||
                        string.IsNullOrEmpty(txtOgretmenAd.Text) || string.IsNullOrEmpty(txtOgretmenSoyad.Text))
                    {
                        MessageBox.Show("Lütfen tüm zorunlu alanları doldurun!");
                        return;
                    }

                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO Ogretmenler (KullaniciAdi, Sifre, Adi, Soyadi, Email, Brans, Tarih)
                            VALUES (@kullaniciAdi, @sifre, @ad, @soyad, @email, @brans, @tarih)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@kullaniciAdi", txtOgretmenKullaniciAdi.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtOgretmenSifre.Text);
                            cmd.Parameters.AddWithValue("@ad", txtOgretmenAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtOgretmenSoyad.Text);
                            cmd.Parameters.AddWithValue("@email", txtOgretmenEmail.Text);
                            cmd.Parameters.AddWithValue("@brans", txtOgretmenBrans.Text);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgretmenlerAsync();
                    MessageBox.Show("Öğretmen başarıyla eklendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgretmenSil_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir öğretmen seçin!");
                    return;
                }

                try
                {
                    string id = dgvListe.SelectedRows[0].Cells["OgretmenID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var cmd = new MySqlCommand("DELETE FROM Ogretmenler WHERE OgretmenID=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgretmenlerAsync();
                    MessageBox.Show("Öğretmen başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnOgretmenGuncelle_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellemek için bir öğretmen seçin!");
                    return;
                }

                try
                {
                    string id = dgvListe.SelectedRows[0].Cells["OgretmenID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            UPDATE Ogretmenler
                            SET KullaniciAdi=@kullaniciAdi, Sifre=@sifre, Adi=@ad, Soyadi=@soyad, Email=@email, Brans=@brans, Tarih=@tarih
                            WHERE OgretmenID=@id";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@kullaniciAdi", txtOgretmenKullaniciAdi.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtOgretmenSifre.Text);
                            cmd.Parameters.AddWithValue("@ad", txtOgretmenAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtOgretmenSoyad.Text);
                            cmd.Parameters.AddWithValue("@email", txtOgretmenEmail.Text);
                            cmd.Parameters.AddWithValue("@brans", txtOgretmenBrans.Text);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@id", id);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleOgretmenlerAsync();
                    MessageBox.Show("Öğretmen başarıyla güncellendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnDersProgramiEkle_Click(object sender, EventArgs e)
            {
                try
                {
                    if (cmbGun.SelectedItem == null || cmbDers.SelectedValue == null ||
                        cmbOgrenci.SelectedValue == null || cmbSaat.SelectedValue == null)
                    {
                        MessageBox.Show("Lütfen gün, ders, öğrenci ve saat aralığı seçin!");
                        return;
                    }

                    string ogrenciID = cmbOgrenci.SelectedValue.ToString();
                    string dersID = cmbDers.SelectedValue.ToString();
                    string gun = cmbGun.SelectedItem.ToString();
                    string saat = cmbSaat.SelectedValue.ToString();

                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO DersProgrami (OgrenciID, DersID, Gun, Saat)
                            VALUES (@ogrenciID, @dersID, @gun, @saat)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                            cmd.Parameters.AddWithValue("@dersID", dersID);
                            cmd.Parameters.AddWithValue("@gun", gun);
                            cmd.Parameters.AddWithValue("@saat", saat);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleDersProgramiAsync();
                    MessageBox.Show("Ders programı başarıyla eklendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnDersProgramiGuncelle_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellemek için bir ders programı seçin!");
                    return;
                }

                try
                {
                    string programID = dgvListe.SelectedRows[0].Cells["ProgramID"].Value.ToString();
                    string ogrenciID = cmbOgrenci.SelectedValue.ToString();
                    string dersID = cmbDers.SelectedValue.ToString();
                    string gun = cmbGun.SelectedItem.ToString();
                    string saat = cmbSaat.SelectedValue.ToString();

                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = @"
                            UPDATE DersProgrami
                            SET OgrenciID=@ogrenciID, DersID=@dersID, Gun=@gun, Saat=@saat
                            WHERE ProgramID=@id";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                            cmd.Parameters.AddWithValue("@dersID", dersID);
                            cmd.Parameters.AddWithValue("@gun", gun);
                            cmd.Parameters.AddWithValue("@saat", saat);
                            cmd.Parameters.AddWithValue("@id", programID);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleDersProgramiAsync();
                    MessageBox.Show("Ders programı başarıyla güncellendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnDersProgramiSil_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir ders programı seçin!");
                    return;
                }

                DialogResult result = MessageBox.Show("Bu ders programını silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                try
                {
                    string programID = dgvListe.SelectedRows[0].Cells["ProgramID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var cmd = new MySqlCommand("DELETE FROM DersProgrami WHERE ProgramID=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", programID);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleDersProgramiAsync();
                    MessageBox.Show("Ders programı başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

        private async void btnSinavEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSinavDers.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir ders seçin!");
                    return;
                }

                if (cmbSinavOgretmen.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir öğretmen seçin!");
                    return;
                }

                var secilenOgretmen = (dynamic)cmbSinavOgretmen.SelectedItem;

                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"INSERT INTO Sinavlar (DersAdi, SinavTarihi, SinavSaati, OgretmenID) 
                                   VALUES (@ders, @tarih, @saat, @ogretmenID)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ders", cmbSinavDers.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tarih", dtpSinavTarih.Value.Date);
                        cmd.Parameters.AddWithValue("@saat", dtpSinavSaat.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@ogretmenID", secilenOgretmen.OgretmenID);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await ListeleSinavlarAsync();
                MessageBox.Show("Sınav başarıyla eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }
            private async void btnDuyuruEkle_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtDuyuruBaslik.Text) || string.IsNullOrEmpty(rtbDuyuruIcerik.Text) ||
                        cmbDuyuruHedef.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun!");
                        return;
                    }

                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        string query = "INSERT INTO Duyurular (Baslik, Icerik, HedefRol) VALUES (@baslik, @icerik, @hedefRol)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@baslik", txtDuyuruBaslik.Text);
                            cmd.Parameters.AddWithValue("@icerik", rtbDuyuruIcerik.Text);
                            cmd.Parameters.AddWithValue("@hedefRol", cmbDuyuruHedef.SelectedItem.ToString() == "Öğrenci" ? "Ogrenci" : "Ogretmen");
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleDuyurularAsync();
                    MessageBox.Show("Duyuru başarıyla eklendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void btnDuyuruSil_Click(object sender, EventArgs e)
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir duyuru seçin!");
                    return;
                }

                try
                {
                    string id = dgvListe.SelectedRows[0].Cells["DuyuruID"].Value.ToString();
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        await connection.OpenAsync();
                        using (var cmd = new MySqlCommand("DELETE FROM Duyurular WHERE DuyuruID=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await ListeleDuyurularAsync();
                    MessageBox.Show("Duyuru başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
                }
            }

            private async void button1_Click(object sender, EventArgs e)
            {
                await ListeleOgretmenlerAsync();
            }

            private async void button2_Click(object sender, EventArgs e)
            {
                await ListeleOgrencilerAsync();
            }

            private async void button3_Click(object sender, EventArgs e)
            {
                await ListeleDersProgramiAsync();
            }

            private async void button4_Click(object sender, EventArgs e)
            {
                await ListeleSinavlarAsync();
            }

            private async void button5_Click(object sender, EventArgs e)
            {
                await ListeleDuyurularAsync();
            }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtVeliAd.Text) || string.IsNullOrWhiteSpace(txtVeliSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtVeliTelefon.Text) || lstOgrenciler.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun ve bir öğrenci seçin.");
                    return;
                }

                // Extract OgrenciID
                var selectedOgrenci = lstOgrenciler.SelectedItem;
                var ogrenciIDProperty = selectedOgrenci.GetType().GetProperty("OgrenciID");
                if (ogrenciIDProperty == null)
                {
                    MessageBox.Show("Öğrenci ID'si bulunamadı.");
                    return;
                }
                int ogrenciID = Convert.ToInt32(ogrenciIDProperty.GetValue(selectedOgrenci));
                if (ogrenciID <= 0)
                {
                    MessageBox.Show("Öğrenci ID'si geçersiz.");
                    return;
                }

                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();

                    // Check if the student already has a parent (check veli_id in Ogrenciler)
                    string checkQuery = "SELECT veli_id FROM Ogrenciler WHERE OgrenciID = @ogrenciID";
                    using (var checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        object result = await checkCmd.ExecuteScalarAsync();
                        if (result != null && result != DBNull.Value)
                        {
                            MessageBox.Show("Bu öğrencinin zaten kayıtlı bir velisi var!");
                            return;
                        }
                    }

                    // Add the parent to the veliler table
                    string insertQuery = @"
                INSERT INTO veliler (ad, soyad, telefon)
                VALUES (@ad, @soyad, @telefon);
                SELECT LAST_INSERT_ID();"; // Get the newly inserted veli_id
                    int newVeliId;
                    using (var insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@ad", txtVeliAd.Text);
                        insertCmd.Parameters.AddWithValue("@soyad", txtVeliSoyad.Text);
                        insertCmd.Parameters.AddWithValue("@telefon", txtVeliTelefon.Text);
                        newVeliId = Convert.ToInt32(await insertCmd.ExecuteScalarAsync());
                    }

                    // Link the student to the new parent by updating veli_id in Ogrenciler
                    string updateQuery = "UPDATE Ogrenciler SET veli_id = @veliID WHERE OgrenciID = @ogrenciID";
                    using (var updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@veliID", newVeliId);
                        updateCmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                        await updateCmd.ExecuteNonQueryAsync();
                    }
                }

                await ListeleVelilerAsync();
                MessageBox.Show("Veli başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }   
        private void button8_Click(object sender, EventArgs e)
            {
                 ListeleVelilerAsync();
            }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate selection in DataGridView
                if (dgvListe.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silmek için bir veli seçin.");
                    return;
                }

                // Extract veli_id from the selected row
                if (!int.TryParse(dgvListe.CurrentRow.Cells["veli_id"]?.Value?.ToString(), out int veliID) || veliID <= 0)
                {
                    MessageBox.Show("Veli ID'si geçersiz.");
                    return;
                }

                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    connection.Open();

                    // Check for associated students and update their veli_id to NULL
                    string updateQuery = "UPDATE Ogrenciler SET veli_id = NULL WHERE veli_id = @veliID";
                    using (var updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@veliID", veliID);
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{rowsAffected} öğrencinin veli bağlantısı kaldırıldı.");
                        }
                    }

                    // Delete the veli from the veliler table
                    string deleteQuery = "DELETE FROM veliler WHERE veli_id = @veliID";
                    using (var deleteCmd = new MySqlCommand(deleteQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@veliID", veliID);
                        int rowsDeleted = deleteCmd.ExecuteNonQuery();
                        if (rowsDeleted == 0)
                        {
                            MessageBox.Show("Veli bulunamadı veya zaten silinmiş.");
                            return;
                        }
                    }
                }

                ListeleVelilerAsync();
                MessageBox.Show("Veli başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message} {(ex.InnerException != null ? $"\nİç hata: {ex.InnerException.Message}" : "")}");
            }
        }

        private void cmbSinavDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSinavDers.SelectedItem != null)
            {
                DersinOgretmenleriniDoldur(cmbSinavDers.SelectedItem.ToString());
            }
        }
        private async Task DersinOgretmenleriniDoldur(string dersAdi)
        {
            try
            {
                using (var connection = new MySqlConnection(conn.ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"SELECT OgretmenID, CONCAT(Adi, ' ', Soyadi) as TamAd 
                                   FROM Ogretmenler 
                                   WHERE Brans = @dersAdi";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@dersAdi", dersAdi);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            cmbSinavOgretmen.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                cmbSinavOgretmen.Items.Add(new
                                {
                                    OgretmenID = reader["OgretmenID"].ToString(),
                                    TamAd = reader["TamAd"].ToString()
                                });
                            }
                            cmbSinavOgretmen.DisplayMember = "TamAd";
                            cmbSinavOgretmen.ValueMember = "OgretmenID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğretmenler yüklenemedi: {ex.Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir sınav seçin!");
                    return;
                }

                var selectedRow = dgvListe.SelectedRows[0];
                if (selectedRow.Cells["SinavID"].Value == null)
                {
                    MessageBox.Show("Seçili sınavın ID'si bulunamadı!");
                    return;
                }

                string sinavID = selectedRow.Cells["SinavID"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Seçili sınavı silmek istediğinizden emin misiniz?\nDers: {selectedRow.Cells["DersAdi"].Value}\nTarih: {selectedRow.Cells["SinavTarihi"].Value}\nSaat: {selectedRow.Cells["SinavSaati"].Value}",
                    "Sınav Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var connection = new MySqlConnection(conn.ConnectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Sinavlar WHERE SinavID = @sinavID";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@sinavID", sinavID);
                            int affectedRows = cmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                ListeleSinavlarAsync();
                                MessageBox.Show("Sınav başarıyla silindi!");
                            }
                            else
                            {
                                MessageBox.Show("Sınav silinirken bir hata oluştu. Hiçbir kayıt silinmedi.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sınav silinirken hata oluştu:\n{ex.Message}");
            }
        }
    }
    }
    