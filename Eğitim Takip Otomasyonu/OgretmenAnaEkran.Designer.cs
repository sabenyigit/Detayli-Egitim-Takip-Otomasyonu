namespace Eğitim_Takip_Otomasyonu
{
    partial class OgretmenAnaEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgretmenAnaEkran));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devamsızlıkİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesajlaşmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHosgeldiniz = new System.Windows.Forms.Label();
            this.btnDuyurularYenile = new System.Windows.Forms.Button();
            this.dgvDuyurular = new System.Windows.Forms.DataGridView();
            this.lblMerhaba = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyurular)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
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
            this.notİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.notİşlemleriToolStripMenuItem_Click);
            // 
            // devamsızlıkİşlemleriToolStripMenuItem
            // 
            this.devamsızlıkİşlemleriToolStripMenuItem.Name = "devamsızlıkİşlemleriToolStripMenuItem";
            this.devamsızlıkİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.devamsızlıkİşlemleriToolStripMenuItem.Text = "Devamsızlık İşlemleri";
            this.devamsızlıkİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.devamsızlıkİşlemleriToolStripMenuItem_Click);
            // 
            // mesajlaşmaToolStripMenuItem
            // 
            this.mesajlaşmaToolStripMenuItem.Name = "mesajlaşmaToolStripMenuItem";
            this.mesajlaşmaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mesajlaşmaToolStripMenuItem.Text = "Mesajlaşma";
            this.mesajlaşmaToolStripMenuItem.Click += new System.EventHandler(this.mesajlaşmaToolStripMenuItem_Click);
            // 
            // dersToolStripMenuItem
            // 
            this.dersToolStripMenuItem.Name = "dersToolStripMenuItem";
            this.dersToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.dersToolStripMenuItem.Text = "Ders İşlemleri";
            // 
            // lblHosgeldiniz
            // 
            this.lblHosgeldiniz.AutoSize = true;
            this.lblHosgeldiniz.Location = new System.Drawing.Point(369, 42);
            this.lblHosgeldiniz.Name = "lblHosgeldiniz";
            this.lblHosgeldiniz.Size = new System.Drawing.Size(0, 13);
            this.lblHosgeldiniz.TabIndex = 1;
            // 
            // btnDuyurularYenile
            // 
            this.btnDuyurularYenile.Location = new System.Drawing.Point(567, 284);
            this.btnDuyurularYenile.Name = "btnDuyurularYenile";
            this.btnDuyurularYenile.Size = new System.Drawing.Size(108, 23);
            this.btnDuyurularYenile.TabIndex = 8;
            this.btnDuyurularYenile.Text = "Duyuruları Yenile";
            this.btnDuyurularYenile.UseVisualStyleBackColor = true;
            this.btnDuyurularYenile.Click += new System.EventHandler(this.btnDuyurularYenile_Click);
            // 
            // dgvDuyurular
            // 
            this.dgvDuyurular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyurular.Location = new System.Drawing.Point(459, 82);
            this.dgvDuyurular.Name = "dgvDuyurular";
            this.dgvDuyurular.Size = new System.Drawing.Size(329, 196);
            this.dgvDuyurular.TabIndex = 7;
            this.dgvDuyurular.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuyurular_CellDoubleClick);
            // 
            // lblMerhaba
            // 
            this.lblMerhaba.AutoSize = true;
            this.lblMerhaba.Location = new System.Drawing.Point(369, 58);
            this.lblMerhaba.Name = "lblMerhaba";
            this.lblMerhaba.Size = new System.Drawing.Size(0, 13);
            this.lblMerhaba.TabIndex = 9;
            // 
            // OgretmenAnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMerhaba);
            this.Controls.Add(this.btnDuyurularYenile);
            this.Controls.Add(this.dgvDuyurular);
            this.Controls.Add(this.lblHosgeldiniz);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OgretmenAnaEkran";
            this.Load += new System.EventHandler(this.OgretmenAnaEkran_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyurular)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dsaToolStripMenuItem;
        private System.Windows.Forms.Label lblHosgeldiniz;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devamsızlıkİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesajlaşmaToolStripMenuItem;
        private System.Windows.Forms.Button btnDuyurularYenile;
        private System.Windows.Forms.DataGridView dgvDuyurular;
        private System.Windows.Forms.Label lblMerhaba;
    }
}