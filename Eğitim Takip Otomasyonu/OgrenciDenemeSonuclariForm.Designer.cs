namespace Eğitim_Takip_Otomasyonu
{
    partial class OgrenciDenemeSonuclariForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciDenemeSonuclariForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTurkceYanlis = new System.Windows.Forms.TextBox();
            this.txtTurkceDogru = new System.Windows.Forms.TextBox();
            this.btnSonucuKaydet = new System.Windows.Forms.Button();
            this.btnGecmisDenemeleriGor = new System.Windows.Forms.Button();
            this.dgvGecmisDenemeler = new System.Windows.Forms.DataGridView();
            this.txtSosyalYanlis = new System.Windows.Forms.TextBox();
            this.txtSosyalDogru = new System.Windows.Forms.TextBox();
            this.txtMatYanlis = new System.Windows.Forms.TextBox();
            this.txtMatDogru = new System.Windows.Forms.TextBox();
            this.txtFenYanlis = new System.Windows.Forms.TextBox();
            this.txtFenDogru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğrenciİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersNotlarımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devamsızlıklarımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersProgramımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sınavİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkmışSorularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denemelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puanHesaplaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.özelNotlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesajlaşmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisDenemeler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doğru";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yanlış";
            // 
            // txtTurkceYanlis
            // 
            this.txtTurkceYanlis.Location = new System.Drawing.Point(162, 122);
            this.txtTurkceYanlis.Name = "txtTurkceYanlis";
            this.txtTurkceYanlis.Size = new System.Drawing.Size(100, 20);
            this.txtTurkceYanlis.TabIndex = 1;
            // 
            // txtTurkceDogru
            // 
            this.txtTurkceDogru.Location = new System.Drawing.Point(162, 80);
            this.txtTurkceDogru.Name = "txtTurkceDogru";
            this.txtTurkceDogru.Size = new System.Drawing.Size(100, 20);
            this.txtTurkceDogru.TabIndex = 2;
            // 
            // btnSonucuKaydet
            // 
            this.btnSonucuKaydet.Location = new System.Drawing.Point(268, 189);
            this.btnSonucuKaydet.Name = "btnSonucuKaydet";
            this.btnSonucuKaydet.Size = new System.Drawing.Size(75, 50);
            this.btnSonucuKaydet.TabIndex = 3;
            this.btnSonucuKaydet.Text = "Sonucu Kaydet";
            this.btnSonucuKaydet.UseVisualStyleBackColor = true;
            this.btnSonucuKaydet.Click += new System.EventHandler(this.btnSonucuKaydet_Click);
            // 
            // btnGecmisDenemeleriGor
            // 
            this.btnGecmisDenemeleriGor.Location = new System.Drawing.Point(392, 189);
            this.btnGecmisDenemeleriGor.Name = "btnGecmisDenemeleriGor";
            this.btnGecmisDenemeleriGor.Size = new System.Drawing.Size(75, 50);
            this.btnGecmisDenemeleriGor.TabIndex = 4;
            this.btnGecmisDenemeleriGor.Text = "Geçmiş Denemeleri Gör";
            this.btnGecmisDenemeleriGor.UseVisualStyleBackColor = true;
            this.btnGecmisDenemeleriGor.Click += new System.EventHandler(this.btnGecmisDenemeleriGor_Click);
            // 
            // dgvGecmisDenemeler
            // 
            this.dgvGecmisDenemeler.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGecmisDenemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGecmisDenemeler.Location = new System.Drawing.Point(12, 316);
            this.dgvGecmisDenemeler.Name = "dgvGecmisDenemeler";
            this.dgvGecmisDenemeler.Size = new System.Drawing.Size(776, 282);
            this.dgvGecmisDenemeler.TabIndex = 5;
            // 
            // txtSosyalYanlis
            // 
            this.txtSosyalYanlis.Location = new System.Drawing.Point(284, 122);
            this.txtSosyalYanlis.Name = "txtSosyalYanlis";
            this.txtSosyalYanlis.Size = new System.Drawing.Size(100, 20);
            this.txtSosyalYanlis.TabIndex = 1;
            // 
            // txtSosyalDogru
            // 
            this.txtSosyalDogru.Location = new System.Drawing.Point(284, 80);
            this.txtSosyalDogru.Name = "txtSosyalDogru";
            this.txtSosyalDogru.Size = new System.Drawing.Size(100, 20);
            this.txtSosyalDogru.TabIndex = 2;
            // 
            // txtMatYanlis
            // 
            this.txtMatYanlis.Location = new System.Drawing.Point(411, 122);
            this.txtMatYanlis.Name = "txtMatYanlis";
            this.txtMatYanlis.Size = new System.Drawing.Size(100, 20);
            this.txtMatYanlis.TabIndex = 1;
            // 
            // txtMatDogru
            // 
            this.txtMatDogru.Location = new System.Drawing.Point(411, 80);
            this.txtMatDogru.Name = "txtMatDogru";
            this.txtMatDogru.Size = new System.Drawing.Size(100, 20);
            this.txtMatDogru.TabIndex = 2;
            // 
            // txtFenYanlis
            // 
            this.txtFenYanlis.Location = new System.Drawing.Point(536, 122);
            this.txtFenYanlis.Name = "txtFenYanlis";
            this.txtFenYanlis.Size = new System.Drawing.Size(100, 20);
            this.txtFenYanlis.TabIndex = 1;
            // 
            // txtFenDogru
            // 
            this.txtFenDogru.Location = new System.Drawing.Point(536, 80);
            this.txtFenDogru.Name = "txtFenDogru";
            this.txtFenDogru.Size = new System.Drawing.Size(100, 20);
            this.txtFenDogru.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Matematik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Türkçe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sosyal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Fen";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTurkceDogru);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTurkceYanlis);
            this.groupBox1.Controls.Add(this.txtSosyalYanlis);
            this.groupBox1.Controls.Add(this.btnGecmisDenemeleriGor);
            this.groupBox1.Controls.Add(this.txtSosyalDogru);
            this.groupBox1.Controls.Add(this.btnSonucuKaydet);
            this.groupBox1.Controls.Add(this.txtMatYanlis);
            this.groupBox1.Controls.Add(this.txtFenDogru);
            this.groupBox1.Controls.Add(this.txtMatDogru);
            this.groupBox1.Controls.Add(this.txtFenYanlis);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 262);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deneme Sonuçlarını Girin";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.öğrenciİşlemleriToolStripMenuItem,
            this.sınavİşlemleriToolStripMenuItem,
            this.dersİşlemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            this.anasayfaToolStripMenuItem.Click += new System.EventHandler(this.anasayfaToolStripMenuItem_Click);
            // 
            // öğrenciİşlemleriToolStripMenuItem
            // 
            this.öğrenciİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dersNotlarımToolStripMenuItem,
            this.devamsızlıklarımToolStripMenuItem,
            this.dersProgramımToolStripMenuItem});
            this.öğrenciİşlemleriToolStripMenuItem.Name = "öğrenciİşlemleriToolStripMenuItem";
            this.öğrenciİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.öğrenciİşlemleriToolStripMenuItem.Text = "Öğrenci İşlemleri";
            // 
            // dersNotlarımToolStripMenuItem
            // 
            this.dersNotlarımToolStripMenuItem.Name = "dersNotlarımToolStripMenuItem";
            this.dersNotlarımToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dersNotlarımToolStripMenuItem.Text = "Ders Notlarım";
            this.dersNotlarımToolStripMenuItem.Click += new System.EventHandler(this.dersNotlarımToolStripMenuItem_Click);
            // 
            // devamsızlıklarımToolStripMenuItem
            // 
            this.devamsızlıklarımToolStripMenuItem.Name = "devamsızlıklarımToolStripMenuItem";
            this.devamsızlıklarımToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devamsızlıklarımToolStripMenuItem.Text = "Devamsızlıklarım";
            this.devamsızlıklarımToolStripMenuItem.Click += new System.EventHandler(this.devamsızlıklarımToolStripMenuItem_Click);
            // 
            // dersProgramımToolStripMenuItem
            // 
            this.dersProgramımToolStripMenuItem.Name = "dersProgramımToolStripMenuItem";
            this.dersProgramımToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dersProgramımToolStripMenuItem.Text = "Ders Programım";
            this.dersProgramımToolStripMenuItem.Click += new System.EventHandler(this.dersProgramımToolStripMenuItem_Click);
            // 
            // sınavİşlemleriToolStripMenuItem
            // 
            this.sınavİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yKSToolStripMenuItem,
            this.puanHesaplaToolStripMenuItem});
            this.sınavİşlemleriToolStripMenuItem.Name = "sınavİşlemleriToolStripMenuItem";
            this.sınavİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.sınavİşlemleriToolStripMenuItem.Text = "Sınav İşlemleri";
            // 
            // yKSToolStripMenuItem
            // 
            this.yKSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konularToolStripMenuItem,
            this.çıkmışSorularToolStripMenuItem,
            this.denemelerToolStripMenuItem});
            this.yKSToolStripMenuItem.Name = "yKSToolStripMenuItem";
            this.yKSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yKSToolStripMenuItem.Text = "YKS";
            // 
            // konularToolStripMenuItem
            // 
            this.konularToolStripMenuItem.Name = "konularToolStripMenuItem";
            this.konularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.konularToolStripMenuItem.Text = "Konular";
            this.konularToolStripMenuItem.Click += new System.EventHandler(this.konularToolStripMenuItem_Click);
            // 
            // çıkmışSorularToolStripMenuItem
            // 
            this.çıkmışSorularToolStripMenuItem.Name = "çıkmışSorularToolStripMenuItem";
            this.çıkmışSorularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.çıkmışSorularToolStripMenuItem.Text = "Çıkmış Sorular";
            this.çıkmışSorularToolStripMenuItem.Click += new System.EventHandler(this.çıkmışSorularToolStripMenuItem_Click);
            // 
            // denemelerToolStripMenuItem
            // 
            this.denemelerToolStripMenuItem.Name = "denemelerToolStripMenuItem";
            this.denemelerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.denemelerToolStripMenuItem.Text = "Denemeler";
            this.denemelerToolStripMenuItem.Click += new System.EventHandler(this.denemelerToolStripMenuItem_Click);
            // 
            // puanHesaplaToolStripMenuItem
            // 
            this.puanHesaplaToolStripMenuItem.Name = "puanHesaplaToolStripMenuItem";
            this.puanHesaplaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.puanHesaplaToolStripMenuItem.Text = "Puan Hesapla";
            this.puanHesaplaToolStripMenuItem.Click += new System.EventHandler(this.puanHesaplaToolStripMenuItem_Click);
            // 
            // dersİşlemleriToolStripMenuItem
            // 
            this.dersİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.özelNotlarToolStripMenuItem,
            this.mesajlaşmaToolStripMenuItem});
            this.dersİşlemleriToolStripMenuItem.Name = "dersİşlemleriToolStripMenuItem";
            this.dersİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.dersİşlemleriToolStripMenuItem.Text = "Ders İşlemleri";
            // 
            // özelNotlarToolStripMenuItem
            // 
            this.özelNotlarToolStripMenuItem.Name = "özelNotlarToolStripMenuItem";
            this.özelNotlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.özelNotlarToolStripMenuItem.Text = "Özel Notlar";
            this.özelNotlarToolStripMenuItem.Click += new System.EventHandler(this.özelNotlarToolStripMenuItem_Click);
            // 
            // mesajlaşmaToolStripMenuItem
            // 
            this.mesajlaşmaToolStripMenuItem.Name = "mesajlaşmaToolStripMenuItem";
            this.mesajlaşmaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mesajlaşmaToolStripMenuItem.Text = "Mesajlaşma";
            this.mesajlaşmaToolStripMenuItem.Click += new System.EventHandler(this.mesajlaşmaToolStripMenuItem_Click);
            // 
            // OgrenciDenemeSonuclariForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 610);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvGecmisDenemeler);
            this.Name = "OgrenciDenemeSonuclariForm";
            this.Text = "OgrenciDenemeSonuclariForm";
            this.Load += new System.EventHandler(this.OgrenciDenemeSonuclariForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisDenemeler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTurkceYanlis;
        private System.Windows.Forms.TextBox txtTurkceDogru;
        private System.Windows.Forms.Button btnSonucuKaydet;
        private System.Windows.Forms.Button btnGecmisDenemeleriGor;
        private System.Windows.Forms.DataGridView dgvGecmisDenemeler;
        private System.Windows.Forms.TextBox txtSosyalYanlis;
        private System.Windows.Forms.TextBox txtSosyalDogru;
        private System.Windows.Forms.TextBox txtMatYanlis;
        private System.Windows.Forms.TextBox txtMatDogru;
        private System.Windows.Forms.TextBox txtFenYanlis;
        private System.Windows.Forms.TextBox txtFenDogru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğrenciİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersNotlarımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devamsızlıklarımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersProgramımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sınavİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkmışSorularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denemelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puanHesaplaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem özelNotlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesajlaşmaToolStripMenuItem;
    }
}