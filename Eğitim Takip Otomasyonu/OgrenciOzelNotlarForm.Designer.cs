namespace Eğitim_Takip_Otomasyonu
{
    partial class OgrenciOzelNotlarForm
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
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciOzelNotlarForm));
            this.txtNot = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstNotlar = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.button3 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label3.Location = new System.Drawing.Point(562, 312);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(199, 48);
            label3.TabIndex = 13;
            label3.Text = "Yukarıda kaydettiğiniz\r\nmesajları görebilirsiniz.";
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(23, 44);
            this.txtNot.Multiline = true;
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(494, 325);
            this.txtNot.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Düzenle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstNotlar
            // 
            this.lstNotlar.FormattingEnabled = true;
            this.lstNotlar.Location = new System.Drawing.Point(577, 125);
            this.lstNotlar.Name = "lstNotlar";
            this.lstNotlar.Size = new System.Drawing.Size(153, 160);
            this.lstNotlar.TabIndex = 2;
            this.lstNotlar.SelectedIndexChanged += new System.EventHandler(this.lstNotlar_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(610, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(700, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Sil";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OgrenciOzelNotlarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 395);
            this.Controls.Add(this.button3);
            this.Controls.Add(label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lstNotlar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNot);
            this.Name = "OgrenciOzelNotlarForm";
            this.Text = "OgrenciOzelNotlarForm";
            this.Load += new System.EventHandler(this.OgrenciOzelNotlarForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstNotlar;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button3;
    }
}