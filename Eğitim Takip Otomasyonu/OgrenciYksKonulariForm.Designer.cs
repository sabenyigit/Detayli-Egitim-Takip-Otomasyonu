namespace Eğitim_Takip_Otomasyonu
{
    partial class OgrenciYksKonulariForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciYksKonulariForm));
            this.lstDersler = new System.Windows.Forms.ListBox();
            this.lstKonular = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkTamamlandi = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDersler
            // 
            this.lstDersler.FormattingEnabled = true;
            this.lstDersler.Location = new System.Drawing.Point(153, 61);
            this.lstDersler.Name = "lstDersler";
            this.lstDersler.Size = new System.Drawing.Size(224, 160);
            this.lstDersler.TabIndex = 0;
            this.lstDersler.SelectedIndexChanged += new System.EventHandler(this.lstDersler_SelectedIndexChanged);
            // 
            // lstKonular
            // 
            this.lstKonular.FormattingEnabled = true;
            this.lstKonular.Location = new System.Drawing.Point(400, 61);
            this.lstKonular.Name = "lstKonular";
            this.lstKonular.Size = new System.Drawing.Size(224, 160);
            this.lstKonular.TabIndex = 1;
            this.lstKonular.SelectedIndexChanged += new System.EventHandler(this.lstKonular_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkTamamlandi
            // 
            this.chkTamamlandi.AutoSize = true;
            this.chkTamamlandi.BackColor = System.Drawing.Color.Transparent;
            this.chkTamamlandi.Location = new System.Drawing.Point(153, 227);
            this.chkTamamlandi.Name = "chkTamamlandi";
            this.chkTamamlandi.Size = new System.Drawing.Size(434, 30);
            this.chkTamamlandi.TabIndex = 3;
            this.chkTamamlandi.Text = "Seçtiğiniz konuyu bitirdiğinizi düşünüyorsanız,konuyu seçip kutucuğu işaretleyebi" +
    "lirsiniz.\r\n\r\n";
            this.chkTamamlandi.UseVisualStyleBackColor = false;
            this.chkTamamlandi.CheckedChanged += new System.EventHandler(this.chkTamamlandi_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lütfen TYT Dersi Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lütfen Ders Konusu Seçiniz";
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
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 5;
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
            this.dersNotlarımToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dersNotlarımToolStripMenuItem.Text = "Ders Notlarım";
            this.dersNotlarımToolStripMenuItem.Click += new System.EventHandler(this.dersNotlarımToolStripMenuItem_Click);
            // 
            // devamsızlıklarımToolStripMenuItem
            // 
            this.devamsızlıklarımToolStripMenuItem.Name = "devamsızlıklarımToolStripMenuItem";
            this.devamsızlıklarımToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.devamsızlıklarımToolStripMenuItem.Text = "Devamsızlıklarım";
            this.devamsızlıklarımToolStripMenuItem.Click += new System.EventHandler(this.devamsızlıklarımToolStripMenuItem_Click);
            // 
            // dersProgramımToolStripMenuItem
            // 
            this.dersProgramımToolStripMenuItem.Name = "dersProgramımToolStripMenuItem";
            this.dersProgramımToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
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
            this.yKSToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.yKSToolStripMenuItem.Text = "YKS";
            // 
            // konularToolStripMenuItem
            // 
            this.konularToolStripMenuItem.Name = "konularToolStripMenuItem";
            this.konularToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.konularToolStripMenuItem.Text = "Konular";
            this.konularToolStripMenuItem.Click += new System.EventHandler(this.konularToolStripMenuItem_Click);
            // 
            // çıkmışSorularToolStripMenuItem
            // 
            this.çıkmışSorularToolStripMenuItem.Name = "çıkmışSorularToolStripMenuItem";
            this.çıkmışSorularToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.çıkmışSorularToolStripMenuItem.Text = "Çıkmış Sorular";
            this.çıkmışSorularToolStripMenuItem.Click += new System.EventHandler(this.çıkmışSorularToolStripMenuItem_Click);
            // 
            // denemelerToolStripMenuItem
            // 
            this.denemelerToolStripMenuItem.Name = "denemelerToolStripMenuItem";
            this.denemelerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.denemelerToolStripMenuItem.Text = "Denemeler";
            this.denemelerToolStripMenuItem.Click += new System.EventHandler(this.denemelerToolStripMenuItem_Click);
            // 
            // puanHesaplaToolStripMenuItem
            // 
            this.puanHesaplaToolStripMenuItem.Name = "puanHesaplaToolStripMenuItem";
            this.puanHesaplaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
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
            this.özelNotlarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.özelNotlarToolStripMenuItem.Text = "Özel Notlar";
            this.özelNotlarToolStripMenuItem.Click += new System.EventHandler(this.özelNotlarToolStripMenuItem_Click);
            // 
            // mesajlaşmaToolStripMenuItem
            // 
            this.mesajlaşmaToolStripMenuItem.Name = "mesajlaşmaToolStripMenuItem";
            this.mesajlaşmaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.mesajlaşmaToolStripMenuItem.Text = "Mesajlaşma";
            this.mesajlaşmaToolStripMenuItem.Click += new System.EventHandler(this.mesajlaşmaToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-61, 291);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // OgrenciYksKonulariForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(855, 266);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTamamlandi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstKonular);
            this.Controls.Add(this.lstDersler);
            this.Name = "OgrenciYksKonulariForm";
            this.Text = "OgrenciYksKonulariForm";
            this.Load += new System.EventHandler(this.OgrenciYksKonulariForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDersler;
        private System.Windows.Forms.ListBox lstKonular;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkTamamlandi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.CheckBox checkBox1;
    }
}