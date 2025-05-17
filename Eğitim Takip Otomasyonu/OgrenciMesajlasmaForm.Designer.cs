namespace Eğitim_Takip_Otomasyonu
{
    partial class OgrenciMesajlasmaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciMesajlasmaForm));
            this.cmbOgretmenler = new System.Windows.Forms.ComboBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.lstMesajlar = new System.Windows.Forms.ListBox();
            this.btnMesajlariListele = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbOgretmenler
            // 
            this.cmbOgretmenler.FormattingEnabled = true;
            this.cmbOgretmenler.Location = new System.Drawing.Point(386, 50);
            this.cmbOgretmenler.Name = "cmbOgretmenler";
            this.cmbOgretmenler.Size = new System.Drawing.Size(154, 21);
            this.cmbOgretmenler.TabIndex = 0;
            this.cmbOgretmenler.SelectedIndexChanged += new System.EventHandler(this.cmbOgretmenler_SelectedIndexChanged);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(280, 163);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(406, 278);
            this.txtMesaj.TabIndex = 1;
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(386, 95);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(154, 20);
            this.txtEposta.TabIndex = 2;
            // 
            // lstMesajlar
            // 
            this.lstMesajlar.FormattingEnabled = true;
            this.lstMesajlar.Location = new System.Drawing.Point(44, 50);
            this.lstMesajlar.Name = "lstMesajlar";
            this.lstMesajlar.Size = new System.Drawing.Size(179, 225);
            this.lstMesajlar.TabIndex = 4;
            this.lstMesajlar.SelectedIndexChanged += new System.EventHandler(this.lstMesajlar_SelectedIndexChanged);
            this.lstMesajlar.DoubleClick += new System.EventHandler(this.lstMesajlar_DoubleClick);
            // 
            // btnMesajlariListele
            // 
            this.btnMesajlariListele.Location = new System.Drawing.Point(93, 281);
            this.btnMesajlariListele.Name = "btnMesajlariListele";
            this.btnMesajlariListele.Size = new System.Drawing.Size(75, 61);
            this.btnMesajlariListele.TabIndex = 5;
            this.btnMesajlariListele.Text = "Mesajları Görüntüle";
            this.btnMesajlariListele.UseVisualStyleBackColor = true;
            this.btnMesajlariListele.Click += new System.EventHandler(this.btnMesajlariListele_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(573, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Gönder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(305, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Öğretmeni\r\nSeçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(305, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Öğretmen \r\nEposta\'sı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 96);
            this.label3.TabIndex = 10;
            this.label3.Text = "Yukarıda seçtiğiniz hocanın\r\ngönderdiği mesajları ve sizin \r\ngönderdiğiniz mesajl" +
    "arı \r\ngörebilirsiniz.\r\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.öğrenciİşlemleriToolStripMenuItem,
            this.sınavİşlemleriToolStripMenuItem,
            this.dersİşlemleriToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            this.anasayfaToolStripMenuItem.Click += new System.EventHandler(this.anasayfaToolStripMenuItem_Click_1);
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
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            // 
            // OgrenciMesajlasmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(698, 453);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnMesajlariListele);
            this.Controls.Add(this.lstMesajlar);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.cmbOgretmenler);
            this.Name = "OgrenciMesajlasmaForm";
            this.Text = "OgrenciMesajlasmaForm";
            this.Load += new System.EventHandler(this.OgrenciMesajlasmaForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOgretmenler;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.ListBox lstMesajlar;
        private System.Windows.Forms.Button btnMesajlariListele;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}