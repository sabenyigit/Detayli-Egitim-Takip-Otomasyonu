namespace Eğitim_Takip_Otomasyonu
{
    partial class OgrenciNotlarForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.cmbDersler = new System.Windows.Forms.ComboBox();
            this.txtNot1 = new System.Windows.Forms.TextBox();
            this.txtNot2 = new System.Windows.Forms.TextBox();
            this.txtPerformans1 = new System.Windows.Forms.TextBox();
            this.txtPerformans2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.konularaGöreVideolarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Yenile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(140, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ders Notlarım";
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
            this.menuStrip1.Size = new System.Drawing.Size(456, 24);
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
            this.denemelerToolStripMenuItem,
            this.konularaGöreVideolarToolStripMenuItem});
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
            // cmbDersler
            // 
            this.cmbDersler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDersler.FormattingEnabled = true;
            this.cmbDersler.Location = new System.Drawing.Point(207, 111);
            this.cmbDersler.Name = "cmbDersler";
            this.cmbDersler.Size = new System.Drawing.Size(121, 21);
            this.cmbDersler.TabIndex = 12;
            // 
            // txtNot1
            // 
            this.txtNot1.Enabled = false;
            this.txtNot1.Location = new System.Drawing.Point(207, 147);
            this.txtNot1.Name = "txtNot1";
            this.txtNot1.ReadOnly = true;
            this.txtNot1.Size = new System.Drawing.Size(100, 20);
            this.txtNot1.TabIndex = 13;
            // 
            // txtNot2
            // 
            this.txtNot2.Enabled = false;
            this.txtNot2.Location = new System.Drawing.Point(207, 173);
            this.txtNot2.Name = "txtNot2";
            this.txtNot2.ReadOnly = true;
            this.txtNot2.Size = new System.Drawing.Size(100, 20);
            this.txtNot2.TabIndex = 14;
            // 
            // txtPerformans1
            // 
            this.txtPerformans1.Enabled = false;
            this.txtPerformans1.Location = new System.Drawing.Point(207, 199);
            this.txtPerformans1.Name = "txtPerformans1";
            this.txtPerformans1.ReadOnly = true;
            this.txtPerformans1.Size = new System.Drawing.Size(100, 20);
            this.txtPerformans1.TabIndex = 15;
            // 
            // txtPerformans2
            // 
            this.txtPerformans2.Enabled = false;
            this.txtPerformans2.Location = new System.Drawing.Point(207, 225);
            this.txtPerformans2.Name = "txtPerformans2";
            this.txtPerformans2.ReadOnly = true;
            this.txtPerformans2.Size = new System.Drawing.Size(100, 20);
            this.txtPerformans2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ders Seçimi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "1. Not:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "2. Not:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "1. Performans Not:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "2. Performans Not:";
            // 
            // konularaGöreVideolarToolStripMenuItem
            // 
            this.konularaGöreVideolarToolStripMenuItem.Name = "konularaGöreVideolarToolStripMenuItem";
            this.konularaGöreVideolarToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.konularaGöreVideolarToolStripMenuItem.Text = "Konulara Göre Videolar";
            // 
            // OgrenciNotlarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(456, 359);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPerformans2);
            this.Controls.Add(this.txtPerformans1);
            this.Controls.Add(this.txtNot2);
            this.Controls.Add(this.txtNot1);
            this.Controls.Add(this.cmbDersler);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "OgrenciNotlarForm";
            this.Text = "OgrenciNotlarForm";
            this.Load += new System.EventHandler(this.OgrenciNotlarForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ComboBox cmbDersler;
        private System.Windows.Forms.TextBox txtNot1;
        private System.Windows.Forms.TextBox txtNot2;
        private System.Windows.Forms.TextBox txtPerformans1;
        private System.Windows.Forms.TextBox txtPerformans2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem konularaGöreVideolarToolStripMenuItem;
    }
}