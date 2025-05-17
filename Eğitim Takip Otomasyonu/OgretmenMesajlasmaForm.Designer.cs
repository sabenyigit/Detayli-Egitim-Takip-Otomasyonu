namespace Eğitim_Takip_Otomasyonu
{
    partial class OgretmenMesajlasmaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgretmenMesajlasmaForm));
            this.cmbOgrenciler = new System.Windows.Forms.ComboBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.lstMesajlar = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devamsızlıkİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesajlaşmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbOgrenciler
            // 
            this.cmbOgrenciler.FormattingEnabled = true;
            this.cmbOgrenciler.Location = new System.Drawing.Point(378, 52);
            this.cmbOgrenciler.Name = "cmbOgrenciler";
            this.cmbOgrenciler.Size = new System.Drawing.Size(163, 21);
            this.cmbOgrenciler.TabIndex = 0;
            this.cmbOgrenciler.SelectedIndexChanged += new System.EventHandler(this.cmbOgrenciler_SelectedIndexChanged);
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(378, 95);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(163, 20);
            this.txtEposta.TabIndex = 1;
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(274, 163);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(406, 281);
            this.txtMesaj.TabIndex = 2;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(572, 77);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(75, 23);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // lstMesajlar
            // 
            this.lstMesajlar.FormattingEnabled = true;
            this.lstMesajlar.Location = new System.Drawing.Point(46, 55);
            this.lstMesajlar.Name = "lstMesajlar";
            this.lstMesajlar.Size = new System.Drawing.Size(173, 238);
            this.lstMesajlar.TabIndex = 4;
            this.lstMesajlar.DoubleClick += new System.EventHandler(this.lstMesajlar_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "Mesajları Görüntüle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(300, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Öğrenci\r\nEposta\'sı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(300, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Öğrenci\r\nSeçiniz\r\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.dsaToolStripMenuItem,
            this.dersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            // 
            // dsaToolStripMenuItem
            // 
            this.dsaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notİşlemleriToolStripMenuItem,
            this.devamsızlıkİşlemleriToolStripMenuItem,
            this.mesajlaşmaToolStripMenuItem});
            this.dsaToolStripMenuItem.Name = "dsaToolStripMenuItem";
            this.dsaToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.dsaToolStripMenuItem.Text = "Öğretmen İşlemler";
            // 
            // notİşlemleriToolStripMenuItem
            // 
            this.notİşlemleriToolStripMenuItem.Name = "notİşlemleriToolStripMenuItem";
            this.notİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.notİşlemleriToolStripMenuItem.Text = "Not İşlemleri";
            // 
            // devamsızlıkİşlemleriToolStripMenuItem
            // 
            this.devamsızlıkİşlemleriToolStripMenuItem.Name = "devamsızlıkİşlemleriToolStripMenuItem";
            this.devamsızlıkİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.devamsızlıkİşlemleriToolStripMenuItem.Text = "Devamsızlık İşlemleri";
            // 
            // mesajlaşmaToolStripMenuItem
            // 
            this.mesajlaşmaToolStripMenuItem.Name = "mesajlaşmaToolStripMenuItem";
            this.mesajlaşmaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mesajlaşmaToolStripMenuItem.Text = "Mesajlaşma";
            // 
            // dersToolStripMenuItem
            // 
            this.dersToolStripMenuItem.Name = "dersToolStripMenuItem";
            this.dersToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.dersToolStripMenuItem.Text = "Ders İşlemleri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 96);
            this.label3.TabIndex = 11;
            this.label3.Text = "Yukarıda seçtiğiniz öğrencinin\r\ngönderdiği mesajları ve sizin \r\ngönderdiğiniz mes" +
    "ajları \r\ngörebilirsiniz.\r\n";
            // 
            // OgretmenMesajlasmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(692, 456);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstMesajlar);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.cmbOgrenciler);
            this.Name = "OgretmenMesajlasmaForm";
            this.Text = "OgretmenMesajlasmaForm";
            this.Load += new System.EventHandler(this.OgretmenMesajlasmaForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOgrenciler;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.ListBox lstMesajlar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devamsızlıkİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesajlaşmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}